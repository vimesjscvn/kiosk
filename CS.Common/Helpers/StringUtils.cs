using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace CS.Common.Helpers
{
    /// <summary>
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        ///     Converts to snakecase.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString())).ToLower();
        }

        /// <summary>
        ///     Validates the card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns></returns>
        public static bool ValidateCardNumber(string cardNumber)
        {
            var rx = new Regex(@"^79[0-9]{10}$");
            return rx.IsMatch(cardNumber);
        }

        /// <summary>
        ///     Maps the valid patient code.
        /// </summary>
        /// <param name="patientCode">The patient code.</param>
        /// <returns></returns>
        public static string MapValidPatientCode(string patientCode)
        {
            var mapHopitalCode = "37101.";
            if (!patientCode.Contains(mapHopitalCode))
                patientCode = mapHopitalCode + patientCode;
            return patientCode;
        }

        /// <summary>
        ///     Determines whether [is phone number] [the specified phone number].
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>
        ///     <c>true</c> if [is phone number] [the specified phone number]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPhoneNumber(string phoneNumber)
        {
            return Regex.Match(phoneNumber, @"(84|0[3|5|7|8|9])+([0-9]{8})\b").Success;
        }

        /// <summary>
        ///     Converts to valid phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns></returns>
        public static string ConvertToValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.StartsWith("+84")) phoneNumber = $"0{phoneNumber.Substring(3)}";
            if (phoneNumber.StartsWith("84")) phoneNumber = $"0{phoneNumber.Substring(2)}";
            return phoneNumber;
        }

        /// <summary>
        ///     Generates the shortener.
        /// </summary>
        /// <returns></returns>
        public static string GenerateShortener()
        {
            var urlsafe = string.Empty;
            Enumerable.Range(48, 75).Where(i => i < 58 || (i > 64 && i < 91) || i > 96)
                .OrderBy(o => new Random().Next()).ToList().ForEach(i => urlsafe += Convert.ToChar(i));
            return urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
        }

        /// <summary>
        ///     Hex2utf8s the specified hexadecimal.
        /// </summary>
        /// <param name="hex">The hexadecimal.</param>
        /// <returns></returns>
        public static string Hex2utf8(string hex)
        {
            try
            {
                var encodedBytes = Enumerable.Range(0, hex.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                    .ToArray();
                var utf8 = new UTF8Encoding();
                var decodedString = utf8.GetString(encodedBytes);
                return decodedString;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        ///     Determines whether [is possible hexadecimal string] [the specified string].
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        ///     <c>true</c> if [is possible hexadecimal string] [the specified string]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPossibleHexStr(string str)
        {
            return str.Length > 10;
        }

        /// <summary>
        ///     Determines whether [is birth year] [the specified string].
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        ///     <c>true</c> if [is birth year] [the specified string]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBirthYear(string str)
        {
            return str.Length == 4 && int.TryParse(str, out _);
        }

        /// <summary>
        ///     Determines whether the specified string is date.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        ///     <c>true</c> if the specified string is date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDate(string str)
        {
            return DateTime.TryParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out _);
        }

        /// <summary>
        ///     Determines whether [is place code] [the specified string].
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        ///     <c>true</c> if [is place code] [the specified string]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPlaceCode(string str)
        {
            return str.Length == 6 && str[2] == '-';
        }

        /// <summary>
        ///     Determines whether the specified string is gender.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        ///     <c>true</c> if the specified string is gender; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGender(string str)
        {
            return str == "1" || str == "2";
        }

        /// <summary>
        ///     Normalizes the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public static string NormalizeAddress(string address)
        {
            return address
                .Trim()
                .ToLower()
                .Replace("tp", "thành phố")
                .Replace("thị trấn", "")
                .Replace("thị xã", "")
                .Replace("thành phố", "")
                .Replace("huyện", "")
                .Replace("xã", "")
                .Replace("quận", "")
                .Replace("phường", "")
                .Replace("tỉnh", "")
                .Replace("t.", "")
                .Replace("p.", "")
                .Replace(",", "")
                .Replace(".", "")
                .Replace(" ", "");
        }

        /// <summary>
        ///     Converts the string to hexadecimal.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public static string ConvertStringToHex(string input, Encoding encoding)
        {
            var stringBytes = encoding.GetBytes(input);
            var sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (var b in stringBytes) sbBytes.AppendFormat("{0:X2}", b);
            return sbBytes.ToString();
        }

        /// <summary>
        ///     Converts the hexadecimal to string.
        /// </summary>
        /// <param name="hexInput">The hexadecimal input.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public static string ConvertHexToString(string hexInput, Encoding encoding)
        {
            var numberChars = hexInput.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2) bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            return encoding.GetString(bytes);
        }

        /// <summary>
        ///     Truncates the name of the patient.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string TruncatePatientName(string text)
        {
            text = text.Trim();
            if (text.LastIndexOf(' ') != -1)
            {
                var lastNameTemp = text.Substring(text.LastIndexOf(' '));
                var firstNameTemp = text.Substring(0, text.LastIndexOf(' ')).Split(" ");
                var splitName1 = "";
                var splitName2 = "";

                if (text.Length >= 20)
                {
                    for (var i = 0; i < firstNameTemp.Length; i++)
                        if (i >= 2)
                            splitName2 += firstNameTemp[i].Substring(0, 1) + " ";
                        else
                            splitName1 += firstNameTemp[i] + " ";
                    return splitName1 + splitName2 + lastNameTemp;
                }
            }

            return text;
        }

        /// <summary>
        ///     Converts the string to object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString">The json string.</param>
        /// <returns></returns>
        public static T ConvertStringToObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        ///     Converts the object to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string ConvertObjectToString<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}