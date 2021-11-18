using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class TeamMemberTests
    {
        static List<WeeklyReport> reportsList = new List<WeeklyReport>();
        TeamMember teamMember = new TeamMember("Lucia", "Hoffman", "CEO", "dwadad", "lucia@hoffman.com")
        {
            ReportsList = reportsList,
            ReportsListFromMember = reportsList,
            ReportsListToMember = reportsList,
            companyId = 48
        };
        [Fact]
        public void ShouldBeAbleToCreateTeamMemberObject()
        {
            Assert.NotNull(teamMember);
            Assert.Equal("Lucia", teamMember.FirstName);
            Assert.Equal("Hoffman", teamMember.LastName);
            Assert.Equal("CEO", teamMember.Title);
            Assert.Equal("dwadad", teamMember.InviteLink);
            Assert.Equal("lucia@hoffman.com", teamMember.Mail);
            Assert.Equal(reportsList, teamMember.ReportsList);
            Assert.Equal(reportsList, teamMember.ReportsListFromMember);
            Assert.Equal(reportsList, teamMember.ReportsListToMember);
        }

        [Theory]
        [InlineData(null, "New Surname", "New title")]
        [InlineData("", "New Surname", "New title")]
        public void ShouldUpdateFirstNameCorrectly(string newName, string newSurname, string newTitle)
        {
            string oldName = teamMember.FirstName;
            teamMember.UpdateMemberData(newName, newSurname, newTitle);
            Assert.Equal(oldName, teamMember.FirstName);
        }

        [Theory]
        [InlineData("New Name", null, "New title")]
        [InlineData("New Name", "", "New title")]
        public void ShouldUpdateLastNameCorrectly(string newName, string newSurname, string newTitle)
        {
            string oldSurname = teamMember.LastName;
            teamMember.UpdateMemberData(newName, newSurname, newTitle);
            Assert.Equal(oldSurname, teamMember.LastName);
        }

        [Theory]
        [InlineData("New Name", "New Surname", null)]
        [InlineData("New Name", "New Surname", "")]
        public void ShouldUpdateTitleCorrectly(string newName, string newSurname, string newTitle)
        {
            string oldTitle = teamMember.Title;
            teamMember.UpdateMemberData(newName, newSurname, newTitle);
            Assert.Equal(oldTitle, teamMember.Title);
        }
    }
}
