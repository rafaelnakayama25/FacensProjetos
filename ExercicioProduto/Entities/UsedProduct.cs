using System.Globalization; // Importa o namespace System.Globalization para lidar com formatação de números e datas específicas de culturas.

namespace ExercicioProduto.Entities // Define um namespace chamado ExercicioProduto.Entities para organizar o código.
{
    class UsedProduct : Product // Define uma classe chamada UsedProduct que herda da classe Product.
    {
        public DateTime ManufactureDate { get; set; } // Declara uma propriedade pública chamada ManufactureDate para armazenar a data de fabricação do produto usado.

        public UsedProduct() // Construtor padrão vazio.
        {
            // Não realiza nenhuma operação no construtor padrão.
        }

        public UsedProduct(string name, double price, DateTime manufactureDate) : base(name, price) // Construtor que recebe nome, preço e data de fabricação como parâmetros.
        {
            ManufactureDate = manufactureDate; // Define o valor da propriedade ManufactureDate com o valor passado como argumento.
        }

        public override string priceTag() // Sobrescreve o método priceTag da classe base Product para incluir informações específicas do produto usado.
        {
            return Name + " (used) $ " + Price.ToString("F2", CultureInfo.InvariantCulture) + " (Manufacture date: " + ManufactureDate + ")"; // Retorna uma string formatada com o nome do produto, indicando que é usado, preço e data de fabricação.
        }
    }
}
