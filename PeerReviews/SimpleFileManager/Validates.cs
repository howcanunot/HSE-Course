using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace FileManager {
    partial class Program {

        /// <summary>
        /// Проверка абсолютного пути на корректность.
        /// </summary>
        /// <param name="path">Путь, который нужно проверить.</param>
        /// <returns>true | false.</returns>
        public static bool ValidateAbsolutePath(string path) {
            if (Directory.Exists(GetRightPath(path)) && path != "..")
                return true;
            return false;
        }

        /// <summary>
        /// Преобразует путь в нормальный вид в зависимости от платформы.
        /// </summary>
        /// <param name="path">Путь для обработки.</param>
        /// <returns>Обработанный путь.</returns>
        public static string GetRightPath(string path) {
            if (path == "..")
                return path;
            // Для Windows.
            if (GetCurrentDisk()[0] != '/') {
                path = path.Replace('/', '\\');
                string[] partPath = path.Split('\\');
                string rightPath = "";
                foreach (var item in partPath)
                    if (item != "")
                        rightPath += (item) + "\\";
                return rightPath;
            }
            // Для Mac Os & Linux.
            else {
                path = path.Replace('\\', '/');
                string[] partPath = path.Split('/');
                string rightPath = path[0] == '/' ? "/" : "";
                foreach (var item in partPath)
                    if (item != "")
                        rightPath += (item) + "/";
                return rightPath;
            }
        }

       /// <summary>
       /// Обрабатывет входные команды. Убирает лишние проблемы.
       /// Для решения пробелмы с пробелом в названиях файлов и папок я решил использовать "".
       /// </summary>
       /// <param name="input">Входная строка.</param>
       /// <returns>Массива строк, состоящий из входных аргументов.</returns>
        public static string[] SpaceHandler(string input) {
            // stringList хранит введённые аргументы, разделенные пробелом.
            var stringList = new List<string>();
            string str = "";
            // Цикл обработки команд.
            for (int i = 0; i < input.Length; i++) {
                // Если есть ".
                if (input[i] == '"') {
                    i++;
                    while (input[i] != '"')
                        str += input[i++];
                }
                else if (input[i] != ' ')
                    str += input[i];
                else if (input[i] == ' ' && str != "") {
                    stringList.Add(str);
                    str = "";
                }

            }
            stringList.Add(str);
            string[] command = new string[stringList.Count];
            for (int i = 0; i < command.Length; i++) command[i] = stringList[i];
            return command;
        }

        /// <summary>
        /// Получет текст с консоли, чтобы записать его в файл.
        /// Ввод текста заканчивается, когда пользователь вводит строку //null.
        /// </summary>
        /// <returns>Строку с разделителями для файла.</returns>
        public static string GetTextFromConsole() {
            Console.WriteLine("[>] Enter your text. Enter //null on new line to end\n");
            List<string> lines = new List<string>();
            // Пока не будет введена строка //null.
            do {
                lines.Add(Console.ReadLine());
            } while (lines[lines.Count - 1] != "//null");

            string stringText = "";
            // Запись всех строк в одну и добавление разделителей.
            for (int i = 0; i < lines.Count() - 1; i++)
                stringText += lines[i] + "\n";
            if (stringText == "")
                stringText = "Empty file\n";
            return stringText;
        }

        /// <summary>
        /// Проверка введённой кодировки на корректность из списка доступных кодировок.
        /// </summary>
        /// <param name="encoding">Ввeденная кодировка.</param>
        /// <returns>true | false.</returns>
        public static bool ValidateEncoding(string encoding) {
            if (encoding != "UTF-8" && encoding != "UNICODE" && encoding != "ASCII"
                && encoding != "DEFAULT" && encoding != "UTF-16")
                return false;
            return true;
        }
        /// <summary>
        /// Возвращает кодировку в зависимости от строки с названием кодировки.
        /// </summary>
        /// <param name="encoding">Кодировка в виде строки.</param>
        /// <returns>Свойство класса Encoding.</returns>
        public static Encoding GetRightEncoding(string encoding) {
            switch (encoding) {
                case "UTF-8":
                    return Encoding.UTF8;
                case "ASCII":
                    return Encoding.ASCII;
                case "UTF-16":
                    return Encoding.Unicode;
                case "UNICODE":
                    return Encoding.Unicode;
                case "DEFAULT":
                    return Encoding.Default;
                default:
                    return Encoding.UTF8;
            }
        }

        /// <summary>
        /// Обрабатывает путь(заменяет слеши на нужные, приводит к нижнему регистру и т.д.).
        /// Путь обрабывается по-разному в зависимости от платформы.
        /// </summary>
        /// <param name="path">Путь, который нужно обработать.</param>
        public static void PathHandler(string path) {
            // Для Windows.
            if (GetCurrentDisk() != "/") {
                // Для абсолютного пути.
                if (path.Contains(':') && Directory.Exists(path)) {
                    CurrentPath = path[path.Length - 1] == '\\' ? path : path + "\\";
                    CurrentPath = path[0].ToString().ToUpper() + CurrentPath.Substring(1);
                }
                // Для относительного пути.
                else if (Directory.Exists(CurrentPath + path))
                    CurrentPath += path[path.Length - 1] == '\\' ? path : path + "\\";
                else
                    Console.WriteLine(IncorrectPath);
            }
            // Для Mac OS & Linux.
            else {
                // Для абсолютного пути.
                if (path[0] == '/' && Directory.Exists(path)) {
                    CurrentPath = path[path.Length - 1] == '/' ? path : path + "/";
                }
                // Для относительно пути.
                else if (Directory.Exists(Path.Combine(CurrentPath, path)))
                    CurrentPath += path[path.Length - 1] == '/' ? path : path + "/";
                else
                    Console.WriteLine(IncorrectPath);
            }
        }

        /// <summary>
        /// Получает текст из файлов и сохраняет его в одну строку для нового файла.
        /// </summary>
        /// <param name="command">
        /// command[0]=название команды.
        /// command[1]=название(путь) файла.
        /// command[n-1]=название(путь) файла.
        /// command[n]=название нового файла.
        /// </param>
        /// <returns>Строку с текстом для нового файла.</returns>
        public static string GetFilesText(string[] command) {
            string text = "";
            // Цикл обработки и получения текста для абсолютного и относительно пути.
            for (int i = 1; i < command.Length - 1; i++)
                if ((command[i][0] == '/' || command[i].Contains(':')) && File.Exists(command[i]))
                    text += File.ReadAllText(command[i]);
                else if (File.Exists(Path.Combine(CurrentPath, command[i])))
                    text += File.ReadAllText(Path.Combine(CurrentPath, command[i]));
            // Если хотя бы одного файла не существует.
                else
                    return "-1";
            return text;
        }

    }
}
