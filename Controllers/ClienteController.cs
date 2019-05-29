using System;
using Estacionamento_MVC.Models;
using Estacionamento_MVC.Repositorios;
using EstacionamentoMVC.Repositorios;
using EstacionamentoMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento_MVC.Controllers
{
    public class ClienteController : Controller
{
    private MarcasRepositorio marcaRepositorio = new MarcasRepositorio();
    private ModelosRepositorio modeloRepositorio = new ModelosRepositorio();
        [HttpGet]
        public IActionResult Index(){
            var marcasRecuperadas = marcaRepositorio.Listar();
            var modelosRecuperados = modeloRepositorio.Listar();

            ClienteViewModel cliente = new ClienteViewModel();

            cliente.marcas = marcasRecuperadas;
            cliente.modelos = modelosRecuperados;

            return View(cliente);
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


        public IActionResult BuscarporData(DateTime data){
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            
            ViewData["clientes"] = clienteRepositorio.BuscarPorData(data);

            return View();
           
        }
    }
}