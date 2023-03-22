using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseHandelApp.Contexts;
using CaseHandelApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseHandelApp.Services
{
    internal class StatusTypeService
    {
        private readonly DataContext _context = new DataContext();
        public StatusTypeService()
        {
            InitializeAsync().ConfigureAwait(false);
        }
        public async Task<StatusEntity> GetOrCreateAsync(string statusName)
        {
            var _statusEntity = await _context.Status.FirstOrDefaultAsync(x => x.StatusName == statusName);
            if (_statusEntity == null)
            {
                _statusEntity = new StatusEntity()
                {
                    StatusName = statusName,
                };
                _context.Add(_statusEntity);
                await _context.SaveChangesAsync();
            }
            return _statusEntity;
        }

        private async Task InitializeAsync()
        {
            if (!await _context.Status.AnyAsync())
            {
                var _statuses = new List<StatusEntity>()
                {
                    new StatusEntity() { StatusTypeCode= 1, StatusName="Not Started"},
                    new StatusEntity() { StatusTypeCode= 2, StatusName = "Processing" },
                    new StatusEntity() { StatusTypeCode= 3, StatusName = "Finished" },
                };
                await _context.AddRangeAsync(_statuses);
                await _context.SaveChangesAsync();
            }
        }
    }
}
