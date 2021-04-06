using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace FileManager {
    partial class Program {

        /// <summary>
        /// Возвращает диск, на котором расположена папка с проектом.
        /// Именно с этого диска начнёт работу программа.
        /// Если прогамма запущена на мака, возвращается /.
        /// </summary>
        /// <returns>Строку с диском, на котором запущен проект.</returns>
        public static string GetCurrentDisk() {
            if (Directory.GetCurrentDirectory()[0] != '/')
                return Directory.GetCurrentDirectory()[0] + ":\\";
            return "/";
        }

        /// <summary>
        /// Этот метод вызывется пр команде cd и изменяет путь, в зависимости от параметра.
        /// Пользователь может передовать абсолютный и относительный путь.
        /// </summary>
        /// <param name="directoryPath">путь к директории, к которой хочет перейти пользователь.</param>
        public static void ChangeDirectory(string[] directoryPath) {
            // В команде cd не может быть больше 2 элементов.
            if (directoryPath.Length > 2 || directoryPath.Length < 2) {
                Console.WriteLine(IncorrectPath + "\n");
                return;
            }
            // Для более удобной обработки я все приводил к нижнему регистру.
            string path = directoryPath[1].ToLower();
            // Метод GetRightPath описан в Validates.cs.
            path = GetRightPath(path);
            // Если пользователь хочет перейти на директорию назад.
            if (path == "..")
                GoBack();
            else
                PathHandler(path);
            
        }

        /// <summary>
        /// Метод GoBack спускает текущий путь на дерикторию назад.
        /// В зависимости от системы, на которой запущена программа.
        /// </summary>
        public static void GoBack() {
            // Для Windows.
            if (GetCurrentDisk()[0] != '/') {
                string[] partPath = CurrentPath.Split('\\');
                if (partPath.Length <= 2)
                    return;
                CurrentPath = "";
                for (int i = 0; i < partPath.Length - 2; i++)
                    CurrentPath += partPath[i] + "\\";
            }
            // Для Mac Os & Linux.
            else {
                string[] partPath = CurrentPath.Split('/');
                if (partPath.Length <= 2)
                    return;
                CurrentPath = "";
                for (int i = 0; i < partPath.Length - 2; i++)
                    CurrentPath += partPath[i] + "/";
            }

        }
        /// <summary>
        /// Выводит информацию о том, что хранится в директории.
        /// Для этого сначала выводятся все вложенные папки, затем все файлы.
        /// Для этого написаны ещё 2 метода.
        /// Метод работает как для текущей папки, так и для абсолютного пути.
        /// </summary>
        /// <param name="command">
        /// command[0]=команда.
        /// comand[1]=путь у директории(необязательный аргумент).
        /// </param>
        public static void PrintDirectoryContent(string[] command) {
            // Если в команде больше 2 аргументов - команда некорректная.
            if (command.Length > 2) {
                Console.WriteLine(IncorrectArguments);
                return;
            }
            // Если введёный путь некорректный.
            if (command.Length == 2 && !ValidateAbsolutePath(command[1])) {
                Console.WriteLine(IncorrectPath + ". Use correct absolute path" + "\n");
                return;
            }
            // printPath хранит строку с путём, для которого выводится информация.
            // Если пользователь хочет вывести информацию для текущей папки, в printPath передается CurrentPath.
            // Иначе путь, который ввёл пользователь.
            string printPath = command.Length > 1 ? command[1] : CurrentPath;
            printPath = GetRightPath(printPath);
            GetDirectoryInfo(printPath);
            GetFilesInfo(printPath);

        }

        /// <summary>
        /// Выводит информацию о директориях, которые расположены в path.
        /// </summary>
        /// <param name="path">Путь к директориям</param>
        public static void GetDirectoryInfo(string path) {
            string[] dirs = Directory.GetDirectories(path);
            // Данная строка нужна для оформления вывода информации.
            Console.WriteLine("|\t  Name\t         |\tType\t|\tLast Modify\t |\tCreation Time \t  |");
            foreach (var dir in dirs) {
                var dirInfo = new DirectoryInfo(dir);
                string dirName = dirInfo.Name;
                if (dirName.Length > 21)
                    // Если название слишком большое.
                    dirName = dirName.Substring(0, 21) + "...";
                Console.WriteLine($"|{dirName,24}|{"dir",14}|{dirInfo.LastWriteTime,24}|{dirInfo.CreationTime,24}|");
            }
        }

        /// <summary>
        /// Выводит информации о файлах, которые расположены в path.
        /// </summary>
        /// <param name="path">Путь к файлам.</param>
        public static void GetFilesInfo(string path) {
            string[] files = Directory.GetFiles(path);
            foreach (var file in files) {
                var fileInfo = new FileInfo(file);
                string fileName = fileInfo.Name;
                // Если название файла слишком большое.
                if (fileName.Length > 21)
                    fileName = fileName.Substring(0, 21) + "...";
                Console.WriteLine($"|{fileName,24}|{fileInfo.Extension,14}|{fileInfo.LastWriteTime,24}|{fileInfo.CreationTime,24}|");
            }
        }

        /// <summary>
        /// Копирует файл в нужную директорию.
        /// Если command имеет 3 элемента, копирует файл в текущую директорию, иначе в введённую.
        /// </summary>
        /// <param name="command">
        /// command[0]=название команды.
        /// command[1]=имя файла для копирования.
        /// command[2]=путь для копии(необязательный аргумент).
        /// </param>
        public static void CopyFile(string[] command) {
            // Проверка на корректность.
            if (command.Length > 3 || command.Length < 2 || (command.Length > 2 && command[2].Length == 3)) {
                Console.WriteLine(IncorrectArguments);
                return;
            }
            // Проверка на то, существует ли копируемый файл вообще.
            if (!File.Exists(Path.Combine(CurrentPath, command[1]))) {
                Console.WriteLine($"[!] {command[1]} doesn't exist\n");
                return;
            }
            // Метод копирования.
            MakeFileCopy(command);
        }

        /// <summary>
        /// Создаёт копию файла в нужной директории.
        /// </summary>
        /// <param name="command">Тот же, как и CopyFile.</param>
        public static void MakeFileCopy(string[] command) {
            var fileInfo = new FileInfo(Path.Combine(CurrentPath + command[1]));
            // Если пользователь хочет создать копию в текушей директории.
            if (command.Length == 2)
                // Try/catch проверяет, существует ли уже копия файла.
                try {
                    File.Copy(Path.Combine(CurrentPath, command[1]), Path.Combine(CurrentPath, fileInfo.Name.Split('.')[0] + "(copy)" + fileInfo.Extension));
                }
                catch {
                    Console.WriteLine($"[!] Copy of {fileInfo.Name} already exist\n");
                }
            // Если пользователь хочет создать копию в другой директории.
            else if (ValidateAbsolutePath(command[2]))
                // Try/catch проверяет, существует ли уже копия файла.
                try {
                    File.Copy(Path.Combine(CurrentPath, command[1]), Path.Combine(command[2], fileInfo.Name.Split('.')[0] + "(copy)" + fileInfo.Extension));
                }
                catch {
                    Console.WriteLine($"[!] Copy of {fileInfo.Name} already exist\n");
                }
            else
                Console.WriteLine(IncorrectPath);
        }

        /// <summary>
        /// Удаляет файл или директорию.
        /// </summary>
        /// <param name="command">
        /// command[0]=название команды.
        /// command[1]=название файла или папки для удаления.
        /// </param>
        public static void DeleteFileOrDirectory(string[] command) {
            if (command.Length != 2) {
                Console.WriteLine(IncorrectArguments);
                return;
            }
            // Проверка существует ли файл или директория для удаления.
            if (!File.Exists(Path.Combine(CurrentPath, command[1])) && !Directory.Exists(Path.Combine(CurrentPath, command[1]))) {
                Console.WriteLine($"[!] {command[1]} doesn't exist\n");
                return;
            }

            DeleteFile(command);
            DeleteDirectory(command);
        }
        /// <summary>
        /// Удаление файла.
        /// </summary>
        /// <param name="commnd">Тот же, как и у DeleteFileOrDirectory.</param>
        public static void DeleteFile(string[] commnd) {
            // Проверка на то, существует ли файл.
            if (!File.Exists(Path.Combine(CurrentPath, commnd[1])))
                return;
            File.Delete(Path.Combine(CurrentPath, commnd[1]));
        }

        /// <summary>
        /// Удаление директории.
        /// </summary>
        /// <param name="commnd">Тот же, как и у DeleteFileOrDirectory.</param>
        public static void DeleteDirectory(string[] commnd) {
            // Проверка на то, существует ли директория.
            if (!Directory.Exists(Path.Combine(CurrentPath, commnd[1])))
                return;
            Directory.Delete(Path.Combine(CurrentPath, commnd[1]));
        }

        /// <summary>
        /// Перемещает файл или директорию в другую директорию.
        /// </summary>
        /// <param name="command">
        /// command[0]=название команды.
        /// command[1]=имя файла или директории.
        /// command[2]=новый путь для файла или директории.
        /// </param>
        public static void MoveFileOrDirectory(string[] command) {
            // Проверка на корректность команды.
            if (command.Length != 3) {
                Console.WriteLine(IncorrectArguments);
                return;
            }
            // Проверка на то, существует ли в текущей директории папка или файл для перемещения.
            if (!File.Exists(Path.Combine(CurrentPath, command[1])) && !Directory.Exists((Path.Combine(CurrentPath, command[1])))) {
                Console.WriteLine($"[!] {command[1]} doesn't exist\n");
                return;
            }
            // Проверка нового пути.
            if (!ValidateAbsolutePath(command[2])) {
                Console.WriteLine(IncorrectPath);
                return;
            }
            MoveFile(command);
            MoveDirectory(command);
        }

        /// <summary>
        /// Перемещает файл в новую директорию.
        /// </summary>
        /// <param name="commnd">Тот же, как и у MoveFileOrDirectory.</param>
        public static void MoveFile(string[] commnd) {
            // Проверка существования файла.
            if (!File.Exists(Path.Combine(CurrentPath, commnd[1])))
                return;
            var fileInfo = new FileInfo(Path.Combine(CurrentPath, commnd[1]));
            // Try/catch отлавливает, можно ли переместить файл в новую директорию.
            try {
                File.Move(Path.Combine(CurrentPath, fileInfo.Name), Path.Combine(commnd[2], fileInfo.Name));
            }
            catch {
                Console.WriteLine("[!] I don't have enought acces or file already exist\n");
            }
        }
        /// <summary>
        /// Перемещает директорию в новую директорию.
        /// </summary>
        /// <param name="commnd">Тот же, как и у MoveFileOrDirectory.</param>
        public static void MoveDirectory(string[] commnd) {
            // Проверка на существование директории.
            if (!Directory.Exists(Path.Combine(CurrentPath, commnd[1])))
                return;
            var dirInfo = new DirectoryInfo(Path.Combine(CurrentPath, commnd[1]));
            // Try/catch отлавливает, можно ли переместить директорию в новую директорию.
            try {
                Directory.Move(Path.Combine(CurrentPath, dirInfo.Name), Path.Combine(commnd[2], dirInfo.Name));
            }
            catch {
                Console.WriteLine("[!] I don't have enought access or directory already exist\n");
            }
        }

        /// <summary>
        /// Создает файл или директорию в текущей директории.
        /// Если пердано имя без расширения - создаётся директория, иначе txt файл.
        /// Для создания txt файла пользователю нужно заполнить его в выбранной кодировке.
        /// </summary>
        /// <param name="command">
        /// command[0]=название команды.
        /// command[1]=название файла или директории.
        /// command[2]=кодировка(необязательный аргумент).
        /// </param>
        public static void CreateFileOrDirectory(string[] command) {
            // Проверка на корректность.
            if (command.Length > 3 || command.Length < 2) {
                Console.WriteLine(IncorrectArguments);
                return;
            }

            if (command[1].Contains("."))
                CreateFile(command);
            else
                CreateDirectory(command);
        }

        /// <summary>
        /// Создаёт файл и заполняет его в выбранной кодировке.
        /// Если кодировка не выбрана - используется UTF-8.
        /// </summary>
        /// <param name="command">Тот же, как и у CreateFileOrDirectory.</param>
        public static void CreateFile(string[] command) {
            // Если command имеет длину 2, значит пользователь не передал кодировку, значить ставится UTF-8.
            string encoding = command.Length == 3 ? command[2].ToUpper() : "UTF-8";
            // Проверка на то, существует ли уже файл.
            if (File.Exists(Path.Combine(CurrentPath, command[1]))) {
                Console.WriteLine($"[!] {command[1]} already exist\n");
                return;
            }
            // Проверка на корректность кодировки. ValidateEncoding описан в Validates.
            if (!ValidateEncoding(encoding)) {
                Console.WriteLine("[!] Incorrect encoding\n");
                return;
            }
            // Try/catch отлавливает возможные ошибки при создании файла.
            try {
                File.WriteAllText(Path.Combine(CurrentPath, command[1]), GetTextFromConsole(), GetRightEncoding(encoding));
            }
            catch {
                Console.WriteLine("[!] Unacceptable symbols in the name or not enought access\n");
                return;
            }
        }

        /// <summary>
        /// Создаёт пустую папку.
        /// </summary>
        /// <param name="command">Тот же, как и у CreateFileIrDirectory.</param>
        public static void CreateDirectory(string[] command) {
            // Проверка на корректность.
            if (command.Length > 2) {
                Console.WriteLine(IncorrectArguments);
                return;
            }
            // Проверка на то, существует ли уже папка.
            if (Directory.Exists(Path.Combine(CurrentPath, command[1]))) {
                Console.WriteLine($"[!] {command[1]} already exist\n");
                return;
            }
            Directory.CreateDirectory(Path.Combine(CurrentPath, command[1]));
        }

        /// <summary>
        /// Выводит содержимое файла в консоль в выбранной кодировке.
        /// Если кодировка не выбрана - используется UTF-8;
        /// </summary>
        /// <param name="command">
        /// command[0]=название команды.
        /// command[1]=имя файла.
        /// command[2]=кодировка(необязательный аргумент).
        /// </param>
        public static void PrintFile(string[] command) {
            // Проверка на корректность.
            if (command.Length > 3 || command.Length < 2 || (command[1].Contains('.') && command[1].Split('.')[1] != "txt")) {
                Console.WriteLine(IncorrectArguments);
                return;
            }
            // Проверка на то, существует ли файл.
            if (!File.Exists(Path.Combine(CurrentPath, command[1]))) {
                Console.WriteLine($"[!] {command[1]} doesn't exist\n");
                return;
            }
            // Если command имеет длину 2, значит пользователь не передал кодировку, значить ставится UTF-8.
            string encoding = command.Length == 3 ? command[2].ToUpper() : "UTF-8";
            string[] fileLines = File.ReadAllLines(Path.Combine(CurrentPath, command[1]));
            string allText = "";
            foreach (var line in fileLines)
                if (line != "\n")
                    allText += line + "\n";
            Console.WriteLine($"[<] {command[1]} :");
            Print(allText, encoding);

        }

        /// <summary>
        /// Выводит текст в консоль в кодировке encoding.
        /// </summary>
        /// <param name="text">Текст для вывода.</param>
        /// <param name="encoding">Кодировка.</param>
        public static void Print(string text, string encoding) {
            // Проверка на корректность кодировки.
            if (!ValidateEncoding(encoding)) {
                Console.WriteLine("[!] Incorrect encoding\n");
                return;
            }
            Console.OutputEncoding = GetRightEncoding(encoding);
            Console.WriteLine(text);
            Console.OutputEncoding = Encoding.UTF8;
        }

        /// <summary>
        /// Выводит информацию о доступных дисках.
        /// </summary>
        public static void GetDisks() {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives) {
                Console.WriteLine("Drive {0}", d.Name);
                if (d.IsReady == true) {
                    Console.WriteLine("    Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
                    Console.WriteLine("    Total available space:          {0, 15} bytes",d.TotalFreeSpace);
                    Console.WriteLine("    Total size of drive:            {0, 15} bytes ", d.TotalSize);
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Сливает текст нескольких файлов и сохраняет его в новом файле в текущей директории.
        /// Количество файлов должно быть больше 1.
        /// </summary>
        /// <param name="command">
        /// command[0]=название команды.
        /// command[1]=имя файла для слияния.
        /// command[n-1]=имя файла для слияния.
        /// command[n]=имя файла, в который сохраняется текст.
        /// </param>
        public static void MergeTextFiles(string[] command) {
            // Проверка на корректность.
            if (command.Length < 4) {
                Console.WriteLine(IncorrectArguments);
                return;
            }
            // Имя создаваемого файла.
            string last = command[command.Length - 1];
            // Текст для слияния. GetFilesText описан в файле Validates.
            string filesText = GetFilesText(command);
            if (File.Exists(Path.Combine(CurrentPath, last))) {
                Console.WriteLine($"[!] {last} is already exist\n");
                return;
            }
            // Если хотя бы 1 путь был некорректным.
            if (filesText == "-1") {
                Console.WriteLine("[!] some of the files don't exist\n");
                return;
            }
            File.WriteAllText(Path.Combine(CurrentPath, last), filesText);
        }

    }
}
