using System;
using System.Linq.Expressions;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Queries
{
    public class StudentQueries
    {
       public static Expression<Func<Student, bool>> GetStudentDocumentInfo(string document)
        {
            return x => x.Document.Number == document;
        } 
        public static Expression<Func<Student, bool>> GetStudentEmailInfo(string email)
        {
            return x => x.Email.Address == email;
        } 
    }
}