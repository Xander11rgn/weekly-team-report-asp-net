using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CM.WeeklyTeamReport.Domain
{
    public class TeamMemberRepository : IRepository<TeamMember>
    {
        string connectionString = "Server=ANTON-PC;Database=WeeklyTeamReportLib;Trusted_Connection=True;";
        SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        public TeamMember Create(TeamMember teamMember)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("INSERT INTO TeamMembers (FirstName,  LastName, Title, InviteLink, Mail, CompanyId)" +
                                                           "VALUES (@FirstName,  @LastName, @Title, @InviteLink, @Mail, @CompanyId);" +
                                                           "SELECT * FROM TeamMembers WHERE TeamMemberId = SCOPE_IDENTITY()", connection);
                SqlParameter FirstName = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 20)
                {
                    Value = teamMember.FirstName
                };
                SqlParameter LastName = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20)
                {
                    Value = teamMember.LastName
                };
                SqlParameter Title = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 20)
                {
                    Value = teamMember.Title
                };
                SqlParameter InviteLink = new SqlParameter("@InviteLink", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = teamMember.InviteLink
                };
                SqlParameter Mail = new SqlParameter("@Mail", System.Data.SqlDbType.NVarChar, 100)
                {
                    Value = teamMember.Mail
                };
                SqlParameter CompanyId = new SqlParameter("@CompanyId", System.Data.SqlDbType.Int)
                {
                    Value = teamMember.companyId
                };

                command.Parameters.AddRange(new object[] { FirstName, LastName, Title, InviteLink, Mail, CompanyId });
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapTeamMember(reader);
                }
            }
            return null;
        }

        public void Delete(int teamMemberId)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("DELETE FROM TeamMembers WHERE TeamMemberId = @TeamMemberId", connection);
                SqlParameter TeamMemberId = new SqlParameter("@TeamMemberId", System.Data.SqlDbType.Int)
                {
                    Value = teamMemberId
                };

                command.Parameters.Add(TeamMemberId);
                command.ExecuteNonQuery();
            }
        }

        public TeamMember Read(int teamMemberId)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("SELECT * FROM TeamMembers WHERE TeamMemberId = @TeamMemberId", connection);
                SqlParameter TeamMemberId = new SqlParameter("@TeamMemberId", System.Data.SqlDbType.Int)
                {
                    Value = teamMemberId
                };

                command.Parameters.Add(TeamMemberId);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapTeamMember(reader);
                }
            }
            return null;
        }

        public TeamMember Update(TeamMember teamMember)
        {
            using (var connection = GetSqlConnection())
            {
                var command = new SqlCommand("UPDATE TeamMembers " +
                                             "SET FirstName = @FirstName, LastName = @LastName, Title = @Title, InviteLink = @InviteLink, Mail = @Mail, CompanyId = @CompanyId " +
                                             "WHERE TeamMemberId = @TeamMemberId;" +
                                             "SELECT * FROM TeamMembers WHERE TeamMemberId = @TeamMemberId", connection);
                SqlParameter FirstName = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 20)
                {
                    Value = teamMember.FirstName
                };
                SqlParameter LastName = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20)
                {
                    Value = teamMember.LastName
                };
                SqlParameter Title = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 20)
                {
                    Value = teamMember.Title
                };
                SqlParameter InviteLink = new SqlParameter("@InviteLink", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = teamMember.InviteLink
                };
                SqlParameter Mail = new SqlParameter("@Mail", System.Data.SqlDbType.NVarChar, 100)
                {
                    Value = teamMember.Mail
                };
                SqlParameter CompanyId = new SqlParameter("@CompanyId", System.Data.SqlDbType.Int)
                {
                    Value = teamMember.companyId
                };
                SqlParameter TeamMemberId = new SqlParameter("@TeamMemberId", System.Data.SqlDbType.Int)
                {
                    Value = teamMember.teamMemberId
                };

                command.Parameters.AddRange(new object[] { FirstName, LastName, Title, InviteLink, Mail, CompanyId, TeamMemberId });
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapTeamMember(reader);
                }
            }
            return null;
        }


        private static TeamMember MapTeamMember(SqlDataReader reader)
        {
            return new TeamMember(reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["Title"].ToString(), reader["InviteLink"].ToString(), reader["Mail"].ToString())
            {
                teamMemberId = (int)reader["TeamMemberId"],
                companyId = (int)reader["CompanyId"]
            };
        }
    }
}
