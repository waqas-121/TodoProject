using Microsoft.AspNetCore.Mvc;
using Todolist.Data;
using Todolist.Models;

namespace Todolist.Controllers
{
	public class TodoController : Controller

	{
		private readonly ApplicationDbContext _db;
		public TodoController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{

			List<Todo> list = _db.todos.ToList();
			return View(list);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Todo obj)
		{
			if (ModelState.IsValid)
			{

				_db.todos.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
