using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string Team { get; set; }
        public string Interests { get; set; }
        public string Bio { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool AttendingFirstDay { get; set; }
        public bool AttendingSecondDay { get; set; }
        public bool AttendingBothDays { get; set; }

        [JsonIgnore]
        public DateTime? CreationTime { get; set; }
    }
}
