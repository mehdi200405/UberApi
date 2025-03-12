using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UberApi.Controllers
{
    public class VehiculeController : Controller
    {
        // GET: VehiculeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehiculeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehiculeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiculeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehiculeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehiculeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
