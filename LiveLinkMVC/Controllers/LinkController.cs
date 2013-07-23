using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveLinkMVC.Models;
using LiveLinkMVC.Utility;

namespace LiveLinkMVC.Controllers
{
    public class LinkController : Controller
    {
        LiveLinkRepository repo = new LiveLinkRepository();

        //
        // GET: /Link/

        [Authorize]
        public ActionResult Index()
        {
            string currentuser = User.Identity.Name;
           
            var list = repo.Query(l => l.Owner == currentuser).ToList();
            return View(list);
        }

        //
        // GET: /Link/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
          
           LiveLink livelink = repo.GetById(id);
          
            if (livelink == null)
            {
                return HttpNotFound();
            }
            return View(livelink);
        }

        //
        // GET: /Link/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Link/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(LiveLink livelink)
        {
            if (ModelState.IsValid)
            {
                livelink.Owner = User.Identity.Name;
                
                repo.Add(livelink);
               
                return RedirectToAction("Index");
            }

            return View(livelink);
        }

        //
        // GET: /Link/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            
            LiveLink livelink = repo.GetById(id);
            if (livelink == null)
            {
                return HttpNotFound();
            }
            return View(livelink);
        }

        //
        // POST: /Link/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(LiveLink livelink)
        {
            if (ModelState.IsValid)
            {
               
                repo.Update(livelink);
                //db.Entry(livelink).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livelink);
        }

        //
        // GET: /Link/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            
            LiveLink livelink = repo.GetById(id);
            if (livelink == null)
            {
                return HttpNotFound();
            }
            return View(livelink);
        }

        //
        // POST: /Link/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
           
            repo.DeleteById(id);
            return RedirectToAction("Index");
        }


        //
        // GET: /Link/Resolve/string
        [HttpGet]
        public RedirectResult Resolve(string encryption )
        {
            DateTime currenttime = DateTime.Now;
            string enc = encryption;
            RedirectResult redirect;
            int id = Convert.ToInt32(Crypto.Decrypt(enc));
            LiveLink livelink = repo.GetById(id);
            if ( currenttime > livelink.End  )
            {
                redirect = new RedirectResult(Url.Content("/Link/Expired"));
            }
            else
            {
                redirect = new RedirectResult(livelink.Link);
            }
           
            return redirect;
        }


        //
        // GET: /Link/expired
        [HttpGet]
        public ActionResult Expired()
        {
         

            return View("Expired");
        }



      
    }
}