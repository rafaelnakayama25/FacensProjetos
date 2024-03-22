namespace Projetao{
    public abstract class Dispositivo{
        public int ID { get;}
        public string Nome { get; set; }
        public bool Status { get; set; }
        public List<DadosDispositivo> Dados {get;} = new List<DadosDispositivo>();
        public Gateway Gateway {get;}

        protected Dispositivo(int id, string nome, bool status, Gateway gateway ){
            ID = id;
            Nome = nome;
            Status = status;
            Gateway = gateway;
        }

        public abstract void ColetarDados();

    }
}

