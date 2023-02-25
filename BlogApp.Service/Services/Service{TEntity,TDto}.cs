using BlogApp.Core.Repositories;
using BlogApp.Core.Services;
using BlogApp.Core.UnitOfWork;
using BlogApp.Service.Mappings.AutoMapper;
using BlogApp.SharedLibrary.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto> 
        where TEntity : class, new()
        where TDto : class,new()
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<TDto>> AddAsync(TDto dto)
        {
            if (dto == null)
            {
                var errorDto = new ErrorDto("Dto is null");
                return Response<TDto>.Fail(400, errorDto);
            }

            var entity = ObjectMapper.Mapper.Map<TEntity>(dto);

            await _repository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(entity);

            return Response<TDto>.Success(newDto, 200);
        }

        public async Task<Response<NoDataDto>> DeleteAsync(int id)
        {
            var data = await _repository.GetByIdAsyncy(id);
            if (data == null)
            {
                return Response<NoDataDto>.Fail(400, $"{id} sahip data bulunamaması nedeniyle silme işlemi gerçekleştirilememiştir.");
            }
            _repository.Delete(data);
            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(data);
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            if (entities == null)
            {
                return Response<IEnumerable<TDto>>.Fail(404, "Veri bulunmaması nedenilye getirilememiştir.");
            }
            var newDtos = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(entities);
            return Response<IEnumerable<TDto>>.Success(newDtos, 200);
        }

        public async Task<Response<IEnumerable<TDto>>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var data = _repository.GetByFilter(predicate).ToList();
            if (data == null)
            {
                return Response<IEnumerable<TDto>>.Fail(400, "Filter hatası nedeniyle datalar bulunamamıştır.");
            }
            var newDtos = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(data);

            return Response<IEnumerable<TDto>>.Success(newDtos, 200);
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsyncy(id);
            if (data == null)
            {
                return Response<TDto>.Fail(404, $"Girilen {id}'ye sahip veri bulunamamıştır.");
            }

            var newDto = ObjectMapper.Mapper.Map<TDto>(data);
            return Response<TDto>.Success(newDto, 200);

        }

        public async Task<Response<TDto>> UpdateAsync(TDto dto, int id)
        {
            var unChangedData = await _repository.GetByIdAsyncy(id);
            if (unChangedData == null)
            {
                return Response<TDto>.Fail(404, $"Giriilen {id}'ye sahip veri bulunamamıştır.");
            }
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(dto);
            _repository.Update(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);
            return Response<TDto>.Success(newDto, 200);
        }
    }
}
