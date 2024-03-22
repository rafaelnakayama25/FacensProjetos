using APIRPG.Entities;
using APIRPG.Interfaces;

public class Guerreiro : Personagem, IClasseFisica
{
    public override void UsarHabilidade()
    {
        AtaqueFisico();
    }

    public void AtaqueFisico()
    {
        Console.WriteLine("Guerreiro está atacando fisicamente.");
    }
}