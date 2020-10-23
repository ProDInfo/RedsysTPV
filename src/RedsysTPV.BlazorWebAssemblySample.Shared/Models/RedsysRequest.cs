using RedsysTPV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedsysTPV.BlazorWebAssemblySample.Shared.Models
{
    public class RedsysRequest
    {
        public PaymentFormData Request { get; set; }
        public string ConnectionUrl { get; set; }
    }
}
