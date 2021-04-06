using System;
using System.Threading;

namespace task {
    partial class Program {

        /*
         * Метод ReadPlayerNumber считывает попытки игрока угадать число и проверяет их на корректность.
         * Если данные некорректны, выводится сообщение об ошибке и ввод запрашивается заново.
         * Также в ReadPlayerNumber вызывается метод CheckDigitDuplicates, который описан в файле Validates.cs.
         * Метод получает строку и длину, которой она должна быть.
        */
        public static string ReadPlayerNumber(string Line, int Length) {

            // Возможность сдаться.
            if (Line.ToLower() == "/surrender")
                return "flag";

            // Переменная number нужна, чтобы не проверять Line на отсутствие других символов вручную.
            // Если метод TryParse() вернет false - значит во входной строке есть другие символы, или число отрицательно.
            ulong number;

            // Также обработал числа, которые начинаются с нуля и которые по длине не совподают с Length.
            while (!ulong.TryParse(Line, out number) || (Line[0] == '0' && Length != 1) || Line.Length != Length
                || !CheckDigitDuplicates(number, Length)) {
                // Если ввод был некорректным игроку выведится сообщение об ошибки красным цветом.
                // После этого программа попросить игрока введи число заново.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(IncorrectPlayerNumber);
                Line = Console.ReadLine();
            }
            return Line;
        }

        /*
         * Метод ReadLength делает тоже самое, что и ReadPlayerNumber, только для начальной длины загаданного числа.
         * Также я отдельно вынес функцию CheckLength, которая проверяет длину на положительность и корректность (<10).
         * Хотя этого можно было и не делать, но мне просто захотелось.
         * Метод CheckLength описан в файле Validates.cs.
        */
        public static int ReadLength(string Line) {
            int number;
            Console.WriteLine();
            while (!int.TryParse(Line, out number) || !CheckLength(number)) {
                // Если ввод был некорректным игроку выведится сообщение об ошибки красным цветом.
                // После этого программа попросить игрока введи число заново.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(IncorrectLengthInput);
                Line = Console.ReadLine();
                Console.WriteLine();
            }

            return number;

        }

        /*
         * Метод ThoughtsImitaion нужно только, чтобы сделать видимость того, что компьютер "загадывает" число.
         * Никакой другой функции метод не несёт и является чисто декоротивным.
        */
        public static void ThoughtsImitation() {
            for (int iter = 0; iter < 3; iter++) {
                // После вывода каждой точки, программа "засыпает" на 1 секунды.
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.Write("\n");
        }
    }
}
