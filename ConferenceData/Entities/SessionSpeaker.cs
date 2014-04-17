using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Entities
{
    public class SessionSpeaker
    {
        public int Id { get; set; }
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Session Session { get; set; }
    }
}
