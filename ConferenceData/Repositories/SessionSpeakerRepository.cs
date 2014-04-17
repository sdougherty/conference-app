using ConferenceData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Repositories
{
    public class SessionSpeakerRepository
    {
        public SessionSpeaker Get(int userId)
        {
            SessionSpeaker speaker = null;

            using (var db = new ConferenceDbContext())
            {
                speaker = db.SessionSpeakers
                    .Where(s => s.User.Id == userId)
                    .Include(s => s.User)
                    .FirstOrDefault();
            }

            return speaker;
        }

        public IEnumerable<SessionSpeaker> GetAll()
        {
            List<SessionSpeaker> speakers = null;

            using (var db = new ConferenceDbContext())
            {
                speakers = db.SessionSpeakers
                    .Include(s => s.User)
                    .ToList();
            }

            return speakers;
        }

        public IEnumerable<SessionSpeaker> GetAll(int conferenceId)
        {
            List<SessionSpeaker> speakers = null;

            using (var db = new ConferenceDbContext())
            {
                speakers = db.SessionSpeakers
                    .Where(s => s.Id == conferenceId)
                    .Include(s => s.User)
                    .ToList();
            }

            return speakers;
        }

        public SessionSpeaker Create(SessionSpeaker speaker)
        {
            using (var db = new ConferenceDbContext())
            {
                db.SessionSpeakers.Add(speaker);
                db.SaveChanges();
            }

            return speaker;
        }

        public SessionSpeaker Create(int userId, int sessionId)
        {
            SessionSpeaker speaker = null;

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
                    throw new ArgumentException(String.Format("The specified user id: '{0}' is already registered to speak at session id: '{1}'.", user.Id.ToString(), session.Id.ToString()));
                }

                speaker = new SessionSpeaker();
                speaker.User = user;
                speaker.Session = session;

                db.SessionSpeakers.Add(speaker);
                db.SaveChanges();
            }

            return speaker;
        }

        public SessionSpeaker Update(SessionSpeaker speaker)
        {
            using (var db = new ConferenceDbContext())
            {
                db.SessionSpeakers.Attach(speaker);
                db.Entry(speaker).State = EntityState.Modified;
                db.SaveChanges();
            }

            return speaker;
        }

        public int Delete(int userId)
        {
            int result = 0;

            using (var db = new ConferenceDbContext())
            {
                var speaker = db.SessionSpeakers
                    .Where(s => s.User.Id == userId)
                    .FirstOrDefault();

                if (speaker != null)
                {
                    db.SessionSpeakers.Remove(speaker);
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
                result = db.SessionSpeakers.Any(u => u.User.Id == user.Id && u.Session.Id == session.Id);
            }

            return result;
        }
    }
}
