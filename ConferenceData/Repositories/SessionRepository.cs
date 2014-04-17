using ConferenceData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Repositories
{
    public class SessionRepository
    {
        public Session Get(int sessionId)
        {
            Session session = null;

            using (var db = new ConferenceDbContext())
            {
                session = db.Sessions
                    .Where(s => s.Id == sessionId)
                    .Include(s => s.Format)
                    .Include(s => s.Tracks)
                    .OrderBy(s => s.StartTime)
                    .FirstOrDefault(); 
            }

            return session;
        }

        public IEnumerable<Session> GetAll()
        {
            List<Session> sessions = null;

            using (var db = new ConferenceDbContext())
            {
                sessions = db.Sessions
                    .Include(s => s.Format)
                    .Include(s => s.Tracks)
                    .OrderBy(s => s.StartTime)
                    .ToList(); 
            }

            return sessions;
        }

        public IEnumerable<Session> GetAll(int conferenceId)
        {
            List<Session> sessions = null;

            using (var db = new ConferenceDbContext())
            {
                sessions = db.Sessions
                    .Where(s => s.Conference.Id == conferenceId)
                    .Include(s => s.Format)
                    .Include(s => s.Tracks)
                    .OrderBy(s => s.StartTime)
                    .ToList();
            }      

            return sessions;
        }

        public Session Create(Session session)
        {
            using (var db = new ConferenceDbContext())
            {
                db.Sessions.Add(session);
                db.SaveChanges();
            }

            return session;
        }

        public Session Update(Session session)
        {
            using (var db = new ConferenceDbContext())
            {
                db.Sessions.Attach(session);
                db.Entry(session).State = EntityState.Modified;
                db.SaveChanges();
            }

            return session;
        }

        public int Delete(int sessionId)
        {
            int result = 0;

            using (var db = new ConferenceDbContext())
            {
                var session = db.Sessions.Find(sessionId);

                if (session != null)
                {
                    db.Sessions.Remove(session);
                    result = db.SaveChanges();
                }
            }

            return result;
        }
    }
}
