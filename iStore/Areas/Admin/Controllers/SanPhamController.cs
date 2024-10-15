using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iStore.Models;

namespace iStore.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly iStoreDB db = new iStoreDB();

        // GET: Admin/SanPham
        public ActionResult Index(string search = "", string SortColumn = "id_sanpham", string IconClass = "fa-solid fa-arrow-up")
        {
            // Khởi tạo danh mục và thương hiệu
            ViewBag.DanhMuc = db.DanhMucs.ToList();
            ViewBag.ThuongHieu = db.ThuongHieux.ToList();

            // Tìm kiếm sản phẩm theo tên
            List<SanPham> sanPhams = db.SanPhams
                .Where(row => row.ten_sanpham.Contains(search))
                .ToList();

            ViewBag.Search = search;

            // Sắp xếp sản phẩm theo cột (id, tên, giá, số lượng)
            ViewBag.SortColumn = SortColumn;
            string iconClassToggle = IconClass == "fa-solid fa-arrow-down" ? "fa-solid fa-arrow-up" : "fa-solid fa-arrow-down";
            ViewBag.IconClassToggle = iconClassToggle;

            switch (SortColumn)
            {
                case "id_sanpham":
                    sanPhams = IconClass == "fa-solid fa-arrow-up" ? sanPhams.OrderBy(row => row.id_sanpham).ToList() : sanPhams.OrderByDescending(row => row.id_sanpham).ToList();
                    break;
                case "ten_sanpham":
                    sanPhams = IconClass == "fa-solid fa-arrow-up" ? sanPhams.OrderBy(row => row.ten_sanpham).ToList() : sanPhams.OrderByDescending(row => row.ten_sanpham).ToList();
                    break;
                case "gia_sanpham":
                    sanPhams = IconClass == "fa-solid fa-arrow-up" ? sanPhams.OrderBy(row => row.gia_sanpham).ToList() : sanPhams.OrderByDescending(row => row.gia_sanpham).ToList();
                    break;
                case "soluong":
                    sanPhams = IconClass == "fa-solid fa-arrow-up" ? sanPhams.OrderBy(row => row.soluong).ToList() : sanPhams.OrderByDescending(row => row.soluong).ToList();
                    break;
            }

            ViewBag.IconClass = iconClassToggle;
            return View(sanPhams);
        }

        // Thêm sản phẩm - GET
        public ActionResult Tao()
        {
            ViewBag.DanhMuc = db.DanhMucs.ToList();
            ViewBag.ThuongHieu = db.ThuongHieux.ToList();

            // Kiểm tra và tạo thư mục nếu không tồn tại
            var path = Server.MapPath("~/Assets/img_sanpham");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return View();
        }

        // Thêm sản phẩm - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tao(SanPham sanpham, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanpham);
                db.SaveChanges();

                if (uploadImage != null && uploadImage.ContentLength > 0)
                {
                    int id = sanpham.id_sanpham;

                    string extension = Path.GetExtension(uploadImage.FileName);
                    string _FileName = "sanpham" + id.ToString() + "_" + extension;
                    string _path = Path.Combine(Server.MapPath("~/Assets/img_sanpham"), _FileName);
                    uploadImage.SaveAs(_path);

                    // Cập nhật đường dẫn ảnh
                    sanpham.url_hinhanh = _FileName;
                    db.Entry(sanpham).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            // Nếu có lỗi, khởi tạo lại danh mục và thương hiệu
            ViewBag.DanhMuc = db.DanhMucs.ToList();
            ViewBag.ThuongHieu = db.ThuongHieux.ToList();
            return View(sanpham);
        }

        // Sửa sản phẩm - GET
        public ActionResult Sua(int id)
        {
            SanPham sanPham = db.SanPhams.FirstOrDefault(row => row.id_sanpham == id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            // Khởi tạo danh mục và thương hiệu
            ViewBag.DanhMuc = db.DanhMucs.ToList();
            ViewBag.ThuongHieu = db.ThuongHieux.ToList();

            return View(sanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sua(SanPham sanpham, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null && uploadImage.ContentLength > 0)
                {
                    // Lưu hình ảnh mới
                    string extension = Path.GetExtension(uploadImage.FileName);
                    string _FileName = "sanpham" + sanpham.id_sanpham.ToString() + "_" + extension;
                    string _path = Path.Combine(Server.MapPath("~/Assets/img_sanpham"), _FileName);
                    uploadImage.SaveAs(_path);

                    // Xóa hình ảnh cũ nếu tồn tại
                    if (!string.IsNullOrEmpty(sanpham.url_hinhanh))
                    {
                        string oldImagePath = Path.Combine(Server.MapPath("~/Assets/img_sanpham"), sanpham.url_hinhanh);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Cập nhật đường dẫn ảnh mới
                    sanpham.url_hinhanh = _FileName;
                }

                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Nếu có lỗi, khởi tạo lại danh mục và thương hiệu
            ViewBag.DanhMuc = db.DanhMucs.ToList();
            ViewBag.ThuongHieu = db.ThuongHieux.ToList();
            return View(sanpham);
        }

        // Xóa sản phẩm
        public ActionResult Xoa(int id)
        {
            SanPham sanPham = db.SanPhams.FirstOrDefault(row => row.id_sanpham == id);
            if (sanPham != null)
            {
                // Xóa hình ảnh liên quan
                if (!string.IsNullOrEmpty(sanPham.url_hinhanh))
                {
                    string oldImagePath = Path.Combine(Server.MapPath("~/Assets/img_sanpham"), sanPham.url_hinhanh);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                db.SanPhams.Remove(sanPham);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Xem chi tiết sản phẩm
        public ActionResult ChiTiet(int id)
        {
            SanPham sanPham = db.SanPhams.FirstOrDefault(row => row.id_sanpham == id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }
    }
}
