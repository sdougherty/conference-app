using ConferenceData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceData.Repositories
{
    public class UserRepository
    {
        public User Get(int userId)
        {
            User user = null;

            using (var db = new ConferenceDbContext())
            {
                user = db.Users.Find(userId);
            }

            return user;
        }

        public User Get(string emailAddress)
        {
            User user = null;

            using (var db = new ConferenceDbContext())
            {
                user = db.Users.Where(u => u.EmailAddress == emailAddress).FirstOrDefault();
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();

            using (var db = new ConferenceDbContext())
            {
                users = (from u in db.Users
                         orderby u.LastName ascending
                         select u).ToList();
            }

            return users;
        }

        public User Create(User user)
        {
            if (UserExists(user))
            {
                throw new ArgumentException(String.Format("The specified user: '{0}' already exists in the system.", user.EmailAddress));
            }

            using (var db = new ConferenceDbContext())
            {
                user.CreationTime = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
            }

            return user;
        }

        public User Update(User user)
        {
            using (var db = new ConferenceDbContext())
            {
                db.Users.Attach(user);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

            return user;
        }

        public int Delete(int id)
        {
            int result = 0;

            using (var db = new ConferenceDbContext())
            {
                var user = db.Users.Find(id);

                db.Users.Remove(user);
                result = db.SaveChanges();
            }

            return result;
        }

        private bool UserExists(User user)
        {
            bool result = false;

            using (var db = new ConferenceDbContext())
            {
                result = db.Users.Any(u => u.EmailAddress.ToLower() == user.EmailAddress.ToLower());
            }

            return result;
        }
    }
}
