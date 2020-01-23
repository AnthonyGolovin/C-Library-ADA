using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Library.Controllers
{
    public class HomeController : Controller
    {

      private readonly LibraryContext _db;

      public HomeController(LibraryContext db)
      {
        _db = db;
      }
      [HttpGet("/")]
      public ActionResult Index(string Search)
      {
        List<Author> model = _db.Authors.ToList();
        List<Book> modelb = _db.Books.Include(books => books.Author).ToList();
        // var combine = model.Concat(modelb);
      if(Search!=null) {
        model = _db.Authors.Where(author => author.Name.Contains(Search)).ToList();
        modelb = _db.Books.Where(books => books.Description.Contains(Search)).ToList();
      
      }
      var combine = model.AddRange(modelb);
      return View(combine);
      }

    }
}
