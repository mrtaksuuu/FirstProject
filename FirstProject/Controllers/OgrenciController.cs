using FirstProject.Entities;
using FirstProject.Entities.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly AppDbContext _db;

        public OgrenciController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var liste = await _db.Ogrenciler.Include(p => p.sinif).ToListAsync(); //Controller da index sayfasına Öğrenci listesini gönderdik. Sınıflarında göstermek için Include methodunu (sql kısmında inner join) kullandık

            return View(liste);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var liste = new Ogrenci(); //öğrenci listesinden bir instance alıp Gette Viewe gönderdik



            //Sınıf Listesini select-options olarak kullanıcıya seçmesi için listesiyi gönderdik..
            var sınıfQuery = await _db.Siniflar.ToListAsync();
            ViewBag.sinif = sınıfQuery.Select(p => new SelectListItem()
            {
                Text = p.SinifAdi,
                Value = p.Id.ToString()
            });
            return View(liste);

        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci ogrenci)
        {

            await _db.Ogrenciler.AddAsync(ogrenci); //gelen öğrenci listesini ekledik
            await _db.SaveChangesAsync();       //sql kısmında savechange yaparak execute yapmış olduk
            return RedirectToAction("Index");   //ekleme yapıldıktan sonra index sayfasına yönlendirildi
        }
        public async Task<IActionResult> Remove(int id)
        {
            var removeogrenci = await _db.Ogrenciler.FindAsync(id);
            _db.Remove(removeogrenci);

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var removeogrenci = await _db.Ogrenciler.FindAsync(id);
            //Sınıf Listesini select - options olarak kullanıcıya seçmesi için listesiyi gönderdik..
            var sınıfQuery = await _db.Siniflar.ToListAsync();
            ViewBag.sinif = sınıfQuery.Select(p => new SelectListItem()
            {
                Text = p.SinifAdi,
                Value = p.Id.ToString()
            });
            return View(removeogrenci);

        }
        [HttpPost]
        public async Task<IActionResult> Update(Ogrenci ogrenci)
        {
            _db.Ogrenciler.Update(ogrenci);

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}
