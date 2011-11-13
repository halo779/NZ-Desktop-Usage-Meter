namespace MeterBase
{
    /// <summary>
    /// Constructor for all Base values
    /// </summary>
    public class MeterBase
    {
        #region Varables
        public string
            Username        = "",
            Password        = "",
            LastError       = "";
        public byte
            RenewDate       = 1,
            DaysLeft        = 1;
        public decimal
            Total           = 0,
            Used            = 0,
            PerDay          = 0,
            Remaining       = 0,
            Cost            = 0,
            UnmeteredData   = 0,
            Percentage      = 0;
        public bool
            Configured      = false,
            PPM             = false,
            ShowUnmetered   = false;
        public int 
            UpdateInterval  = 30;
        #endregion

        #region GenericHelperFunctions
        /// <summary>
        /// Used to encode a plain text string into a 64 bit encoded string
        /// </summary>
        /// <param name="toEncode">String you wish to encode</param>
        /// <seealso cref="http://arcanecode.wordpress.com/2007/03/21/encoding-strings-to-base64-in-c/">Code sourced from http://arcanecode.wordpress.com/2007/03/21/encoding-strings-to-base64-in-c/ </seealso>
        /// <returns>Encoded string</returns>
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        /// <summary>
        /// Used to decode a 64 bit encoded string into a plain text string
        /// </summary>
        /// <seealso cref="http://arcanecode.wordpress.com/2007/03/21/encoding-strings-to-base64-in-c/">Code sourced from http://arcanecode.wordpress.com/2007/03/21/encoding-strings-to-base64-in-c/ </seealso>
        /// <param name="encodedData">String you Wish to decode</param>
        /// <returns>Decoded String</returns>
        static public string DecodeFrom64(string encodedData)
        {
            // Code sourced from http://arcanecode.wordpress.com/2007/03/21/encoding-strings-to-base64-in-c/
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
        #endregion
    }
}
