using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz_Lib
{
    public class FizzBuzzTools
    {
        public const uint defaultDivider1 = 3;
        public const uint defaultDivider2 = 5;
        public const int defaultStart = 1;
        public const int defaultEnd = 100;
        public static List<string> FizzBuzzLstString(int? start,int? end,uint? divider1, uint? divider2,uint column=20)
        {
            string strFizzBuzz = String.Empty;
            List<string> strList = new List<string>();
            if(start<end)
            {
                for(var i=start;i<=end;i++)
                {
                    if (i % divider1 == 0) strFizzBuzz += "Fizz";
                    if (i % divider2 == 0) strFizzBuzz += "Buzz";
                    if (i % divider1 != 0 && i % divider2 != 0) strFizzBuzz += i.ToString();
                    strFizzBuzz += " ";
                    if (i % column == 0 && i!=0)
                    {
                        strList.Add(strFizzBuzz);
                        strFizzBuzz = String.Empty;
                    }
                }
            }
            else
            {
                for (var i = start; i >= end; i--)
                {
                    if (i % divider1 == 0) strFizzBuzz += "Fizz";
                    if (i % divider2 == 0) strFizzBuzz += "Buzz";
                    if (i % divider1 != 0 && i % divider2 != 0) strFizzBuzz += i.ToString();
                    strFizzBuzz += " ";
                    if (i % column == 0 && i!=0)
                    {
                        strList.Add(strFizzBuzz);
                        strFizzBuzz = String.Empty;
                    }
                }
            }
            strList.Add(strFizzBuzz);
            return strList;
        }
        public static bool PrimeNumber(uint? number)
        {
            for(uint i=2; i<number;i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        public static string FizzBuzzPatternString(int? start, int? end, uint? divider1, uint? divider2)
        {
            return String.Format("({0}...{1})({2}|{3})",start,end,divider1,divider2);
        }
    }
}
