using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseHandelApp.Contexts;
using CaseHandelApp.Models.Entities;
using CaseHandelApp.Models.Form;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CaseHandelApp.Services
{
    internal class CommentService
    {
        private readonly DataContext _context=new DataContext();
        private readonly UserService _userService = new UserService();
        public async Task CreateAsync(CommentForm form)
        {
            var _user =await _userService.GetUser(form.UserEmail);
            var commentEntity = new CommentEntity()
            {
                Comments = form.Comment,
                CaseId = form.CaseId,
                UserId = _user.Id,
            };
            await _context.Comments.AddAsync(commentEntity);
            await _context.SaveChangesAsync();  
        }
        public async Task GetAllComments()
        {
            await _context.Comments.ToListAsync();
        }
    }
}
