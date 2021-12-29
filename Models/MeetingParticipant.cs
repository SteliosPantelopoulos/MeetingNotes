using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingNotes.Models
{
    public class MeetingParticipant
    {        
        public int Id { get; set; }

        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }

        public string ParticipantId { get; set; }
        public ApplicationUser Participant { get; set; }
    }
}
