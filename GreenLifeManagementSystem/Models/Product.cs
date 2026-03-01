using System;

namespace GreenLifeManagementSystem.Models
{
    
    public class Product
    {
        
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }

        
        public void UpdateStock(int amount)
        {
            StockQuantity += amount;
        }
    }
}