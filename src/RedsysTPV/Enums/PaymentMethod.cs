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

        [Description("A")]
        Transfer,

        [Description("D")]
        Domiciliation,

        [Description("T")]
        CreditCardAndIUPay,
    }
}
