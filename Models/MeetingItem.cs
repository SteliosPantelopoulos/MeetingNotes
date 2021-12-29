using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingNotes.Models
{
    public class MeetingItem
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public string AssignedTo { get; set; }

        public int RiskLevelId { get; set; }
        public RiskLevel RiskLevel { get; set; }

        public string RequestedBy { get; set; }

        public Boolean ChangeRequested { get; set; }

        public Boolean VissibleInMinutes { get; set; } = true; 

        public string FileAttachment { get; set; }
        
        public string FileName { get; set; }    //required if attachment exists

        public string FileType { get; set; }    //required if attachment exists

    }
}
