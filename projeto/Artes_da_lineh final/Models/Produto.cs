using System.Collections.Generic;

namespace Artes_da_lineh_final.Models
{
    public class Produto
    {
        public int id{get;set;}
        public string imagem{get;set;}
        public List<string> imagens{get;set;}
        public string nome{get;set;}
        public double preco{get;set;}
    }
}