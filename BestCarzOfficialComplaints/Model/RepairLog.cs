using System;

namespace BestCarzOfficialComplaints.Model
{
    public class RepairLog
    {
        public string Id { get; set; }
        public string MechanicUsername { get; set; }
        public string MechanicUserId { get; set; }
        public string[] IssueFixed { get; set; }
        public DateTime dateFixed { get; set; }

    }
}