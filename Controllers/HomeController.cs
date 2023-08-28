using Microsoft.AspNetCore.Mvc;
using RegisterWebSite.Models;
using System.Diagnostics;

namespace RegisterWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsContext _newsContext;
       public HomeController(NewsContext context) { 
            this._newsContext = context;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        [HttpGet]
        public IActionResult Index()
        {
            var resul=_newsContext.Categories.ToList();
            return View(resul);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveContact(ContactUs conus)
        {
            _newsContext.ContactUss.Add(conus);
            _newsContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult updatecont(int Id)
        {
            var co=_newsContext.ContactUss.Find(Id);
            if (co is null)
            {
                return View("Error");
            }
            return View( co);
        }

        public IActionResult saveupdate(int Id, ContactUs us)
        {
            if (us == null)
            {
                return Content("not found");
            }
            else
            {



                if (ModelState.IsValid)
                {

                    var ed = _newsContext.ContactUss.FirstOrDefault(x => x.Id == Id);
                    if (ed != null)
                    {
                        ed.Name = us.Name;
                        ed.Message = us.Message;
                        ed.Email = us.Email;
                        ed.Subject = us.Subject;
                        //  _newsContext.Update(us);
                        _newsContext.SaveChanges();
                        return RedirectToAction("Messages");
                    }
                    else
                    {
                        return Content("null");
                    }

                }
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult deletcontact(int Id)
        {
            var delcon=_newsContext.ContactUss.FirstOrDefault(x=>x.Id == Id);
            return View(delcon);
        }
        public IActionResult savedeletecontact(int Id)
        {
            var contdel = _newsContext.ContactUss.Find(Id);
            _newsContext.ContactUss.Remove(contdel);
            _newsContext.SaveChanges();
            return RedirectToAction("Messages");
        }
        public IActionResult Messages()
        {
            var mes=_newsContext.ContactUss.ToList();
            return View(mes);
        }
        public IActionResult News(int Id)
        {
            var nam=_newsContext.Categories.Find(Id);
            ViewData["Name"] = nam.Name;
          // ViewBag.cc=nam.Name;

          var result=_newsContext.news.Where(x=>x.CategoryId==Id).ToList();
            return View(result);
        }
        public IActionResult deleteNew( int Id)
        {
            var del= _newsContext.news.Find(Id);
            _newsContext.news.Remove(del);
            _newsContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult insmember()
        {
            return View();
        }
        public IActionResult saveinsmember()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}