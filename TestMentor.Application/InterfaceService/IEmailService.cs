using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Application.Handle.HandleEmail;

namespace TestMentor.Application.InterfaceService
{
    public interface IEmailService
    {
        string SendEmail(EmailMessage message);
    }
}
