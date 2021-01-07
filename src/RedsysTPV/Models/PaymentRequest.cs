using RedsysTPV.Converters;
using RedsysTPV.Enums;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

// https://pagosonline.redsys.es/parametros-entrada-salida.html
namespace RedsysTPV.Models
{
    public class PaymentRequest
    {
        /// <summary>
        /// Las 2 últimas posiciones hacen referencia a los decimales de la moneda, excepto para el YEN que no tiene decimales.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonConverter(typeof(CurrencyToStringJsonConverter))]
        public decimal Ds_Merchant_Amount { get; set; }
        /// <summary>
        /// Opcional. Representa el código de autorización necesario para identificar de manera inequivoca la transacción original sobre la que se desea realizar la devolución.
        /// </summary>
        public string Ds_Merchant_AuthorisationCode { get; }
        /// <summary>
        /// Obligatorio para operativa COF Visa y MC. Valores posibles:
        /// "S": Sí es primera transacción COF(almacenar credenciales).
        /// "N": No es primera transacción COF.
        /// Cualquier otro valor no se tendrá en cuenta y la operación no se procesará como COF.
        /// </summary>
        public string Ds_Merchant_Cof_Ini { get; }
        /// <summary>
        /// Opcional. Este identificador es devuelto en la respuesta de la primera operación COF (almacenamiento de credenciales), y deberá enviarse en transacciones sucesivas realizadas con las credenciales que generaron este mismo Id_txn.
        /// </summary>
        public string Ds_Merchant_Cof_Txnid { get; }
        /// <summary>
        /// Opcional para COF Visa y MC. Valores posibles:
        /// "I": Installments.
        /// "R": Recurring.
        /// "H": Reauthorization.
        /// "E": Resubmission.
        /// "D": Delayed.
        /// "M": Incremental.
        /// "N": No Show.
        /// "C": Otras.
        /// </summary>
        public string Ds_Merchant_Cof_Type { get; }
        /// <summary>
        /// Los valores posibles se incluyen en la tabla de idiomas
        /// </summary>
        [JsonConverter(typeof(EnumToThreeStringConverter<Language>))]
        public Language Ds_Merchant_ConsumerLanguage { get; set; }
        /// <summary>
        /// Se debe enviar el código numérico de la moneda según el ISO-4217, ver tabla de monedas.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonConverter(typeof(EnumToThreeStringConverter<Currency>))]
        public Currency Ds_Merchant_Currency { get; set; }
        /// <summary>
        /// Conditional. Código CVV2 de la tarjeta.
        /// </summary>
        public string Ds_Merchant_Cvv2 { get; }

        /// <summary>
        /// Valores posibles:
        // "true": identifica la intención de realizar la operación sin autenticación.
        // "moto": identifica la operación como pago MOTO.
        /// </summary>
        public string Ds_Merchant_DirectPayment { get; set; }
        public object Ds_Merchant_Emv3ds { get; }
        public string Ds_Merchant_ExpiryDate { get; }

        /// <summary>
        /// Identificador del código de grupo asociado a la referencia
        /// </summary>
        public string Ds_Merchant_Group { get; }
        /// <summary>
        ///	Este parámetro indica la referencia de la tarjeta a utilizar, o la solicitud de generar una referencia.
        /// Para generar una nueva referencia enviar "REQUIRED" en el caso de REST/SOAP el parámetro DS_MERCHANT_PAN es Obligatorio.
        /// </summary>
        public string Ds_Merchant_Identifier { get; set; }
        /// <summary>
        /// Identificador de la operación de INSITE.
        /// </summary>
        public string Ds_Merchant_IdOper { get; }
        /// <summary>
        /// Código FUC asignado al comercio.(Nº de comercio)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Ds_Merchant_MerchantCode { get; set; }
        /// <summary>
        /// Cadena de datos que no procesará el TPV-Virtual y se devolverán de la misma forma en la respuesta
        /// </summary>
        public string Ds_Merchant_MerchantData { get; set; }
        /// <summary>
        /// Para la entrada de realizar pago esta información se mostrará al titular en la pantallas con las que este interaciona. En caso de no informarse aparecerá el nombre configurado en la administración del TPV- Virtual.
        /// </summary>
        public string Ds_Merchant_MerchantName { get; set; }
        /// <summary>
        /// Si el comercio tiene configurada notificación online "HTTP" en el módulo de administración, se enviará una petición post con el resultado de la transacción a la URL especificada.
        /// </summary>
        public string Ds_Merchant_MerchantURL { get; set; }
        /// <summary>
        /// 	Se recomienda, por posibles problemas en el proceso de liquidación, que los 4 primeros dígitos sean numéricos. Para los dígitos restantes solo utilizar los siguientes caracteres ASCII:
        /// Del 48 = 0 al 57 = 9
        /// Del 65 = A al 90 = Z
        /// Del 97 = a al 122 = z
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Ds_Merchant_Order { get; set; }
        /// <summary>
        /// Tarjeta. Su longitud depende del tipo de tarjeta.
        /// </summary>
        public string Ds_Merchant_Pan { get; }
        /// <summary>
        /// Forma de pago aplicable. Ver tabla DS_MERCHANT_PAYMETHODS
        /// </summary>
        [JsonConverter(typeof(EnumDescriptionConverter<PaymentMethod>))]
        public PaymentMethod Ds_Merchant_Paymethods { get; set; }

