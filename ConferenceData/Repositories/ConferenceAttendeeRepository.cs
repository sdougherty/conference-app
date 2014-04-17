using ConferenceData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Repositories
{
    public class ConferenceAttendeeRepository
    {
        public ConferenceAttendee Get(int conferenceAttendeeId)
        {
            ConferenceAttendee attendee = null;

            using (var db = new ConferenceDbContext())
            {
                attendee = db.ConferenceAttendees
                            .Where(ca => ca.Id == conferenceAttendeeId)
                            .Include(ca => ca.User)
                            .FirstOrDefault();
            }

            return attendee;
        }

        public ConferenceAttendee Get(int conferenceId, int userId)
        {
            ConferenceAttendee attendee = null;

            using (var db = new ConferenceDbContext())
            {
                var list = db.ConferenceAttendees
                            .Where(ca => ca.Conference.Id == conferenceId && ca.User.Id == userId)
                            .Include(ca => ca.User)
                            .ToList();
            }

            return attendee;
        }

        public IEnumerable<ConferenceAttendee> GetAll()
        {
            List<ConferenceAttendee> attendees = null;

            using (var db = new ConferenceDbContext())
            {
                attendees = db.ConferenceAttendees
                            .Include(ca => ca.User)
                            .ToList();
            }

            return attendees;
        }

        public IEnumerable<ConferenceAttendee> GetAll(int conferenceId)
        {
            List<ConferenceAttendee> attendees = null;

            using (var db = new ConferenceDbContext())
            {
                attendees = db.ConferenceAttendees
                    .Where(a => a.Conference.Id == conferenceId)
                    .Include(a => a.User)
                    .ToList();
            }

            return attendees;
        }

        public ConferenceAttendee Create(ConferenceAttendee conferenceAttendee)
        {
            using (var db = new ConferenceDbContext())
            {
                db.ConferenceAttendees.Add(conferenceAttendee);
                db.SaveChanges();
            }

            return conferenceAttendee;
        }

        public ConferenceAttendee Create(int conferenceId, int userId)
        {
            ConferenceAttendee conferenceAttendee = null;

            using (var db = new ConferenceDbContext())
            {
                var user = db.Users.Find(userId);

                if (user == null)
                {
                    throw new ArgumentException(String.Format("The specified user id: '{0}' was not found.", userId.ToString()));
                }

                var conference = db.Conferences.Find(conferenceId);

                if (conference == null)
                {
                    throw new ArgumentException(String.Format("The specified conference id: '{0}' was not found.", conferenceId.ToString()));
                }

                if (IsUserRegistered(user, conference))
                {
                    throw new ArgumentException(String.Format("The specified user id: '{0}' is already registered to attend conference id: '{1}'.", user.Id.ToString(), conference.Id.ToString()));
                }

                conferenceAttendee = new ConferenceAttendee();
                conferenceAttendee.Conference = conference;
                conferenceAttendee.User = user;
                conferenceAttendee.RegistrationTime = DateTime.Now;

                db.ConferenceAttendees.Add(conferenceAttendee);
                db.SaveChanges();
            }

            return conferenceAttendee;
        }

        public ConferenceAttendee Update(ConferenceAttendee conferenceAttendee)
        {
            using (var db = new ConferenceDbContext())
            {
                db.ConferenceAttendees.Attach(conferenceAttendee);
                db.Entry(conferenceAttendee).State = EntityState.Modified;
                db.SaveChanges();
            }

            return conferenceAttendee;
        }

        public int Delete(int conferenceAttendeeId)
        {
            int result = 0;

            using (var db = new ConferenceDbContext())
            {
                var conferenceAttendee = db.ConferenceAttendees.Find(conferenceAttendeeId);

                db.ConferenceAttendees.Remove(conferenceAttendee);
                result = db.SaveChanges();
            }

            return result;
        }

        public int Delete(int conferenceId, int userId)
        {
            int result = 0;

            using (var db = new ConferenceDbContext())
            {
                var attendee = db.ConferenceAttendees
                    .Where(ca => ca.Conference.Id == conferenceId && ca.User.Id == userId)
                    .FirstOrDefault();

                if (attendee != null)
                {
                    db.ConferenceAttendees.Remove(attendee);
                    result = db.SaveChanges();
                }
            }

            return result;
        }

        private bool IsUserRegistered(User user, Conference conference)
        {
            bool result = false;

            using (var db = new ConferenceDbContext())
            {
                result = db.ConferenceAttendees.Any(u => u.User.Id == user.Id && u.Conference.Id == conference.Id);
            }

            return result;
        }
    }
}
