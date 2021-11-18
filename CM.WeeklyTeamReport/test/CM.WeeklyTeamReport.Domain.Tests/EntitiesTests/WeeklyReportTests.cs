using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class WeeklyReportTests
    {
        [Fact]
        public void ShouldBeAbleToCreateWeeklyReportObject()
        {
            WeeklyReport weeklyReport = new WeeklyReport("May 9", "May 16", "2020", Morales.Okay, Morales.Low, Morales.Great, "adawd", "adad", "wdad", "adawd", "adad", "wdad");
            Assert.NotNull(weeklyReport);
            Assert.Equal("May 9", weeklyReport.StartDate);
            Assert.Equal("May 16", weeklyReport.EndDate);
            Assert.Equal("2020", weeklyReport.Year);
            Assert.Equal(Morales.Okay, weeklyReport.MoraleValue);
            Assert.Equal(Morales.Low, weeklyReport.StressValue);
            Assert.Equal(Morales.Great, weeklyReport.WorkloadValue);
            Assert.Equal("adawd", weeklyReport.MoraleComment);
            Assert.Equal("adad", weeklyReport.StressComment);
            Assert.Equal("wdad", weeklyReport.WorkloadComment);
            Assert.Equal("adawd", weeklyReport.WeekHighComment);
            Assert.Equal("adad", weeklyReport.WeekLowComment);
            Assert.Equal("wdad", weeklyReport.AnythingElseComment);
        }
    }
}
