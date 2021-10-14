using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand: Notifiable<Notification>, ICommand
    {
        
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Document { get;  set; }
        public string Address { get;  set; }
        
        public string BarCode { get;  set; }
        public string BoletoNumber { get;  set; }

        public string PaymentNumber { get;  set; }
        public DateTime PaidDate { get;  set; }
        public DateTime ExpireDate { get;  set; }
        public decimal Total { get;  set; }
        public decimal TotalPaid { get;  set; }
        public string OwnerPayer { get;  set; }
        public string PayerDocument { get;  set; }
        public EDocumentType PayerDocumentType {get; set;}
        public string PayerEmail { get;  set; }
        public string PayerAddressStreet { get;  set; }
        public string PayerAddressNumber { get;  set; }
        public string PayerAddressNeighborhood { get;  set; }
        public string PayerAddressCity { get;  set; }
        public string PayerAddressState { get;  set; }
        public string PayerAddressCountry { get;  set; }
        public string PayerAddressZipCode { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateBoletoSubscriptionCommand>()
                .Requires()
                .IsGreaterThan(FirstName,3,"Name.FirstName","Nome deve conter mais que 3 caracteres.")
                .IsGreaterThan(LastName,3,"Name.lastName","Nome deve conter mais que 3 caracteres.")
                .IsLowerOrEqualsThan(FirstName,40,"Name.FirstName","Nome deve conter menos que 40 caracteres.")
            );
        }
    }
}