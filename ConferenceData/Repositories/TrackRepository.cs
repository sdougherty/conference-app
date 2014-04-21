using ConferenceData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Repositories
{
    public class TrackRepository
    {
        public Track Get(int trackId)
        {
            Track track = null;

            using (var db = new ConferenceDbContext())
            {
                track = db.Tracks.Find(trackId);
            }

            return track;
        }

        public IEnumerable<Track> GetAll()
        {
            var tracks = new List<Track>();

            using (var db = new ConferenceDbContext())
            {
                tracks = (from t in db.Tracks
                         orderby t.Name ascending
                         select t).ToList();
            }

            return tracks;
        }

        public IEnumerable<Track> GetAll(int conferenceId)
        {
            List<Track> tracks = null; 

            using (var db = new ConferenceDbContext())
            {
                tracks = db.Tracks
                    .Where(t => t.Conference.Id == conferenceId)
                    .OrderBy(t => t.Name)
                    .ToList();

            }

            return tracks;
        }

        public Track Create(Track track)
        {
            using (var db = new ConferenceDbContext())
            {
                db.Tracks.Add(track);
                db.SaveChanges();
            }

            return track;
        }

        public Track Update(Track track)
        {
            using (var db = new ConferenceDbContext())
            {
                db.Tracks.Attach(track);
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
            }

            return track;
        }

        public int Delete(int id)
        {
            int result = 0;

            using (var db = new ConferenceDbContext())
            {
                var track = db.Tracks.Find(id);

                if (track != null)
                {
                    db.Tracks.Remove(track);
                    result = db.SaveChanges();
                }
            }

            return result;
        }
    }
}
