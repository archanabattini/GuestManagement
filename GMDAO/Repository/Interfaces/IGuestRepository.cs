using GMDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMDAO.Repository
{
    public interface IGuestRepository
    {
        List<GuestDTO> GetAllGuests();
        GuestDTO CreateNewGuest(GuestDTO guest);
        GuestDTO UpdateGuest(GuestDTO guest);
        GuestDTO GetGuestById(int guestId);
    }
}
