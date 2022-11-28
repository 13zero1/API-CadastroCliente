using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Util
{
    public class Authentication
    {
        //criando token para passar ao cliente
        public static string TOKEN = "1301301301301301301301";

        //criando mensagem de erro
        public static string FALHA_AUTENTICAÇAO = "FALHA NA AUTENTICAÇÃO: o token informado é inválido.";
        IHttpContextAccessor contextAccessor;

        public Authentication(IHttpContextAccessor context)
        {
            contextAccessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string TokenRecebido = contextAccessor.HttpContext.Request.Headers["Token"].ToString();
                if (String.Equals(TOKEN, TokenRecebido) == false)
                {
                    throw new Exception(FALHA_AUTENTICAÇAO);
                }    
            }
            catch
            {
                throw new Exception(FALHA_AUTENTICAÇAO); 
            }
        }
    }
}
