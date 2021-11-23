using CM.WeeklyTeamReport.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CM.WeeklyTeamReport.WebApp.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/team-members")]
    public class TeamMemberController : ControllerBase
    {
        private readonly IRepository<TeamMember> _repository;

        [ActivatorUtilitiesConstructor]
        public TeamMemberController(IRepository<TeamMember> repository)
        {
            _repository = repository;
        }
        
        public TeamMemberController()
        {
        }


        [HttpGet]
        public List<TeamMember> ReadAll(int companyId)
        {
            TeamMemberRepository teamMemberRepository = new TeamMemberRepository();
            return teamMemberRepository.ReadAllById(companyId);
        }

        [Route("{id:int}")]
        [HttpGet]
        public TeamMember Read(int id)
        {
            return _repository.Read(id);
        }

        [HttpPost]
        public TeamMember Create([FromQuery] TeamMember teamMember)
        {
            return _repository.Create(teamMember);
        }

        [HttpPut]
        public TeamMember Update([FromQuery] TeamMember teamMember)
        {
            return _repository.Update(teamMember);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
