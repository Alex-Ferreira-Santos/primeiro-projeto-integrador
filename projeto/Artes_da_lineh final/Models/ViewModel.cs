using System.Collections.Generic;

namespace Artes_da_lineh_final.Models
{
    public class ViewModel
    {
        public Desenhos desenho { get; set; }
        public List<Desenhos> listaDesenhos { get; set; }
        public DesenhosRepository desenhosRepository { get; set; }
        public Pedido pedido { get; set; }
        public List<Pedido> listaPedido { get; set; }
        public PedidoRepository pedidoRepository { get; set; }
        public Produto produto { get; set; }
        public List<Produto> listaProduto { get; set; }
        public List<Produto> listaProduto1 { get; set; }
        public ProdutoRepository produtoRepository { get; set; }
        public Usuario usuario { get; set; }
        public List<Usuario> listaUsuario { get; set; }
        public UsuarioRepository usuarioRepository { get; set; }
        public Mensagem mensagem { get; set; }
        public string nome { get; set; }
    }
}