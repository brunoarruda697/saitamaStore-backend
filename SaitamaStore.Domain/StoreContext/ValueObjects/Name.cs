using FluentValidator.Validation;
using FluentValidator;

namespace SaitamaStore.Domain.StoreContext.ValueObjects
{
    public class Name
    {
        public Name(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            
            new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}