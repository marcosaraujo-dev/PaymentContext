using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentQueriesTests
    {
        // Red, Green, Refactor
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();
            for (var i = 0; i <= 10; i++)
            {
                _students.Add(  new Student(
                                new Name("Aluno", i.ToString()),
                                new Document("7777777777" + i.ToString(), EDocumentType.CPF),
                                new Email(i.ToString() + "@yuyu.co")
                            ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentDocumentInfo("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentDocumentInfo("77777777777");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }

        [TestMethod]
        public void ShouldReturnNullWhenEmailNotExists()
        {
            var exp = StudentQueries.GetStudentEmailInfo("11@yuyu.co");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenEmailExists()
        {
            var exp = StudentQueries.GetStudentEmailInfo("7@yuyu.co");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }
    }
}