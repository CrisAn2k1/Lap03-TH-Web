using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab03_DuongQuocAn.Models;
using PagedList;

namespace Lab03_DuongQuocAn.Controllers
{
    public class RubikController : Controller
    {
        // GET: Rubik
        public ActionResult Index(int? page, string searchString)
        {
            ViewBag.Keyword = searchString;
            if (page == null)
                page = 1;
            int pageSize = 3;
            return View(Rubik.getAll(searchString).ToPagedList(page.Value, pageSize));
        }

        // GET: Rubik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Rubik find = Rubik.FindRubikByID(id.Value);
            if (find == null)
                return HttpNotFound();
            return View(find);
        }

        // GET: Rubik/Create
        public ActionResult Create()
        {
            List<Loai> maloai = Loai.getAll();
            List<SelectListItem> item = new List<SelectListItem>();
            foreach (var i in maloai)
            {
                item.Add(new SelectListItem
                {
                    Text = i.tenloai,
                    Value = i.maloai.ToString()
                });

            }
            ViewBag.maloai = item;
            return View(new Rubik());
        }

        // POST: Rubik/Create
        [HttpPost]
        public ActionResult Create(Rubik newrubik)
        {
            if (ModelState.IsValid)
            {
                newrubik.insert();
                return RedirectToAction("Index");
            }
            else
                return View("Create", newrubik);
        }

        // GET: Rubik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Rubik find = Rubik.FindRubikByID(id.Value);
            if (find == null)
                return HttpNotFound();
            List<Loai> maloai = Loai.getAll();
            List<SelectListItem> item = new List<SelectListItem>();
            foreach (var i in maloai)
            {
                item.Add(new SelectListItem
                {
                    Text = i.tenloai,
                    Value = i.maloai.ToString()
                });

            }
            ViewBag.maloai = item;
            return View(find);
        }

        // POST: Rubik/Edit/5
        [HttpPost]
        public ActionResult Edit(Rubik rubikEdit)
        {
            if (ModelState.IsValid)
            {
                rubikEdit.Update();
                return RedirectToAction("Index");
            }
            else
                return View("Index", rubikEdit);
        }

        // GET: Rubik/Delete/5
        public ActionResult Delete(int? id)
        {
            RubikModel context = new RubikModel();
            var delete = context.Rubik.FirstOrDefault(p => p.id == id);
            return View(delete);
        }

        // POST: Rubik/Delete/5
        [HttpPost]
        public ActionResult Delete(Rubik rubikDel)
        {
            try
            {
                RubikModel context = new RubikModel();
                var delete = context.Rubik.FirstOrDefault(p => p.id == rubikDel.id);
                context.Rubik.Remove(delete);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }



        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}
