using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Site01.Controllers
{
    public class PalavraController : Controller
    {
        //Listar todas as palavras do banco de dados
        public IActionResult Index()
        {
            return View();
        }

        //CRUD - Cadastrar, Consultar, Atualizar e Excluir. Create, Retrieve, Update, Delete - CRUD.
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Palavra palavra)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar()
        {
            return View("Cadastrar");
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm]Palavra palavra)
        {
            return View("Cadastrar");
        }

        //Palavra/Excluir/39
        //{Controller}/{Action}/{Id?}
        [HttpGet]
        public IActionResult Excluir(int Id)
        {
            //TODO - Excluir registro no banco
            return RedirectToAction("Index");
        }
    }
}