namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        /// <summary>
        /// Converts string to MD5 hash.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Converts string to boolean.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>bool</returns>
        public static bool ToBoolean(this string input)
        {
            // Checks if the input contains a true-like value
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts string to short.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>short</returns>
        public static short ToShort(this string input)
        {
            // Converts input to short
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts string to integer.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>int</returns>
        public static int ToInteger(this string input)
        {
            // Converts input to int
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts string to long
        /// </summary>
        /// <param name="input"></param>
        /// <returns>long</returns>
        public static long ToLong(this string input)
        {
            // Converts input to long
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts string to DateTime.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this string input)
        {
            // Converts input to DateTime
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalize first letter of string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            // Checks if the input is null or empty string then returns it
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            // Else capitalize first letter of input
            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns string between start and end string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="startString"></param>
        /// <param name="endString"></param>
        /// <param name="startFrom"></param>
        /// <returns>string</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts every Cyrillic letter to Latin in string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            // Replace every bulgarian letter in the input with latin
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts every Latin letter to Cyrillic in string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };
            // Replace every Latin letter with Cyrillic
            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts username to be valid.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string ToValidUsername(this string input)
        {
            // Convert input so that it has only latin letters
            input = input.ConvertCyrillicToLatinLetters();
            // Remove every symbol that is not a number, letter, /, _, . and returns new string
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts filename to be valid.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string ToValidLatinFileName(this string input)
        {
            // Replace every whitespace with '-' and every bulgarian letter with latin
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            // Remove every letter, digit, _, ., \, - and returns new string 
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Get first characters in string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="charsCount"></param>
        /// <returns>string</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Get file extension of filename.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>string</returns>
        public static string GetFileExtension(this string fileName)
        {
            // Checks if the filename is null or whitespace
            // then returns empty string
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            // Split filename by .
            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            // Checks if the filename is not correct
            // then returns empty string
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }
            // Returns only extension of filename
            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Get the type of file by it's file extension.
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns>string</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            // Get the type of file
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts string to array of bytes.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>byte[]</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }


    }
}
