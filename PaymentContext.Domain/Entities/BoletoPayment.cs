using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode,
            string boletoNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string ownerPayer,
            Document document,
            Address address,
            Email email
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
            this.barCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string barCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}