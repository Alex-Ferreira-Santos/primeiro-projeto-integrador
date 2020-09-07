using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Artes_da_lineh_final.Models
{
    public class DesenhosRepository : Repository
    {
        public void insert(Desenhos d)
        {
            conexao.Open();
            string sql="INSERT INTO desenhos(imagemDesenho, fraseDesenho) values(@imagem,@frase)";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@imagem",d.imagem);
            comando.Parameters.AddWithValue("@frase",d.frase);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<Desenhos> select()
        {
            conexao.Open();
            string sql="SELECT * FROM desenhos";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            MySqlDataReader reader=comando.ExecuteReader();
            List<Desenhos> lista=new List<Desenhos>();
            while (reader.Read())
            {
                Desenhos d=new Desenhos();
                d.id=reader.GetInt32("idDesenho");
                if(!reader.IsDBNull(reader.GetOrdinal("imagemDesenho")))
                    d.imagem=reader.GetString("imagemDesenho");
                if(!reader.IsDBNull(reader.GetOrdinal("fraseDesenho")))
                    d.frase=reader.GetString("fraseDesenho");
                lista.Add(d);
            }
            conexao.Close();
            return lista;
        }
        public List<Desenhos> main()
        {
            conexao.Open();
            string sql="SELECT * FROM desenhos order by idDesenho desc limit 2";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            MySqlDataReader reader=comando.ExecuteReader();
            List<Desenhos> lista=new List<Desenhos>();
            while (reader.Read())
            {
                Desenhos d=new Desenhos();
                d.id=reader.GetInt32("idDesenho");
                if(!reader.IsDBNull(reader.GetOrdinal("imagemDesenho")))
                    d.imagem=reader.GetString("imagemDesenho");
                if(!reader.IsDBNull(reader.GetOrdinal("fraseDesenho")))
                    d.frase=reader.GetString("fraseDesenho");
                lista.Add(d);
            }
            conexao.Close();
            return lista;
        }
        public void update(Desenhos d)
        {
            conexao.Open();
            string sql="UPDATE desenhos SET imagemDesenho=@imagem,fraseDesenho=@frase where idDesenho=@id";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",d.id);
            comando.Parameters.AddWithValue("@imagem",d.imagem);
            comando.Parameters.AddWithValue("@frase",d.frase);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void delete(Desenhos d)
        {
            conexao.Open();
            string sql="DELETE FROM desenhos where idDesenho=@id and imagemDesenho=@imagem";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",d.id);
            comando.Parameters.AddWithValue("@imagem",d.imagem);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}