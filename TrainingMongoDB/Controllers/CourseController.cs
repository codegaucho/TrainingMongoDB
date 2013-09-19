//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

namespace TrainingMongoDB.Controllers
{
    using System;
    using System.Web.Mvc;
    using Data.Entities;
    using Data.Services;

    public class CourseController : Controller
    {
        //
        // GET: /Course/

        public ActionResult Index()
        {
            var courseService = new CourseService();
            var courseDetails = courseService.GetCourseDetails(100, 0);

            return View(courseDetails);
        }

        //
        // GET: /Course/Details/5

        public ActionResult Details(string id)
        {
            var courseService = new CourseService();
            var course = courseService.GetById(id);
            return View(course);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            return View(
                new Course() { 
                    //we can add createdAt and the like here
                }
            );
        }

        //
        // POST: /Course/Create
        //added ValidateInput(false) to allow for the submission of raw html

        [HttpPost, ValidateInput(false)]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(Course course)
        {
            try
            {
                if (ModelState.IsValid) {
                    var courseService = new CourseService();
                    courseService.Create(course);
                    return RedirectToAction("Index");
                }

                //return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Course/Edit/5

        public ActionResult Edit(string id)
        {
            var courseService = new CourseService();
            var course = courseService.GetById(id);

            return View(course);
        }

        //
        // POST: /Course/Edit/5
        //added ValidateInput(false) to allow for the submission of raw html

        [HttpPost, ValidateInput(false)]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit(Course course)
        {
            try
            {
                if (ModelState.IsValid) {
                    var courseService = new CourseService();
                    courseService.Update(course);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(string id)
        {
            var courseService = new CourseService();
            var course = courseService.GetById(id);
            return View(course);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost]
        public ActionResult Delete(Course course)
        {
            try
            {
                var courseService = new CourseService();
                courseService.Delete(course.Id.ToString());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
