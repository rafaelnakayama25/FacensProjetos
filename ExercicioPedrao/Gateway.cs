using System;
using System.Collections.Generic;
namespace Projetao{
    public class Gateway{
        private List<Dispositivo> dispositivos = new List<Dispositivo>();
        private int proximoId = 1;

        public int ObterIdDispositivo(){
            return proximoId++;
        }

        public void AddDispositivo(Dispositivo dispositivo){
            dispositivos.Add(dispositivo);
        }

        public void RemDispositivo(int id){
            Dispositivo dispositivo = dispositivos.Find(d => d.ID == id);
            if(dispositivo != null)
                dispositivos.Remove(dispositivo);
        }

        public void ListarDispositivo(){
            foreach(var dispositivo in dispositivos){
                Console.WriteLine($"ID: {dispositivo.ID}, Nome: {dispositivo.Nome}, Status: {dispositivo.Status}");
            }
        }
    }
}

