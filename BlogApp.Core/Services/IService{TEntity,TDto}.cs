using BlogApp.SharedLibrary.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Services
{
    public interface IService<TEntity,TDto> where TEntity: class where TDto : class
    {
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<IEnumerable<TDto>>> GetByFilterAsync(Expression<Func<TEntity,bool>> predicate);
        Task<Response<TDto>> GetByIdAsync(int id);
        Task<Response<TDto>> AddAsync(TDto dto);
        Task<Response<TDto>> UpdateAsync(TDto dto,int id);
        Task<Response<NoDataDto>> DeleteAsync(int id);



    }
}
