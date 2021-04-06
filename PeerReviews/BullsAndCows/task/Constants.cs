﻿using System;

namespace task {

    /*
     * Этот файл просто содержит строковые константы, которые я посчитал слишком длинными.
     * Поэтому решено было их вынести в отдельный файл.
    */
    partial class Program {
        // Строка приветствия игрока.
        static string Greeting =
                          "+--------------------------------------------------------------------------------------+\n" +
                          "|         Привет! Давай сыграем в игру 'Быки и Коровы'.                                |\n" +
                          "|         Суть игры очень проста : я загадываю n - значное натуральное число,          |\n" +
                          "|         (n ты выбираешь сам), n будет не больше 9.                                   |\n" +
                          "|         Тебе нужно понять, какое число я загадал. Сделать это несложно:              |\n" +
                          "|                                                                                      |\n" +
                          "|               1. Ты можешь вводить какое-то n - значное натуральное число.           |\n" +
                          "|               2. Я буду говорить тебе о том, сколько цифр(коров) угадано,            |\n" +
                          "|                  но не расположено на своих местах,                                  |\n" +
                          "|                  и сколько цифр(быков) угадано и находится на своих местах.          |\n" +
                          "|               3. После чего ты переходишь обратно к шагу 1.                          |\n" +
                          "|                                                                                      |\n" +
                          "|         Я обещаю, что загаданное число будет корректным, то есть не будет:           |\n" +
                          "|                                                                                      |\n" +
                          "|               1. Ненатуральным или начинаться с нуля.                                |\n" +
                          "|               2. Содержать одинаковые цифры.                                         |\n" +
                          "|               3. Содержать другие символы, кроме цифр.                               |\n" +
                          "|                                                                                      |\n" +
                          "|         Раунды будут продолжаться, пока ты не угадаешь число.                        |\n" +
                          "|         Если ты захочешь сдаться, введи /surrender в любом регистре.                 |\n" +
                          "|         Если ты захочешь экстренно закрыть игру, нажми крестик в консоли.            |\n" +
                          "|         А теперь, давай начнем. =)                                                   |\n" +
                          "+--------------------------------------------------------------------------------------+\n";
        // Сообщение о том, что игрок ввёл некорректную длину загаданного числа.
        static string IncorrectLengthInput = "Пожалуйста, выбери корректное значение n " +
                    "(n должно быть натуральным числом, меньшим 10): ";
        // Сообщение о том, что игрок ввёл некорректное значние предпалагаемого числа.
        static string IncorrectPlayerNumber = "Пожалуйста, введи корректное число нужной длины без одинаковых цифр: ";

    }
}
