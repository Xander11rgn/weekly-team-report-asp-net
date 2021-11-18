using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CM.WeeklyTeamReport.Domain
{
    public class WeeklyReportRepository : IRepository<WeeklyReport>
    {
        string connectionString = "Server=ANTON-PC;Database=WeeklyTeamReportLib;Trusted_Connection=True;";
        SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        public WeeklyReport Create(WeeklyReport weeklyReport)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("INSERT INTO WeeklyReports (StartDate,  EndDate, Year, MoraleValueId, StressValueId, WorkloadValueId, MoraleComment, StressComment, WorkloadComment, " +
                                             "WeekHighComment, WeekLowComment, AnythingElseComment, TeamMemberId)" +
                                             "VALUES (@StartDate,  @EndDate, @Year, @MoraleValueId, @StressValueId, @WorkloadValueId, @MoraleComment, @StressComment, @WorkloadComment, @WeekHighComment," +
                                             "@WeekLowComment, @AnythingElseComment, @TeamMemberId);" +
                                             "SELECT * FROM WeeklyReports WHERE WeeklyReportId = SCOPE_IDENTITY()", connection);
                SqlParameter StartDate = new SqlParameter("@StartDate", System.Data.SqlDbType.Date)
                {
                    Value = weeklyReport.StartDate
                };
                SqlParameter EndDate = new SqlParameter("@EndDate", System.Data.SqlDbType.Date)
                {
                    Value = weeklyReport.EndDate
                };
                SqlParameter Year = new SqlParameter("@Year", System.Data.SqlDbType.NChar, 4)
                {
                    Value = weeklyReport.Year
                };
                SqlParameter MoraleValueId = new SqlParameter("@MoraleValueId", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.MoraleValue
                };
                SqlParameter StressValueId = new SqlParameter("@StressValueId", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.StressValue
                };
                SqlParameter WorkloadValueId = new SqlParameter("@WorkloadValueId", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.WorkloadValue
                };
                SqlParameter MoraleComment = new SqlParameter("@MoraleComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.MoraleComment
                };
                SqlParameter StressComment = new SqlParameter("@StressComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.StressComment
                };
                SqlParameter WorkloadComment = new SqlParameter("@WorkloadComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.WorkloadComment
                };
                SqlParameter WeekHighComment = new SqlParameter("@WeekHighComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.WeekHighComment
                };
                SqlParameter WeekLowComment = new SqlParameter("@WeekLowComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.WeekLowComment
                };
                SqlParameter AnythingElseComment = new SqlParameter("@AnythingElseComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.AnythingElseComment
                };
                SqlParameter TeamMemberId = new SqlParameter("@TeamMemberId", System.Data.SqlDbType.Int)
                {
                    Value = weeklyReport.teamMemberId
                };

                command.Parameters.AddRange(new object[] { StartDate, EndDate, Year, MoraleValueId, StressValueId, WorkloadValueId, MoraleComment, StressComment, WorkloadComment, WeekHighComment,
                                                           WeekLowComment, AnythingElseComment, TeamMemberId });
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapWeeklyReport(reader);
                }
            }
            return null;
        }

        public void Delete(int weeklyReportId)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("DELETE FROM WeeklyReports WHERE WeeklyReportId = @WeeklyReportId", connection);
                SqlParameter WeeklyReportId = new SqlParameter("@WeeklyReportId", System.Data.SqlDbType.Int)
                {
                    Value = weeklyReportId
                };

                command.Parameters.Add(WeeklyReportId);
                command.ExecuteNonQuery();
            }
        }

        public WeeklyReport Read(int weeklyReportId)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("SELECT * FROM WeeklyReports WHERE WeeklyReportId = @WeeklyReportId", connection);
                SqlParameter WeeklyReportId = new SqlParameter("@WeeklyReportId", System.Data.SqlDbType.Int)
                {
                    Value = weeklyReportId
                };

                command.Parameters.Add(WeeklyReportId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapWeeklyReport(reader);
                }
            }
            return null;
        }

        public WeeklyReport Update(WeeklyReport weeklyReport)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("UPDATE WeeklyReports " +
                                             "SET StartDate = @StartDate, EndDate = @EndDate, Year = @Year, MoraleValueId = @MoraleValueId, StressValueId = @StressValueId, WorkloadValueId = @WorkloadValueId," +
                                             "MoraleComment = @MoraleComment, StressComment = @StressComment, WorkloadComment = @WorkloadComment, WeekHighComment = @WeekHighComment, WeekLowComment = @WeekLowComment, AnythingElseComment = @AnythingElseComment " +
                                             "WHERE WeeklyReportId = @WeeklyReportId;" +
                                             "SELECT * FROM WeeklyReports WHERE WeeklyReportId = @WeeklyReportId", connection);
                SqlParameter StartDate = new SqlParameter("@StartDate", System.Data.SqlDbType.Date)
                {
                    Value = weeklyReport.StartDate
                };
                SqlParameter EndDate = new SqlParameter("@EndDate", System.Data.SqlDbType.Date)
                {
                    Value = weeklyReport.EndDate
                };
                SqlParameter Year = new SqlParameter("@Year", System.Data.SqlDbType.NChar, 4)
                {
                    Value = weeklyReport.Year
                };
                SqlParameter MoraleValueId = new SqlParameter("@MoraleValueId", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.MoraleValue
                };
                SqlParameter StressValueId = new SqlParameter("@StressValueId", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.StressValue
                };
                SqlParameter WorkloadValueId = new SqlParameter("@WorkloadValueId", System.Data.SqlDbType.Int)
                {
                    Value = (int)weeklyReport.WorkloadValue
                };
                SqlParameter MoraleComment = new SqlParameter("@MoraleComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.MoraleComment
                };
                SqlParameter StressComment = new SqlParameter("@StressComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.StressComment
                };
                SqlParameter WorkloadComment = new SqlParameter("@WorkloadComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.WorkloadComment
                };
                SqlParameter WeekHighComment = new SqlParameter("@WeekHighComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.WeekHighComment
                };
                SqlParameter WeekLowComment = new SqlParameter("@WeekLowComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.WeekLowComment
                };
                SqlParameter AnythingElseComment = new SqlParameter("@AnythingElseComment", System.Data.SqlDbType.NVarChar)
                {
                    Value = weeklyReport.AnythingElseComment
                };
                SqlParameter WeeklyReportId = new SqlParameter("@WeeklyReportId", System.Data.SqlDbType.Int)
                {
                    Value = weeklyReport.weeklyReportId
                };

                command.Parameters.AddRange(new object[] { StartDate, EndDate, Year, MoraleValueId, StressValueId, WorkloadValueId, MoraleComment, StressComment, WorkloadComment, WeekHighComment,
                                                           WeekLowComment, AnythingElseComment, WeeklyReportId });
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapWeeklyReport(reader);
                }
            }
            return null;
        }


        private static WeeklyReport MapWeeklyReport(SqlDataReader reader)
        {
            return new WeeklyReport(reader["StartDate"].ToString(), reader["EndDate"].ToString(), reader["Year"].ToString(), (Morales)(int)reader["MoraleValueId"], (Morales)(int)reader["StressValueId"],
                                    (Morales)(int)reader["WorkloadValueId"], reader["MoraleComment"].ToString(), reader["StressComment"].ToString(), reader["WorkloadComment"].ToString(),
                                    reader["WeekHighComment"].ToString(), reader["WeekLowComment"].ToString(), reader["AnythingElseComment"].ToString())
            {
                teamMemberId = (int)reader["TeamMemberId"],
                weeklyReportId = (int)reader["WeeklyReportId"]
            };
        }
    }
}
