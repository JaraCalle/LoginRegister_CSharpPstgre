using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LoginRegisterPostresql
{
    internal class LoginRegisterPstgre
    {
        NpgsqlConnection _connection = new NpgsqlConnection("Server = localhost; User Id= postgres; Password = db204112; Database = prueba");

        public void Login(string usuario, string clave)
        {
            _connection.Close();
            string query = "Select * from login.usuario where usuario = '" + usuario + "' and clave = '" + clave + "'";
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            _connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                MessageBox.Show("Acceso autorizado");
            }
            else
            {
                MessageBox.Show("Acceso denegado");
            }
            
            _connection.Close();
        }

        public void Register(string usuario, string clave)
        {
            _connection.Close();
            string query = "Select usuario from login.usuario where usuario = '" + usuario + "'";
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            _connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Ya se encuentra registrado");
            }
            else
            {
                _connection.Close();

                string queryInsert = "Insert into login.usuario(usuario, clave) values('" + usuario + "', '" + clave + "')";
                NpgsqlCommand commandInsert = new NpgsqlCommand(queryInsert, _connection);

                _connection.Open();
                commandInsert.ExecuteNonQuery();
                _connection.Close();

                MessageBox.Show("Se ha registrado correctamente");
            }

            
        }
    }
}
