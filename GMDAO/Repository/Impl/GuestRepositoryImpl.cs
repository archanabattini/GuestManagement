using GMDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMDAO.Repository
{
    
    public class GuestRepositoryImpl : IGuestRepository
    {
        GuestDbContext db;

        public GuestRepositoryImpl(GuestDbContext db)
        {
            this.db = db;
        }

            public List<GuestDTO> GetAllGuests()
        {
            return db.Guests.ToList();
        }
        public GuestDTO CreateNewGuest(GuestDTO guest)
        {
            GuestDTO g = new GuestDTO();

            g.FirstName = guest.FirstName;
            g.LastName = guest.LastName;
            g.Email = guest.Email;
            g.PhoneNumber = guest.PhoneNumber;

            g = db.Guests.Add(g).Entity;
            db.SaveChanges();
            return g;
        }
        public GuestDTO UpdateGuest(GuestDTO guest)
        {
            GuestDTO g = GetGuestById(guest.GuestId);

            if (g != null)
            {
                g.FirstName = guest.FirstName;
                g.LastName = guest.LastName;
                g.Email = guest.Email;
                g.PhoneNumber = guest.PhoneNumber;
                db.SaveChanges();
            }

            return GetGuestById(guest.GuestId);
        }
        public GuestDTO GetGuestById(int guestId)
        {
            return db.Guests.Where(x => x.GuestId == guestId).FirstOrDefault();
        }
    }
}
