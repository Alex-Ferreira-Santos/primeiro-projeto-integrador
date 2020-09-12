using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Artes_da_lineh_final.Models
{
    public class PedidoRepository : Repository
    {
        public void insert(Pedido p)
        {
            conexao.Open();
            string sql="INSERT INTO pedido(nomePedido, estadoPedido, enderecoPedido, telefonePedido, dataPedidoPedido, pedidoPedido, usuarioPedido) values(@nome, @estado, @endereco, @telefone, @datapedido, @pedido, @usuario)";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@nome",p.nome);
            comando.Parameters.AddWithValue("@estado",p.estado);
            comando.Parameters.AddWithValue("@endereco",p.endereco);
            comando.Parameters.AddWithValue("@telefone",p.telefone);
            comando.Parameters.AddWithValue("@datapedido",p.dataPedido);
            comando.Parameters.AddWithValue("@pedido",p.pedido);
            comando.Parameters.AddWithValue("@usuario",p.usuario);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<Pedido> select(Pedido pe)
        {
            conexao.Open();
            string sql="SELECT * FROM pedido";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            MySqlDataReader reader=comando.ExecuteReader();
            List<Pedido> lista=new List<Pedido>();
            while (reader.Read())
            {
                Pedido p=new Pedido();
                p.id=reader.GetInt32("idPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("nomePedido")))
                    p.nome=reader.GetString("nomePedido");
                if(!reader.IsDBNull(reader.GetOrdinal("estadoPedido")))
                    p.estado=reader.GetString("estadoPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("enderecoPedido")))
                    p.endereco=reader.GetString("enderecoPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("telefonePedido")))
                    p.telefone=reader.GetString("telefonePedido");
                if(!reader.IsDBNull(reader.GetOrdinal("dataPedidoPedido")))
                    p.dataPedido=reader.GetDateTime("dataPedidoPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("PedidoPedido")))
                    p.pedido=reader.GetString("PedidoPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("usuarioPedido")))
                    p.usuario=reader.GetString("usuarioPedido");
                lista.Add(p);
            }
            conexao.Close();
            return lista;
        }
        public List<Pedido> selectU(Pedido pe)
        {
            conexao.Open();
            string sql="SELECT * FROM pedido where usuarioPedido=@usuario";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@usuario",pe.usuario);
            MySqlDataReader reader=comando.ExecuteReader();
            List<Pedido> lista=new List<Pedido>();
            while (reader.Read())
            {
                Pedido p=new Pedido();
                p.id=reader.GetInt32("idPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("nomePedido")))
                    p.nome=reader.GetString("nomePedido");
                if(!reader.IsDBNull(reader.GetOrdinal("estadoPedido")))
                    p.estado=reader.GetString("estadoPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("enderecoPedido")))
                    p.endereco=reader.GetString("enderecoPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("telefonePedido")))
                    p.telefone=reader.GetString("telefonePedido");
                if(!reader.IsDBNull(reader.GetOrdinal("dataPedidoPedido")))
                    p.dataPedido=reader.GetDateTime("dataPedidoPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("PedidoPedido")))
                    p.pedido=reader.GetString("PedidoPedido");
                if(!reader.IsDBNull(reader.GetOrdinal("usuarioPedido")))
                    p.usuario=reader.GetString("usuarioPedido");
                lista.Add(p);
            }
            conexao.Close();
            return lista;
        }
        public void update(Pedido p)
        {
            conexao.Open();
            string sql="UPDATE pedido SET nomePedido=@nome,estadoPedido=@estado,enderecoPedido=@endereco,telefonePedido=@telefone,dataPedidoPedido=@datapedido,pedidoPedido=@pedido,usuarioPedido=@usuario where idPedido=@id";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",p.id);
            comando.Parameters.AddWithValue("@nome",p.nome);
            comando.Parameters.AddWithValue("@estado",p.estado);
            comando.Parameters.AddWithValue("@endereco",p.endereco);
            comando.Parameters.AddWithValue("@telefone",p.telefone);
            comando.Parameters.AddWithValue("@datapedido",p.dataPedido);
            comando.Parameters.AddWithValue("@pedido",p.pedido);
            comando.Parameters.AddWithValue("@usuario",p.usuario);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void delete(Pedido p)
        {
            conexao.Open();
            string sql="DELETE FROM pedido where idPedido=@id and pedidoPedido=@pedido";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",p.id);
            comando.Parameters.AddWithValue("@pedido",p.pedido);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}