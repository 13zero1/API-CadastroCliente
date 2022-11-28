using System;
using System.Collections.Generic;
using System.Data;
using WebAPI.Util;

namespace WebAPI.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data_Cadastro { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Data_Nascimento { get; set; }
        public string Tipo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; } 
        public string Cidade { get; set; }
        public string Uf { get; set; }



        public void ClientRegister()
        {
            //CRIANDO ACESSO A CLASSE DE DADOS
            DAL objDAL = new DAL();

            string sql = "insert into cliente(nome, data_cadastro, cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf)" +
                         $"values('{Nome}','{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")}', '{Cpf_Cnpj}', '{DateTime.Parse(Data_Nascimento).ToString("yyyy/MM/dd")}'," +
                         $"'{Tipo}', '{Telefone}', '{Email}', '{Cep}', '{Logradouro}', '{Numero}', '{Bairro}', '{Complemento}', '{Cidade}', '{Uf}')";

            objDAL.ExecutarComandoSQL(sql); 
        }



        //ATUALIZANDO UM CLIENTE
        public void ClientRefresh()
        {
            //CRIANDO ACESSO A CLASSE DE DADOS
            DAL objDAL = new DAL();

            string sql = "update cliente set " +
                         $"nome = '{Nome}'," +
                         $"data_cadastro = '{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")}'," +
                         $"cpf_cnpj = '{Cpf_Cnpj}'," +
                         $"data_nascimento = '{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")}'," +
                         $"tipo = '{Tipo}'," +
                         $"telefone = '{Telefone}'," +
                         $"email = '{Email}'," +
                         $"cep = '{Cep}'," +
                         $"logradouro = '{Logradouro}'," +
                         $"numero = '{Numero}'," +
                         $"bairro = '{Bairro}'," +
                         $"complemento = '{Complemento}'," +
                         $"cidade = '{Cidade}', " +
                         $"uf = '{Uf}' where id = {Id}";

            objDAL.ExecutarComandoSQL(sql);
        }



        //RETORNAR LISTA DE CLIENTE
        public List<ClientModel> ClientList()
        {
            List<ClientModel> list = new List<ClientModel>();
            ClientModel item;

            //CRIANDO ACESSO A CLASSE DE DADOS
            DAL objDAL = new DAL();
            
            //SELECIONAR OS DADOS POR NOME EM ORDEM CRESCENTE
            string sql = "select * from Cliente order by nome asc";
            DataTable dados = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new ClientModel()
                {
                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    Nome = dados.Rows[i]["nome"].ToString(),
                    Data_Cadastro = DateTime.Parse(dados.Rows[i]["data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
                    Cpf_Cnpj = dados.Rows[i]["cpf_cnpj"].ToString(),
                    Data_Nascimento = DateTime.Parse(dados.Rows[i]["data_nascimento"].ToString()).ToString("dd/MM/yyyy"),
                    Tipo = dados.Rows[i]["tipo"].ToString(),
                    Telefone = dados.Rows[i]["telefone"].ToString(),
                    Email = dados.Rows[i]["email"].ToString(),
                    Cep = dados.Rows[i]["cep"].ToString(),
                    Logradouro = dados.Rows[i]["logradouro"].ToString(),
                    Numero = dados.Rows[i]["numero"].ToString(),
                    Bairro = dados.Rows[i]["bairro"].ToString(),
                    Complemento = dados.Rows[i]["complemento"].ToString(),
                    Cidade = dados.Rows[i]["cidade"].ToString(),
                    Uf = dados.Rows[i]["uf"].ToString()
                };
                list.Add(item);
            }
            return list;
        }





        //RETORNAR UM CLIENTE ESPECIFICO
        public ClientModel RetornarCliente(int id)
        {
            ClientModel item;

            //CRIANDO ACESSO A CLASSE DE DADOS
            DAL objDAL = new DAL();

            //APRESENTAR UM CLIENTE ESPECIFICO
            // o '$' na frente do 'Server =' substitui o '+' na hr da concatenação
            string sql = $"select * from Cliente where id = {id}";
            DataTable dados = objDAL.RetornarDataTable(sql);

            item = new ClientModel()
            {
                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                Nome = dados.Rows[0]["nome"].ToString(),
                Data_Cadastro = DateTime.Parse(dados.Rows[0]["data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
                Cpf_Cnpj = dados.Rows[0]["cpf_cnpj"].ToString(),
                Data_Nascimento = DateTime.Parse(dados.Rows[0]["data_nascimento"].ToString()).ToString("dd/MM/yyyy"),
                Tipo = dados.Rows[0]["tipo"].ToString(),
                Telefone = dados.Rows[0]["telefone"].ToString(),
                Email = dados.Rows[0]["email"].ToString(),
                Cep = dados.Rows[0]["cep"].ToString(),
                Logradouro = dados.Rows[0]["logradouro"].ToString(),
                Numero = dados.Rows[0]["numero"].ToString(),
                Bairro = dados.Rows[0]["bairro"].ToString(),
                Complemento = dados.Rows[0]["complemento"].ToString(),
                Cidade = dados.Rows[0]["cidade"].ToString(),
                Uf = dados.Rows[0]["uf"].ToString()
            };
            return item;
        }

        //DELETANDO UM CLIENTE
        public void DeletarCliente(int id)
        {

            //CRIANDO ACESSO A CLASSE DE DADOS
            DAL objDAL = new DAL();

            //SELECIONAR OS DADOS POR ID PARA SER DELETADO
            // o uso do '$' na frente do código substitui o '+' na hr da concatenação
            string sql = $"delete from Cliente where id = {id}";

            objDAL.RetornarDataTable(sql);
        
        }
    }
}