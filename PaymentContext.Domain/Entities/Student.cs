using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student:Entity
    {
        private IList<Subscription> _subscription;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscription = new List<Subscription>();
            AddNotifications(name,document, email);
        }
        public Student(Name name, Document document, Email email, Active active)
        {
            Name = name;
            Document = document;
            Email = email;
            Active = active;
            _subscription = new List<Subscription>();
            AddNotifications(name,document, email);
        }
        public Student(Name name, Document document, Email email, Address address, Active active)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            Active = active;
            _subscription = new List<Subscription>();
           
           AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; set; }
 
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public Active Active { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get{return _subscription.ToArray();} }
        
        
        // public void Activate(bool active)
        // {

        //     Active.Activate(active);
        // }
        
        public void AddSubscription(Subscription subscription)
        {
            
            var hasSubscriptionActive = false;

            foreach(var sub in _subscription){
                if(sub.Active)
                    hasSubscriptionActive = true;
                //sub.Activate(false);
            }
            AddNotifications(new Contract<Student>()
                .Requires()
                .IsFalse(hasSubscriptionActive,"Student.Subscriptions","Voce já possui uma assinatura ativa")
                .AreNotEquals(0,subscription.Payments.Count, "Student.Subscriptions", "Essa assinatura não contém pagamentos")
            );
            if(IsValid)
                _subscription.Add(subscription);
        }
        
    }
}