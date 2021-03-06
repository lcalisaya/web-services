using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Mvc;
using WebServices.Domain;

namespace WebServices.WebClient.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44376/");

            var request = clientHttp.GetAsync("api/player").Result;

            if (request.IsSuccessStatusCode) 
            {
                var dataInRequest = request.Content.ReadAsStringAsync().Result;
                var playersList = JsonConvert.DeserializeObject<List<Player>>(dataInRequest);
                return View(playersList);
            }

            return View(new List<Player>());
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44376/");

            var request = clientHttp.GetAsync($"api/player/{id}").Result;

            if (request.IsSuccessStatusCode)
            {
                var dataInRequest = request.Content.ReadAsStringAsync().Result;
                var selectedPlayer = JsonConvert.DeserializeObject<Player>(dataInRequest);
                return View(selectedPlayer);
            }

            return View(new Player());
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View(new Player());
        }

        // POST: Player/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //Insert logic here
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri("https://localhost:44376/");

                Player myNewPlayer = new Player()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    BirthDate = DateTime.Parse(collection["BirthDate"]),
                    Nationality = collection["Nationality"],
                    ActualClub = collection["ActualClub"],
                    Genre = collection["Genre"]
                };

                var request = clientHttp.PostAsync("api/player", myNewPlayer, new JsonMediaTypeFormatter()).Result;

                if (request.IsSuccessStatusCode)
                {
                    var dataInRequest = request.Content.ReadAsStringAsync().Result;
                    var isPlayerCreated = JsonConvert.DeserializeObject<bool>(dataInRequest);
                    if (isPlayerCreated)
                    {
                        TempData["UserMessage"] = "New Player recorded successfully!";
                        return RedirectToAction("Index");
                    }
                }
                return View(myNewPlayer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44376/");

            var request = clientHttp.GetAsync($"api/player/{id}").Result;

            if (request.IsSuccessStatusCode)
            {
                var dataInRequest = request.Content.ReadAsStringAsync().Result;
                var selectedPlayer = JsonConvert.DeserializeObject<Player>(dataInRequest);
                return View(selectedPlayer);
            }
            return View(new Player());
        }

        // POST: Player/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //Update logic here
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri("https://localhost:44376/");

                Player updatedPlayer = new Player()
                {
                    Id = Int32.Parse(collection["Id"]),
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    BirthDate = DateTime.Parse(collection["BirthDate"]),
                    Nationality = collection["Nationality"],
                    ActualClub = collection["ActualClub"],
                    Genre = collection["Genre"]
                };

                var request = clientHttp.PutAsync($"api/player/{id}", updatedPlayer, new JsonMediaTypeFormatter()).Result;

                if (request.IsSuccessStatusCode)
                {
                    var dataInRequest = request.Content.ReadAsStringAsync().Result;
                    var isPlayerCreated = JsonConvert.DeserializeObject<bool>(dataInRequest);
                    if (isPlayerCreated)
                    {
                        TempData["UserMessage"] = "Player updated successfully!";
                        return RedirectToAction("Index");
                    }
                }
                return View(updatedPlayer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Player/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Player/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                //delete logic here
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri("https://localhost:44376/");

                var request = clientHttp.DeleteAsync($"api/player/{id}").Result;

                if (request.IsSuccessStatusCode)
                {
                    if (request.Content.ReadAsStringAsync().Result == "true")
                    {
                        TempData["UserMessage"] = "Player updated successfully!";
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
