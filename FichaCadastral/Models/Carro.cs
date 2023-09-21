
namespace FichaCadastral.Models
{
    public class Carro : Veiculo
    {
        public Carro()
        {
            QuantidadeRodas = 4;
        }
        public int QuantidadeRodas { get; set; }

        public override void Acelerar()
        {
            InjetarCombustivel(4);
        }
        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - quantidadeCombustivel;
        }
    }

}
