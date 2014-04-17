using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Entities
{
    public class Conference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        [JsonIgnore]
        public virtual ICollection<ConferenceAttendee> Attendees { get; set; }

        [JsonIgnore]
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
