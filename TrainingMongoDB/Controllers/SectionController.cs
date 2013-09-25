//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

namespace TrainingMongoDB.Controllers {
    using System;
    using System.Web.Mvc;
    using Data.Entities;
    using Data.Services;

    public class SectionController : Controller {
        //
        // GET: /Section/

        public ActionResult Index() {
            var sectionService = new SectionService();
            var sectionDetails = sectionService.GetSectionDetails(100, 0);

            return View(sectionDetails);
        }

        //
        // GET: /Section/Details/5

        public ActionResult Details(string id) {
            var sectionService = new SectionService();
            var section = sectionService.GetById(id);
            return View(section);
        }

        //
        // GET: /Section/Create
        public ActionResult Create() {
            return View(
                new Section()
                {
                    //we can add createdAt and the like here
                }
            );
        }

        //
        // POST: /Section/Create
        // added ValidationInput(false) to allow for the submission of raw html
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Section section) {
            try {
                if (ModelState.IsValid) {
                    var courseService = new SectionService();
                    courseService.Create(section);
                    return RedirectToAction("Index");
                }

                return View();
            } catch {
                return View();
            }
        }

        //
        // GET: /Section/Edit/5
        public ActionResult Edit(string id) {
            var sectionService = new SectionService();
            var section = sectionService.GetById(id);

            return View(section);
        }

        //
        // POST: /Section/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Section section) {
            try {
                if (ModelState.IsValid) {
                    var service = new SectionService();
                    service.Update(section);
                    return RedirectToAction("Index");
                }

                return View();
            } catch {
                return View();
            }
        }

        //
        // GET: /Section/Delete/5

        public ActionResult Delete(string id) {
            var service = new SectionService();
            var section = service.GetById(id);
            return View(section);
        }

        //
        // POST: /Section/Delete/5

        [HttpPost]
        public ActionResult Delete(Section section) {
            try {
                var service = new SectionService();
                service.Delete(section.Id.ToString());

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
