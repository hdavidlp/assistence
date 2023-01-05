using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBAssistance.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBAssistance.BussinesLayer.Repositories.PeriodRepository
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly DBAssistenceContext _dbAssistenceContext;

        public PeriodRepository(DBAssistenceContext dbAssistanceContext)
        {
            _dbAssistenceContext = dbAssistanceContext;
        }

        public IEnumerable<Period> GetPeriods()
        {
            return _dbAssistenceContext.Period.ToList();
        }
        public async Task<Period> GetPeriodAsync(int periodId)
        {
            //return  _dbAssistenceContext.Period.Where(p => p.PeriodID == periodId).FirstOrDefault();
            return await _dbAssistenceContext.Period.Where(p => p.PeriodID == periodId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPeriod (Period period)
        {
            _dbAssistenceContext.Period.Add(period);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeletePeriod(Period period)
        {
            _dbAssistenceContext?.Period.Remove(period);    
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbAssistenceContext.SaveChangesAsync() >= 0;
        }

        


    }
}
