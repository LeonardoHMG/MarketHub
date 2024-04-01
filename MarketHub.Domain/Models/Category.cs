using MarketHub.Domain.Entities;
using MarketHub.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketHub.Domain.Models
{
    public sealed class Category : EntityBase
    {
        public Category() { }
        public Category(string description, bool isActive)
        {
            ValidateAndSetAttributes(description, isActive);
        }

        public string Description { get; private set; }
        public bool IsActive { get; private set; } = true;

        private void ValidateAndSetAttributes(string description, bool isActive)
        {
            ValidateDescription(description);
            Description = description;
            IsActive = isActive;
        }

        private void ValidateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                DomainExceptionValidation.ExceptionHandler(true, "Invalid Description. Description is required!");

            if (description.Length > 20)
                DomainExceptionValidation.ExceptionHandler(true, "Too long description.");

            if (description.Length <= 3)
                DomainExceptionValidation.ExceptionHandler(true, "Too short description.");
        }
    }
}
