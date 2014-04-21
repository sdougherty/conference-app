using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Entities
{
    public class ConferenceAttendee
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public DateTime? RegistrationTime { get; set; }
        public bool AttendingFirstDay { get; set; }
        public bool AttendingSecondDay { get; set; }
        public bool AttendingBothDays { get; set; }

        [JsonIgnore]
        public virtual Conference Conference { get; set; }
    }
}
