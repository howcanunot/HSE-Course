using System;
using System.Collections.Generic;

/*
 * В данном блоке реализованы методы генерации зададанного числа и подсчёт "быков" и "коров".
*/

namespace task {
    partial class Program {

        /*
         * Метод GenerateHiddenNumber генерирует корректное загаданное число.
         * В метод передается только длина, которая должна быть у загаданного числа.
         * Число не начинается с нуля и не содержит других символов, кроме цифр(которые не повторяются).
         * Само число хратится в типе данных string, а не int, чтобы его было удобнее сравнивать с числом игрока.
         * Чтобы в числе не было одинаковых цифт я использовал структуру данных HashSet.
         * Эта структура хранит только уникальные элементы.
         * При генерации очередной цифры я проверял, есть ли она в HashSet'е.
         * Если её там нет, то я добавлял символ к результату и закидывал этот символ в HashSet.
         * Иначе символ генерируется заново.
        */
        public static string GenerateHiddenNumber(int LengthOfNumber) {
            // Создание экземпляра класса Random и HashSet'a, в котором будут храниться использованные символы.
            Random rand = new Random();
            HashSet<char> set = new HashSet<char>();
            // Строка Number хранит само загаданное число.
            string Number = "";

            // Случай, когда длина загаданного числа равна 1(т.е число может начинаться с 0) я обработал отдельно.
            if (LengthOfNumber == 1) {
                Number += (char)(rand.Next(0, 10) + '0');
                return Number;
            }
            // Т.к первая цифра не может быть нулём, то случайная цифра выберается из диапозона от 1 .. 9.
            // После получения цифры, она переводится в char и добавляется к строке Number.
            Number += (char)(rand.Next(1, 10) + '0');
            // Добавление первого символа в HashSet.
            set.Add(Number[0]);

            // Цикл, который собирает загаданное число.
            // Цикл будет работать, пока длина загаданного числа меньше нужной.
            while (Number.Length < LengthOfNumber) {
                //Получение случайно цифры и преобразoвание её в тип char.
                char DigitOfNumber = (char)(rand.Next(0, 10) + '0');

                // если символа нет в HashSet'e прибавляю к Number символ и закидываю этот символ в HashSet.
                if (!set.Contains(DigitOfNumber)) {
                    Number += DigitOfNumber;
                    set.Add(DigitOfNumber);
                }
            }

            return Number;

        }
        /*
         * Метод BullsAmout просто подсчитывает количество "быков".
         * "Бык" есть, если у двух чисел на одинаковых позициях одинаковые цифры.
         * Метод получает 2 строки: загаданную строку и строку игрока.
         * Именно это в методе и проверяется, а результат хранится в count.
        */
        public static int BullsAmount(string HiddenNumber, string PlayerNumber) {
            int count = 0;
            for (int pos = 0; pos < HiddenNumber.Length; pos++)
                if (HiddenNumber[pos] == PlayerNumber[pos])
                    count++;
            return count;
        }

        /*
         * Метод CowsAmount подсчитывает количество "коров".
         * "Корова" есть, если в двух числах есть такие 2 равные цифры, у которых разные позиции.
         * Метод получает 2 строки: загаданную строку и строку игрока.
         * В моём методе PosOfHidden-позиция для загаданного числа.
         * PosOfPlayer-позиция для числа игрока.
         * Результат также хранится в count.
        */
        public static int CowsAmount(string HiddenNumber, string PlayerNumber) {
            int count = 0;
            for (int PosOfHidden = 0; PosOfHidden < HiddenNumber.Length; PosOfHidden++)
                for (int PosOfPlayer = 0; PosOfPlayer < HiddenNumber.Length; PosOfPlayer++)
                    if (HiddenNumber[PosOfHidden] == PlayerNumber[PosOfPlayer] && PosOfHidden != PosOfPlayer)
                        count++;
            return count;
        }
    }
}
