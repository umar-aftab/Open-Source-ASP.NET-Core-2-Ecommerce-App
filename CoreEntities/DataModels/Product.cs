using System;
using System.Collections.Generic;

namespace CoreEntities
{
    public partial class Product
    {
        public Product()
        {
            FlaggedProduct = new HashSet<FlaggedProduct>();
            OrderProduct = new HashSet<OrderProduct>();
            TransactionHistory = new HashSet<TransactionHistory>();
        }

        public Guid ProductId { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductCategoryId { get; set; }
        public string Condition { get; set; }
        public Guid ProductCreator { get; set; }
        public bool Flagged { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<FlaggedProduct> FlaggedProduct { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
        public ICollection<TransactionHistory> TransactionHistory { get; set; }
    }
}
