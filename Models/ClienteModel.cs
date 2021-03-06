using System;
using EstacionamentoMVC.Models;

namespace Estacionamento_MVC.Models
{
    public class ClienteModel
    {
        public string Nome {get;set;}
        public string Marca {get;set;}
        public string Modelo {get;set;}

        public int Id {get; set;}
        public string Placa {get; set;}
        public DateTime DataEntrada {get;set;}


        public ClienteModel(int id, string nome, string marca, string modelo, string placa, DateTime dataEntrada){
            this.Id = id;
            this.Nome = nome;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Placa = placa;
            this.DataEntrada = dataEntrada;

        }

        public ClienteModel(string nome, string modelo, string marca, string placa){
            this.Nome = nome;
            this.Modelo = modelo;
            this.Marca = marca;
            this.Placa = placa;
           
        }
    }
}