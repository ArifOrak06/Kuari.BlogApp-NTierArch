using BlogApp.Core.DTOs;
using BlogApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebAPI.Controllers
{
   
    public class CommentsController : CustomBaseController
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var result = await _commentService.GetAllAsync();
            return CreateActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var result = await _commentService.GetByIdAsync(id);
            return CreateActionResult(result);  
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentCreateDto commentCreateDto)
        {
            var result = await _commentService.AddAsync(commentCreateDto);
            return CreateActionResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(CommentUpdateDto commentUpdateDto)
        {
            var result = await _commentService.UpdateAsync(commentUpdateDto, commentUpdateDto.Id);
            return CreateActionResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            var result = await _commentService.DeleteAsync(id);
            return CreateActionResult(result);
        }
    }
}
