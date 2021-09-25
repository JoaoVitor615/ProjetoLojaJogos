using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoLoja.Models;
using ProjetoLoja.Repositorio;

namespace ProjetoLoja.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        Acoes ac = new Acoes();
        //PARTE DO JOGO

        public ActionResult Jogo()
        {
            var jogo = new Jogo();
            return View(jogo);
        }


        [HttpPost]
        public ActionResult CadJogo(Jogo jogo)
        {
            ac.CadastrarJogo(jogo);
            return View(jogo);
        }

        public ActionResult ListarJogo()
        {
            var ExibeJogo = new Acoes();
            var TodosJogos = ExibeJogo.ListarJogo();
            return View(TodosJogos);
        }

        // PARTE DO CLIENTE
        public ActionResult Cliente()
        {
            var cliente = new Cliente();
            return View(cliente);
        }


        [HttpPost]
        public ActionResult CadCli(Cliente cliente)
        {
            ac.CadastrarCliente(cliente);
            return View(cliente);
        }

        public ActionResult ListarCliente()
        {
            var ExibeCli = new Acoes();
            var TodosCli = ExibeCli.ListarCliente();
            return View(TodosCli);
        }

        // PARTE DO FUNCIONÁRIO
        public ActionResult Funcionario()
        {
            var funcio = new Funcionario();
            return View(funcio);
        }


        [HttpPost]
        public ActionResult CadFunc(Funcionario func)
        {
            ac.CadastrarFunc(func);
            return View(func);
        }

        public ActionResult ListarFuncionario()
        {
            var ExibeFunc = new Acoes();
            var TodosFunc = ExibeFunc.ListarFuncionario();
            return View(TodosFunc);
        }
    }
}