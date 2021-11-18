using System;
using System.Collections.Generic;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class CompanyTests
    {
        List<TeamMember> teamMembers = new List<TeamMember>();
        [Fact]
        public void ShouldBeAbleToCreateCompanyObject()
        {
            Company company = new Company("Company Name", teamMembers, "2021");
            Assert.NotNull(company);
            Assert.Equal("Company Name", company.CompanyName);
            Assert.Equal(teamMembers, company.TeamMembers);
            Assert.Equal("2021", company.JoinDate);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldUpdateCompanyNameNullCorrectly(string newCompanyName)
        {
            Company company = new Company("Company Name", teamMembers, "2021");
            string oldCompanyName = company.CompanyName;
            company.UpdateCompanyName(newCompanyName);
            Assert.Equal(oldCompanyName, company.CompanyName);
        }

        [Theory]
        [InlineData("New Company Name")]
        public void ShouldUpdateCompanyNameCorrectly(string newCompanyName)
        {
            Company company = new Company("Company Name", teamMembers, "2021");
            string oldCompanyName = company.CompanyName;
            company.UpdateCompanyName(newCompanyName);
            Assert.NotEqual(oldCompanyName, company.CompanyName);
        }
    }
}
