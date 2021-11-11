﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CM.WeeklyTeamReport.Domain
{
    public class TeamMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string InviteLink { get; set; }
        public string Mail { get; set; }
        public List<WeeklyReport> ReportsList { get; set; }
        public List<WeeklyReport> ReportsListFromMember { get; set; }
        public List<WeeklyReport> ReportsListToMember { get; set; }

        public TeamMember(string firstName, string lastName, string title, string inviteLink, string mail, List<WeeklyReport> reportsList, List<WeeklyReport> reportsListFromMember, List<WeeklyReport> reportsListToMember)
        {
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            InviteLink = inviteLink;
            Mail = mail;
            ReportsList = reportsList;
            ReportsListFromMember = reportsListFromMember;
            ReportsListToMember = reportsListToMember;
        }

        public void UpdateMemberData(string firstName, string lastName, string title)
        {
            if ((firstName != null) && (firstName.Length > 0))
            {
                FirstName = firstName;
            }
            if ((lastName != null) && (lastName.Length > 0))
            {
                LastName = lastName;
            }
            if ((title != null) && (title.Length > 0))
            {
                Title = title;
            }
        }
    }
}