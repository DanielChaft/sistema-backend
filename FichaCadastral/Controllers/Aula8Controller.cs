using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FichaCadastral.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Olá Mundo via API !";
            return mensagem;
        }

        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá Mundo via API " + nome;
            return mensagem;
        }

        [Route("somar")]
        [HttpGet]
        public string Somar(int valor1, int valor2)
        {
            var soma = valor1 + valor2;
            var mensagem = "A soma é igual a: " + soma;
            return mensagem;
        }

        [Route("media")]
        [HttpGet]
        public string Media(int valor1, int valor2)
        {
            var media = (valor1 + valor2) / 2;
            var mensagem = "A média dos números é igual a: " + media;
            return mensagem;
        }

        [Route("terreno")]
        [HttpGet]
        public string Terreno(decimal largura, decimal comprimento, decimal valorM2)
        {
            var area = Math.Round((largura * comprimento), 2);
            var precoM2 = Math.Round((area * valorM2), 2);
            var mensagem = "A área do terreno é de: " + (area) + " m2. E o preço total do terreno é de R$ " + (precoM2);
            return mensagem;
        }

        [Route("troco")]
        [HttpGet]
        public string Troco(decimal precoProd, int qtdProduto, decimal valorPago)
        {
            var valorTotal = precoProd * qtdProduto;
            var troco = valorPago - valorTotal;
            var mensagem = "O valor do troco é de: R$ " + troco.ToString("F2");
            return mensagem;
        }

        [Route("pagamento")]
        [HttpGet]
        public string Pagamento(string nome, decimal valorHora, int horasTrabalhadas)
        {
            var valorPagto = horasTrabalhadas * valorHora;
            var mensagem = "O valor do pagamento de " + nome + " é de R$ " + valorPagto.ToString("F2") + " tendo em vista que o valor pago por hora é de R$ " + valorHora.ToString("F2") + " e a quantidade de horas trabalhadas = " + horasTrabalhadas + " Hs.";
            return mensagem;
        }

        [Route("consumo")]
        [HttpGet]
        public string Consumo(int distancia, int totalAbastecido)
        {
            var consumo = distancia / totalAbastecido;
            var mensagem = "O consumo médio de combustível de seu veículo é de " + consumo + " Km por litro.";
            return mensagem;
        }
    }
}
