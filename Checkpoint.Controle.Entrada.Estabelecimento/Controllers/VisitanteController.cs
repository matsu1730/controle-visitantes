using Checkpoint.Controle.Entrada.Estabelecimento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkpoint.Controle.Entrada.Estabelecimento.Controllers
{
    public class VisitanteController : Controller
    {
        private static List<Visitante> _lista = new List<Visitante>();

        private static int _id = 0;

        // CRUD Remover
        [HttpPost]
        public IActionResult Remover(int visitante)
        {
            var index = _lista.FindIndex(c => c.Codigo == visitante);
            _lista.RemoveAt(index);
            TempData["msg"] = "Visitante removido!";
            return RedirectToAction("Index");
        }

        //CRUD Editar
        [HttpPost]
        public IActionResult Editar(Visitante visitante)
        {
            var index = _lista.FindIndex(c => c.Codigo == visitante.Codigo);
            _lista[index] = visitante;
            TempData["msg"] = "Visitante atualizado";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var visitante = _lista.Find(match => match.Codigo == id);
            return View(visitante);
        }

        public IActionResult Index()
        {
            //Ajustar o Index para exibir todos os visitantes da lista
            //em uma tabela HTML
            //Criar a view e a tabela HTML com os dados
            return View(_lista);
        }

        //CRUD Cadastrar
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Visitante visitante)
        {
            visitante.Codigo = ++_id;
            _lista.Add(visitante);
            TempData["cadastro"] = "Visitante cadastrado";
            return RedirectToAction("Cadastrar");
        }

        //Pesquisar
        [HttpPost]
        public IActionResult Pesquisar(string Nome)
        {
            var visitante = _lista.Find(c => c.Nome == Nome);
            return View(visitante);
        }

        [HttpGet]
        public IActionResult Pesquisar()
        {

            return View();
        }
    }
}
