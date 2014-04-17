using ConferenceData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Repositories
{
    public class ConferenceRepository
    {
        public Conference Get(int conferenceId)
        {
            Conference conference = null;

            using (var db = new ConferenceDbContext())
            {
                conference = db.Conferences
                    .Where(c => c.Id == conferenceId)
                    .Include(c => c.Attendees.Select(u => u.User))
                    .Include(c => c.Sessions.Select(s => s.Attendees))
                    .Include(c => c.Sessions.Select(s => s.Attendees.Select(sa => sa.User)))
                    .Include(c => c.Sessions.Select(s => s.Speakers))
                    .Include(c => c.Sessions.Select(s => s.Speakers.Select(ss => ss.User)))
                    .FirstOrDefault(); 
            }

            return conference;
        }

        public IEnumerable<Conference> GetAll()
        {
            List<Conference> conferences = null;

            using (var db = new ConferenceDbContext())
            {
                conferences = db.Conferences
                    .Include(c => c.Attendees.Select(u => u.User))
                    .Include(c => c.Sessions.Select(s => s.Attendees))
                    .Include(c => c.Sessions.Select(s => s.Attendees.Select(sa => sa.User)))
                    .Include(c => c.Sessions.Select(s => s.Speakers))
                    .Include(c => c.Sessions.Select(s => s.Speakers.Select(ss => ss.User)))
                    .ToList();
            }

            return conferences;
        }

        public Conference Create(Conference conference)
        {
            using (var db = new ConferenceDbContext())
            {
                db.Conferences.Add(conference);
                db.SaveChanges();
            }

            return conference;
        }

        public Conference Update(Conference conference)
        {
            using (var db = new ConferenceDbContext())
            {
                db.Conferences.Attach(conference);
                db.Entry(conference).State = EntityState.Modified;
                db.SaveChanges();
            }

            return conference;
        }

        public int Delete(int conferenceId)
        {
            int result = 0;

            using (var db = new ConferenceDbContext())
            {
                var conference = db.Conferences.Find(conferenceId);

                if (conference != null)
                {
                    db.Conferences.Remove(conference);
                    result = db.SaveChanges();
                }
            }

            return result;
        }
    }
}
