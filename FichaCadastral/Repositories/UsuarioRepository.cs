using MySql.Data.MySqlClient;
using ProgramacaoDoZero.Entities;
using System;

namespace ProgramacaoDoZero.Repositories
{
    public class UsuarioRepository
    {
        private string _conectionString;

        public UsuarioRepository(string conectionString)
        {
            _conectionString = conectionString;
        }

        public int Inserir(Usuario usuario)
        {
            var connection = new MySqlConnection(_conectionString);
            var cmd = new MySqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO usuario (nome, sobrenome, telefone, email, genero, senha, usuarioGuid) VALUES (@nome, @sobrenome, @telefone, @email, @genero, @senha, @usuarioGuid)";

            cmd.Parameters.AddWithValue("nome", usuario.Nome);
            cmd.Parameters.AddWithValue("sobrenome", usuario.Sobrenome);
            cmd.Parameters.AddWithValue("telefone", usuario.Telefone);
            cmd.Parameters.AddWithValue("email", usuario.Email);
            cmd.Parameters.AddWithValue("genero", usuario.Genero);
            cmd.Parameters.AddWithValue("senha", usuario.Senha);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.UsuarioGuid);

            connection.Open();

            var affectedRows = cmd.ExecuteNonQuery();

            connection.Close();

            return affectedRows;
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            Usuario usuario = null;

            MySqlConnection connection = new MySqlConnection(_conectionString);

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM usuario WHERE email = @email";

            cmd.Parameters.AddWithValue("email", email);

            connection.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Nome = reader["nome"].ToString();
                usuario.Sobrenome = reader["sobrenome"].ToString();
                usuario.Telefone = reader["telefone"].ToString();
                usuario.Email = reader["email"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.Senha = reader["senha"].ToString();
                usuario.UsuarioGuid = new Guid(reader["usuarioGuid"].ToString());
            }

            connection.Close();

            return usuario;
        }

        public Usuario ObterPorGuid(Guid usuarioGuid)
        {
            Usuario usuario = null;

            var connection = new MySqlConnection(_conectionString);

            var cmd = new MySqlCommand();

            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM usuario WHERE usuarioGuid = @usuarioGuid";

            cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);

            connection.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Nome = reader["nome"].ToString();
                usuario.Sobrenome = reader["sobrenome"].ToString();
                usuario.Telefone = reader["telefone"].ToString();
                usuario.Email = reader["email"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.Senha = reader["senha"].ToString();
                usuario.UsuarioGuid = new Guid(reader["usuarioGuid"].ToString());                                
            }

            connection.Close();

            return usuario;
        }
    }
}
