using System; // Importa o namespace System para acessar tipos fundamentais e funcionalidades básicas.
using System.Globalization; // Importa o namespace System.Globalization para lidar com formatação de números e datas específicas de culturas.
using System.Collections.Generic; // Importa o namespace System.Collections.Generic para usar coleções genéricas, como List.
using ExercicioProduto.Entities; // Importa o namespace ExercicioProduto.Entities para utilizar as classes definidas no mesmo namespace.

namespace ExercicioProduto // Define um namespace chamado ExercicioProduto.
{
    class Program // Define uma classe chamada Program.
    {
        static void Main(string[] args) // Método de entrada do programa.
        {
            List<Product> list = new List<Product>(); // Declara e inicializa uma lista de produtos.

            Console.Write("Enter the number of products: "); // Solicita ao usuário que insira o número de produtos.
            int n = int.Parse(Console.ReadLine()); // Lê o número de produtos inserido pelo usuário e converte para inteiro.

            for (int i = 1; i <= n; i++) // Loop para inserir informações sobre cada produto.
            {
                Console.WriteLine($"Product #{i} data:"); // Indica o número do produto que está sendo inserido.
                Console.Write("Common, used or imported (c/u/i)? "); // Pergunta ao usuário se o produto é comum, usado ou importado.
                char ch = char.Parse(Console.ReadLine()); // Lê a resposta do usuário e converte para um caractere.

                Console.Write("Name: "); // Pede ao usuário o nome do produto.
                string name = Console.ReadLine(); // Lê o nome do produto inserido pelo usuário.

                Console.Write("Price: "); // Pede ao usuário o preço do produto.
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); // Lê o preço do produto inserido pelo usuário e converte para um double, usando formatação de cultura invariante.

                if (ch == 'c') // Se o produto for comum.
                {
                    list.Add(new Product(name, price)); // Adiciona um novo objeto da classe Product à lista, com os valores informados.
                }
                else if (ch == 'u') // Se o produto for usado.
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): "); // Pede ao usuário a data de fabricação do produto.
                    DateTime date = DateTime.Parse(Console.ReadLine()); // Lê a data de fabricação inserida pelo usuário e converte para um objeto DateTime.
                    list.Add(new UsedProduct(name, price, date)); // Adiciona um novo objeto da classe UsedProduct à lista, com os valores informados.
                }
                else // Se o produto for importado.
                {
                    Console.Write("Customs fee: "); // Pede ao usuário a taxa alfandegária do produto.
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); // Lê a taxa alfandegária inserida pelo usuário e converte para um double, usando formatação de cultura invariante.
                    list.Add(new ImportedProduct(name, price, customsFee)); // Adiciona um novo objeto da classe ImportedProduct à lista, com os valores informados.
                }
            }

            Console.WriteLine(); // Imprime uma linha em branco para melhorar a legibilidade na saída.
            Console.WriteLine("PRICE TAGS:"); // Indica que serão exibidas as etiquetas de preço.
            foreach (Product prod in list) // Loop para percorrer cada produto na lista.
            {
                Console.WriteLine(prod.priceTag()); // Imprime a etiqueta de preço do produto.
            }
        }
    }
}
