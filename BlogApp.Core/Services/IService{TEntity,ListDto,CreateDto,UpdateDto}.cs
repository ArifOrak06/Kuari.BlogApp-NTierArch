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
        Task<Response<IEnumerable<ListDto>>> GetAllAsync();
        Task<Response<IEnumerable<ListDto>>> GetByFilterAsync(Expression<Func<TEntity,bool>> predicate);
        Task<Response<ListDto>> GetByIdAsync(int id);
        Task<Response<CreateDto>> AddAsync(CreateDto dto);
        Task<Response<UpdateDto>> UpdateAsync(UpdateDto dto,int id);
        Task<Response<NoDataDto>> DeleteAsync(int id);



    }
}
