using Film_Dizi_API.Data;
using Film_Dizi_API.Mappers;
using Film_Dizi_API.Models;
using Film_Dizi_API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Film_Dizi_API.Repositories.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateCommentAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteCommentAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (commentModel == null)
            {
                return null;
            }

            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id); 
            return comment;
        }

        public async Task<Comment?> UpdateCommentAsync(int id, Comment comment)
        {
            var existingComment = await _context.Comments.FindAsync(id);

            if(existingComment is null)
            {
                return null;  
            }

            existingComment.Title = comment.Title;
            existingComment.Content = comment.Content;

            await _context.SaveChangesAsync();

            return existingComment;
        }
    }
}
