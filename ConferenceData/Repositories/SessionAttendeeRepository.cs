using ConferenceData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Repositories
{
    public class SessionAttendeeRepository
    {
        public SessionAttendee Get(int userId)
        {
            SessionAttendee attendee = null;

            using (var db = new ConferenceDbContext())
            {
                attendee = db.SessionAttendees
                    .Where(s => s.User.Id == userId)
                    .Include(s => s.User)
                    .FirstOrDefault();
            }

            return attendee;
        }

        public IEnumerable<SessionAttendee> GetAll()
        {
            List<SessionAttendee> attendees = null;

            using (var db = new ConferenceDbContext())
            {
                attendees = db.SessionAttendees
                    .Include(s => s.User)
                    .ToList();
            }

            return attendees;
        }

        public IEnumerable<SessionAttendee> GetAll(int conferenceId)
        {
            List<SessionAttendee> attendees = null;

            using (var db = new ConferenceDbContext())
            {
                attendees = db.SessionAttendees
                    .Where(s => s.Id == conferenceId)
                    .Include(s => s.User)
                    .ToList();
            }

            return attendees;
        }

        public SessionAttendee Create(SessionAttendee attendee)
        {
            using (var db = new ConferenceDbContext())
            {
                db.SessionAttendees.Add(attendee);
                db.SaveChanges();
            }

            return attendee;
        }

        public SessionAttendee Create(int userId, int sessionId)
        {
            SessionAttendee attendee = null;

            using (var db = new ConferenceDbContext())
            {
                var user = db.Users.Find(userId);

                if (user == null)
                {
                    throw new ArgumentException(String.Format("The specified user id: '{0}' was not found.", userId.ToString()));
                }

                var session = db.Sessions.Find(sessionId);

                if (session == null)
                {
                    throw new ArgumentException(String.Format("The specified session id: '{0}' was not found.", sessionId.ToString()));
                }

                if (IsUserRegistered(user, session))
                {
                    throw new ArgumentException(String.Format("The specified user id: '{0}' is already registered to attend session id: '{1}'.", user.Id.ToString(), session.Id.ToString()));
                }

                attendee = new SessionAttendee();
                attendee.User = user;
                attendee.Session = session;
                attendee.RegistrationTime = DateTime.Now;

                db.SessionAttendees.Add(attendee);
                db.SaveChanges();
            }

            return attendee;
        }

        public SessionAttendee Update(SessionAttendee attendee)
        {
            using (var db = new ConferenceDbContext())
            {
                db.SessionAttendees.Attach(attendee);
                db.Entry(attendee).State = EntityState.Modified;
                db.SaveChanges();
            }

            return attendee;
        }

        public int Delete(int userId)
        {
            int result = 0;

            using (var db = new ConferenceDbContext())
            {
                var attendee = db.SessionAttendees
                    .Where(s => s.User.Id == userId)
                    .FirstOrDefault();

                if (attendee != null)
                {
                    db.SessionAttendees.Remove(attendee);
                    result = db.SaveChanges();
                }
            }

            return result;
        }

        private bool IsUserRegistered(User user, Session session)
        {
            bool result = false;

            using (var db = new ConferenceDbContext())
            {
                result = db.SessionAttendees.Any(u => u.User.Id == user.Id && u.Session.Id == session.Id);
            }

            return result;
        }
    }
}
