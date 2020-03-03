using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Library.Mail;
using Site01.Models;

namespace Site01.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Contato = new Contato();
            return View();
        }

        public IActionResult ReceberContato([FromForm]Contato contato)
        {

            if (ModelState.IsValid)
            {
                // Entra - Passou na validação
                // String conteudo = string.Format("Nome: {0}, E-mail: {1}, Assunto: {2}, Mensagem: {3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);
                // Return new ContentResult() { Content = conteudo };

                ViewBag.Contato = new Contato(); // Existe uma outra forma, seria até mais correto
                EnviarEmail.EnviarMensagemContato(contato);
                ViewBag.Mensagem = "Mensagem enviada com sucesso";
                return View("Index");
                

            }
            else
            {
                ViewBag.Contato = contato;
                // Não passou
                return View("Index");
            }

            // Como usei [Required] em Contato.cs por conta do using System.ComponentModel.DataAnnotations; não precisei validar
            /* if (contato.Nome.Length <= 0)
             {
                //aqui poderia colocar uma mensagem caso não usasse o using System.ComponentModel.DataAnnotations;

             }
             */
            
        }

        /* Obter dados Manualmente

        public IActionResult ReceberContato()
        {
            //POST - Request.Form
            //Get - Request.QueryString

            Contato contato = new Contato();

            contato.Nome = Request.Form["nome"];
            contato.Email = Request.Form["email"];
            contato.Assunto = Request.Form["assunto"];
            contato.Mensagem = Request.Form["mensagem"];

            string conteudo = string.Format("Nome: {0}, E-mail: {1}, Assunto: {2}, Mensagem: {3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);

            return new ContentResult() { Content = conteudo};
        }

    */
    } 
}