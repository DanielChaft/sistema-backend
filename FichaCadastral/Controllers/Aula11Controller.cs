using FichaCadastral.Models;
using Microsoft.AspNetCore.Mvc;

namespace FichaCadastral.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "Azul";
            meuVeiculo.Marca = "Mitsubishi";
            meuVeiculo.Modelo = "Lancer";
            meuVeiculo.Placa = "EVM3038";

            meuVeiculo.Acelerar();

            return meuVeiculo;
        }

        [Route("obterCarro")]
        [HttpGet]
        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Cor = "Prata";
            meuCarro.Marca = "Honda";
            meuCarro.Modelo = "Civic";
            meuCarro.Placa = "EJN5140";

            meuCarro.Acelerar();

            return meuCarro;
        }

        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Cor = "Preta";
            minhaMoto.Marca = "Honda";
            minhaMoto.Modelo = "Hayabuza";
            minhaMoto.Placa = "EZ453";

            minhaMoto.Acelerar();

            return minhaMoto;
        }
    }
}
