using System;

namespace Artes_da_lineh_final.Models
{
    public class Pedido
    {
        public int id{get;set;}
        public string nome{get;set;}
        public string estado{get;set;}
        public string endereco{get;set;}
        public string telefone{get;set;}
        public DateTime dataPedido{get;set;}
        public string pedido{get;set;}
        public string usuario{get;set;}
    }
}