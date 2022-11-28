using FirstProject.Entities;
using FirstProject.Entities.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{
    public class SinifController : Controller
    {
        private readonly AppDbContext _db;

        public SinifController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var liste = await _db.Siniflar.ToListAsync(); //Controller da index sayfasına sınıf listesini gönderdik.
            return View(liste);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var liste = new Sinif(); //Sinif listesinden bir instance alıp Gette Viewe gönderdik
            return View(liste);

        }
        [HttpPost]
        public async Task<IActionResult> Create(Sinif sinif)
        {

            await _db.Siniflar.AddAsync(sinif); //gelen sınıf listesini ekledik
            await _db.SaveChangesAsync();       //sql kısmında savechange yaparak execute yapmış olduk
            return RedirectToAction("Index");   //ekleme yapıldıktan sonra index sayfasına yönlendirildi
        }

    }
}
