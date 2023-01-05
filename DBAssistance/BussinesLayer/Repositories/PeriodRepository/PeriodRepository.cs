using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBAssistance.DataLayer.Entities;

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
        public Period GetPeriod(int periodId)
        {
            return  _dbAssistenceContext.Period.Where(p => p.PeriodID == periodId).FirstOrDefault();
        }
    }
}
