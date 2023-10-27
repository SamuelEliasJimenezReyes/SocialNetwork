using AutoMapper;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Model> : IBaseService<SaveViewModel, ViewModel, Model>
         where SaveViewModel : class
         where ViewModel : class
         where Model : class
    {
        private readonly IGenericRepository<Model> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Model> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel value)
        {
            Model entity = _mapper.Map<Model>(value);

            entity = await _repository.AddAsync(entity);

            SaveViewModel saveEntity = _mapper.Map<SaveViewModel>(entity);

            return saveEntity;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity != null)
            {
                if (entity is BaseEntity baseEntity)
                {
                    baseEntity.IsDeleted = true;
                    await _repository.UpdateAsync(entity, id);
                }
            }
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            var entityList = await _repository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(entityList);
        }

        public virtual async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            SaveViewModel saveEntity = _mapper.Map<SaveViewModel>(entity);

            return saveEntity;
        }

        public virtual async Task Update(SaveViewModel value, int id)
        {
            Model entity = _mapper.Map<Model>(value);
            await _repository.UpdateAsync(entity, id);
        }
    }
}
