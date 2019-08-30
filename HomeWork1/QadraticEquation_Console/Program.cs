using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QadraticEquation_Lib;

namespace QadraticEquation_Console
{
    class Program
    {

        static void Main(string[] args)
        {

            double a;
            double b;
            double c;
            double D;
            double x1;
            double x2;
            for (; ; )
            {
                 x1 = 0;
                 x2 = 0;

                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("ax²+bx+c=0");

                a = GetValueFromUser("a");
                b = GetValueFromUser("b");
                c = GetValueFromUser("c");
                if (b != 0 && c != 0)
                {
                    D = QETools.GetDiscriminant(a, b, c);
                    Console.WriteLine(QETools.QEToString(a, b, c) + "0");
                    if (D < 0) Console.WriteLine("Квадратное уровнение не имеет корней. D={0} (D<0)", D);
                    else if (D == 0)
                    {
                        x1 = x2 = QETools.GetX1(D, b, a);
                        Console.WriteLine("Уровнение имеет два равных корня x1=x2={0}", x1);
                    }
                    else if (D > 0)
                    {
                        x1 = QETools.GetX1(D, b, a);
                        x2 = QETools.GetX2(D, b, a);
                        Console.WriteLine("Уровнение имеет два корня x1={0}, x2={1}", x1, x2);
                    }
                    if (D >= 0)
                    {


                        Console.WriteLine(QETools.LinMult(a, b, c, x1, x2));


                    }
                }
                else Console.WriteLine("Уровнение не имеет смысла b=0,c=0");
                Console.Write("Решить ещё уровнение (y):");
                string nextRun = Console.ReadLine();
                if (nextRun == "y" || nextRun == "Y")
                {
                    Console.Clear();
                    
                }
                else
                {
                    Console.WriteLine();
                    break;
                }

            }


        }
        static double GetValueFromUser(string val)
        {
            string strValue;
            for (; ; )
            {
                Console.Write("Введите число (" + val + ") :");
                strValue = Console.ReadLine();
                if (strValue != String.Empty)
                {
                    double tempV = 0;

                    int valErr = 0;

                    try
                    {
                        valErr = QETools.ParseValue(strValue, ref tempV);
                        if (valErr == 0)
                        {
                            if (val == "a")
                            {
                                if (tempV == 0) ErrorMessage(val, 4);
                                else return tempV;
                            }
                            else return tempV;
                        }
                        else ErrorMessage(val, valErr);
                    }
                    catch(Exception ex)
                    {
                        ErrorMessage(ex.Message,3);
                    }
                    
                }

            }
        }
        static void ErrorMessage(string val, int err)
        {
            switch (err)
            {
                case 1:
                    Console.WriteLine("Ваше числo (" + val + ") имеет не верный формат (возможно есть буквы в числе). Повторите ввод.");
                    break;
                case 2:
                    Console.WriteLine("Ваше число (" + val + ") не входит в допустимый диапазон чисел. Повторите ввод.");
                    break;
                case 3:
                    Console.WriteLine("Произошла непредвиденная ошибка \" " + val +  " \". Повторите ввод.");
                    break;
                case 4:
                    Console.WriteLine("Первый  коэффициент (" + val + ") не должен равняться 0. Повторите ввод.");
                    break;

            }

        }
    }
}
