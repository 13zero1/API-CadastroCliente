using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;  //---> 2
using System.Data.SqlClient;

namespace WebAPI.Util
{
    public class DAL
    {
        // CRIANDO VARIAVEIS DE CONEXÃO
        private static string Server = "localhost"; //servidor
        private static string Database = "dbcliente"; //banco de dados
        private static string User = "root"; //usuario
        private static string Password = ""; //senha do usuario
        private MySqlConnection Connection;

        // o '$' na frente do 'Server =' substitui o '+' na hr da concatenação 
        // usando o 'Sslmode' pra dizer que nao ta usando o 'protocolo ssl'
        // chatset serve para garantir o uso correto da acentuação
        private string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;charset=utf8;";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        // CRIANDO METODOS RESPONSAVEL POR EXECUTAR COMANDOS DO BANCO(Inser, Update, Delete 
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

        // CRIANDO METODOS PRA RETORNAR DADOS DO BANCO (2)
        public DataTable RetornarDataTable(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdaptar = new MySqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdaptar.Fill(Dados);
            return Dados;
        }
    }
}