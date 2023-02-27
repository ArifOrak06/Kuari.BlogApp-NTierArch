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

        public async Task<CustomResponseDto<CreateDto>> AddAsync(CreateDto dto)
        {
            if (dto == null)
            {
                
                return CustomResponseDto<CreateDto>.Fail(400,"Dto is null");
            }

            var entity = ObjectMapper.Mapper.Map<TEntity>(dto);

            await _repository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<CreateDto>(entity);

            return CustomResponseDto<CreateDto>.Success(200,newDto);
        }

        public async Task<CustomResponseDto<NoDataDto>> DeleteAsync(int id)
        {
            var data = await _repository.GetByIdAsyncy(id);
            if (data == null)
            {
                return CustomResponseDto<NoDataDto>.Fail(400, $"{id} sahip data bulunamaması nedeniyle silme işlemi gerçekleştirilememiştir.");
            }
            _repository.Delete(data);
            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<ListDto>(data);
            return CustomResponseDto<NoDataDto>.Success(204);
        }

        public async Task<CustomResponseDto<IEnumerable<ListDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            if (entities == null)
            {
                return CustomResponseDto<IEnumerable<ListDto>>.Fail(404, "Veri bulunmaması nedenilye getirilememiştir.");
            }
            var newDtos = ObjectMapper.Mapper.Map<IEnumerable<ListDto>>(entities);
            return CustomResponseDto<IEnumerable<ListDto>>.Success(200,newDtos);
        }

        public async Task<CustomResponseDto<IEnumerable<ListDto>>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var data = _repository.GetByFilter(predicate).ToList();
            if (data == null)
            {
                return CustomResponseDto<IEnumerable<ListDto>>.Fail(400, "Filter hatası nedeniyle datalar bulunamamıştır.");
            }
            var newDtos = ObjectMapper.Mapper.Map<IEnumerable<ListDto>>(data);

            return CustomResponseDto<IEnumerable<ListDto>>.Success(200,newDtos);
        }

        public async Task<CustomResponseDto<ListDto>> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsyncy(id);
            if (data == null)
            {
                return CustomResponseDto<ListDto>.Fail(404, $"Girilen {id}'ye sahip veri bulunamamıştır.");
            }

            var newDto = ObjectMapper.Mapper.Map<ListDto>(data);
            return CustomResponseDto<ListDto>.Success(200,newDto);

        }

        public async Task<CustomResponseDto<UpdateDto>> UpdateAsync(UpdateDto dto, int id)
        {
            var unChangedData = await _repository.GetByIdAsyncy(id);
            if (unChangedData == null)
            {
                return CustomResponseDto<UpdateDto>.Fail(404, $"Girilen {id}'ye sahip veri bulunamamıştır.");
            }
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(dto);
            _repository.Update(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = ObjectMapper.Mapper.Map<UpdateDto>(newEntity);
            return CustomResponseDto<UpdateDto>.Success(200,newDto);
        }
    }
}
