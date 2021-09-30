using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        public Datetime CreateDate { get; set; }
        public Datetime LastUpdateDate { get; set; }
        public Datetime? ExpireDate { get; set; }
        public List<Subscription> Subscription { get; set; }
        public List<Payment> Payments { get; set; }      
        public bool Active { get; set; }

    }
}