namespace Projetao{
    public class Higrometro : Dispositivo{
        public Higrometro(int id, string nome, bool status, Gateway gateway) : base(id, nome, status, gateway){

        }

        public override void ColetarDados()
        {
            Random perc = new Random();
            double umidade = perc.Next(0,100);
            Dados.Add(new DadosDispositivo(DateTime.Now, umidade));
        }
    }
}