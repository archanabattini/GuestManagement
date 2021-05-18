using GMServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMServices.Services
{
    public interface IGuestService
    {
        Guest Create(Guest guest);
        List<Guest> Guests();

        Guest Get(int guestId);

        Guest Edit(Guest guest);
    }
}
