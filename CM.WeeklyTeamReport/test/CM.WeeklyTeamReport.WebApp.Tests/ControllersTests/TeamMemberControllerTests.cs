using CM.WeeklyTeamReport.Domain;
using CM.WeeklyTeamReport.WebApp.Controllers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CM.WeeklyTeamReport.WebApp.Tests
{
    public class TeamMemberControllerTests
    {
        /*[Fact]
        public void ShouldReturnAllTeamMembers()
        {
            var teamMemberController = new TeamMemberController();
            var teamMembers = teamMemberController.ReadAll(48);
            teamMembers.Should().NotBeNull();
            teamMembers.Should().HaveCount(3);
        }*/

        [Fact]
        public void ShouldReturnTeamMemberById()
        {
            var fixture = new TeamMemberControllerFixture();
            fixture.TeamMemberRepository
                .Setup(x => x.Read(1))
                .Returns(new TeamMember());
            var controller = fixture.GetTeamMemberController();
            var teamMember = controller.Read(1);
            teamMember.Should().NotBeNull();
            fixture.TeamMemberRepository.Verify(x => x.Read(1), Times.Once);
        }

        [Fact]
        public void ShouldCreateTeamMember()
        {
            var teamMember = new TeamMember();
            var fixture = new TeamMemberControllerFixture();
            fixture.TeamMemberRepository
                .Setup(x => x.Create(teamMember))
                .Returns(teamMember);
            var controller = fixture.GetTeamMemberController();
            teamMember = controller.Create(teamMember);
            teamMember.Should().NotBeNull();
            fixture.TeamMemberRepository.Verify(x => x.Create(teamMember), Times.Once);
        }

        [Fact]
        public void ShouldUpdateTeamMember()
        {
            var teamMember = new TeamMember();
            var fixture = new TeamMemberControllerFixture();
            fixture.TeamMemberRepository
                .Setup(x => x.Update(teamMember))
                .Returns(teamMember);
            var controller = fixture.GetTeamMemberController();
            teamMember = controller.Update(teamMember);
            teamMember.Should().NotBeNull();
            fixture.TeamMemberRepository.Verify(x => x.Update(teamMember), Times.Once);
        }

        [Fact]
        public void ShouldDeleteTeamMember()
        {
            var fixture = new TeamMemberControllerFixture();
            fixture.TeamMemberRepository
                .Setup(x => x.Delete(1));
            var controller = fixture.GetTeamMemberController();
            controller.Delete(1);
            fixture.TeamMemberRepository.Verify(x => x.Delete(1), Times.Once);
        }
    }

    public class TeamMemberControllerFixture
    {
        public Mock<IRepository<TeamMember>> TeamMemberRepository { get; set; }

        public TeamMemberControllerFixture()
        {
            TeamMemberRepository = new Mock<IRepository<TeamMember>>();
        }

        public TeamMemberController GetTeamMemberController()
        {
            return new TeamMemberController(TeamMemberRepository.Object);
        }
    }
}