using System.Globalization; // Importa o namespace System.Globalization para lidar com formatação de números e datas específicas de culturas.

namespace ExercicioProduto.Entities // Define um namespace chamado ExercicioProduto.Entities para organizar o código.
{
    class ImportedProduct : Product // Define uma classe chamada ImportedProduct que herda da classe Product.
    {
        public double CustomsFee { get; set; } // Declara uma propriedade pública chamada CustomsFee para armazenar a taxa alfandegária do produto.

        public ImportedProduct() // Construtor padrão vazio.
        {
            // Não realiza nenhuma operação no construtor padrão.
        }

        public ImportedProduct(string name, double price, double customsFee) : base(name, price) // Construtor que recebe nome, preço e taxa alfandegária como parâmetros.
        {
            CustomsFee = customsFee; // Define o valor da propriedade CustomsFee com o valor passado como argumento.
        }

        public double TotalPrice() // Método para calcular o preço total do produto importado (preço base + taxa alfandegária).
        {
            return Price + CustomsFee; // Retorna a soma do preço base e da taxa alfandegária.
        }

        public override string priceTag() // Sobrescreve o método priceTag da classe base Product para incluir informações específicas do produto importado.
        {
            return Name + " $ " + TotalPrice().ToString("F2", CultureInfo.InvariantCulture) + " (Customs fee: $ " + CustomsFee.ToString("F2", CultureInfo.InvariantCulture) + ")"; // Retorna uma string formatada com o nome do produto, preço total e taxa alfandegária, utilizando formatação específica da cultura invariante para garantir a consistência da formatação numérica.
        }
    }
}
