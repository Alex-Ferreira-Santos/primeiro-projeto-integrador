using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Artes_da_lineh_final.Models
{
    public class ProdutoRepository : Repository
    {
        public void insert(Produto p)
        {
            conexao.Open();
            string sql="INSERT INTO produtos(imagemProdutos,imagem1Produtos,imagem2Produtos,imagem3Produtos,imagem4Produtos,imagem5Produtos, nomeProdutos, precoProdutos) values(@imagem, @imagem1, @imagem2, @imagem3, @imagem4, @imagem5, @nome, @preco)";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@imagem",p.imagem);
            comando.Parameters.AddWithValue("@imagem1",p.imagem1);
            comando.Parameters.AddWithValue("@imagem2",p.imagem2);
            comando.Parameters.AddWithValue("@imagem3",p.imagem3);
            comando.Parameters.AddWithValue("@imagem4",p.imagem4);
            comando.Parameters.AddWithValue("@imagem5",p.imagem5);
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
        public List<Produto> product(int id)
        {
            conexao.Open();
            string sql=$"SELECT * FROM produtos where idProdutos={id}";
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
                p.imagem1=reader.IsDBNull(reader.GetOrdinal("imagem1Produtos"))? null : reader.GetString("imagem1Produtos");
                p.imagem2=reader.IsDBNull(reader.GetOrdinal("imagem2Produtos"))? null : reader.GetString("imagem2Produtos");
                p.imagem3=reader.IsDBNull(reader.GetOrdinal("imagem3Produtos"))? null : reader.GetString("imagem3Produtos");
                p.imagem4=reader.IsDBNull(reader.GetOrdinal("imagem4Produtos"))? null : reader.GetString("imagem4Produtos");
                p.imagem5=reader.IsDBNull(reader.GetOrdinal("imagem5Produtos"))? null : reader.GetString("imagem5Produtos");
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