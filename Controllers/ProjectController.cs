using project.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace project.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProjectController : Controller
    {
        private ApplicationDbContext context;

        public ProjectController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Project
        public ActionResult Index()
        {
            var pros = context.Projects.Include(p => p.tasks);
            List<Models.project> projects = context.Projects.ToList();

            return View("Index", pros);
        }

        public ActionResult Details(int id)
        {
            //Models.project pro = context.Projects.SingleOrDefault(p => p.projectId == id);
            //Models.project pp =
            //    (from a in context.Projects join c in context.Tasks on a.projectId equals c.projectId select a)
            //    .SingleOrDefault();
            Models.project pro = context.Projects.Include(t => t.tasks).SingleOrDefault(p => p.projectId == id);
            return View("Details", pro);
        }

        [HttpPost]
        public ActionResult ProcessCreate(Models.project project)
        {
            Models.project pro = context.Projects.SingleOrDefault(p => p.projectId == project.projectId);
            if (pro != null)
            {
                pro.name = project.name;
                pro.description = project.description;
                pro.endDate = project.endDate;
            }
            else
            {
                context.Projects.Add(project);
            }
            context.SaveChanges();
            return View("Details", project);
        }

        public ActionResult Edit(int id)
        {
            Models.project pro = context.Projects.SingleOrDefault(p => p.projectId == id);
            return View("EditForm", pro);
        }

        public ActionResult Create()
        {
            return View("EditForm", new Models.project());
        }

        public ActionResult Delete(int id)
        {
            Models.project pro = context.Projects.SingleOrDefault(p => p.projectId == id);
            if (pro != null)
            {
                context.Projects.Remove(pro);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}