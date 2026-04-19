using MVCForumApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCForumApp.Tests
{
    public class UserTests
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        [Fact]
        public void User_WithTooShortLoginAndPassword_ShouldHaveValidationErrors()
        {
            var user = new User { Login = "123", Password = "123" };
            var errors = ValidateModel(user);

            Assert.NotEmpty(errors);
            Assert.Contains(errors, v => v.MemberNames.Contains("Login"));
            Assert.Contains(errors, v => v.MemberNames.Contains("Password"));
        }

        [Fact]
        public void User_WithCorrectData_ShouldNotHaveValidationErrors()
        {
            var user = new User { Login = "Admin123", Password = "Password123!" };
            var errors = ValidateModel(user);

            Assert.Empty(errors);
        }
    }
}