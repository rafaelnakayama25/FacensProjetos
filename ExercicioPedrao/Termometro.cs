namespace Projetao{
    public class Termometro : Dispositivo{
        public Termometro(int id, string nome, bool status, Gateway gateway) : base(id, nome, status, gateway){

        }

        public override void ColetarDados()
        {
            Random celcius = new Random();
            double temperatura = celcius.Next(0,100);
            Dados.Add(new DadosDispositivo(DateTime.Now, temperatura));
        }
    }
}