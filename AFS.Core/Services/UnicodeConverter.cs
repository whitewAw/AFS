using System.Globalization;
using System.Text.RegularExpressions;

namespace AFS.Core.Services
{
    internal class UnicodeConverter
    {
        static Regex rx = new Regex(@"\\[uU]([0-9A-F]{4})");
        internal static string UnicodeEscapesIntoUnicodeCharacters(string str)
        {
            return rx.Replace(str, match => ((char)Int32.Parse(match.Value.Substring(2), NumberStyles.HexNumber)).ToString());
        }
    }
}
