using iStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iStore.Areas.Admin.Controllers
{
    public class ThuongHieuController : Controller
    {
        private readonly iStoreDB db = new iStoreDB();

        public ActionResult Index(string search)
        {
            var thuongHieus = db.ThuongHieux.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                thuongHieus = thuongHieus.Where(th => th.ten_thuonghieu.Contains(search)).ToList();
            }
            return View(thuongHieus);
        }

        public ActionResult Tao()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Thêm xác thực token anti-forgery
        public ActionResult Tao(ThuongHieu thuongHieu)
        {
            if (ModelState.IsValid)
            {
                db.ThuongHieux.Add(thuongHieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thuongHieu);
        }

        public ActionResult Sua(int id)
        {
            ThuongHieu thuongHieu = db.ThuongHieux.FirstOrDefault(th => th.id_thuonghieu == id);
            if (thuongHieu == null)
            {
                return HttpNotFound();
            }
            return View(thuongHieu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Thêm xác thực token anti-forgery
        public ActionResult Sua(ThuongHieu thuongHieu)
        {
            if (ModelState.IsValid)
            {
                ThuongHieu th = db.ThuongHieux.FirstOrDefault(t => t.id_thuonghieu == thuongHieu.id_thuonghieu);
                if (th != null)
                {
                    th.ten_thuonghieu = thuongHieu.ten_thuonghieu;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(thuongHieu);
        }

        public ActionResult Xoa(int id)
        {
            ThuongHieu thuongHieu = db.ThuongHieux.Find(id);
            if (thuongHieu == null)
            {
                return HttpNotFound();
            }
            return View(thuongHieu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Thêm xác thực token anti-forgery
        public ActionResult xacnhanXoa(int id)
        {
            ThuongHieu thuongHieu = db.ThuongHieux.Find(id);
            if (thuongHieu != null)
            {
                db.ThuongHieux.Remove(thuongHieu);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
