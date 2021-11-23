using CM.WeeklyTeamReport.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CM.WeeklyTeamReport.WebApp.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository<Company> _repository;

        public CompanyController(IRepository<Company> repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public List<Company> ReadAll()
        {
            return _repository.ReadAll();
        }

        [Route("{id:int}")]
        [HttpGet]
        public Company Read(int id)
        {
            return _repository.Read(id);
        }

        [HttpPost]
        public Company Create([FromQuery] Company company)
        {
            return _repository.Create(company);
        }

        [HttpPut]
        public Company Update([FromQuery] Company company)
        {
            return _repository.Update(company);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
