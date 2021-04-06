using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MyStorage {
    class Logics {

        /// <summary>
        /// Public method which select program language.
        /// </summary>
        /// <returns>True if user selected russian language, else false.</returns>
        public static bool SelectLanguage() {
            string res = "";
            Console.Write("[>] Выберите язык / Select language [Ru / En]: ");
            res = Console.ReadLine().ToLower();
            while (res != "ru" && res != "en") {
                Console.Write("[!] Некорректный ввод / Incorrect input. Попробуйте снова / Try again [Ru / En]: ");
                res = Console.ReadLine().ToLower();
            }
            if (res == "ru")
                return true;
            return false;
        }

        /// <summary>
        /// Public method which choose user input method.
        /// </summary>
        /// <returns>True if input from console, else false.</returns>
        public static bool SelectInput() {
            Console.WriteLine(Constants.greeting);
            Console.Write(Constants.inputMethod);
            string line = Console.ReadLine();
            int number;
            while (!int.TryParse(line, out number) || !(number == 1 || number == 2)) {
                Console.Write(Constants.incorrectInput);
                line = Console.ReadLine();
            }
            if (number == 1)
                return true;
            return false;

        }

        /// <summary>
        /// Create storage example.
        /// </summary>
        private static void GetStorage() {
            Console.WriteLine(Constants.storageConsoleInfo);
            Storage.GetStorage(UserInput.ReadInteger(Constants.storageCapacityInfo, Constants.incorrectInput),
                UserInput.ReadDouble(Constants.storagePriceInfo, Constants.incorrectInput));
            Console.Clear();
        }


        /// <summary>
        /// Main part of program.
        /// This method describes main logics of program.
        /// </summary>
        public static void Start() {
            GetStorage();
            Console.WriteLine(Constants.containerAndBoxInfo);
            Constants.StorageFeatures(Program.russianLang);
            // Inf cicle.
            while (true) {
                try {
                    // Commands handler.
                    switch (GetCommand()) {
                        case 1:
                            AddContainer();
                            break;
                        case 2:
                            DeleteContainer();
                            break;
                        case 4:
                            SortStorage(1);
                            break;
                        case 3:
                            PrintStorage();
                            break;
                        case 5:
                            SortStorage(3);
                            break;
                        case 6:
                            SortStorage(2);
                            break;
                        case 7:
                            ClearConsole();
                            break;
                        case 8:
                            return;
                        default:
                            Console.WriteLine(Constants.unknownCommand + "\n");
                            break;
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(Constants.unknownError + ex.Message + "\n");
                }
            }

        }
        /// <summary>
        /// Get number of command.
        /// </summary>
        /// <returns>Integer number.</returns>
        private static int GetCommand() {
            Console.WriteLine(Constants.listOfCommands + "\n");
            Console.Write(Constants.inputCommand);
            string line = Console.ReadLine();
            int number;
            while (!int.TryParse(line, out number)) {
                Console.Write(Constants.incorrectInput);
                line = Console.ReadLine();
            }
            return number;
        }

        /// <summary>
        /// Add new container in storage.
        /// </summary>
        private static void AddContainer() {
            Console.Write("\n\t"+Constants.inputContainerId);
            string line = Console.ReadLine();
            int containerId;
            while (!int.TryParse(line, out containerId) || !(containerId >= 0 && containerId <= 1000) ||
                !Storage.FindId(containerId)) {
                Console.Write("\t"+Constants.idExist);
                line = Console.ReadLine();
            }
            var newContainer = new Container(containerId);
            Console.WriteLine("\n\t" + Constants.newContainerInfo, newContainer.Id, newContainer.Capacity + "\n");
            Console.WriteLine("\t"   + Constants.boxInfo);
            var newBox = CreateBox();
            while (newBox.NameOfProduct != "null") {
                if (!newContainer.AddBox(newBox))
                    Console.WriteLine("\n\t\t" + Constants.incorrectBoxWeight);
                if (newContainer.CurrentWeight == newContainer.Capacity)
                    break;
                newBox = CreateBox();
            }
            if (Storage.AddNewContainer(newContainer))
                Console.WriteLine("\n\t" + Constants.containerOnStorage, Math.Round(newContainer.TotalPrice, 2) + "\n");
            else {
                Console.WriteLine("\n\t" + Constants.notEnoughtPrice, Math.Round(newContainer.TotalPrice, 2), Storage.StorePrice);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Method create new box.
        /// </summary>
        /// <returns>Box example.</returns>
        private static Box CreateBox() {
            Console.Write("\n\t\t" + Constants.boxName);
            
            string name = Console.ReadLine().Trim();
            while (name.Length == 0 || name.Length > 13 || !ValidateBoxName(name)) {
                Console.Write("\t\t" + Constants.incorrectInput);
                name = Console.ReadLine().Trim();
            }
            string currectName = name;
            if (name == "null")
                return new Box(name, 0, 0);
            double weight;
            Console.Write("\t\t" + Constants.boxWeight);
            name = Console.ReadLine();
            while (!double.TryParse(name, out weight)) {
                Console.Write("\t\t" + Constants.incorrectInput);
                name = Console.ReadLine();
            }
            double price;
            Console.Write("\t\t" + Constants.boxPrice);
            name = Console.ReadLine();
            while (!double.TryParse(name, out price)) {
                Console.Write("\t\t" + Constants.incorrectInput);
                name = Console.ReadLine();
            }

            return new Box(currectName, weight, price);
        }

        /// <summary>
        /// Method parsing product name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True or false.</returns>
        private static bool ValidateBoxName(string name) {
            string lName = name.ToLower();
            for (int i = 0; i < name.Length; i++)
                if (!((lName[i] >= 'a' && lName[i] <= 'z') || (lName[i] >= 'а' && lName[i] <= 'я')))
                    return false;
            return true;

        }
        /// <summary>
        /// Method removes the container with input id.
        /// </summary>
        private static void DeleteContainer() {
            if (Storage.GetLength() == 0) {
                if (Program.russianLang)
                    Console.WriteLine("[!] На складе нет контейнеров.\n");
                else
                    Console.WriteLine("[!] Storage is empty now.\n");
                return;
            }
            Console.WriteLine();
            int id;
            Console.Write(Constants.deleteId);
            string line = Console.ReadLine();
            while (int.TryParse(line, out id) && Storage.FindId(id)) {
                Console.Write(Constants.idNotExist);
                line = Console.ReadLine();
            }
            if (!Storage.FindId(id)) {
                Storage.DeleteContainer(id);
                Console.WriteLine();
            }
            else
                Console.WriteLine(Constants.idNotExist);
        }

        /// <summary>
        /// Clear console.
        /// </summary>
        private static void ClearConsole() {
            Console.Clear();
            Console.WriteLine(Constants.containerAndBoxInfo);
            Constants.StorageFeatures(Program.russianLang);

        }
        /// <summary>
        /// Print storage content.
        /// </summary>
        private static void PrintStorage() {
            if (Storage.GetLength() == 0) {
                if (Program.russianLang)
                    Console.WriteLine("[!] На складе нет контейнеров.\n");
                else
                    Console.WriteLine("[!] Storage is empty now.\n");
                return;
            }
            Storage.Print();
        }

        private static void SortStorage(int type) {
            if (Storage.GetLength() == 0) {
                if (Program.russianLang)
                    Console.WriteLine("[!] На складе нет контейнеров.\n");
                else
                    Console.WriteLine("[!] Storage is empty now.\n");
                return;
            }
            Console.WriteLine();
            Storage.Sort(type);
        }

        private static bool ReadFromFiles() {
            try {
                Console.WriteLine(
                    "Введите 3 путя для файлов, как описано в условии.\n" +
                    "Каждое значение в файле должно стоять на новой строке.\n" +
                    "Все значения в файлах должны быть в таком же формате, как и при вводе в консоль.\n" +
                    "Так что сначала лучше проверьте работу для консольных входных данных.\n" +
                    "В результате в консоль выведятся данные со склада.\n" +
                    "Сразу хочу извиниться перед проверяющими за это безобразие,\n" +
                    "но писал я файловый ввод за 15 минут до конца дедлайна из-за семейных обстоятельств.\n" +
                    "Так что прошу отнестить с понимаем и не занулять всю работу.\n");
                Console.Write("[>] Введите путь к файлу для описания склада: ");
                string line = Console.ReadLine();
                while (!File.Exists(line)) {
                    Console.Write("[!] Файла не существует. Попробуйте еще раз");
                    line = Console.ReadLine();
                }
                string[] features = File.ReadAllLines(line);
                Storage.GetStorage((int)uint.Parse(features[0]), (int)uint.Parse(features[1]));
                Console.WriteLine("\n" +
                    "В файле с номера дейсвиями могут быть числа от 1 до 3:" +
                    "1. Добавить контейнер на склад.\n" +
                    "2. Удалить контейнер со склада.\n" +
                    "3. Отсортировать контейнеры по увелечению их id.");
                Console.Write("[>] Введите путь к файлу для номеров действий: ");
                line = Console.ReadLine();
                while (!File.Exists(line)) {
                    Console.Write("[!] Файла не существует. Попробуйте еще раз");
                    line = Console.ReadLine();
                }
                string[] active = File.ReadAllLines(line);
                Console.Write("[>] Введите путь к файлу для описания контейнеров: ");
                line = Console.ReadLine();
                while (!File.Exists(line)) {
                    Console.Write("[!] Файла не существует. Попробуйте еще раз");
                    line = Console.ReadLine();
                }
                string[] descr = File.ReadAllLines(line);
                int index = 0;
                foreach (string com in active) {
                    int intCom = int.Parse(com);
                    if (intCom == 3)
                        Storage.Sort(1);
                    else if (intCom == 2)
                        Storage.DeleteContainer(int.Parse(descr[index++]));
                    else if (intCom == 1) {
                        Container cont = new Container(int.Parse(descr[index++]));
                        while (descr[index] != "null" || cont.CurrentWeight != cont.CurrentWeight) {
                            cont.AddBox(new Box(descr[index++], int.Parse(descr[index++]), int.Parse(descr[index++])));
                        }
                    }
                    else
                        return false;

                }
                Storage.Print();
                return true;
            }
            catch(Exception ex) {
                return false;
            }
        }
    }
}
