using iStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iStore.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly iStoreDB db = new iStoreDB();
        // GET: Admin/SanPham
        public ActionResult Index(string search = "", string SortColumn = "id_sanpham", string IconClass = "fa-sort-asc")
        {
            // Tìm kiếm
            List<SanPham> sanPhams = db.SanPhams
                .Where(row => row.ten_sanpham.Contains(search))
                .ToList();
            ViewBag.Search = search;

            // Sắp xếp
            ViewBag.SortColumn = SortColumn;
            string iconClassToggle = IconClass == "fa-sort-desc" ? "fa-sort-asc" : "fa-sort-desc";
            ViewBag.IconClassToggle = iconClassToggle;
            switch (SortColumn)
            {
                case "product_id":
                    sanPhams = IconClass == "fa-sort-asc" ? sanPhams.OrderBy(row => row.id_sanpham).ToList() : sanPhams.OrderByDescending(row => row.id_sanpham).ToList();
                    break;
                case "product_name":
                    sanPhams = IconClass == "fa-sort-asc" ? sanPhams.OrderBy(row => row.id_sanpham).ToList() : sanPhams.OrderByDescending(row => row.ten_sanpham).ToList();
                    break;
            }
            ViewBag.IconClass = iconClassToggle;
            return View(sanPhams);
        }
    }
}