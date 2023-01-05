using DBAssistance.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Repositories.GroupRepository
{
    public class GroupRepository:IGroupRepository
    {
        private readonly DBAssistenceContext _dbAssistenceContext;
        public GroupRepository(DBAssistenceContext dbAssistenceContext)
        {
            _dbAssistenceContext = dbAssistenceContext ?? throw new ArgumentNullException(nameof(dbAssistenceContext));
        }

        public IEnumerable<Group> GetGroups()
        {
            return _dbAssistenceContext.Group.ToList();
        }

        public Group GetGroup(int id)
        {
            return _dbAssistenceContext.Group.Where(g => g.GroupID == id).FirstOrDefault();
        }

        public Group GetGroupWithStudents(int id)
        {
            var groupSelected = _dbAssistenceContext.Group.
                Where(g => g.GroupID == id).Include(s => s.Courses).FirstOrDefault();

            groupSelected.Period = _dbAssistenceContext.Period.
                Where(p => p.PeriodID == groupSelected.PeriodID).FirstOrDefault();

            return groupSelected;
        }

        public IEnumerable<Group> GetGroupWithPeriodDetails()
        {
            return _dbAssistenceContext.Group.Include(p => p.Period).ToList();
        } 

       

    }
}
