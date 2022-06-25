using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NumeralSystemOperations
{
    public static class Numerals
    {
        #region FIELDS

        private const int MaxBase = 36;
        
        private readonly static ArgumentException BaseTooBigEx = new ArgumentException("Base number cannot exceed 36.");

        private readonly static ArgumentException InvalidDigitsEx = new ArgumentException("Number must consist exclusively of numeric or alphabetic digits.");

        private readonly static ArgumentException MismatchEx = new ArgumentException("Number does not match given base.");

        #endregion

        #region PUBLIC
        public static string ConvertNumericSystem(string numberToConvert, int currentBase, int targetBase)
        {
            if (currentBase > MaxBase || targetBase > MaxBase)
            {
                throw BaseTooBigEx;
            }

            if (InputIsValidNumber(numberToConvert))
            {
                throw InvalidDigitsEx;
            }

            numberToConvert = numberToConvert.ToUpper();

            if (!NumberMatchesBase(numberToConvert, currentBase))
            {
                throw MismatchEx;
            }

            if (currentBase == targetBase)
            {
                return numberToConvert;
            }

            decimal numberToConvertDecimal;

            if (currentBase == 10)
            {
                numberToConvertDecimal = decimal.Parse(numberToConvert);
            }
            else
            {
                numberToConvertDecimal = DecimalFromNumber(numberToConvert, currentBase);
            }

            if (targetBase == 10)
            {
                return numberToConvertDecimal.ToString();
            }

            return TrimStrayZeroes(NumberFromDecimal(numberToConvertDecimal, targetBase));
        }

        public static bool NumberMatchesBase(string numberToVerify, int baseToVerify)
        {            
            if (baseToVerify > MaxBase)
            {
                return false;
            }

            if (baseToVerify == 1)
            {
                foreach(char c in numberToVerify)
                {
                    if (c != '1')
                    {
                        return false;
                    }
                }
                return true;
            }

            if (baseToVerify <= 10)
            {
                foreach(char c in numberToVerify)
                {
                    if (!CharIsDigitLowerThan(c, baseToVerify) && (c != '.'))
                    {
                        return false;
                    }
                }
            }
            else
            {
                foreach (char c in numberToVerify)
                {
                    if (!(char.IsDigit(c) || (CharIsUpperCaseLetter(c) && IntValueFromAlphabeticDigit(c) < baseToVerify) || (c == '.')))
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        #endregion

        #region PRIVATE
                
        private static bool InputIsValidNumber(string inputToCheck)
        {
            bool containsComma = false;

            foreach (char ch in inputToCheck)
            {
                
                if (!(
                    ch == '.' != containsComma
                    && (char.IsDigit(ch)
                    || CharIsLowerCaseLetter(ch)
                    || CharIsUpperCaseLetter(ch)
                    )))
                {
                    return false;
                }
                if (!containsComma) containsComma = ch == '.';
            }
            return true;

        }

        private static int IntValueFromAlphabeticDigit(char alphabeticDigit)
        {
            return (byte)alphabeticDigit - 55;
        }

        private static char AlphabeticDigitFromIntValue(int value)
        {
            return (char)(value + 55);
        }

        private static bool CharIsUpperCaseLetter(char ch)
        {
            return char.GetUnicodeCategory(ch) == UnicodeCategory.UppercaseLetter;
        }

        private static bool CharIsLowerCaseLetter(char ch)
        {
            return char.GetUnicodeCategory(ch) == UnicodeCategory.LowercaseLetter;
        }

        private static bool CharIsDigitLowerThan(char ch, int number)
        {
            return char.IsDigit(ch) && int.Parse(ch.ToString()) < number;
        }

        private static bool CharHasIndexInRange(char charToCheck, int minRange, int maxRange)
        {
            return (byte)charToCheck >= minRange && (byte)charToCheck <= maxRange;
        }

        private static string TrimStrayZeroes(string inputString)
        {
            string result = inputString;

            while (result.Length > 1 && result[0] == '0')
            {
                result = result.Substring(1, result.Length-1);
            }
            return result;
        }

        private static string NumberFromInteger(int intToConvert, int targetBase)
        {
            if (targetBase == 1)
            {
                return IntegerToUnary(intToConvert);
            }
            
            string result = string.Empty;

            char charToAdd = '0';

            int valueToAdd = intToConvert % targetBase;

            int remainingValue = intToConvert / targetBase;

            if (valueToAdd > 0 && valueToAdd < 10)
            {
                charToAdd = (char)(valueToAdd + 48);
            }
            else if (valueToAdd >= 10)
            {
                charToAdd = AlphabeticDigitFromIntValue(valueToAdd);
            }

            result += charToAdd;

            if (remainingValue > 0)
            {
                result = NumberFromInteger(remainingValue, targetBase) + result;
            }

            return result;
        }

        private static int IntegerFromNumber(string numberToConvert, int currentBase)
        {
            if (currentBase == 1)
            {
                return UnaryToInteger(numberToConvert);
            }
            
            int length = numberToConvert.Length;

            char c = numberToConvert[0];

            byte cIndex = Convert.ToByte(c);

            int currentValue = 0;

            if (char.IsDigit(c))
            {
                currentValue = (cIndex - 48) * (int)Math.Pow(currentBase, length - 1);
            }
            else if (CharIsUpperCaseLetter(c))
            {
                currentValue = IntValueFromAlphabeticDigit(c) * (int)Math.Pow(currentBase, length - 1);
            }

            if (length > 1)
            {
                string remainingValue = numberToConvert.Substring(1, length - 1);
                currentValue += IntegerFromNumber(remainingValue, currentBase);
            }

            return currentValue;
        }

        private static int UnaryToInteger(string numberToConvert)
        {
            int result = 0;

            for (int i = 1; i <= numberToConvert.Length; i++)
            {
                result += 1;
            }

            return result;
        }

        private static string IntegerToUnary(int numberToConvert)
        {
            string result = string.Empty;

            for (int i = 1; i <= numberToConvert; i++)
            {
                result = '1' + result;
            }

            return result;
        }

        private static decimal DecimalFromNumber(string numberToConvert, int currentBase)
        {
            string fractionPart = SubstringDigitsOnOneSideOfComma(numberToConvert, true);
            string wholePart = SubstringDigitsOnOneSideOfComma(numberToConvert, false);
            
            int wholePartConverted = IntegerFromNumber(wholePart, currentBase);

            decimal fractionPartConverted = 0;

            int pow = 0;

            foreach (char digit in fractionPart)
            {
                pow -= 1;

                int digitValue = CharIsUpperCaseLetter(digit) ? IntValueFromAlphabeticDigit(digit) : int.Parse(digit.ToString());

                decimal value = digitValue * (decimal)Math.Pow(currentBase, pow);

                fractionPartConverted += value;
            }

            return wholePartConverted + fractionPartConverted;
        }

        private static string NumberFromDecimal(decimal decimalToConvert, int targetBase)
        {
            int wholePart = (int)Math.Truncate(decimalToConvert);
            decimal fractionPart = decimalToConvert - (int)Math.Truncate(decimalToConvert);

            string wholePartConverted = NumberFromInteger(wholePart, targetBase);

            if (fractionPart == 0) return wholePartConverted;

            string fractionPartConverted = ".";

            decimal remainder = fractionPart;
            
            for (int pow = -1; pow >= -20; pow--)
            {
                decimal digitValue = 0;
                decimal singleDigitValue = (decimal)Math.Pow(targetBase, pow);

                if (singleDigitValue > remainder) 
                {
                    fractionPartConverted += 0;
                    continue;
                }

                int multiplier = 0;

                while ((remainder - singleDigitValue >= digitValue) && multiplier < targetBase - 1)
                {
                    digitValue += singleDigitValue;
                    multiplier++;
                }


                fractionPartConverted += (multiplier > 9 ? AlphabeticDigitFromIntValue(multiplier) : multiplier.ToString());

                remainder -= digitValue;
                if (remainder == 0) break;
            }

            if (remainder != 0) fractionPartConverted += "...";

            return wholePartConverted + fractionPartConverted;
        }

        private static string SubstringDigitsOnOneSideOfComma(string number, bool afterComma = false)
        {
            string result = string.Empty;
            
            bool commaIsLocated = false;

            foreach(char ch in number)
            {
                if (ch == ',' || ch == '.')
                {
                    commaIsLocated = true;
                }
                else if (commaIsLocated == afterComma && ch != '-')
                {
                    result += ch;
                }
                
                if (commaIsLocated && !afterComma)
                {
                    break;
                }

            }

            return result.Trim();
        }

        #endregion
    }
}
