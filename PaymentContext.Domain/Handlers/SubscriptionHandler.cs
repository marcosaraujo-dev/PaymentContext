using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :  Notifiable<Notification>, 
                                        IHandler<CreateBoletoSubscriptionCommand>,
                                        IHandler<CreatePayPalSubscriptionCommand>,
                                        IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emaiLService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emaiLService = emailService;
        }

        #region CreateBoletoSubscriptionCommand
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar seu cadastro");
            }
            // verificar se o documento está cadastrado
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este Documento já existe.");

            // verificar se o email está cadastrado
            if (_repository.EmailExists(command.PayerEmail))
                AddNotification("Email", "Este Email já existe.");

            // Gerar os VOs

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.PayerEmail);
            var address = new Address(command.PayerAddressStreet,
                                        command.PayerAddressNumber,
                                        command.PayerAddressNeighborhood,
                                        command.PayerAddressCity,
                                        command.PayerAddressState,
                                        command.PayerAddressCountry,
                                        command.PayerAddressZipCode
                                        );


            // Gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode,
                                            command.BoletoNumber,
                                            command.PaidDate,
                                            command.ExpireDate,
                                            command.Total, 
                                            command.TotalPaid, 
                                            command.PayerEmail, 
                                            new Document(command.PayerDocument, command.PayerDocumentType), 
                                            address, 
                                            email
                                            );

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Aplicar as validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Checar Notificações (controle de validações)
            if(!IsValid)
                return new CommandResult(false,"Não foi possível realizar sua assinatura");

            // Salvar as informações
            _repository.CreateSubscription(student);

            // enviar e-mail de boas vindas
            _emaiLService.Send(student.Name.ToString(), 
                                student.Email.Address,
                                "Bem Vindo A central de Cursos",
                                "Seu pagamento do boleto foi confirmado e sua assinatura foi criada com sucesso, boa sorte nos estudos!");
           
            // retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
        #endregion

        #region CreatePayPalSubscriptionCommand
        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            // fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar seu cadastro");
            }
            // verificar se o documento está cadastrado
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este Document já existe.");

            // verificar se o email está cadastrado
            if (_repository.EmailExists(command.PayerEmail))
                AddNotification("Email", "Este Email já existe.");

            // Gerar os VOs

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.PayerEmail);
            var address = new Address(command.PayerAddressStreet,
                                        command.PayerAddressNumber,
                                        command.PayerAddressNeighborhood,
                                        command.PayerAddressCity,
                                        command.PayerAddressState,
                                        command.PayerAddressCountry,
                                        command.PayerAddressZipCode
                                        );


            // Gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(command.TransactionCode,
                                            command.PaidDate,
                                            command.ExpireDate,
                                            command.Total, 
                                            command.TotalPaid, 
                                            command.PayerEmail, 
                                            new Document(command.PayerDocument, command.PayerDocumentType), 
                                            address, 
                                            email
                                            );

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Aplicar as validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Checar Notificações (controle de validações)
            if(!IsValid)
                return new CommandResult(false,"Não foi possível realizar sua assinatura");

            // Salvar as informações
            _repository.CreateSubscription(student);
            
            // enviar e-mail de boas vindas
            _emaiLService.Send(student.Name.ToString(), 
                                student.Email.Address,
                                "Bem Vindo A central de Cursos",
                                "Seu pagamento no paypal foi confirmado e sua assinatura foi criada com sucesso, boa sorte nos estudos!"
                             );

            // retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
        #endregion

        #region CreateCreditCardSubscriptionCommand
        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            // fail Fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar seu cadastro");
            }
            // verificar se o documento está cadastrado
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este Document já existe.");

            // verificar se o email está cadastrado
            if (_repository.EmailExists(command.PayerEmail))
                AddNotification("Email", "Este Email já existe.");

            // Gerar os VOs

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.PayerEmail);
            var address = new Address(command.PayerAddressStreet,
                                        command.PayerAddressNumber,
                                        command.PayerAddressNeighborhood,
                                        command.PayerAddressCity,
                                        command.PayerAddressState,
                                        command.PayerAddressCountry,
                                        command.PayerAddressZipCode
                                        );


            // Gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(command.CardHolderNumber,
                                            command.CardNumber,
                                            command.LastTransactionNumber,
                                            command.PaidDate,
                                            command.ExpireDate,
                                            command.Total, 
                                            command.TotalPaid, 
                                            command.PayerEmail, 
                                            new Document(command.PayerDocument, command.PayerDocumentType), 
                                            address, 
                                            email
                                            );

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Aplicar as validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Checar Notificações (controle de validações)
            if(!IsValid)
                return new CommandResult(false,"Não foi possível realizar sua assinatura");

            // Salvar as informações
            _repository.CreateSubscription(student);

            // enviar e-mail de boas vindas
            _emaiLService.Send(student.Name.ToString(), 
                                student.Email.Address,
                                "Bem Vindo A central de Cursos",
                                "Seu pagamento do cartão de crédito foi aprovado e sua assinatura foi criada com sucesso, boa sorte nos estudos!"
                                );
            // retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
        #endregion
    }
}