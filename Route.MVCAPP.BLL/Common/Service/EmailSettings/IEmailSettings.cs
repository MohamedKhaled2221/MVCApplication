using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Models.identity;

namespace Route.MVCAPP.BLL.Common.Service.EmailSettings
{
    public interface IEmailSettings
    {
        public void SendEmail(Email email);
    }
}
