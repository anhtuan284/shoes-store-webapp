using QLBG.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.WEB
{
    public interface IVnPaySvc
    {
        string CreatePaymentUrl(HttpContext ctx, VnPayRequestModel model);
        VnPaymentResponseModel PaymentExcute(IQueryCollection collections);
    }
}
