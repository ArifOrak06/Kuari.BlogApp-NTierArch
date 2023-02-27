using BlogApp.SharedLibrary.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Services
{
    public interface IService<TEntity, ListDto,CreateDto, UpdateDto> 
        where TEntity: class 
        where CreateDto : class 
        where UpdateDto : class
        where ListDto : class
    {
        Task<CustomResponseDto<IEnumerable<ListDto>>> GetAllAsync();
        Task<CustomResponseDto<IEnumerable<ListDto>>> GetByFilterAsync(Expression<Func<TEntity,bool>> predicate);
        Task<CustomResponseDto<ListDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<CreateDto>> AddAsync(CreateDto dto);
        Task<CustomResponseDto<UpdateDto>> UpdateAsync(UpdateDto dto,int id);
        Task<CustomResponseDto<NoDataDto>> DeleteAsync(int id);



    }
}
