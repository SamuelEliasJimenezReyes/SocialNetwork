using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Publications;

namespace WebApp.SocialNetwork.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private IPublicationService _service;

        public PublicationController(IPublicationService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Delete(int id ) => View(await _service.GetByIdSaveViewModel(id));
        public async Task<IActionResult> Edit(int id ) => View("SavePublication",await _service.GetByIdSaveViewModel(id));

        [HttpPost]
        public async Task<IActionResult> Edit(SavePublicationViewModel vm)
        {

            SavePublicationViewModel result = await _service.GetByIdSaveViewModel(vm.ID);
            vm.ID = result.ID;
            vm.PublishDate = DateTime.Now;
            if (result.ID != 0 && result != null && vm.File != null)
            {
                vm.ImagePath = UploadFile(vm.File, vm.UserID);
                await _service.Update(vm, vm.ID);

            }

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SavePublicationViewModel vm)
        {
            await _service.Delete(vm.ID);
            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }


        [HttpPost]
        public async Task<IActionResult> Create(SavePublicationViewModel vm)
        {
            vm.PublishDate=DateTime.Now;
            SavePublicationViewModel result = await _service.Add(vm);
            vm.ID = result.ID;
            if (result.ID != 0 && result != null && vm.File != null)
            {
                vm.ImagePath = UploadFile(vm.File, vm.UserID);
                await _service.Update(vm, vm.ID);

            }

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }


        private string UploadFile(IFormFile file, string UserID, bool isEditMode = false, string imagePath = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return imagePath;
                }
            }
            string basePath = $"/Images/Publications/{UserID}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //get file extension
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{fileName}";
        }

    }
}
