using System;

namespace Projetao{
    class Program{
        static void Main(string[] args){
            Gateway gateway = new Gateway();

            while(true){
                Console.WriteLine("Menu: ");
                Console.WriteLine("1 - Adicionar: ");
                Console.WriteLine("2 - Remover: ");
                Console.WriteLine("3 - Listar: ");
                Console.WriteLine("4 - Sair: ");
                Console.WriteLine("Escolha uma opção válida: ");

                string opt = Console.ReadLine();

                switch(opt){
                    case "1":
                        Console.WriteLine("Digite o nome do dispositivo: ");
                        string nomeDispositivo = Console.ReadLine();
                        Console.WriteLine("O dispositivo está ativo? (true/false)");
                        if (bool.TryParse(Console.ReadLine(), out bool status)){
                            int Iddispositivo = gateway.ObterIdDispositivo();
                            Dispositivo termometro = new Termometro(Iddispositivo, nomeDispositivo, status, gateway);
                            gateway.AddDispositivo(termometro);
                            Console.WriteLine("Dispositivo adicionado.");
                        }
                        else{
                            Console.WriteLine("Entrada invalida para 'status'. ");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Digite o Id a ser removido: ");
                        if(int.TryParse(Console.ReadLine(), out int IdRemover)){
                            gateway.RemDispositivo(IdRemover);
                            Console.WriteLine("Dispositivo removido. ");
                        }
                        else{
                            Console.WriteLine("Entrada invalida para id.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Lista de dispositivos: ");
                        gateway.ListarDispositivo();
                        break;

                    case "4":
                    Console.WriteLine("Tchau.");
                    return;

                    default: 
                    Console.WriteLine("opcao invalida");
                    break;
                }
            }
        }
    }
}