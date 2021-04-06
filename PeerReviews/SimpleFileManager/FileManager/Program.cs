using System;
using System.IO;

namespace FileManager {
    partial class Program {
        // Строка CurrentPath хранит текущий путь, с которым работает пользователь.
        static string CurrentPath = GetCurrentDisk();

        /// <summary>
        /// Метод Main содержит основную локигу программы.
        /// Обработчик команд я реализовал через switch/case.
        /// Поэтому получилось немного длиннее, чем я ожидал.
        /// Большинство строковых констант я вынес в файл Constants.cs.
        /// Все методы, реализующие команды вынесены в файл Commands.
        /// Всякого вида обработки я вынес в файл Validates.cs.
        /// </summary>
        static void Main(string[] args) {

            // Вывод приветствия и начальной инфомации для знакомства с программой.
            Console.WriteLine(greetings);
            Console.WriteLine(description);
            Console.WriteLine(avaliableEncodings);
            Console.WriteLine(help + "\n");
            Console.WriteLine(commands);

            // Старт основной части программы.
            do {
                Console.Write("[>] Hit ENTER to start: \n");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);

            Console.Clear();
            // Напоминание про команду help выводится при каждой очистке консоли.
            Console.WriteLine(note);

            // Обработчик команд. В зависимости от поступающей команды вызывается тот или иной метод.
            // Цикл будет выполнятся, пока пользователь не введёт команду exit.
            while (true) {

                // После каждой команды выводится текущий путь.
                Console.Write("\n" + CurrentPath + "> ");
                // Метод SpaceHandler описан в файле Validate.cs.
                // Его задача в правильной обработки пробелов в названии файлов и т.д.
                string[] command = SpaceHandler(Console.ReadLine().Trim());
                // Все методы я загнал в try/catch, чтобы исключить возможность аварийного завершения.
                try {
                    // Все команды приводятся к нижнему регистру, чтобы упростить их обработку.
                    // Для каждой команды выводится свой метод. Все они описаны в файле Commands.cs.
                    switch (command[0].ToLower()) {
                        case "cd":
                            ChangeDirectory(command);
                            break;
                        case "exit":
                            return;
                        case "help":
                            Console.WriteLine(commands);
                            break;
                        case "clean":
                            Console.Clear();
                            Console.WriteLine(note);
                            break;
                        case "dir":
                            PrintDirectoryContent(command);
                            break;
                        case "copy":
                            CopyFile(command);
                            break;
                        case "del":
                            DeleteFileOrDirectory(command);
                            break;
                        case "move":
                            MoveFileOrDirectory(command);
                            break;
                        case "new":
                            CreateFileOrDirectory(command);
                            break;
                        case "print":
                            PrintFile(command);
                            break;
                        case "disks":
                            GetDisks();
                            break;
                        case "":
                            break;
                        case "merge":
                            MergeTextFiles(command);
                            break;
                        default:
                            // Если команды не существует.
                            Console.WriteLine($"[!] Command '{command[0]}' doesn't exist");
                            break;

                    }
                }
                catch {
                    // В случае вылета ошибки в каком-либо из методов выводится седующее сообщение.
                    Console.WriteLine("[!] Something went wrong\n" +
                                      "    Maybe i don't have enought access to do that.\n");
                }
            }

        }
    }
}
