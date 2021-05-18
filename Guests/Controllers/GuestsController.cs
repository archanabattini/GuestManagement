using GMServices.ViewModels;
using GMServices.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Guests.Controllers
{
    public class GuestsController : Controller
    {
        private IGuestService service;

        public GuestsController(IGuestService service)
        {
            this.service = service;
        }


        // GET: GuestController
        public ActionResult Index()
        {
            return View("Guests");
        }

        public JsonResult Get()
        {
            return Json(service.Guests(),JsonConvert.DefaultSettings);
        }
        // GET: GuestsController/Create
        public ActionResult Create()
        {
            return View("Manage");
        }

        // POST: GuestsController/Create
        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelErrors());
                }
                guest = service.Create(guest);
                return Created("Guests", guest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // GET: GuestsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Manage");
        }

        public JsonResult GetGuest(int id)
        {
            return Json(service.Get(id), JsonConvert.DefaultSettings);
        }

        // POST: GuestsController/Edit/5
        [HttpPost]
        public ActionResult Edit(Guest guest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelErrors());
                }
                guest = service.Edit(guest);
                return Ok(guest);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private Dictionary<string, string[]> ModelErrors()
        {
            var errorList = ModelState.ToDictionary(mv => mv.Key, mv => mv.Value.Errors.Select(e => e.ErrorMessage).ToArray());
            return errorList;
        }
    }
}
