using DBAssistance;
using DBAssistance.BussinesLayer.Services.GroupService;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        

        private readonly IGroupService _groupService;


        public GroupController(IGroupService groupService)
        {
            _groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));  
        }

        [HttpGet]
        public ActionResult<IEnumerable<Group>> Get()
        {
            
            return Ok(_groupService.GetGroups());
        }
        [HttpGet("id")]
        public ActionResult<GroupDto > GetGroupById(int id)
        {
            return Ok(_groupService.GetGroup(id));
        }

        [HttpGet("full")]
        public ActionResult<Group> GetGroupsWithPeriodDetails()
        {
            return Ok(_groupService.GetGroupsWithPeriodDetails());
        }

        [HttpGet("id/students")]
        public ActionResult<Group> GetGroupWithStudents(int id)
        {
            return _groupService.GetGroupWithStudents(id);
        }

        [HttpGet("id/studentsdto")]
        public ActionResult<GroupAndStudentsDto> GetGroupAndStudentsDto(int id)
        {
            return _groupService.GetGroupWithStudentsDto(id);
        }
    }
}
