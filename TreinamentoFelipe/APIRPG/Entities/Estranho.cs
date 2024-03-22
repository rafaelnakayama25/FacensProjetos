using APIRPG.Entities;
using APIRPG.Interfaces;

public class Estranho : Personagem, IClasseFisica, IClasseMagica 
{
    public override void UsarHabilidade() //sobrescrevendo o metodo UsarHabilidade
    {
        AtaqueFisico();
        LancarMagia();
    }

    public void AtaqueFisico()
    {
        Console.WriteLine("Estranho está atacando fisicamente.");
    }

    public void LancarMagia()
    {
        Console.WriteLine("Estranho está lançando magia.");
    }
}