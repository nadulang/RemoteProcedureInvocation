using System;
using System.Threading;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MediatR;
using MimeKit;
using UserService.Application.Models.Query;
using UserService.Domain.Entities;
using UserService.Infrastructure.Persistences;

namespace UserService.Application.UseCases.Users.Command.CreateUser
{
    public class CreateUserHandler : IRequestHandler<BaseRequest<Users_>, BaseDto<Users_>>
    {
        private readonly UsersContext _context;

        public CreateUserHandler(UsersContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Users_>> Handle(BaseRequest<Users_> request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;

            var user = new Domain.Entities.Users_
            {
                name = input.name,
                username = input.username,
                email = input.email,
                password = input.password,
                address = input.address
            };

            _context.UsersData.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Cantik-Cantik Ngiau", "cacangie45@gmail.com"));
            message.To.Add(new MailboxAddress("Cantik-Cantik Ngiau", "cacangie45@gmail.com"));
            message.Subject = "You have created a user";

            message.Body = new TextPart("plain")
            {
                Text = @"Welcome! If you receiving this email that means you have created a user. If you didn't do this, please contact the customer service immediately."
            };

            using (var client = new SmtpClient())
            {

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.mailtrap.io", 2525, false);


                client.Authenticate("84b015139889ab", "a7eda17f7b7703");

                client.Send(message);
                client.Disconnect(true);
                Console.WriteLine("E-mail Sent");
            }

            return new BaseDto<Users_>
            {
                message = "Success add a user data",
                success = true,
                data = input
            };
        }
    }
}
