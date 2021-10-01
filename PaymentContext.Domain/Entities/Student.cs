using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscription;
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscription = new List<Subscription>();
        }
        public Student(string firstName, string lastName, string document, string email, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Active = active;
            _subscription = new List<Subscription>();
        }
        public Student(string firstName, string lastName, string document, string email, string address, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Address = address;
            Active = active;
            _subscription = new List<Subscription>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public bool Active { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get{return _subscription.ToArray();} }
        
        
        public void Activate(bool active)
        {
            Active = active;
        }
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