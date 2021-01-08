using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RedsysTPV.Enums
{
    public enum TransactionType
    {
        [Description("0")]
        Authorisation,

        [Description("1")]
        Preauthorisation,

        [Description("2")]
        Confirmation,

        [Description("3")]
        AutomaticRefund,

        [Description("5")]
        RecurringTransaction,

        [Description("6")]
        NextTransaction,

        [Description("7")]
        PreauthorisationSeparate,

        [Description("8")]
        ConfirmationSeparate,

        [Description("9")]
        CancellationOfPreauthorisation,

        [Description("15")]
        Paygold,

        [Description("17")]
        AuthenticationPuce,

        [Description("34")]
        DevolucionSinOriginal,

        [Description("37")]
        PremioDeApuestas,

        //[Description("A")]
        //TraditionalPayment,
        //[Description("O")]
        //DeferredAuthorisation,

        //[Description("P")]
        //DeferredAuthorisationConfirmation, 

        //[Description("Q")]
        //DeferredAuthorisationCancellation,

        //[Description("R")]
        //InitialDeferredRecurringTransaction,

        //[Description("S")]
        //DeferredNextRecurringAuthorisation,
    }
}
