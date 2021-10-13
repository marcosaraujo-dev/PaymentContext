using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment: Entity
    {
        protected Payment( DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string ownerPayer, Document document, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            OwnerPayer = ownerPayer;
            Document = document;
            Address = address;
            Email = email;

            AddNotifications(new Contract<Payment>()
                .Requires()
                .IsGreaterThan(0,Total, "Payment.Total","O valor total não pode ser zero")
                .IsGreaterOrEqualsThan(0,TotalPaid, "Payment.Totalpaid","O valor total não pode ser zero")
            );
           
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string OwnerPayer { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
        
    }
}