using System;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Document { get;  set; }
        public string Address { get;  set; }
        
        public string TransactionCode { get;  set; }

         public string PaymentNumber { get;  set; }
        public DateTime PaidDate { get;  set; }
        public DateTime ExpireDate { get;  set; }
        public decimal Total { get;  set; }
        public decimal TotalPaid { get;  set; }
        public string OwnerPayer { get;  set; }
        public string PayerDocument { get;  set; }
        public EDocumentType PayerDocumentType {get; set;}
        public string PayerEmail { get;  set; }
        public string PayerAddressStreet { get; private set; }
        public string PayerAddressNumber { get; private set; }
        public string PayerAddressNeighborhood { get; private set; }
        public string PayerAddressCity { get; private set; }
        public string PayerAddressState { get; private set; }
        public string PayerAddressCountry { get; private set; }
        public string PayerAddressZipCode { get; private set; }
    }
}