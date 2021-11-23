using CM.WeeklyTeamReport.Domain;
using CM.WeeklyTeamReport.WebApp.Controllers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CM.WeeklyTeamReport.WebApp.Tests
{
    public class WeeklyReportControllerTests
    {
        [Fact]
        public void ShouldReturnAllWeeklyReports()
        {
            var weeklyReportController = new WeeklyReportController();
            var weeklyReports = weeklyReportController.ReadAll(1);
            weeklyReports.Should().NotBeNull();
            weeklyReports.Should().HaveCount(3);
        }

        [Fact]
        public void ShouldReturnWeeklyReportById()
        {
            var fixture = new WeeklyReportControllerFixture();
            fixture.WeeklyReportRepository
                .Setup(x => x.Read(1))
                .Returns(new WeeklyReport());
            var controller = fixture.GetWeeklyReportController();
            var weeklyReport = controller.Read(1);
            weeklyReport.Should().NotBeNull();
            fixture.WeeklyReportRepository.Verify(x => x.Read(1), Times.Once);
        }

        [Fact]
        public void ShouldCreateWeeklyReport()
        {
            var weeklyReport = new WeeklyReport();
            var fixture = new WeeklyReportControllerFixture();
            fixture.WeeklyReportRepository
                .Setup(x => x.Create(weeklyReport))
                .Returns(weeklyReport);
            var controller = fixture.GetWeeklyReportController();
            weeklyReport = controller.Create(weeklyReport);
            weeklyReport.Should().NotBeNull();
            fixture.WeeklyReportRepository.Verify(x => x.Create(weeklyReport), Times.Once);
        }

        [Fact]
        public void ShouldUpdateWeeklyReport()
        {
            var weeklyReport = new WeeklyReport();
            var fixture = new WeeklyReportControllerFixture();
            fixture.WeeklyReportRepository
                .Setup(x => x.Update(weeklyReport))
                .Returns(weeklyReport);
            var controller = fixture.GetWeeklyReportController();
            weeklyReport = controller.Update(weeklyReport);
            weeklyReport.Should().NotBeNull();
            fixture.WeeklyReportRepository.Verify(x => x.Update(weeklyReport), Times.Once);
        }

        [Fact]
        public void ShouldDeleteWeeklyReport()
        {
            var fixture = new WeeklyReportControllerFixture();
            fixture.WeeklyReportRepository
                .Setup(x => x.Delete(1));
            var controller = fixture.GetWeeklyReportController();
            controller.Delete(1);
            fixture.WeeklyReportRepository.Verify(x => x.Delete(1), Times.Once);
        }
    }

    public class WeeklyReportControllerFixture
    {
        public Mock<IRepository<WeeklyReport>> WeeklyReportRepository { get; set; }

        public WeeklyReportControllerFixture()
        {
            WeeklyReportRepository = new Mock<IRepository<WeeklyReport>>();
        }

        public WeeklyReportController GetWeeklyReportController()
        {
            return new WeeklyReportController(WeeklyReportRepository.Object);
        }
    }
}