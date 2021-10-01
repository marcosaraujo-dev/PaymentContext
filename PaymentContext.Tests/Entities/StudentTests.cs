using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {   
            var subscription = new Subscription(null);
            var student = new Student("Marcos","Araujo de Souza","3333333","marcos@teste.com");  

            student.AddSubscription(subscription);      
        }

    }
}