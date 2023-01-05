using DBAssistance.BussinesLayer.Dto;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.GroupService
{
    public interface IGroupService
    {
        IEnumerable<Group> GetGroups();
        GroupDto GetGroup(int id);
        IEnumerable<Group> GetGroupsWithPeriodDetails();
        Group GetGroupWithStudents(int idGroup);
        GroupAndStudentsDto GetGroupWithStudentsDto(int id);
    }
}