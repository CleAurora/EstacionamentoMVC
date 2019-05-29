using System.Collections.Generic;
using System.IO;
using EstacionamentoMVC.Models;

namespace EstacionamentoMVC.Repositorios
{
    public class ModelosRepositorio
    {
        public List<Models.ModeloModel> Listar(){
            List<ModeloModel> listaDeModelos = new List<ModeloModel>();
            string[] linhas = File.ReadAllLines("Database/ModelosCarro.csv");
            ModeloModel modelo;

            foreach (var item in linhas)
            {
                if(string.IsNullOrEmpty(item))
                {
                    continue;
                }
                string[]linha = item.Split(";");
                modelo =  new ModeloModel(
                    id: int.Parse(linha[0]),
                    nome: linha[1]
                );
                listaDeModelos.Add(modelo);
            }
            return listaDeModelos;
        }// fim listar
    }
}