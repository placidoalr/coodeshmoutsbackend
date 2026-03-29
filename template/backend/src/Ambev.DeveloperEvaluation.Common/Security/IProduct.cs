using Ambev.DeveloperEvaluation.Common.ValueObjects;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um produto no sistema.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Nome ou título do produto.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Preço do produto em valor numérico.
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Descrição detalhada do produto.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Categoria à qual o produto pertence.
        /// </summary>
        string Category { get; }

        /// <summary>
        /// URL ou caminho da imagem do produto.
        /// </summary>
        string Image { get; }

        /// <summary>
        /// Avaliação do produto, contendo nota média e quantidade de avaliações.
        /// </summary>
        Rating Rating { get; }
    }
}
