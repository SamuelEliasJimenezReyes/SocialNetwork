using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.Services;
using SocialNetwork.Core.Application.ViewModels.Coments;
using SocialNetwork.Core.Domain.Entites;
using WebApp.SocialNetwork.Middlewares;
// probando en el origin 
namespace WebApp.SocialNetwork.Controllers
{
    public class ComentController : Controller
    {
        private readonly IComentsService _service;
        private readonly IPublicationService _publicationService;
        private readonly ValidateUserSession _validateUserSession;

        public ComentController(IComentsService service, IPublicationService publicationService, ValidateUserSession validateUserSession)
        {
            _service = service;
            _publicationService = publicationService;
            _validateUserSession = validateUserSession;
        }


        [HttpPost]
        public async Task<IActionResult> Add(string Content, int PublicationID, string UserID)
        {
            if (Content== string.Empty|| Content==null)
            {
                ViewBag.Publications = await _publicationService.GetAllViewModel();
                ViewBag.Comments = await _service.GetAllViewModel();

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            SaveComentsViewModel comments = new ();
            comments.PublicationID = PublicationID;
            comments.UserID = UserID;
            comments.Content = Content;

            await _service.Add(comments);

            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }


    }
}
