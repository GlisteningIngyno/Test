using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_Задание
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 задание
            GenerateFillArray(100);
            //2 задание
            SearchRepeatChar("Hello");
            //3 задание
            BaseConverter bconvert = new BaseConverter();
            bconvert.Convert(Console.ReadLine());
            //4 задани
            CalcСornerClock(23,1);

            Console.ReadLine();
        }
        static void GenerateFillArray(int len)
        {
            float[] array = new float[len];
            float max = float.MinValue;
            float min = float.MaxValue;
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (float)random.NextDouble();
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }
            float ave = array.Sum() / array.Length;
            Console.WriteLine($"Мax = {max}, Min = {min}, Ave = {ave}\n");
        }
        static void SearchRepeatChar(string input)
        {
            HashSet<char> table = new HashSet<char>();
            HashSet<char> tableRepeat = new HashSet<char>();

            input = input.ToLower();
            Console.Write("Повторяющие символы - ");
            foreach (char c in input) 
            {
                if (!table.Contains(c)) table.Add(c) ;
                else
                {   
                    if (tableRepeat.Add(c)) Console.Write("{0}, ", c);
                }
            }
            Console.WriteLine();
        }
        static void CalcСornerClock(int hours, int minutes)
        {
            if (hours > 12) hours -= 12;
            double divisionMinut = 360 / 60;
            double divisionHourse60min = 5 * divisionMinut;
            double divisionHourse1min = divisionHourse60min / 60;

            double valMinutes = minutes * divisionMinut;
            double valHours = hours * divisionHourse60min + minutes * divisionHourse1min;

            double cornerOne = Math.Abs(valMinutes - valHours);
            Console.WriteLine("Угол составил  - {0}", cornerOne);
        }
    }
    public class BaseConverter
    {
        public BaseConverter()
        {
            Console.Write("\nВведите значение температуры в С : ");
        }
        public double Convert(string str)
        {
            double temp;
            while(!double.TryParse(str, out temp))
            {
                Console.WriteLine("Неверный формат входных данных. Повторите ввод.\n");
                Console.Write("Введите значение температуры в С : ");
                str = Console.ReadLine();
            }

            Console.WriteLine("Выберите формат конвертации [К/ф]");
            var input = Console.ReadKey(true);
            while (input.Key != ConsoleKey.R && input.Key != ConsoleKey.A)
            {
                input = Console.ReadKey(true);
            }

            double result = 0;
            switch (input.Key)
            {
                case ConsoleKey.R:
                    result = ConvertKelvin(temp);
                    Console.WriteLine("Результат конвертации - {0}К\n",result);
                    break;
                case ConsoleKey.A:
                    result =  ConvertFahrenheit(temp);
                    Console.WriteLine("Результат конвертации - {0}F\n", result);
                    break;
            }
            return result;
        }
        private double ConvertKelvin(double temp)
        {
            double result = temp + 273.15;
            return result;
        }
        private double ConvertFahrenheit(double temp)
        {
            double result = (9/5 * temp) + 32;
            return result;
        }
    }

}
