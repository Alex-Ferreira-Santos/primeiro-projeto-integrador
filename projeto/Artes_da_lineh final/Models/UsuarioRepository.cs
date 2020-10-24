using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
namespace Artes_da_lineh_final.Models
{
    public class UsuarioRepository : Repository
    {
        public void insert(Usuario u)
        {
            conexao.Open();
            string sql="INSERT INTO usuario(nomeUsuario, emailUsuario, senhaUsuario, idadeUsuario, avatarUsuario, tipoUsuario) values(@nome, @email, @senha, @idade, @avatar, @tipo)";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            Criptografia criptografia = new Criptografia(SHA512.Create());
            u.senha = criptografia.CriptografarSenha(u.senha);
            comando.Parameters.AddWithValue("@nome",u.nome);
            comando.Parameters.AddWithValue("@email",u.email);
            comando.Parameters.AddWithValue("@senha",u.senha);
            comando.Parameters.AddWithValue("@idade",u.idade);
            comando.Parameters.AddWithValue("@avatar",u.avatar);
            comando.Parameters.AddWithValue("@tipo",u.tipo);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<Usuario> select()
        {
            conexao.Open();
            string sql="SELECT * FROM usuario";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            MySqlDataReader reader=comando.ExecuteReader();
            List<Usuario> lista=new List<Usuario>();
            while (reader.Read())
            {
                Usuario u=new Usuario();
                u.id=reader.GetInt32("idUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
                    u.nome=reader.GetString("nomeUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("emailUsuario")))
                    u.email=reader.GetString("emailUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("senhaUsuario")))
                    u.senha=reader.GetString("senhaUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("idadeUsuario")))
                    u.idade=reader.GetInt32("idadeUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("tipoUsuario")))
                    u.tipo=reader.GetInt32("tipoUsuario");
                u.avatar=reader.GetString("avatarUsuario");
                lista.Add(u);
            }
            conexao.Close();
            return lista;
        }
        public List<Usuario> foto(int? id)
        {
            conexao.Open();
            string sql=$"SELECT * FROM usuario where idUsuario={id}";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            MySqlDataReader reader=comando.ExecuteReader();
            List<Usuario> lista=new List<Usuario>();
            while (reader.Read())
            {
                Usuario u=new Usuario();
                u.id=reader.GetInt32("idUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
                    u.nome=reader.GetString("nomeUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("emailUsuario")))
                    u.email=reader.GetString("emailUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("senhaUsuario")))
                    u.senha=reader.GetString("senhaUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("idadeUsuario")))
                    u.idade=reader.GetInt32("idadeUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("tipoUsuario")))
                    u.tipo=reader.GetInt32("tipoUsuario");
                u.avatar=reader.GetString("avatarUsuario");
                lista.Add(u);
            }
            conexao.Close();
            return lista;
        }
        public Usuario login(Usuario u)
        {
            conexao.Open();
            string sql="SELECT * FROM usuario where emailUsuario=@email and senhaUsuario=@senha";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            Criptografia criptografia = new Criptografia(SHA512.Create());
            u.senha = criptografia.CriptografarSenha(u.senha);
            comando.Parameters.AddWithValue("@nome",u.nome);
            comando.Parameters.AddWithValue("@email",u.email);
            comando.Parameters.AddWithValue("@senha",u.senha);
            comando.Parameters.AddWithValue("@tipo",u.tipo);
            comando.Parameters.AddWithValue("@avatar",u.avatar);
            MySqlDataReader reader=comando.ExecuteReader();
            Usuario usr=null;
            if(reader.Read())
            {
                usr=new Usuario();
                usr.id=reader.GetInt32("idUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("emailUsuario")))
                    usr.email=reader.GetString("emailUsuario");
                if(!reader.IsDBNull(reader.GetOrdinal("senhaUsuario")))
                    usr.senha=reader.GetString("senhaUsuario");
                usr.tipo=reader.GetInt32("tipoUsuario");
                usr.nome=reader.GetString("nomeUsuario");
                usr.avatar=reader.GetString("avatarUsuario");
            }
            conexao.Close();
            return usr;
        }
        public void updateU(Usuario u,int? id)
        {
            conexao.Open();
            string sql=$"UPDATE usuario SET nomeUsuario=@nome,emailUsuario=@email,avatarUsuario=@avatar,senhaUsuario=@senha,tipoUsuario=@tipo where idUsuario={id}";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            Criptografia criptografia = new Criptografia(SHA512.Create());
            u.senha = criptografia.CriptografarSenha(u.senha);
            comando.Parameters.AddWithValue("@nome",u.nome);
            comando.Parameters.AddWithValue("@email",u.email);
            comando.Parameters.AddWithValue("@avatar",u.avatar);
            comando.Parameters.AddWithValue("@senha",u.senha);
            comando.Parameters.AddWithValue("@tipo",u.tipo);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void updateA(Usuario u)
        {
            conexao.Open();
            string sql="UPDATE usuario SET tipoUsuario=@tipo where nomeUsuario=@nome and idUsuario=@id";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            comando.Parameters.AddWithValue("@id",u.id);
            comando.Parameters.AddWithValue("@nome",u.nome);
            comando.Parameters.AddWithValue("@tipo",u.tipo);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void delete(Usuario u,int? id)
        {
            conexao.Open();
            string sql=$"DELETE FROM usuario where idUsuario={id} and emailUsuario=@email and senhaUsuario=@senha";
            MySqlCommand comando=new MySqlCommand(sql,conexao);
            Criptografia criptografia = new Criptografia(SHA512.Create());
            u.senha = criptografia.CriptografarSenha(u.senha);
            comando.Parameters.AddWithValue("@email",u.email);
            comando.Parameters.AddWithValue("@senha",u.senha);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}