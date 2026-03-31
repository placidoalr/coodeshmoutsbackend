using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.ValueObjects
{

    /// <summary>
    /// Representa um item dentro do carrinho.
    /// </summary>
    public class CartProduct
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Quantidade do produto adicionada ao carrinho.
        /// </summary>
        public int Quantity { get; set; }
    }
}
