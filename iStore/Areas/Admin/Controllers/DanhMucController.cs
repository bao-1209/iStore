using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iStore.Models;

namespace iStore.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            iStoreDB db = new iStoreDB();
            List<DanhMuc> danhMucs = db.DanhMucs.ToList();
            return View(danhMucs);
        }

        //Thêm danh mục sản phẩm
        public ActionResult taoDanhMuc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult taoDanhMuc(DanhMuc taodanhmuc)
        {
            iStoreDB db = new iStoreDB();
            db.DanhMucs.Add(taodanhmuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult suaDanhMuc(int id)
        {
            iStoreDB db = new iStoreDB();
            DanhMuc danhmuc = db.DanhMucs.Where(row => row.id_danhmuc == id).FirstOrDefault();
            return View(danhmuc);
        }

        [HttpPost]
        public ActionResult suaDanhMuc(DanhMuc suadanhmuc)
        {
            iStoreDB db = new iStoreDB();
            DanhMuc danhmuc = db.DanhMucs.Where(row => row.id_danhmuc == suadanhmuc.id_danhmuc).FirstOrDefault();

            //cap nhat
            danhmuc.ten_danhmuc = suadanhmuc.ten_danhmuc;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}