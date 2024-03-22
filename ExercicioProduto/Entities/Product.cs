using System.Globalization; // Importa o namespace System.Globalization para lidar com formatação de números e datas específicas de culturas.

namespace ExercicioProduto.Entities // Define um namespace chamado ExercicioProduto.Entities para organizar o código.
{
    class Product // Define uma classe chamada Product.
    {
        public string Name { get; set; } // Declara uma propriedade pública chamada Name para armazenar o nome do produto.
        public double Price { get; set; } // Declara uma propriedade pública chamada Price para armazenar o preço do produto.

        public Product() // Construtor padrão vazio.
        {
            // Não realiza nenhuma operação no construtor padrão.
        }

        public Product(string name, double price) // Construtor que recebe nome e preço como parâmetros.
        {
            Name = name; // Define o valor da propriedade Name com o valor passado como argumento.
            Price = price; // Define o valor da propriedade Price com o valor passado como argumento.
        }

        public virtual string priceTag() // Método para gerar uma representação em forma de string do produto.
        {
            return Name + " $ " + Price.ToString("F2", CultureInfo.InvariantCulture); // Retorna uma string formatada com o nome do produto e seu preço, utilizando formatação específica da cultura invariante para garantir a consistência da formatação numérica.
        }
    }
}
