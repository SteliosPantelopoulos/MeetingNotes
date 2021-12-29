using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MeetingNotes.Models
{ 
    public enum Status { New, Started, Finished}
        
    
    public class Meeting
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedByName { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        
        
        public DateTime DateUpdated { get; set; }  //initialise with date created

        public DateTime MeetingDate { get; set; }

        public Status MeetingStatus { get; set; }

        public string Title { get; set; }

        public string ExternalParticipants { get; set; }

        public ICollection<MeetingItem> MeetingItems { get; set; } = new List<MeetingItem>();
        public ICollection<MeetingParticipant> MeetingParticipants { get; set; } = new List<MeetingParticipant>();
    }
}
