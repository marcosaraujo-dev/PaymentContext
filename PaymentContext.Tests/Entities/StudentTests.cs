using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {   
        private readonly Name _name;
        private readonly Document _document;
        
        private readonly Address _address;
        
        private readonly Email _email;
        private readonly Student _student;

        public StudentTests()
        {
            _name = new Name("Yusuke", "Urameshi");
            _document = new Document("30457559098",EDocumentType.CPF);
            _email = new Email("yusuke@yuyu.co");
            _student = new Student(_name, _document, _email);
            _address = new Address("Rua 70","79","bairro 7","Santos", "SP","BR","9897654");

           
           
        }

        [TestMethod]
        public void ShouldReturnErroWhenHadActiveSubscription()
        {   
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("98786543",DateTime.Now, DateTime.Now.AddDays(5),10,10,"Empresa",_document,_address,_email);

            subscription.AddPayment(payment);
            
            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription);

            Assert.IsTrue(!_student.IsValid);
        }
        
        [TestMethod]
        public void ShouldReturnErroWhenHadActiveSubscriptionHasNoPayment()
        {   
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);

            Assert.IsTrue(!_student.IsValid);      
        }

         [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);
            Assert.IsTrue(!_student.IsValid);
        }
        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {   
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("98786543",DateTime.Now, DateTime.Now.AddDays(5),10,10,"Empresa",_document,_address,_email);

            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.IsValid);
        }

       
    }
}