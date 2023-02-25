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
    public class Service<TEntity, ListDto, CreateDto, UpdateDto> : IService<TEntity, ListDto, CreateDto, UpdateDto> 
        where TEntity : class, new()
        where CreateDto : class,new()
        where UpdateDto : class,new()
        where ListDto : class,new()
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<CreateDto>> AddAsync(CreateDto dto)
        {
            if (dto == null)
            {
                var errorDto = new ErrorDto("Dto is null");
                return Response<CreateDto>.Fail(400, errorDto);
            }

            var entity = ObjectMapper.Mapper.Map<TEntity>(dto);

            await _repository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<CreateDto>(entity);

            return Response<CreateDto>.Success(newDto, 200);
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

            var newDto = ObjectMapper.Mapper.Map<ListDto>(data);
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<ListDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            if (entities == null)
            {
                return Response<IEnumerable<ListDto>>.Fail(404, "Veri bulunmaması nedenilye getirilememiştir.");
            }
            var newDtos = ObjectMapper.Mapper.Map<IEnumerable<ListDto>>(entities);
            return Response<IEnumerable<ListDto>>.Success(newDtos, 200);
        }

        public async Task<Response<IEnumerable<ListDto>>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var data = _repository.GetByFilter(predicate).ToList();
            if (data == null)
            {
                return Response<IEnumerable<ListDto>>.Fail(400, "Filter hatası nedeniyle datalar bulunamamıştır.");
            }
            var newDtos = ObjectMapper.Mapper.Map<IEnumerable<ListDto>>(data);

            return Response<IEnumerable<ListDto>>.Success(newDtos, 200);
        }

        public async Task<Response<ListDto>> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsyncy(id);
            if (data == null)
            {
                return Response<ListDto>.Fail(404, $"Girilen {id}'ye sahip veri bulunamamıştır.");
            }

            var newDto = ObjectMapper.Mapper.Map<ListDto>(data);
            return Response<ListDto>.Success(newDto, 200);

        }

        public async Task<Response<UpdateDto>> UpdateAsync(UpdateDto dto, int id)
        {
            var unChangedData = await _repository.GetByIdAsyncy(id);
            if (unChangedData == null)
            {
                return Response<UpdateDto>.Fail(404, $"Girilen {id}'ye sahip veri bulunamamıştır.");
            }
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(dto);
            _repository.Update(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<UpdateDto>(newEntity);
            return Response<UpdateDto>.Success(newDto, 200);
        }
    }
}
