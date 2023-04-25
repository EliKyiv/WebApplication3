using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Collections.Generic;


namespace WebApplication3.Controllers
{
    public class FriendController : Controller
    {
        private static List<FriendModel> _friends = new List<FriendModel>()
{
    new FriendModel() { FriendID = 1, FriendName = "John", Place = "New York" },
    new FriendModel() { FriendID = 2, FriendName = "Jane", Place = "Los Angeles" },
    new FriendModel() { FriendID = 3, FriendName = "Mike", Place = "Chicago" }
};

        public IActionResult Index()
        {
            return View(_friends);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FriendID,FriendName,Place")] FriendModel friend)
        {
            if (ModelState.IsValid)
            {
                _friends.Add(friend);
                return RedirectToAction("Index");
            }
            return View(friend);
        }

        public IActionResult Edit(int id)
        {
            FriendModel friend = _friends.FirstOrDefault(f => f.FriendID == id);
            if (friend == null)
            {
                return NotFound();
            }
            return View(friend);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("FriendID,FriendName,Place")] FriendModel friend)
        {
            if (id != friend.FriendID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int index = _friends.FindIndex(f => f.FriendID == id);
                if (index >= 0)
                {
                    _friends[index].FriendName = friend.FriendName;
                    _friends[index].Place = friend.Place;
                    TempData["Message"] = "Friend updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(friend);
        }

        // GET: Friend/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = _friends.FirstOrDefault(m => m.FriendID == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var friend = _friends.FirstOrDefault(m => m.FriendID == id);
            _friends.Remove(friend);
            return RedirectToAction(nameof(Index));
        }
    }
}
