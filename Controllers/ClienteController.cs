using Estacionamento_MVC.Models;
using Estacionamento_MVC.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento_MVC.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form){
            ClienteModel cliente = new ClienteModel(
                nome: form["nome"],
                modelo: form["modelo"],
                marca: form["marca"],
                placa: form["placa"]
            );
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();

            clienteRepositorio.CadastrarCliente(cliente);

            return RedirectToAction("Index", "Cliente");
            
        }// fim cadastrar

        [HttpGet]
        public IActionResult Listar(){
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            ViewData["clientes"] = clienteRepositorio.Listar();

            return View();
        }// fim Listar

        [HttpGet]
        public IActionResult Editar(int id){
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            ClienteModel clienteRecuperado = clienteRepositorio.BuscarPorId(id);
            if(clienteRecuperado != null){
                ViewBag.cliente = clienteRecuperado;
            }else{
                TempData["mensagem"] = "Cliente não encontrado";
                return RedirectToAction("Listar");
            }
            return View();
        }

    }
}