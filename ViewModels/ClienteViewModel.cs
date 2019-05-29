using System.Collections.Generic;
using EstacionamentoMVC.Models;

namespace EstacionamentoMVC.ViewModels
{
    public class ClienteViewModel
    {
        public List<MarcaModel> marcas {get; set;}
        public List<ModeloModel> modelos {get;set;}
    }
}