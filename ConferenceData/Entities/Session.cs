using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Room { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Leaders { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<SessionSpeaker> Speakers { get; set; }
        public virtual ICollection<SessionAttendee> Attendees { get; set; }
        public virtual SessionFormat Format { get; set; }

        [JsonIgnore]
        public virtual Conference Conference { get; set; }
    }
}
