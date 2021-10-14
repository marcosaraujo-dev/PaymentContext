using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name: ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

             AddNotifications(new Contract<Name>()
                .Requires()
                .IsGreaterThan(FirstName,3,"Name.FirstName","Nome deve conter mais que 3 caracteres.")
                .IsGreaterThan(LastName,3,"Name.lastName","Nome deve conter mais que 3 caracteres.")
                .IsLowerOrEqualsThan(FirstName,40,"Name.FirstName","Nome deve conter menos que 40 caracteres.")
            );

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}