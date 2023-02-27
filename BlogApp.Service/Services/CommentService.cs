using BlogApp.Core.DTOs;
using BlogApp.Core.Entities.Concrete;
using BlogApp.Core.Repositories;
using BlogApp.Core.Services;
using BlogApp.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Services
{
    public class CommentService : Service<Comment,CommentListDto,CommentCreateDto,CommentUpdateDto>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork) : base(commentRepository, unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }



    }
}
