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
    [Route("api/companies/{companyId}/team-members/{teamMemberId}/reports")]
    public class WeeklyReportController : ControllerBase
    {
        private readonly IRepository<WeeklyReport> _repository;

        [ActivatorUtilitiesConstructor]
        public WeeklyReportController(IRepository<WeeklyReport> repository)
        {
            _repository = repository;
        }
        public WeeklyReportController()
        {
        }


        [HttpGet]
        public List<WeeklyReport> ReadAll(int teamMemberId)
        {
            WeeklyReportRepository weeklyReportRepository = new WeeklyReportRepository();
            return weeklyReportRepository.ReadAllById(teamMemberId);
        }

        [Route("{id:int}")]
        [HttpGet]
        public WeeklyReport Read(int id)
        {
            return _repository.Read(id);
        }

        [HttpPost]
        public WeeklyReport Create([FromQuery] WeeklyReport weeklyReport)
        {
            return _repository.Create(weeklyReport);
        }

        [HttpPut]
        public WeeklyReport Update([FromQuery] WeeklyReport weeklyReport)
        {
            return _repository.Update(weeklyReport);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
