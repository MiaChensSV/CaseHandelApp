using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CaseHandelApp.Contexts;
using CaseHandelApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseHandelApp.Services
{
    internal class CaseService
    {
        private readonly DataContext _context = new DataContext();
        public async Task<IEnumerable<CaseEntity>> GetAllAsync()
        {
            return await _context.Cases.Include(x => x.User).Include(x => x.Status).ToListAsync();
        }
        public async Task<CaseEntity> GetSpecificAsync(Expression<Func<CaseEntity, bool>> predicate)
        {
            var _case = await _context.Cases
                .Include(x => x.User)
                .Include(x => x.Comments)
                .Include(x => x.Status)
                .FirstOrDefaultAsync(predicate);
            if (_case != null)
            {
                return _case;
            }
            else return null!;
        }
    }
}
