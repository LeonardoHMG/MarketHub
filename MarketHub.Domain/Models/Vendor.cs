using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MarketHub.Domain.Entities;
using MarketHub.Domain.Validations;

namespace MarketHub.Domain.Models
{
    public sealed class Vendor: EntityBase
    {
        public Vendor() { }

        public Vendor(string name, string email, string phone, bool isActive)
        {
            ValidateAndSetAttributes(name, email, phone, isActive);
        }

        public string Name { get;  private set; }
        // public string CNPJ { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public bool IsActive { get; private set; }

        public void ValidateAndSetAttributes(string name, string email, string phone, bool isActive)
        {
            ValidateName(name);
            Name = name;
            // ValidateCNPJ(cnpj);
            // CNPJ = cnpj;
            ValidateEmail(email);
            Email = email;
            ValidatePhone(phone);
            Phone = phone;
            IsActive = isActive;
        }
        public void ValidateName(string name)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(name), "Invalid Name. Name is required!");
        }

        // public void ValidateCNPJ(string cnpj)
        // {
        //     DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(cnpj), "Invalid CNPJ. CNPJ is required!");

        //     string cnpjRegex = @"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$";
        //     DomainExceptionValidation.ExceptionHandler(!Regex.IsMatch(cnpj, cnpjRegex), "Invalid CNPJ. Please enter a valid CNPJ.");
        // }

        public void ValidateEmail(string email)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(email),"Invalid email. Email is required!");

            string emailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            DomainExceptionValidation.ExceptionHandler(!Regex.IsMatch(email, emailRegex),"Invalid Email. Please enter a valid email address.");
        }

        public void ValidatePhone(string phone)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(phone), "Invalid Phone. Phone is required!");
            
            string phoneRegex = @"^\(\d{2}\)\s\d{5}-\d{4}$";
            DomainExceptionValidation.ExceptionHandler(!Regex.IsMatch(phone, phoneRegex), "Invalid Phone. Please enter a valid email address.");
        }

    }
}