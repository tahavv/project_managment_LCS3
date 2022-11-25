using project.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace project.Controllers
{
    [Authorize]
    public class tasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.project).Include(t => t.user);
            return View(tasks.ToList());
        }

        // GET: tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // GET: tasks/Create
        public ActionResult Create()
        {
            ViewBag.projectId = new SelectList(db.Projects, "projectId", "name");
            ViewBag.userId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: tasks/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "taskId,name,description,startDate,endDate,workflow,type,projectId,userId")] tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(tasks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectId = new SelectList(db.Projects, "projectId", "name", tasks.projectId);
            ViewBag.userId = new SelectList(db.Users, "Id", "FirstName", tasks.userId);
            return View(tasks);
        }

        // GET: tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectId = new SelectList(db.Projects, "projectId", "name", tasks.projectId);
            ViewBag.userId = new SelectList(db.Users, "Id", "FirstName", tasks.userId);
            return View(tasks);
        }

        // POST: tasks/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "taskId,name,description,startDate,endDate,workflow,type,projectId,userId")] tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectId = new SelectList(db.Projects, "projectId", "name", tasks.projectId);
            ViewBag.userId = new SelectList(db.Users, "Id", "FirstName", tasks.userId);
            return View(tasks);
        }

        // GET: tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tasks tasks = db.Tasks.Find(id);
            db.Tasks.Remove(tasks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
