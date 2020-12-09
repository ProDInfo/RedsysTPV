using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RedsysTPV.Enums
{
    public enum PaymentMethod
    {
        [Description("C")]
        CreditCard,

        [Description("p")]
        Paypal,

        [Description("R")]
        Transfer,

        [Description("N")]
        Masterpass,

        [Description("z")]
        Bizum,
    }
}
