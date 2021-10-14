using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExistsCreateBoletoSubscription()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Yusuke";
            command.LastName = "Urameshi";
            command.Document = "30457559098";
            command.PayerEmail = "yusuke@yuyu.co";
            command.BarCode = "123456789";
            command.BoletoNumber = "1234654987";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.OwnerPayer = "Koema Corp";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "koema@yuyu.co";
            command.PayerAddressStreet = "Rua 70";
            command.PaymentNumber = "79";
            command.PayerAddressNeighborhood = "bairro 7";
            command.PayerAddressCity = "Santos";
            command.PayerAddressState = "SP";
            command.PayerAddressCountry = "BR";
            command.PayerAddressZipCode = "9897654";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessCreateBoletoSubscription()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Yusuke";
            command.LastName = "Urameshi";
            command.Document = "99540637066";
            command.PayerEmail = "yusuke@yuyu.co";
            command.BarCode = "123456789";
            command.BoletoNumber = "1234654987";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.OwnerPayer = "Koema Corp";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "koema@yuyu.co";
            command.PayerAddressStreet = "Rua 70";
            command.PaymentNumber = "79";
            command.PayerAddressNeighborhood = "bairro 7";
            command.PayerAddressCity = "Santos";
            command.PayerAddressState = "SP";
            command.PayerAddressCountry = "BR";
            command.PayerAddressZipCode = "9897654";

            handler.Handle(command);
            Assert.AreEqual(true, handler.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExistsCreatePayPalSubscription()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreatePayPalSubscriptionCommand();
            command.FirstName = "Yusuke";
            command.LastName = "Urameshi";
            command.Document = "30457559098";
            command.PayerEmail = "yusuke@yuyu.co";
            command.TransactionCode = "123456789";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.OwnerPayer = "Koema Corp";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "koema@yuyu.co";
            command.PayerAddressStreet = "Rua 70";
            command.PaymentNumber = "79";
            command.PayerAddressNeighborhood = "bairro 7";
            command.PayerAddressCity = "Santos";
            command.PayerAddressState = "SP";
            command.PayerAddressCountry = "BR";
            command.PayerAddressZipCode = "9897654";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessCreatePayPalSubscription()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreatePayPalSubscriptionCommand();
            command.FirstName = "Yusuke";
            command.LastName = "Urameshi";
            command.Document = "99540637066";
            command.PayerEmail = "yusuke@yuyu.co";
            command.TransactionCode = "123456789";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.OwnerPayer = "Koema Corp";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "koema@yuyu.co";
            command.PayerAddressStreet = "Rua 70";
            command.PaymentNumber = "79";
            command.PayerAddressNeighborhood = "bairro 7";
            command.PayerAddressCity = "Santos";
            command.PayerAddressState = "SP";
            command.PayerAddressCountry = "BR";
            command.PayerAddressZipCode = "9897654";

            handler.Handle(command);
            Assert.AreEqual(true, handler.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExistsCreateCreditCardSubscription()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateCreditCardSubscriptionCommand();
            command.FirstName = "Yusuke";
            command.LastName = "Urameshi";
            command.Document = "30457559098";
            command.PayerEmail = "yusuke@yuyu.co";
            command.CardHolderNumber = "123456789";
            command.CardNumber = "1234654987";
            command.LastTransactionNumber = "898785674566579876";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.OwnerPayer = "Koema Corp";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "koema@yuyu.co";
            command.PayerAddressStreet = "Rua 70";
            command.PaymentNumber = "79";
            command.PayerAddressNeighborhood = "bairro 7";
            command.PayerAddressCity = "Santos";
            command.PayerAddressState = "SP";
            command.PayerAddressCountry = "BR";
            command.PayerAddressZipCode = "9897654";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessCreateCreditCardSubscription()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateCreditCardSubscriptionCommand();
            command.FirstName = "Yusuke";
            command.LastName = "Urameshi";
            command.Document = "99540637066";
            command.PayerEmail = "yusuke@yuyu.co";
            command.CardHolderNumber = "123456789";
            command.CardNumber = "1234654987";
            command.LastTransactionNumber = "898785674566579876";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.OwnerPayer = "Koema Corp";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "koema@yuyu.co";
            command.PayerAddressStreet = "Rua 70";
            command.PaymentNumber = "79";
            command.PayerAddressNeighborhood = "bairro 7";
            command.PayerAddressCity = "Santos";
            command.PayerAddressState = "SP";
            command.PayerAddressCountry = "BR";
            command.PayerAddressZipCode = "9897654";

            handler.Handle(command);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}