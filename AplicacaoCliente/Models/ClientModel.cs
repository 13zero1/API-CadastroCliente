using AplicacaoCliente.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AplicacaoCliente.Models
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

        public List<ClientModel> AllListClient()
        {
            List<ClientModel> retorno = new List<ClientModel>();
            string json = WebAPI.RequestGET("clientlist", string.Empty);



            // transformando o json em outro formato...
            retorno = JsonConvert.DeserializeObject<List<ClientModel>>(json);
            return retorno;
        }

        public void Inserir()
        {
            string jsonData = JsonConvert.SerializeObject(this);
            string json = WebAPI.RequestPOST("clientregister", jsonData);
        }

    }
}
