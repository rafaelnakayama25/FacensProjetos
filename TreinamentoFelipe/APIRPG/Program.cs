using APIRPG.Entities;
using APIRPG.Interfaces;

namespace Herois
{
    class Program
    {
        static void Main(string[] args)
        {
            // M�todo principal onde o programa come�a
            List<Personagem> personagens = CriarPersonagens(); // Cria uma lista de personagens
            InteragirComPersonagens(personagens); // Interage com os personagens criados
        }

        static List<Personagem> CriarPersonagens()
        {
            // M�todo para criar personagens
            List<Personagem> personagens = new List<Personagem>(); // Inicializa uma lista vazia para armazenar os personagens
            Console.WriteLine("Criando personagens...");
            while (true) // Loop infinito para permitir que o usu�rio adicione quantos personagens desejar
            {
                Console.WriteLine("Escolha o tipo de personagem para adicionar � lista:");
                Console.WriteLine("1. Personagem Gen�rico");
                Console.WriteLine("2. Mago");
                Console.WriteLine("3. Guerreiro");
                Console.WriteLine("4. Estranho");
                Console.WriteLine("5. Encerrar cria��o de personagens");

                int escolha;
                try
                {
                    escolha = int.Parse(Console.ReadLine()); // Converte a entrada do usu�rio para um n�mero inteiro
                    if (escolha < 1 || escolha > 5) // Verifica se a escolha est� dentro do intervalo permitido
                    {
                        Console.WriteLine("Escolha inv�lida. Por favor, tente novamente.");
                        continue;
                    }
                }
                catch (FormatException) // Captura uma exce��o se a entrada do usu�rio n�o puder ser convertida para um n�mero inteiro
                {
                    Console.WriteLine("Entrada inv�lida. Por favor, insira um n�mero v�lido.");
                    continue;
                }

                if (escolha == 5) // Se a escolha for 5, encerra a cria��o de personagens
                {
                    break;
                }

                switch (escolha)
                {
                    case 1:
                        personagens.Add(new Personagem()); // Adiciona um personagem gen�rico � lista
                        break;
                    case 2:
                        personagens.Add(new Mago()); // Adiciona um mago � lista
                        break;
                    case 3:
                        personagens.Add(new Guerreiro()); // Adiciona um guerreiro � lista
                        break;
                    case 4:
                        personagens.Add(new Estranho()); // Adiciona um estranho � lista
                        break;
                }
                Console.WriteLine("Personagem adicionado � lista.");
            }
            return personagens; // Retorna a lista de personagens criada
        }

        static void InteragirComPersonagens(List<Personagem> personagens)
        {
            // M�todo para interagir com os personagens
            Console.WriteLine("\nInteragindo com os personagens...\n");
            foreach (var personagem in personagens)
            {
                Console.WriteLine($"Escolha a a��o para {personagem.GetType().Name}:");
                Console.WriteLine("1. Usar habilidade");
                if (personagem is IClasseFisica)
                {
                    Console.WriteLine("2. Ataque f�sico");
                }
                if (personagem is IClasseMagica)
                {
                    Console.WriteLine("3. Lan�ar magia");
                }

                int escolha;
                try
                {
                    escolha = int.Parse(Console.ReadLine()); // Converte a entrada do usu�rio para um n�mero inteiro
                    if (escolha < 1 || escolha > 3) // Verifica se a escolha est� dentro do intervalo permitido
                    {
                        Console.WriteLine("Escolha inv�lida. Pulando para o pr�ximo personagem.");
                        continue;
                    }
                }
                catch (FormatException) // Captura uma exce��o se a entrada do usu�rio n�o puder ser convertida para um n�mero inteiro
                {
                    Console.WriteLine("Entrada inv�lida. Por favor, insira um n�mero v�lido.");
                    continue;
                }

                switch (escolha)
                {
                    case 1:
                        personagem.UsarHabilidade(); // Chama o m�todo para usar a habilidade do personagem
                        break;
                    case 2 when personagem is IClasseFisica:
                        ((IClasseFisica)personagem).AtaqueFisico(); // Chama o m�todo para realizar um ataque f�sico, se o personagem puder fazer isso
                        break;
                    case 3 when personagem is IClasseMagica:
                        ((IClasseMagica)personagem).LancarMagia(); // Chama o m�todo para lan�ar uma magia, se o personagem puder fazer isso
                        break;
                    default:
                        Console.WriteLine("A��o n�o suportada para este personagem.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}