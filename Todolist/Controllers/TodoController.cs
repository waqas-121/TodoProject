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
				TempData["success"] = "Task Created Successfully";
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Todo? todoData = _db.todos.Find(id);
			if (todoData == null)
			{
				return NotFound();
			}
			return View(todoData);
		}

		[HttpPost]
		public IActionResult Edit(Todo obj)
		{
			if (ModelState.IsValid)
			{
				_db.todos.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Task Updated Successfully";
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Todo? todoData = _db.todos.Find(id);
			if (todoData == null)
			{
				return NotFound();
			}
			return View(todoData);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Todo? todo = _db.todos.Find(id);
			if (todo == null)
			{
				return NotFound();
			}
			_db.todos.Remove(todo);
			_db.SaveChanges();
			TempData["success"] = "Task Deleted Successfully";
			return RedirectToAction("Index");
		}
	}
}
