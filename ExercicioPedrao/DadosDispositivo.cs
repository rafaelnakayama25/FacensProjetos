using System;

namespace Projetao{
    public class DadosDispositivo{
        public double Valor { get; set; } 
        public DateTime Timestamp {get; set; } //a hora que esta retornando os dados

        public DadosDispositivo(DateTime timestamp, double valor){
            Timestamp = timestamp;
            Valor = valor;
        }
    }
}

