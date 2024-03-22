using APIRPG.Entities;
using APIRPG.Interfaces;

namespace Herois
{
    class Program
    {
        static void Main(string[] args)
        {
            // Método principal onde o programa começa
            List<Personagem> personagens = CriarPersonagens(); // Cria uma lista de personagens
            InteragirComPersonagens(personagens); // Interage com os personagens criados
        }

        static List<Personagem> CriarPersonagens()
        {
            // Método para criar personagens
            List<Personagem> personagens = new List<Personagem>(); // Inicializa uma lista vazia para armazenar os personagens
            Console.WriteLine("Criando personagens...");
            while (true) // Loop infinito para permitir que o usuário adicione quantos personagens desejar
            {
                Console.WriteLine("Escolha o tipo de personagem para adicionar à lista:");
                Console.WriteLine("1. Personagem Genérico");
                Console.WriteLine("2. Mago");
                Console.WriteLine("3. Guerreiro");
                Console.WriteLine("4. Estranho");
                Console.WriteLine("5. Encerrar criação de personagens");

                int escolha;
                try
                {
                    escolha = int.Parse(Console.ReadLine()); // Converte a entrada do usuário para um número inteiro
                    if (escolha < 1 || escolha > 5) // Verifica se a escolha está dentro do intervalo permitido
                    {
                        Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
                        continue;
                    }
                }
                catch (FormatException) // Captura uma exceção se a entrada do usuário não puder ser convertida para um número inteiro
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
                    continue;
                }

                if (escolha == 5) // Se a escolha for 5, encerra a criação de personagens
                {
                    break;
                }

                switch (escolha)
                {
                    case 1:
                        personagens.Add(new Personagem()); // Adiciona um personagem genérico à lista
                        break;
                    case 2:
                        personagens.Add(new Mago()); // Adiciona um mago à lista
                        break;
                    case 3:
                        personagens.Add(new Guerreiro()); // Adiciona um guerreiro à lista
                        break;
                    case 4:
                        personagens.Add(new Estranho()); // Adiciona um estranho à lista
                        break;
                }
                Console.WriteLine("Personagem adicionado à lista.");
            }
            return personagens; // Retorna a lista de personagens criada
        }

        static void InteragirComPersonagens(List<Personagem> personagens)
        {
            // Método para interagir com os personagens
            Console.WriteLine("\nInteragindo com os personagens...\n");
            foreach (var personagem in personagens)
            {
                Console.WriteLine($"Escolha a ação para {personagem.GetType().Name}:");
                Console.WriteLine("1. Usar habilidade");
                if (personagem is IClasseFisica)
                {
                    Console.WriteLine("2. Ataque físico");
                }
                if (personagem is IClasseMagica)
                {
                    Console.WriteLine("3. Lançar magia");
                }

                int escolha;
                try
                {
                    escolha = int.Parse(Console.ReadLine()); // Converte a entrada do usuário para um número inteiro
                    if (escolha < 1 || escolha > 3) // Verifica se a escolha está dentro do intervalo permitido
                    {
                        Console.WriteLine("Escolha inválida. Pulando para o próximo personagem.");
                        continue;
                    }
                }
                catch (FormatException) // Captura uma exceção se a entrada do usuário não puder ser convertida para um número inteiro
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
                    continue;
                }

                switch (escolha)
                {
                    case 1:
                        personagem.UsarHabilidade(); // Chama o método para usar a habilidade do personagem
                        break;
                    case 2 when personagem is IClasseFisica:
                        ((IClasseFisica)personagem).AtaqueFisico(); // Chama o método para realizar um ataque físico, se o personagem puder fazer isso
                        break;
                    case 3 when personagem is IClasseMagica:
                        ((IClasseMagica)personagem).LancarMagia(); // Chama o método para lançar uma magia, se o personagem puder fazer isso
                        break;
                    default:
                        Console.WriteLine("Ação não suportada para este personagem.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}