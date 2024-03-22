namespace APIRPG.Entities
{
    public class Personagem
    {
        public int PersonagemId { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }

        public virtual void UsarHabilidade()
        {
            Console.WriteLine("Personagem esta utilizando habilidade generica");
        }
    }
}
