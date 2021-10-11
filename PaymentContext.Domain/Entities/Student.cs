using System.Collections.Generic;
using System.Linq;
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
        }
        public Student(Name name, Document document, Email email, Active active)
        {
            Name = name;
            Document = document;
            Email = email;
            Active = active;
            _subscription = new List<Subscription>();
        }
        public Student(Name name, Document document, Email email, Address address, Active active)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            Active = active;
            _subscription = new List<Subscription>();
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
            // Se tiver uma assinatura ativa
            //Cancela todas as outras assinaturas e deixa a nova como principal

            foreach(var sub in Subscriptions){
                sub.Activate(false);
            }
            _subscription.Add(subscription);
        }
        
    }
}