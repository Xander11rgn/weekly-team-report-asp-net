using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class WeeklyReportRepositoryTests
    {
        [Fact]
        public void ShoulBeAbleToCreateWeeklyReportRepositoryObject()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            weeklyReportRepository.Should().NotBeNull();
        }
        [Fact]
        public void ShoulBeAbleToCreateWeeklyReportAndSaveItToDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            WeeklyReport weeklyReport = new WeeklyReport(DateTime.Now.Date.ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd"), "2021", Morales.Okay, Morales.Low, Morales.Great, "adawd", "adad", "wdad", "adawd", "adad", "wdad")
            {
                teamMemberId = 1
            };
            weeklyReport = weeklyReportRepository.Create(weeklyReport);
            weeklyReport.Should().NotBeNull();
            weeklyReport.weeklyReportId.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ShoulBeAbleToDeleteWeeklyReportFromDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            weeklyReportRepository.Delete(5);
            WeeklyReport weeklyReport = weeklyReportRepository.Read(5);
            weeklyReport.Should().BeNull();
        }

        [Fact]
        public void ShoulBeAbleToReadWeeklyReportFromDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            WeeklyReport weeklyReport = weeklyReportRepository.Read(3);
            weeklyReport.Should().NotBeNull();
            weeklyReport.weeklyReportId.Should().Equals(3);
        }

        [Fact]
        public void ShoulBeAbleToUpdateTeamMemberInDatabase()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            WeeklyReport weeklyReport = new WeeklyReport(DateTime.Now.Date.ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd"), "2021", Morales.Low, Morales.Great, Morales.VeryLow, "adawd", "adad", "wdad", "adawd", "adad", "wdad")
            {
                weeklyReportId = 4
            };
            weeklyReport = weeklyReportRepository.Update(weeklyReport);
            weeklyReport.AnythingElseComment.Should().Equals("wdad");
        }
    }
}
