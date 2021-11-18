using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class TeamMemberRepositoryTests
    {
        List<WeeklyReport> reportsList = new List<WeeklyReport>();
        [Fact]
        public void ShoulBeAbleToCreateTeamMemberRepositoryObject()
        {
            var teamMemberRepository = new TeamMemberRepository();
            teamMemberRepository.Should().NotBeNull();
        }
        [Fact]
        public void ShoulBeAbleToCreateTeamMemberAndSaveItToDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();
            TeamMember teamMember = new TeamMember("Lucia", "Hoffman", "CEO", "dwadad", "lucia@hoffman.com")
            {
                ReportsList = reportsList,
                ReportsListFromMember = reportsList,
                ReportsListToMember = reportsList,
                companyId = 48
            };
            teamMember = teamMemberRepository.Create(teamMember);
            teamMember.Should().NotBeNull();
            teamMember.teamMemberId.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ShoulBeAbleToDeleteTeamMemberFromDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();
            teamMemberRepository.Delete(4);
            TeamMember teamMember = teamMemberRepository.Read(4);
            teamMember.Should().BeNull();
        }

        [Fact]
        public void ShoulBeAbleToReadTeamMemberFromDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();
            TeamMember teamMember = teamMemberRepository.Read(3);
            teamMember.Should().NotBeNull();
            teamMember.teamMemberId.Should().Equals(3);
        }

        [Fact]
        public void ShoulBeAbleToUpdateTeamMemberInDatabase()
        {
            var teamMemberRepository = new TeamMemberRepository();
            TeamMember teamMember = new TeamMember("Lucia", "Hoffman", "CEO", "dwadad", "lucia@hoffman.com")
            {
                ReportsList = reportsList,
                ReportsListFromMember = reportsList,
                ReportsListToMember = reportsList,
                companyId = 48,
                teamMemberId = 3
            };
            teamMember = teamMemberRepository.Update(teamMember);
            teamMember.FirstName.Should().Equals("Lucia");
        }
    }
}
