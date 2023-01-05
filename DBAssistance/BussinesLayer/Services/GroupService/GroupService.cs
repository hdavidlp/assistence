using AutoMapper;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.BussinesLayer.Repositories.GroupRepository;
using DBAssistance.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<Group> GetGroups()
        {
            return _groupRepository.GetGroups();
        }

        public GroupDto GetGroup(int id)
        {
            var res = _groupRepository.GetGroup(id);
            return _mapper.Map <GroupDto>(res);
        }

        public GroupAndStudentsDto GetGroupWithStudentsDto(int id)
        {
            var res = _groupRepository.GetGroupWithStudents(id);

            return  _mapper.Map<GroupAndStudentsDto>(res);
        }

        public IEnumerable<Group> GetGroupsWithPeriodDetails()
        {
            return _groupRepository.GetGroupWithPeriodDetails();
        }

        public Group GetGroupWithStudents(int idGroup)
        {
            return _groupRepository.GetGroupWithStudents(idGroup);
        }
    }
}
