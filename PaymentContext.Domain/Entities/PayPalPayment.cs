using System;
namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(
            string transactionCode,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string ownerPayer,
            string document,
            string address,
            string email
        ) : base(
            paidDate, 
            expireDate, 
            total, 
            totalPaid, 
            ownerPayer, 
            document, 
            address, 
            email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}