using System;
using System.Collections.Generic;

namespace CM.WeeklyTeamReport.Domain
{
    public class Company
    {
        public int CompanyId
        {
            get;
            set;
        }
        public string CompanyName 
        { 
            get; 
            set; 
        }
        public List<TeamMember> TeamMembers 
        { 
            get; 
            set; 
        }
        public string JoinDate 
        { 
            get; 
            set; 
        }
        public Company(string companyName, List<TeamMember> teamMembers, string joinDate)
        {
            CompanyName = companyName; 
            TeamMembers = teamMembers;
            JoinDate = joinDate;
        }

        public void UpdateCompanyName(string companyName)
        {
            if ((companyName != null) && (companyName.Length > 0))
            {
                CompanyName = companyName;
            }
        }
    }
}
