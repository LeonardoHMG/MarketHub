using FluentAssertions;
using MarketHub.Domain.Models;
using MarketHub.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketHub.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact]
        public void WhenCategoryName_LenghtMoreThan_DomainException()
        {   
            Action category=() => new Category("DescriptionTestLongerThan20CharactersUnitTestForDomainException", true);
            category.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Too long description.");    
        }

        [Fact]
        public void WhenCategoryName_IsEmpty_DomainException()
        {
            Action category = () => new Category("", true);
            category.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description. Description is required!");
        }

        [Fact]
        public void WhenCategoryName_LenghtLessThan_DomainException()
        {
            Action category = () => new Category("TV", true);
            category.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Too short description.");
        }
    }
}
