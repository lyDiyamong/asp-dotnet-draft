using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comment;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllAsync();
         public Task<Comment?> GetOneAsync(int id);

        public Task<Comment> CreateAsync(Comment commentModel);

        public Task<Comment?> UpdateAsync(int id, UpdateCommentReqDto commentReqDto);

        public Task<Comment?> DeleteAsync(int id);
    }
}