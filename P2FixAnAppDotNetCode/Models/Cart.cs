﻿using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        private List<CartLine> _cartLines = new List<CartLine>();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CartLine> Lines => _cartLines;

        private List<CartLine> GetCartLineList()
        {
            return _cartLines;
        }
        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            CartLine cartLine = null;

            // Recherchez si le produit est déjà dans le panier
            foreach (var line in _cartLines)
            {
                if (line.Product.Id == product.Id)
                {
                    cartLine = line;
                    break;
                }
            }

            // Si le produit est déjà dans le panier, augmentez la quantité
            if (cartLine != null)
            {
                cartLine.Quantity += quantity;
            }
            // Sinon, ajoutez un nouvel élément CartLine au panier
            else
            {
                _cartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }


        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            return null;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
