using System;

namespace task {
    partial class Program {

        /*
         * Этот метод проверяет введёную пользователем желаемую длину загаданного числа на натуральность и корректность(<10).
        */
        public static bool CheckLength(int number) {
            return number > 0 && number <= 10;
        }

        /*
         * Метод CheckDigitDuplicates проверяет, что у введеного пользователем числа нет одинаковых цифр.
         * Этот метод вызывается после того, как число, ввёденное пользователем, прошло другие проверки.
         * Метод использует массив для подсчёта количества цифр.
         * В конце в цикле, если какая-то цифра встретилась больше 1 раза, выводится false, иначе true.
         * Также метод получет именно число в типе ulong, а не строку.
         * Хотя можно было бы и передовать строку, разницы нет.
        */
        public static bool CheckDigitDuplicates(ulong number, int Length) {

            // Массив хранит количество каждой цифры.
            int[] DigitsCount = new int[10];

            // Заполнение массива DigitCounts.
            while (number > 0) {
                DigitsCount[number % 10]++;
                number /= 10;
            }

            // Проверка корректности.
            for (int pos = 0; pos < 10; pos++)
                if (DigitsCount[pos] > 1)
                    return false;

            return true;
        }
    }
}
