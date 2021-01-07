using System;
using System.Net;
using System.Text;

namespace RedsysTPV.Helpers
{
    public static class Base64
    {
        public static string EncodeCp1252To64(string data)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] toEncodeAsBytes = Encoding.GetEncoding(1252).GetBytes(data);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

        public static string DecodeCp1252From64(string data)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] binary = Convert.FromBase64String(data);
            return Encoding.GetEncoding(1252).GetString(binary);
        }

        public static string EncodeUtf8To64(string data)
        {
            byte[] toEncodeAsBytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

        public static string DecodeUtf8From64(string data)
        {
            byte[] binary = Convert.FromBase64String(data);
            return Encoding.UTF8.GetString(binary);
        }
    }
}
