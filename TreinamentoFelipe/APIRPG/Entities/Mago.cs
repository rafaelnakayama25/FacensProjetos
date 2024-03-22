using APIRPG.Entities;
using APIRPG.Interfaces;

namespace APIRPG.Entities
{

    public class Mago : Personagem, IClasseMagica
    {
        public override void UsarHabilidade()
        {
            LancarMagia();
        }

        public void LancarMagia()
        {
            Console.WriteLine("Mago esta lancando magia");
        }
    }
}
