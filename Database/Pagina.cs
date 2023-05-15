using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Pagina
    {
        public string SqlConn()
        {
            return ConfigurationManager.AppSettings["SqlConn"];
        }

        public DataTable Lista()
        {
            using(SqlConnection connection = new SqlConnection(SqlConn()))
            {
                string queryString = "select * from paginas";
                SqlCommand command= new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand= command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar(string nome, string conteudo, DateTime data)
        {
            using(SqlConnection connection = new SqlConnection(SqlConn()))
            {
                string queryString = "INSERT INTO paginas (nome, data, conteudo) VALUES (@nome, @data, @conteudo)";

                SqlCommand command = new SqlCommand(queryString, connection);
                
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@data", data);
                    command.Parameters.AddWithValue("@conteudo", conteudo);    

                    command.Connection.Open();
                    command.ExecuteNonQuery();
            }
        }

        public void Editar(int id, string nome, string conteudo, DateTime data)
        {
            using (SqlConnection connection = new SqlConnection(SqlConn()))
            {
                
                if (id != 0)
                {
                    string queryString = "UPDATE paginas SET nome=@nome, data=@data, conteudo=@conteudo WHERE id=@id";
                    SqlCommand command = new SqlCommand(queryString, connection);

                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@data", data);
                    command.Parameters.AddWithValue("@conteudo", conteudo);
                    command.Parameters.AddWithValue("@id", id);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

               
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using(SqlConnection connection=new SqlConnection(SqlConn()))
            {
                string queryString = "select * from paginas where id =" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand= command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        public bool Excluir(int id)
        {
            bool excluidoComSucesso = false;

            
                using (SqlConnection connection = new SqlConnection(SqlConn()))
                {
                    string queryString = "delete from paginas where id = " + id;

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    int linhasAfetadas = command.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    excluidoComSucesso = true;
                }
                else return false;
                }

            return excluidoComSucesso;
        }

    }
}
