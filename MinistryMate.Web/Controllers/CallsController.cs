using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinistryMate.Web.Models;
using MinistryMate.Web.Repositories;

namespace MinistryMate.Web.Controllers
{
    public class CallsController : Controller
    {
        private readonly ICallsRepository _callsRepository;

        public CallsController(ICallsRepository callsRepo)
        {
            _callsRepository = callsRepo;
        }

        // GET: Calls
        public async Task<IActionResult> Index()
        {
            string userId = "";
            return View(await _callsRepository.Get(userId));
        }

        // GET: Calls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string userId = string.Empty;
            var call = await _callsRepository.Get(userId, id);
            if (call == null)
            {
                return NotFound();
            }

            return View(call);
        }

        // GET: Calls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AddressLine1,AddressLine2,City,EmailAddress,FirstName,IsActive,LastName,Latitude,Longitude,NextVisitDate,Notes,PhoneNumber,State,ZipCode")] Call call)
        {
            if (ModelState.IsValid)
            {
                await _callsRepository.Add(call);
                return RedirectToAction("Index");
            }
            return View(call);
        }

        // GET: Calls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string userId = string.Empty;
            var call = await _callsRepository.Get(userId, id);
            if (call == null)
            {
                return NotFound();
            }
            return View(call);
        }

        // POST: Calls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AddressLine1,AddressLine2,City,EmailAddress,FirstName,IsActive,LastName,Latitude,Longitude,NextVisitDate,Notes,PhoneNumber,State,ZipCode")] Call call)
        {
            if (id != call.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string userId = string.Empty;
                try
                {
                    await _callsRepository.Update(call);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallExists(userId, call.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(call);
        }

        // GET: Calls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string userId = string.Empty;
            var call = await _callsRepository.Get(userId, id);
            if (call == null)
            {
                return NotFound();
            }

            return View(call);
        }

        // POST: Calls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string userId = string.Empty;
            await _callsRepository.Delete(userId, id);
            return RedirectToAction("Index");
        }

        private bool CallExists(string userId, int callId)
        {
            return _callsRepository.Get(userId, callId) != null;
        }
    }
}
