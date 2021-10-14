using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
using PaymentContext.Shared.Roles;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
            AddNotifications(new Contract<Document>()
                .Requires()
                .IsTrue(Validate(),"Document.Number","Documento inválido")
            );
        }


        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validate()
        {
            ValidarDocumentos validaCPFCNPJ = new ValidarDocumentos();
            if (Type == EDocumentType.CNPJ && validaCPFCNPJ.IsCnpj(Number))
                return true;
            if (Type == EDocumentType.CPF && validaCPFCNPJ.IsCpf(Number))
                return true;
            return false;
        }
    }
}