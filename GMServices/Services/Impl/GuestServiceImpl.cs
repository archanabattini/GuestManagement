using GMDAO.Models;
using GMDAO.Repository;
using GMServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMServices.Services
{
    public class GuestServiceImpl : IGuestService
    {
        IGuestRepository repo;

        public GuestServiceImpl(IGuestRepository repo)
        {
            this.repo = repo;
        }

        Guest IGuestService.Create(Guest guest)
        {

            GuestDTO guestData = repo.CreateNewGuest(toDto(guest));

            return fromDto(guestData);
        }

        List<Guest> IGuestService.Guests()
        {
            List<Guest> guestsVo = new List<Guest>();
            List<GuestDTO> guests = repo.GetAllGuests();

            //Map guests to guestsVo

           foreach(GuestDTO guest in guests)
            {
                guestsVo.Add(fromDto(guest));
            }

            return guestsVo;
        }

        public Guest Get(int guestId)
        {
            return fromDto(repo.GetGuestById(guestId));
        }

        public Guest Edit(Guest guest)
        {
            return fromDto(repo.UpdateGuest(toDto(guest)));
        }

        Guest fromDto(GuestDTO guestDto)
        {
            Guest _guest = new Guest();
            _guest.GuestId = guestDto.GuestId;
            _guest.FirstName = guestDto.FirstName;
            _guest.LastName = guestDto.LastName;
            _guest.Email = guestDto.Email;
            _guest.PhoneNumber = guestDto.PhoneNumber;
            return _guest;
        }

        GuestDTO toDto(Guest guest)
        {
            GuestDTO _guest = new GuestDTO();
            _guest.GuestId = guest.GuestId;
            _guest.FirstName = guest.FirstName;
            _guest.LastName = guest.LastName;
            _guest.Email = guest.Email;
            _guest.PhoneNumber = guest.PhoneNumber;
            return _guest;
        }
    }
}
