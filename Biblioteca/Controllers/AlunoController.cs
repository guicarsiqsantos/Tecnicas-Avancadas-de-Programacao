using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class AlunoController : Controller
    {
		readonly private ApplicationDBContext _db;

		public AlunoController(ApplicationDBContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<AlunoModel> aluno = _db.Alunos;
			return View(aluno);
		}

		public IActionResult Cadastro(AlunoModel alunos)
		{
			if (ModelState.IsValid) {
				_db.Alunos.Add(alunos);
				_db.SaveChanges();

				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public IActionResult Editar(int? id)
		{
            if (id == null || id == 0)
            {
                return NotFound();
            }

			AlunoModel aluno = _db.Alunos.FirstOrDefault(x => x.Id == id);

			if (aluno == null)
			{
				return NotFound();
			}

            return View(aluno);
		}
		[HttpPost]
		public IActionResult Editar(AlunoModel aluno)
		{
			if (ModelState.IsValid)
			{
				_db.Alunos.Update(aluno);
				_db.SaveChanges();

				return RedirectToAction("Index");
			}
			return View(aluno);
		}
		[HttpGet]
		public IActionResult Excluir(int? id)
		{
			if(id == null || id == 0) 
			{ 
				return NotFound(); 
			}

			AlunoModel aluno = _db.Alunos.FirstOrDefault(x => x.Id == id);

			if(aluno == null)
			{
				return NotFound();
			}
			return View(aluno);
		}
		[HttpPost]
		public IActionResult Excluir(AlunoModel aluno) 
		{
			if(aluno == null)
			{
				return NotFound();
			}
			_db.Alunos.Remove(aluno);
			_db.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
