using Ambev.DeveloperEvaluation.Common.ValueObjects;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um carrinho de compras no sistema.
    /// </summary>
    public interface ICart
    {
        /// <summary>
        /// Identificador único do carrinho ou gráfico.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Identificador único do usuário associado.
        /// </summary>
        int UserId { get; }

        /// <summary>
        /// Data de criação ou atualização do carrinho.
        /// </summary>
        string Date { get; }

        /// <summary>
        /// Lista de produtos associados ao carrinho.
        /// </summary>
        IEnumerable<CartProduct> Products { get; }
    }
}
