using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Artes_da_lineh_final.Models
{
    public class ProdutoRepository : Repository
    {
        public void insert(Produto p)
        {
            conexao.Open();
            string sql="INSERT INTO produtos(imagemProdutos, nomeProdutos, precoProdutos) values(@imagem, @nome, @preco)";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@imagem",p.imagem);
            comando.Parameters.AddWithValue("@nome",p.nome);
            comando.Parameters.AddWithValue("@preco",p.preco);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<Produto> select()
        {
            conexao.Open();
            string sql="SELECT * FROM produtos";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            MySqlDataReader reader=comando.ExecuteReader();
            List<Produto> lista=new List<Produto>();
            while (reader.Read())
            {
                Produto p=new Produto();
                p.id=reader.GetInt32("idProdutos");
                if(!reader.IsDBNull(reader.GetOrdinal("nomeProdutos")))
                    p.nome=reader.GetString("nomeProdutos");
                if(!reader.IsDBNull(reader.GetOrdinal("imagemProdutos")))
                    p.imagem=reader.GetString("imagemProdutos");
                if(!reader.IsDBNull(reader.GetOrdinal("precoProdutos")))
                    p.preco=reader.GetDouble("precoProdutos");
                lista.Add(p);
            }
            conexao.Close();
            return lista;
        }
        public List<Produto> main(){
            conexao.Open();
            string sql="SELECT * FROM produtos order by idProdutos desc limit 2";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            MySqlDataReader reader=comando.ExecuteReader();
            List<Produto> lista=new List<Produto>();
            while (reader.Read())
            {
                Produto p=new Produto();
                p.id=reader.GetInt32("idProdutos");
                if(!reader.IsDBNull(reader.GetOrdinal("nomeProdutos")))
                    p.nome=reader.GetString("nomeProdutos");
                if(!reader.IsDBNull(reader.GetOrdinal("imagemProdutos")))
                    p.imagem=reader.GetString("imagemProdutos");
                if(!reader.IsDBNull(reader.GetOrdinal("precoProdutos")))
                    p.preco=reader.GetDouble("precoProdutos");
                lista.Add(p);
            }
            conexao.Close();
            return lista;
        }
        public void update(Produto p)
        {
            conexao.Open();
            string sql="UPDATE produtos SET imagemProdutos=@imagem,nomeProdutos=@nome,precoProdutos=@preco where idProdutos=@id";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",p.id);
            comando.Parameters.AddWithValue("@imagem",p.imagem);
            comando.Parameters.AddWithValue("@nome",p.nome);
            comando.Parameters.AddWithValue("@preco",p.preco);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void delete(Produto p)
        {
            conexao.Open();
            string sql="DELETE FROM produtos where idProdutos=@id and nomeProdutos=@nome";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",p.id);
            comando.Parameters.AddWithValue("@nome",p.nome);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}