        /// <summary>
        /// La longitud máxima es 125. Para la entrada de realizar pago esta información se mostrará al titular en la pantallas con las que este interaciona.
        /// </summary>
        public string Ds_Merchant_ProductDescription { get; set; }
        /// <summary>
        /// Operativa especial de pago de tributos. Código de barras del tributo en operativa especial de pago de tributos. Se requiere activación por parte de la entidad.
        /// </summary>
        public string Ds_Merchant_Tax_Reference { get; }
        /// <summary>
        /// Número de terminal que le asignará su banco.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Ds_Merchant_Terminal { get; set; }
        /// <summary>
        /// Su longitud máxima es de 60 caracteres. Para la entrada de realizar pago esta información se mostrará al titular en la pantallas con las que este interaciona. En la pantalla de pago, el titular podrá modificar este valor.
        /// </summary>
        public string Ds_Merchant_Titular { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonConverter(typeof(EnumDescriptionConverter<TransactionType>))]
        public TransactionType Ds_Merchant_TransactionType { get; set; }

        /// <summary>
        /// URL en la que se enviará una petición HTTP get cuando el resultado de la transacción sea OK. Si este parámetro no viene informado se usará la configuración en el módulo de administración.
        /// </summary>
        public string Ds_Merchant_UrlOK { get; set; }
        /// <summary>
        /// URL en la que se enviará una petición HTTP get cuando el resultado de la transacción sea KO. Si este parámetro no viene informado se usará la configuración en el módulo de administración.
        /// </summary>
        public string Ds_Merchant_UrlKO { get; set; }


        public string Ds_XPayData { get; }
        public string Ds_XPayOrigen { get; }
        public string Ds_XPayType { get; }

        /// <summary>
        /// Indica si entre los campos de respuesta al comercio se incluye información relativa a la dirección de envío que tiene el titular configurada en su cuenta PayPal. Los valores que se pueden indicar en dicho campo son:
        /// S: si se desea obtener dicha información en la respuesta del TPV-Virtual.
        /// N: se NO se desea obtener dicha información en la respuesta del TPV-Virtual.
        /// </summary>
        public string Ds_Merchant_ShippingAddressPyp { get; }
        /// <summary>
        /// Número de personalización que se desea utilizar en la operación. Si no se informa dicho parámetro o el valor que se informa no corresponde con un número de personalización activa existente
        /// </summary>
        public string Ds_Merchant_PersoCode { get; }
        /// <summary>
        /// No debe repetirse. Valor que enviará en la respuesta para identificar a la petición
        /// </summary>
        public string Ds_Merchant_MatchingData { get; }
        /// <summary>
        /// Es el valor de la interfaz PUC, por dónde el comercio procesará la transacción de autorización.
        /// </summary>
        public string Ds_Acquirer_Identifier { get; }

        public string Ds_Merchant_MpiExternal { get; }
        /// <summary>
        /// Para informar el número de teléfono del titular para enviar el SMS con el enlace.
        /// </summary>
        public string Ds_Merchant_Customer_Mobile { get; }
        /// <summary>
        /// Para informar la dirección de mail del titular para enviar el enlace.
        /// </summary>
        public string Ds_Merchant_Customer_Mail { get; } 

        public string Ds_Merchant_P2f_ExpiryDate { get; }
        public string Ds_Merchant_Customer_Sms_Text { get; }
        public string Ds_Merchant_P2f_XmlData { get; }
        public string Ds_Merchant_Dcc { get; }
        public string Ds_Merchant_Excep_Sca { get; }
        public string Ds_Merchant_Ota { get; }


        public PaymentRequest(
            string Ds_Merchant_MerchantCode,
            string Ds_Merchant_Terminal,
            TransactionType Ds_Merchant_TransactionType,
            decimal Ds_Merchant_Amount,
            Currency Ds_Merchant_Currency,
            string Ds_Merchant_Order,
            string Ds_Merchant_MerchantURL,
            string Ds_Merchant_UrlOK,
            string Ds_Merchant_UrlKO,
            Language Ds_Merchant_ConsumerLanguage = Language.Spanish)
        {
            this.Ds_Merchant_MerchantCode = Ds_Merchant_MerchantCode;
            this.Ds_Merchant_Terminal = Ds_Merchant_Terminal;
            this.Ds_Merchant_TransactionType = Ds_Merchant_TransactionType;
            this.Ds_Merchant_Amount = Ds_Merchant_Amount;
            this.Ds_Merchant_Currency = Ds_Merchant_Currency;
            this.Ds_Merchant_Order = Ds_Merchant_Order;
            this.Ds_Merchant_MerchantURL = Ds_Merchant_MerchantURL;
            this.Ds_Merchant_UrlOK = Ds_Merchant_UrlOK;
            this.Ds_Merchant_UrlKO = Ds_Merchant_UrlKO;
            this.Ds_Merchant_ConsumerLanguage = Ds_Merchant_ConsumerLanguage;
        }

        public PaymentRequest Clone()
        {
            PaymentRequest temp = (PaymentRequest)this.MemberwiseClone();
            return temp;
        }
    }
}
