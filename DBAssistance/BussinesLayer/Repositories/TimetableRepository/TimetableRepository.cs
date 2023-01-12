using DBAssistance.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Repositories.TimetableRepository
{
    public class TimetableRepository : ITimetableRepository
    {
        private readonly DBAssistenceContext _dbAssistenceContext;

        public TimetableRepository(DBAssistenceContext dbAssistenceContext)
        {
            _dbAssistenceContext = dbAssistenceContext ??
                throw new ArgumentNullException(nameof(dbAssistenceContext));
        }

        public IEnumerable<Timetable> GetTimetable()
        {
            return _dbAssistenceContext.Timetable.ToList();
        }

        public async Task<bool> CreateTimeTableAsync(Timetable timetable )
        {
            _dbAssistenceContext.Timetable.Add(timetable);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateTimetable()
        {
            return await SaveChangesAsync();
        }

        public async Task<Timetable> GetTimetableAsync(int id)
        {
            var timeTableSelected = await _dbAssistenceContext.Timetable
                .Where(t => t.idTimeTable == id).FirstAsync();

            return timeTableSelected;
        }

        public async Task<bool> TimetableKeyExistAsync(int key)
        {
            return await _dbAssistenceContext.Timetable.AnyAsync(t => t.keyId == key);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbAssistenceContext.SaveChangesAsync() >=0;
        }

    }
}
