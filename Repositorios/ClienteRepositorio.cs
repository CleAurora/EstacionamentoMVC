using System;
using System.Collections.Generic;
using System.IO;
using Estacionamento_MVC.Models;

namespace Estacionamento_MVC.Repositorios
{
    public class ClienteRepositorio
    {
        public ClienteModel CadastrarCliente (ClienteModel cliente){
            if(File.Exists("clientes.csv")){
                cliente.Id = File.ReadAllLines("clientes.csv").Length +1;
            }else{
                cliente.Id = 1;
            }

            cliente.DataEntrada = DateTime.Now;

            StreamWriter sw = new StreamWriter("clientes.csv", true);
            sw.WriteLine($"{cliente.Id};{cliente.Nome};{cliente.Marca};{cliente.Modelo};{cliente.Placa};{cliente.DataEntrada}");
            sw.Close();

            return cliente;
        }//fim Cadastrar

        public List<ClienteModel> Listar(){
            List<ClienteModel> listaDeClientes = new List<ClienteModel>();
            string[] linhas = File.ReadAllLines("clientes.csv");
            ClienteModel cliente;

            foreach (var item in linhas)
            {
                if(string.IsNullOrEmpty(item))
                {
                    continue;
                }
                string[]linha = item.Split(";");
                cliente =  new ClienteModel(
                    id: int.Parse(linha[0]),
                    nome: linha[1],
                    marca: linha[2],
                    modelo: linha[3],
                    placa: linha[4],
                    dataEntrada: DateTime.Parse(linha[5])
                );
                listaDeClientes.Add(cliente);
            }
            return listaDeClientes;
        }// fim listar

        public ClienteModel BuscarPorId(int id){
            List<ClienteModel> listaDeClientes = Listar();

            foreach(var item in listaDeClientes)
            {
                if(id == item.Id){
                    return item;
                }
            }
            return null;
        }//fim buscar por id

        public List<ClienteModel> BuscarPorData(DateTime dataEntrada){
            List<ClienteModel> listaDeClientes = Listar();
            List<ClienteModel> listaPorData = new List<ClienteModel>();
            
            foreach(var item in listaDeClientes)
            {
                if(dataEntrada.Equals(item.DataEntrada)){
                    listaPorData.Add(item);
                }
            }
            return listaPorData;
        }//fim buscar por id

       

        public ClienteModel EditarCliente(ClienteModel cliente){
            string[] linhas = File.ReadAllLines("clientes.csv");

            for(int i=0; i<linhas.Length; i++){
                if(string.IsNullOrEmpty(linhas[i])){
                    continue;
                }
                string[] dadosDLinha = linhas[i].Split(";");
                if(cliente.Id.ToString() == dadosDLinha[0]){
                    linhas[i] = $"{cliente.Id};{cliente.Nome};{cliente.Modelo};{cliente.Marca};{cliente.Placa};{cliente.DataEntrada}";
                    break;
                }
            }//fim for
            File.WriteAllLines("clientes.csv", linhas);
            return cliente;
        }//fim editar

          


    }


}