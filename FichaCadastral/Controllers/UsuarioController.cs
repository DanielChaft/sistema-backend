using Microsoft.AspNetCore.Mvc;
using FichaCadastral.Models;
using ProgramacaoDoZero.Services;
using Microsoft.Extensions.Configuration;
using ProgramacaoDoZero.Models;
using System;

namespace FichaCadastral.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "Parânetro(s) inválido(s)";
            }
            else if (request.email == "")
            {
                result.sucesso = false;
                result.mensagem = "O campo E-mail é obrigatório!";
            }
            else if (request.senha == "")
            {
                result.sucesso = false;
                result.mensagem = "O campo Senha é obrigatório!";
            }
            else
            {
                var conectionString = _configuration.GetConnectionString("programacaoDoZeroDB");

                var usuarioService = new UsuarioService(conectionString);
                result = usuarioService.Login(request.email, request.senha);
            }
            
            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.nome) ||
                string.IsNullOrWhiteSpace(request.sobrenome) ||
                string.IsNullOrWhiteSpace(request.telefone) ||
                string.IsNullOrWhiteSpace(request.email) ||
                string.IsNullOrWhiteSpace(request.genero) ||
                string.IsNullOrWhiteSpace(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios!";
            }
            else
            {
                var conectionString = _configuration.GetConnectionString("programacaoDoZeroDB");

                var usuarioService = new UsuarioService(conectionString);

                result = usuarioService.Cadastro(request.nome, request.sobrenome, request.telefone, request.email, request.genero, request.senha);
            }
                        
            return result;
        }

        [Route("esqueceuSenha")]
        [HttpPost]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null || string.IsNullOrEmpty(request.email))
            {
                result.sucesso = false;
                result.mensagem = "O campo E-mail é obrigatório!";
            }
            else
            {
                var conectionString = _configuration.GetConnectionString("programacaoDoZeroDB");

                var usuarioService = new UsuarioService(conectionString);
                result = usuarioService.EsqueceuSenha(request.email);

                result.sucesso = true;
                result.mensagem = "E-mail de recuperação enviado com sucesso!";
            }
            
            return result;
        }

        [Route("obterUsuario")]
        [HttpGet]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Usuário Guid não encontrado.";
            }
            else
            {
                var conectionString = _configuration.GetConnectionString("programacaoDoZeroDB");
                var usuario = new UsuarioService(conectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuário não existe.";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.Nome;
                }
            }

            return result;
        }
    }
}
