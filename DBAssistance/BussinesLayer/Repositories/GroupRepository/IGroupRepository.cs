using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.GroupRepository
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetGroups();
        Group GetGroup(int id);
        IEnumerable<Group> GetGroupWithPeriodDetails();
        Group GetGroupWithStudents(int id);
    }
}