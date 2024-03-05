using BBShop.Data;
using BBShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BBShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly BbshopContext _db;

        public ShopController(BbshopContext context)
        {
            _db = context;
        }

        public IActionResult Index(int? loai)
        {
            var product = _db.HangHoas.AsQueryable();

            if(loai.HasValue)
            {
                product = product.Where(w => w.MaLoai == loai.Value);
            }

            var result = product.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });

            return View(result);
        }

        public IActionResult Search(string? query)
        {
            var product = _db.HangHoas.AsQueryable();

            if(query != null)
            {
                product = product.Where(p => p.TenHh.Contains(query));
            }

            var result = product.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });

            return View(result);
        }
    }
}
