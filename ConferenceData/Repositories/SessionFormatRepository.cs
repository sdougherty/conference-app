using ConferenceData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Repositories
{
    public class SessionFormatRepository
    {
        public SessionFormat Get(int sessionFormatId)
        {
            SessionFormat format = null;

            using (var db = new ConferenceDbContext())
            {
                format = db.SessionFormats.Find(sessionFormatId);
            }

            return format;
        }

        public IEnumerable<SessionFormat> GetAll()
        {
            var formats = new List<SessionFormat>();

            using (var db = new ConferenceDbContext())
            {
                formats = (from f in db.SessionFormats
                           orderby f.Name ascending
                           select f).ToList();
            }

            return formats;
        }

        public SessionFormat Create(SessionFormat format)
        {
            using (var db = new ConferenceDbContext())
            {
                db.SessionFormats.Add(format);
                db.SaveChanges();
            }

            return format;
        }

        public SessionFormat Update(SessionFormat format)
        {
            using (var db = new ConferenceDbContext())
            {
                db.SessionFormats.Attach(format);
                db.Entry(format).State = EntityState.Modified;
                db.SaveChanges();
            }

            return format;
        }

        public int Delete(int id)
        {
            int result = 0;

            using (var db = new ConferenceDbContext())
            {
                var format = db.SessionFormats.Find(id);

                if (format != null)
                {
                    db.SessionFormats.Remove(format);
                    result = db.SaveChanges();
                }
            }

            return result;
        }
    }
}
