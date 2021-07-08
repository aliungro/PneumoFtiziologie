using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class TherapiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? id)
        {
            var therapies = db.Therapies.Include(a => a.Patient);

            return View(therapies.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var therapies = db.Therapies.Include(sss => sss.Patient).SingleOrDefault(p => p.Id == id);
            var drug = db.Drugs.Find(therapies.DrugId);
            ViewBag.drug = drug.Name;
            ViewBag.drugId = drug.Id;

            return View(therapies);
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                var patient = db.Patients.Find(id);

                ViewBag.patientId = id;
                ViewBag.patient = patient.NameSurName;
                ViewBag.PatientId = id;
            }
            ViewBag.Drugs = db.Drugs.ToList();
            
            return View();
        }


        [Authorize(Roles = "Doctor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateFrom,DateTo,Diagnose,PatientId,DrugId")] Therapy therapy2)
        {
            if (ModelState.IsValid)
            {
                db.Therapies.Add(therapy2);


                string diagnose = Request.Form["Diagnose"];
                int pacient =int.Parse(Request.Form["PatientId"]);
                var patient = db.Patients.Find(pacient);
                var historyofdeseases = patient.HistoryOfDiseases.ToString();
                var added = historyofdeseases + " " + diagnose;
                patient.HistoryOfDiseases = added;

                db.SaveChanges();




                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "Id", "NameSurName", therapy2.PatientId);
            return View(therapy2);
        }


        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Therapy therapy2 = db.Therapies.Find(id);
            if (therapy2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "NameSurName", therapy2.PatientId);
            ViewBag.PatientName = db.Patients.Find(therapy2.PatientId).NameSurName;
            ViewBag.Drugs = db.Drugs.ToList();

            return View(therapy2);
        }
        
        [Authorize(Roles = "Doctor")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateFrom,DateTo,Diagnose,PatientId,DrugId")] Therapy therapy2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(therapy2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new { id = therapy2.PatientId });
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "NameSurName", therapy2.PatientId);
            return View(therapy2);
        }

        // Sterge
        [Authorize(Roles = "Doctor, Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Therapy therapy2 = db.Therapies.Find(id);
            if (therapy2 == null)
            {
                return HttpNotFound();
            }
            return View(therapy2);
        }

        // Sterge
        [Authorize(Roles = "Doctor, Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Therapy therapy2 = db.Therapies.Find(id);
            db.Therapies.Remove(therapy2);
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
