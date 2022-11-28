using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Util;
using System.Data;
using WebAPI.Models;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        Authentication AuthenticationService;
        
        public ClientController(IHttpContextAccessor context)
        {
            AuthenticationService = new Authentication(context);
        }
        
        // LISTAR TODOS OS CLIENTES
        [HttpGet]
        [Route("clientlist")]
        public List<ClientModel> ClientList()
        {
            //chamando a lista de clientes
            return new ClientModel().ClientList();
        }

        // MOSTRAR CLIENTE
        [HttpGet]
        [Route("client/{id}")]
        public ClientModel RetornarCliente(int id)
        {
            return new ClientModel().RetornarCliente(id);
        }

        // ADICIONAR CLIENTE
        [HttpPost]
        [Route("clientregister")]
        public ReturnAllServices ClientRegister([FromBody] ClientModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.ClientRegister();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar registrar cliente: " + ex.Message;
            }
            return retorno;
        }
        
        // ATUALIZAR CLIENTE
        [HttpPut]
        [Route("clientrefresh/{id}")]
        public ReturnAllServices Refresh(int id, [FromBody] ClientModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.Id = id;
                dados.ClientRefresh();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar atualizar cliente: " + ex.Message;
            }
            return retorno;
        }
        
        // DELETAR CLIENTE
        [HttpDelete]
        [Route("clientdelete/{id}")]
        public ReturnAllServices Delete(int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                retorno.Result = true;
                retorno.ErrorMessage = "Cliente excluído com sucesso!";
                AuthenticationService.Autenticar();
                new ClientModel().DeletarCliente(id);
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = ex.Message;
            }
            return retorno;
        }
    }
}