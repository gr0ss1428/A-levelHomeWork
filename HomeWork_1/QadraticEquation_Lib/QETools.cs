using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QadraticEquation_Lib
{
    public class QETools
    {
        public static double GetDiscriminant(double a, double b, double c)
        {
            return Math.Pow(b, 2) - (4 * a * c);
        }
        public static double GetX1(double D, double b, double a)
        {
            b *= -1;
            return (b - Math.Sqrt(D)) / (2 * a);
        }
        public static double GetX2(double D, double b, double a)
        {
            b *= -1;
            return (b + Math.Sqrt(D)) / (2 * a);
        }
        public static int ParseValue(string strValue, ref double value)
        {

            /*
             * Да можно было бы использовать *.TryParse но в таком случае я не узнаю по какой причине не произошла конвертация
             * но так как тут используется не int то это слегда бессмысленно, в double очень большое значение надо вводить для OverflowException если только перегрузить метод для использования int
             * а возможно надо было бы делать что то из разряда обобщенную функцию аля  int ParseValue<T>(string strValue, ref T value) но тогда я не знаею как сделать преобразования типа
             * */
            try
            {
                value = double.Parse(strValue);
            }
            catch (FormatException )
            {
                return 1;
            }
            catch (OverflowException)
            {
                return 2;
            }
            return 0;

        }
        
        public static string LinMult(double a, double b, double c, double x1, double x2)
        {
            
            string linStr = String.Empty;
            //ax2+bx+c=a(x-x1)(x-x2)
            linStr+=QEToString(a, b, c);
            if (x1 != 0 && x2 != 0)
            {
                if (Math.Abs(x1) > Math.Abs(x2))
                {
                    x2 *= a;
                    if (x1 < 0) linStr += String.Format("(x+{0})", Math.Abs(x1));
                    else if (x1 > 0) linStr += String.Format("(x-{0})", x1);
                    if (x2 < 0) linStr += String.Format("({0}x+{1})", GetValString(a), Math.Abs(x2));
                    else if (x2 > 0) linStr += String.Format("({0}x-{1})",GetValString(a), x2);
                }
                else
                {
                    x1 *= a;
                    if (x1 < 0) linStr += String.Format("({0}x+{1})", GetValString(a), Math.Abs(x1));
                    else if (x1 > 0) linStr += String.Format("({0}x-{1})", GetValString(a), x1);
                    if (x2 < 0) linStr += String.Format("(x+{0})", Math.Abs(x2));
                    else if (x2 > 0) linStr += String.Format("(x-{0})", x2);

                }
               
            }
            else if(x1==0&&x2!=0)
            {
                linStr += "x";
                x2 *= a;
                if (x2 < 0) linStr += String.Format("({0}x+{1})",a, Math.Abs(x2));
                else if (x2 > 0) linStr += String.Format("({0}x-{1})",a,x2);

            }
            else if(x1!=0&&x2==0)
            {
                linStr +=  "x";
                x1 *= a;
                if (x1 < 0) linStr += String.Format("({0}x+{1})",a, Math.Abs(x1));
                else if (x1 > 0) linStr += String.Format("({0}x-{1})",a, x1);
            }
            else linStr += "0";
            return linStr;
            string result = String.Format("{0}x² + {1}x + {2} = {0}(x - {3})(x - {4})", a,b,c,x1,x2);
            result.Replace("--", "+");
            result.Replace("+-", "-");
        }
        public static string QEToString(double a,double b,double c)
        {
            string qeString = String.Empty;
            qeString += GetValString(a) + "x² ";
            if(b<0) qeString += GetValString(b) + "x ";
            else if(b>0) qeString +="+"+GetValString(b) + "x ";
            if (c < 0) qeString +=c.ToString();
            else if (c > 0) qeString += "+" + c.ToString();
            return qeString+"=";
        }
        private static string GetValString(double val)
        {
            if (val == 1) return String.Empty;
            else if (val == -1) return "-";
            else return val.ToString();
        }
    }
}
