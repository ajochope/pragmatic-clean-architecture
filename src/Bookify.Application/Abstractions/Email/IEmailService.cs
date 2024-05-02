namespace Bookify.Application.Abstractions.Email
{
    using System.Threading.Tasks;

    public interface IEmailService
    {
        Task SendAsync(Domain.Users.Email recipient, string subject, string body);
    }
}