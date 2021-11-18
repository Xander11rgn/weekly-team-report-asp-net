using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class CompanyRepositoryTests
    {
        [Fact]
        public void ShoulBeAbleToCreateCompanyRepositoryObject()
        {
            var companyRepository = new CompanyRepository();
            companyRepository.Should().NotBeNull();
        }
        [Fact]
        public void ShoulBeAbleToCreateCompanyAndSaveItToDatabase()
        {
            var companyRepository = new CompanyRepository();
            Company company = new Company("some name 2", null, DateTime.Now.Date.ToString("yyyy-MM-dd"));
            company = companyRepository.Create(company);
            company.Should().NotBeNull();
            company.CompanyId.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ShoulBeAbleToDeleteCompanyFromDatabase()
        {
            var companyRepository = new CompanyRepository();
            companyRepository.Delete(49);
            Company company = companyRepository.Read(49);
            company.Should().BeNull();
        }

        [Fact]
        public void ShoulBeAbleToReadCompanyFromDatabase()
        {
            var companyRepository = new CompanyRepository();
            Company company = companyRepository.Read(48);
            company.Should().NotBeNull();
            company.CompanyName.Should().Equals("some name 2");
        }

        [Fact]
        public void ShoulBeAbleToUpdateCompanyInDatabase()
        {
            var companyRepository = new CompanyRepository();
            Company company = new Company("some name 2", null, DateTime.Now.Date.ToString("yyyy-MM-dd"))
            { 
                CompanyId = 48
            };
            company = companyRepository.Update(company);
            company.CompanyName.Should().Equals("some name 2");
        }
    }
}
