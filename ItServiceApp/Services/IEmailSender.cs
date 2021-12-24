using ItServiceApp.Models;
using System.Threading.Tasks;

namespace ItServiceApp.Services
{
	public interface IEmailSender
	{
		Task SendAsync(EmailMessage message);
	}
}
