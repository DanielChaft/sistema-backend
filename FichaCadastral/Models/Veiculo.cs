
namespace FichaCadastral.Models
{
    public class Veiculo
    {
        //Construtores------------------------------
        public Veiculo()
        {
            TanqueCombustivel = 50;
        }
        
        //Atributos ou Propriedades ----------------
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int TanqueCombustivel { get; set; }
        
        //Métodos ---------------------------------
        public virtual void Acelerar()
        {
            InjetarCombustivel(1);
        }
        public void Frear()
        {

        }
        private void InjetarCombustivel (int quantidadeCombustivel)
        {
            TanqueCombustivel = TanqueCombustivel - quantidadeCombustivel;
        }
    }
}
