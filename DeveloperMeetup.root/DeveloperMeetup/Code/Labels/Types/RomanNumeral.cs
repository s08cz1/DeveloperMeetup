using System.Linq;
using DeveloperMeetup.Code.Labels.Interfaces;

namespace DeveloperMeetup.Code.Labels.Types
{
    /// <summary>
    /// Code below is borrowed from StackOverflow
    /// </summary>
    public class RomanNumeral : ILabel
    {
        public string GetLabel(int position)
        {
            var romanNumerals = new string[][]
            {
                new string[]{"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"}, // ones
                new string[]{"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"}, // tens
                new string[]{"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"}, // hundreds
                new string[]{"", "M", "MM", "MMM"} // thousands
            };

            // split integer string into array and reverse array
            var intArr = position.ToString().Reverse().ToArray();
            var len = intArr.Length;
            var romanNumeral = "";
            var i = len;

            // starting with the highest place (for 3046, it would be the thousands 
            // place, or 3), get the roman numeral representation for that place 
            // and add it to the final roman numeral string
            while (i-- > 0)
            {
                romanNumeral += romanNumerals[i][int.Parse(intArr[i].ToString())];
            }

            return romanNumeral;
        }
    }
}
