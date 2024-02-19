using BBShop.Data;
using BBShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BBShop.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly BbshopContext _db;

        public MenuLoaiViewComponent(BbshopContext context)
        {
            _db = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _db.Loais.Select(x => new MenuLoaiVM
            {
                MaLoai = x.MaLoai,
                TenLoai = x.TenLoai,
                SoLuong = x.HangHoas.Count
            });

            return View(data); // mặc định của action view là default.cshtml, nếu muốn đổi tên khác thì View("_tên muốn đổi_",data)
        }
    }
}
