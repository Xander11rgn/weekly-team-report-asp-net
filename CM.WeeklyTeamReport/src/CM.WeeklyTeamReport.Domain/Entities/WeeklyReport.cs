using System;
using System.Collections.Generic;
using System.Text;

namespace CM.WeeklyTeamReport.Domain
{
    public class WeeklyReport
    {
        public int weeklyReportId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Year { get; set; }
        public Morales MoraleValue { get; set; }
        public Morales StressValue { get; set; }
        public Morales WorkloadValue { get; set; }
        public string MoraleComment { get; set; }
        public string StressComment { get; set; }
        public string WorkloadComment { get; set; }
        public string WeekHighComment { get; set; }
        public string WeekLowComment { get; set; }
        public string AnythingElseComment { get; set; }
        public int teamMemberId { get; set; }

        public WeeklyReport(string startDate, string endDate, string year, Morales moraleValue, Morales stressValue, Morales workloadValue, string moraleComment, string stressComment, string workloadComment, string weekHighComment, string weekLowComment, string anythingElseComment)
        {
            StartDate = startDate;
            EndDate = endDate;
            Year = year;
            MoraleValue = moraleValue;
            StressValue = stressValue;
            WorkloadValue = workloadValue;
            MoraleComment = moraleComment;
            StressComment = stressComment;
            WorkloadComment = workloadComment;
            WeekHighComment = weekHighComment;
            WeekLowComment = weekLowComment;
            AnythingElseComment = anythingElseComment;
        }
    }
}
