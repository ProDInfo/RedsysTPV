using System;
using System.Text;

namespace RedsysTPV.Helpers
{
    public static class Base64
    {
        public static string EncodeTo64(string data)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] toEncodeAsBytes = Encoding.GetEncoding(1252).GetBytes(data);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

        public static string DecodeFrom64(string data)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] binary = Convert.FromBase64String(data);
            return Encoding.GetEncoding(1252).GetString(binary);
        }
    }
}
