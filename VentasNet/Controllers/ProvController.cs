using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VentasNet.Controllers
{
    public class ProvController : Controller
    {
        // GET: ProvController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProvController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProvController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvController/Create
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

        // GET: ProvController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProvController/Edit/5
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

        // GET: ProvController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProvController/Delete/5
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
