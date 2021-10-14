using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("12345678901234")]
        [DataRow("12341332455665678900")]
        [DataRow("765978")] 
        public void SouldReturnErrorWhenCNPJIsInvalid(string cnpj){
            var doc = new Document(cnpj,EDocumentType.CNPJ); 
            Assert.IsTrue(!doc.IsValid);  
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow("24042327000194")]
        [DataRow("81495257000163")]
        [DataRow("19690363000124")] 
        public void SouldReturnSuccessWhenCNPJIsValid(string cnpj){
           var doc = new Document(cnpj,EDocumentType.CNPJ); 
            Assert.IsTrue(doc.IsValid);  
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow("0987654766878")]
        [DataRow("12345678900")]
        [DataRow("748388610")] 
        public void SouldReturnErrorWhenCPFIsInvalid(string cpf){
            var doc = new Document(cpf,EDocumentType.CPF); 
            Assert.IsTrue(!doc.IsValid);  
        }
         [TestMethod]
         [DataTestMethod]
         [DataRow("99540637066")]
         [DataRow("20972824073")]
         [DataRow("74838861028")]   
        public void SouldReturnSuccessWhenCPFIsValid(string cpf){
            var doc = new Document(cpf,EDocumentType.CPF); 
            Assert.IsTrue(doc.IsValid);
        }
    }
}