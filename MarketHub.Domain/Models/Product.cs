using MarketHub.Domain.Entities;
using MarketHub.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketHub.Domain.Models
{
    public sealed class Product : EntityBase
    {
        public Product() { }
        public Product(string name, string description, decimal price, int quantity, Guid categoryId, 
            Guid vendorId, bool isActive)
        {
            ValidateAndSetAttributes(name, description, price, quantity, categoryId, vendorId, isActive);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid VendorId { get; private set; }
        public bool IsActive { get; private set; } = true; 

        public void ValidateAndSetAttributes(string name, string description, decimal price, int quantity, Guid categoryId, 
            Guid vendorId, bool isActive)
        {
            ValidateName(name);
            Name = name;
            ValidateDescription(description);
            Description = description;
            ValidatePrice(price);
            Price = price;
            ValidateQuantity(quantity);
            Quantity = quantity;
            ValidateCategoryId(categoryId);
            CategoryId = categoryId;
            ValidateVendorId(vendorId);
            VendorId = vendorId;
            IsActive = isActive;
        }
        public void ValidateName(string name)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(name), "Invalid Name. Name is required!");
        }
        public void ValidateDescription(string description)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(description), "Invalid Description. Description is required!");
            DomainExceptionValidation.ExceptionHandler(description.Length > 150, "Too long description.");
        }
        public void ValidatePrice(decimal price)
        {
            DomainExceptionValidation.ExceptionHandler(price <= 0, "Invalid Price. Price must be greater than zero!");
        }
        public void ValidateQuantity(int quantity)
        {
            DomainExceptionValidation.ExceptionHandler(quantity <= 0, "Invalid Quantity. Quantity must be greater than zero!");
        }
        public void ValidateCategoryId(Guid categoryId)
        {
            DomainExceptionValidation.ExceptionHandler(categoryId == Guid.Empty, "Invalid Category. Category is required!");
        }
        public void ValidateVendorId(Guid vendorId)
        {
            DomainExceptionValidation.ExceptionHandler(vendorId == Guid.Empty, "Invalid Vendor. Vendor is required!");
        }
    }
}
