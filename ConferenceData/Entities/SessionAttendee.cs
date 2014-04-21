using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Entities
{
    public class SessionAttendee
    {
        public int Id { get; set; }
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Session Session { get; set; }
        public DateTime? RegistrationTime { get; set; }
    }
}
