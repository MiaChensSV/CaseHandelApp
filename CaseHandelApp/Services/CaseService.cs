using System.Linq.Expressions;
using CaseHandelApp.Contexts;
using CaseHandelApp.Models.Entities;
using CaseHandelApp.Models.Form;
using Microsoft.EntityFrameworkCore;

namespace CaseHandelApp.Services
{
    internal class CaseService
    {
        private readonly DataContext _context = new DataContext();
        public async Task<IEnumerable<CaseEntity>> GetAllAsync()
        {
            return await _context.Cases.Include(x => x.User)
                                       .Include(x => x.Status)
                                       .Include(x=>x.Comments)
                                       .ToListAsync();
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
        public async Task<CaseEntity> CreateAsync(CaseRegistrationForm form)
        {
            if(_context.Users.Any(x=>x.Email==form.Email))
            {
                var _user=_context.Users.FirstOrDefault(x=>x.Email==form.Email);
                var _comments = _context.Comments.Where(x => x.CaseId == form.CaseId);
                if (!_context.Cases.Any(x => x.Id == form.CaseId))
                {
                    var _caseEntity = new CaseEntity()
                    {
                        Title = form.Title,
                        Description = form.Description,
                        UserId = _user!.Id,
                        Comments = _comments.ToList(),                  
                    };
                    _context.Cases.Add(_caseEntity);
                    await _context.SaveChangesAsync();
                    return _caseEntity;
                }
            }
            return null!;
        }
        public async Task<CaseEntity> UpdateAsync(CaseEntity entity)
        {
            var _caseEntity= await _context.Cases.FirstOrDefaultAsync(x=>x.Id==entity.Id);
            if (_caseEntity!=null)
            {
                _caseEntity.StatusTypeCode= entity.StatusTypeCode;
                _caseEntity.Updated=DateTime.Now;
                _context.Cases.Update(_caseEntity);
                await _context.SaveChangesAsync();
                return _caseEntity;
            }return null!;
        }
    }
}
