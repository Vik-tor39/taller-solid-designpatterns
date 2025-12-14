using Best_Practices.Infraestructure.Factories;
using Best_Practices.Infraestructure.Singletons;
using Best_Practices.Models;
using Best_Practices.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleRepository _repository;
        private readonly IVehicleFactory _factory;

        public HomeController(
            IVehicleRepository repository,
            IVehicleFactory factory,
            ILogger<HomeController> logger)
        {
            _repository = repository;
            _factory = factory;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Vehicles = _repository.GetVehicles()
            };

            string error = Request.Query.ContainsKey("error")
                ? Request.Query["error"].ToString()
                : null;

            ViewBag.ErrorMessage = error;

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(string type)
        {
            try
            {
                var vehicle = _factory.Create(type);
                _repository.AddVehicle(vehicle);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                var vehicle = _repository.Find(id);
                vehicle.StartEngine();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult AddGas(string id)
        {
            try
            {
                var vehicle = _repository.Find(id);
                vehicle.AddGas();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                var vehicle = _repository.Find(id);
                vehicle.StopEngine();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return Redirect($"/?error={ex.Message}");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}

