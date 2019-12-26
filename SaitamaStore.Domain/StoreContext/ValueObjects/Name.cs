using FluentValidator.Validation;
using FluentValidator;

namespace SaitamaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O primeiro nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O primeiro nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "FirstName", "O sobrenome deve conter no máximo 40 caracteres"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}