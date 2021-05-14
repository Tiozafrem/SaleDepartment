using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SaleDepartment.Helper
{
    static class PhoneHelper
    {
        private static readonly string error = "Телефон вводится в формате +x(xxx) xxx-xx-xx.Скобки, пробелы, тире могут отсутсвтовать.";
        public static string CheckPhone(string phone)
        {
            
            if (String.IsNullOrWhiteSpace(phone))
                return error;
            if (Regex.IsMatch(phone.Trim(), @"^\+?\d\s?\-?\(?\d{3}\)?\-?\s?\d{3}\-?\s?\d{2}\-?\d{2}$"))
                return String.Empty;
            return error;
        }
    }
}
