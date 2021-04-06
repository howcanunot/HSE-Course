using System;
using System.Collections.Generic;
using System.Text;

namespace MyStorage {
    /// <summary>
    /// This class select string constants using user language.
    /// </summary>
    class Constants {
        public static string storageConsoleInfo;
        public static string storageCapacityInfo;
        public static string incorrectStorageCapacity;
        public static string storagePriceInfo;
        public static string incorrectPrice;
        public static string greeting;
        public static string inputMethod;
        public static string incorrectInput;
        public static string containerAndBoxInfo;
        public static string listOfCommands;
        public static string inputCommand;
        public static string inputContainerId;
        public static string newContainerInfo;
        public static string boxInfo;
        public static string boxName;
        public static string boxWeight;
        public static string boxPrice;
        public static string incorrectBoxWeight;
        public static string containerOnStorage;
        public static string notEnoughtPrice;
        public static string idExist;
        public static string idNotExist;
        public static string deleteId;
        public static string unknownError;
        public static string unknownCommand;

        private static string storageConsoleInfoRu =
            "[<]    ┏━━━━━━━━━━━━━━━━━━━━━━━━━ Ввод параметров склада ━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n" +
            "       ┃ Склад имеет 2 параметра:                                                   ┃\n" +
            "       ┃      1. Размер склада - натуральное число.                                 ┃\n" +
            "       ┃      2. Цена хранения контейнера на складе - вещественное число > 0.       ┃\n" +
            "       ┃ После создания параметры склада нельзя будет изменить.                     ┃\n" +
            "       ┃ На склад могут поступать новые контейнеры и удаляться старые.              ┃\n" +
            "       ┃ Если суммарная строимость ящиков с продуктами в контейнере не превосходит  ┃\n" +
            "       ┃ цену хранения контейнера на складе, такой контейнер на склад не помещается.┃\n" +
            "       ┃ При добавлении контейнера в уже заполенненый склад, со склада удаляется    ┃\n" +
            "       ┃ тот контейнер, который был добавлен раньше всех остальных.                 ┃\n" +
            "       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n";
        
        
        
        private static string storageConsoleInfoEn =
            "[<]    ┏━━━━━━━━━━━━━━━━━━━━━━━━━ Input storage features ━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n" +
            "       ┃ Storage has 2 features:                                                    ┃\n" +
            "       ┃      1. Capacity of storage - natural number.                              ┃\n" +
            "       ┃      2. Container storage price - real number > 0.                         ┃\n" +
            "       ┃ You cant't change storage features after creation.                         ┃\n" +
            "       ┃ New containers can arrive at the storage and old ones can be removed.      ┃\n" +
            "       ┃ If the total price of boxes with products in a container doesn't exceed    ┃\n" +
            "       ┃ the cost of storing, this container is not placed in the storage.          ┃\n" +
            "       ┃ When a container is added to an already filled storage, the container that ┃\n" +
            "       ┃ was added earlier than all the others is removed from the warehouse.       ┃\n" +
            "       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n";

        private static string storageCapacityInfoRu =
            "[>]    Введите размер склада";
        private static string storageCapacityInfoEn =
            "[>]    Input storage capacity";
        private static string incorrectStorageCapacityRu =
            "[!]    Некорректный ввод. Размера должен быть натуральным числом. Попробуйте еще раз";
        private static string incorrectStorageCapacityEn =
            "[!]    Incorrect input. Capacity have to be natural number. Try again";
        private static string storagePriceInfoRu =
            "[>]    Введите цену хранения контейнера на складе";
        private static string storagePriceInfoEn =
            "[>]    Input price of storage of the container";
        private static string incorrectPriceRu =
            "[!]    Некорректный ввод. Цена должны быть вещественным число > 0. Попробуйте езе раз";
        private static string incorrectPriceEn =
            "[!]    Incorrect input. Price have to be real number > 0. Try again";

        private static string greetingRu =
            "[<]    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ Greeting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n" +
            "       ┃ Эта программа симулирует работа склада.                                    ┃\n" +
            "       ┃ На складе хранятся контейнеры с продуктами. Склад ограничен в размере.     ┃\n" +
            "       ┃ Склад взимает фиксированную плату за хранение контейнеров.                 ┃\n" +
            "       ┃ Перед началом работы вам нужно выбрать способ ввода данных:                ┃\n" +
            "       ┃       1. Ввод данных через консоль.                                        ┃\n" +
            "       ┃       2. Не реализовано (устал).                                           ┃\n" +
            "       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n";
        private static string greetingEn =
            "[<]    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ Greeting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n" +
            "       ┃ This program simulates storage operation.                                  ┃\n" +
            "       ┃ The storage stores containers with products. The storage has limited size. ┃\n" +
            "       ┃ The storage charges a flat fee for storing containers.                     ┃\n" +
            "       ┃ Before program start, you need to select an input method:                  ┃\n" +
            "       ┃       1. Input from console.                                               ┃\n" +
            "       ┃       2. Not released.                                                     ┃\n" +
            "       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n";

        private static string inputMethodRu =
            "[>]    Выберите способ ввода данных [1 / 2]: ";
        private static string inputMethodEn =
            "[>]    Choose input method [1 / 2]: ";
        private static string incorrectInputRu =
            "[!]    Некорректный ввод. Попробуйте еще раз: ";
        private static string incorrectInputEn =
            "[!]    Incorrect input. Try again: ";

        private static string containerAndBoxInfoRu =
            "[<]    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ Контейнеры ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n" +
            "       ┃ Каждый контейнер хранит в себе ящики с продуктами.                         ┃\n" +
            "       ┃ Контейнер имеет 2 главных параметра:                                       ┃\n" +
            "       ┃       1. Уникальный id контейнера - натуральное число [0, 1000].           ┃\n" +
            "       ┃       2. Вместительность контейнера в кг - случайное число [50, 1000].     ┃\n" +
            "       ┃ Количество и список помещаемых в контейнер ящиков вы указываете сами.      ┃\n" +
            "       ┃ При этом суммарная масса ящиков не может превосходить максимально          ┃\n" +
            "       ┃ допустимую массу контейнера - таким образом, если добавление ящика         ┃\n" +
            "       ┃ приводит к превышению допустимой массы,то он не добавляется в контейнер.   ┃\n" +
            "       ┃  ┏━━━━━━━━━━━━━━━━━━━━━━━━━ Ящики с продуктами ━━━━━━━━━━━━━━━━━━━━━━━━━┓  ┃\n" +
            "       ┃  ┃ Ящик с продуктами описывается 3-мя параметрами:                      ┃  ┃\n" +
            "       ┃  ┃        1. Название продукта, который хранится в ящике.               ┃  ┃\n" +
            "       ┃  ┃        2. Масса ящика в килограммах - вещественное число > 0.        ┃  ┃\n" +
            "       ┃  ┃        3. Цена продукта за килограмм - вещественное число > 0.       ┃  ┃\n" +
            "       ┃  ┃ Название может состоять только из русских или английских букв.       ┃  ┃\n" +
            "       ┃  ┃ Также название не можеи иметь длину > 13.                            ┃  ┃\n" +
            "       ┃  ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛  ┃\n" +
            "       ┃ Чтобы закончить собирать контейнер - введите null вместо названия продукта.┃\n" +
            "       ┃ При транспортировке контейнера на склад он может повредиться.              ┃\n" +
            "       ┃ Степерь повреждения - случаная величина в диапозоне [0, 0.5).              ┃\n" +
            "       ┃ Именно такую долю теряет каждый ящик с продуктами внутри контейнера.       ┃\n" +
            "       ┃ Напомню, что  если суммарная стоимость содержимого контейнера              ┃\n" +
            "       ┃ не превосходит стоимость хранения, такой контейнер на склад не помещается. ┃\n" +
            "       ┃ Пожалуйста, не вводите очень большие числа.                                ┃\n" +
            "       ┃ На результат работы программы это не повлияет, но испортит вывод.          ┃\n" +
            "       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n";

        private static string containerAndBoxInfoEn =
            "[<]    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ Containers ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n" +
            "       ┃ Each container contains boxes of goods.                                    ┃\n" +
            "       ┃ Container has 2 main features:                                             ┃\n" +
            "       ┃       1. The unique id of the container - natural number [0, 1000].        ┃\n" +
            "       ┃       2. Container capacity in kg - random number [50, 1000].              ┃\n" +
            "       ┃ You specify the number and list of boxes placed in the container yourself. ┃\n" +
            "       ┃ At the same time, the total weight of boxes cannot exceed the maximum      ┃\n" +
            "       ┃ allowable weight of the container - thus, if adding a box leads to an      ┃\n" +
            "       ┃ excess of the allowable weight, then it is not added to the container.     ┃\n" +
            "       ┃  ┏━━━━━━━━━━━━━━━━━━━━━━━━━━ Boxes with goods ━━━━━━━━━━━━━━━━━━━━━━━━━━┓  ┃\n" +
            "       ┃  ┃ A box with goods is described by 3 parameters:                       ┃  ┃\n" +
            "       ┃  ┃        1. The name of the product that is stored in the box.         ┃  ┃\n" +
            "       ┃  ┃        2. The weight of the box in kilograms - real number> 0.       ┃  ┃\n" +
            "       ┃  ┃        3. Product price per kilogram - real number> 0.               ┃  ┃\n" +
            "       ┃  ┃ The name can only consist of Russian or English letters.             ┃  ┃\n" +
            "       ┃  ┃ Also, the name cannot have length> 13.                               ┃  ┃\n" +
            "       ┃  ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛  ┃\n" +
            "       ┃ To finish building the container - enter null instead of the product name. ┃\n" +
            "       ┃ When transporting a container to a storage, it can be damaged.             ┃\n" +
            "       ┃ The degree of damage is a random value in the range[0, 0.5).               ┃\n" +
            "       ┃ This is the share that every box with food inside the container loses.     ┃\n" +
            "       ┃ If the total cost of the contents of the container doen't exceed the cost  ┃\n" +
            "       ┃ of storage, such a container is not placed in the.                         ┃\n" +
            "       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n";

        private static string listOfCommandsRu =
            "[<]    Список доступных команд:\n" +
            "           1. Добавить контейнер на склад.\n" +
            "           2. Удалить контейнер со склада, используя его id.\n" +
            "           3. Вывести содержимое склада.\n" +
            "           4. Отсортировать контейнеры на складе по увелечению их id.\n" +
            "           5. Отсортировать контейнеры на складе по увелечению их суммарной стоимости.\n" +
            "           6. Отсортировать контейнеры на складе по увелечению их вместительности.\n" +
            "           7. Очистить консоль.\n" +
            "           8. Завершить программу.\n";
        private static string listOfCommandsEn =
            "[<]    List of avaliable commands:\n" +
            "           1. Add container.\n" +
            "           2. Remove container using id.\n" +
            "           3. Вывести содержимое склада.\n" +
            "           4. Sort containers by increasing their id.\n" +
            "           5. Sort containers by increasing their total price.\n" +
            "           6. Sort containers by increasing their capacity.\n" +
            "           7. Clear console.\n" +
            "           8. Exit.\n";
        private static string inputCommandRu = "" +
            "[>]    Введите команду, которую хотите выполнить: ";
        private static string inputCommandEn = "" +
            "[>]    Input command you want to execute: ";
        private static string inputContainerIdRu =
            "[>]    Введите id нового контейнера (натуральное число [0, 1000]): ";
        private static string inputContainerIdEn =
            "[>]    Input new container id (natural number [0, 1000]): ";
        private static string newContainerInfoRu =
            "[<]    Новый контейнер с id {0} был создан. Его вместительность = {1}";
        private static string newContainerInfoEn =
            "[<]    New container with id {0} has created. It has capacity = {1}";
        private static string boxInfoRU =
            "[<]    Теперь нужно заполнить контейнер ящиками с продуктами.\n" +
            "\t       Контейнер будет заполняться, пока суммарная вместительность ящиков не достигнет\n" +
            "\t       вместительности контейнера, или пока вы не прекратите ввод, введя null в поле имени ящика";
        private static string boxInfoEn =
           "[<]    Now you need to fill the container with boxes of goods.\n" +
           "\t       The container will be filled until the total capacity of the boxes reaches\n" +
           "\t       the capacity of the container, or until you stop typing by entering null in the box name";
        private static string boxNameRu =
           "[>]    Введите название продукта, который будет лежать в ящике.\n" +
            "\t\t       Название должно содержать только буквы, а длина должны быть < 14: ";
        private static string boxNameEn =
           "[>]    Input the name of the product that will be in the box.\n" +
            "\t\t       Name have to contains only letters and length have to be < 14: ";
        private static string boxWeightRu =
           "[>]    Введите вес нового ящика с продукатами (вещественное число > 0): ";
        private static string boxWeightEn =
           "[>]    Input weight box with products (real number > 0): ";

        private static string boxPricetRu =
           "[>]    Введите цену за кг продукта нового ящика (вещественное число > 0): ";
        private static string boxPriceEn =
           "[>]    Input price per kg of product in box (real number > 0): ";
        private static string incorrectBoxWeightRu =
           "[!]    Некорректый вес. Вес ящика превысил допустимый вес контейнера.";
        private static string incorrectBoxWeightEn =
           "[!]    Некорректый вес. Weight of the box has exceeded the weight of the container.";
        private static string containerOnStorageRu =
           "[<]    Новый контейнер добавлен на склад.\n" +
            "\t       Стоимость продуктов в контейнере с учетом повреждений = {0}";
        private static string containerOnStorageEn =
           "[<]    New container has added in storage.\n" +
            "\t       Total price of products include damage = {0}";
        private static string notEnoughtPriceRu =
           "[<]    Контейнер не может быть помещен на склад.\n" +
            "\t       Суммарная стоимость продуктов в контейнере учитывая повреждения = {0}.\n" +
            "\t       Необходимая стоимость продуктов для хранения на складе = {1}.";
        private static string notEnoughtPriceEn =
           "[<]    The container cannot be placed in the storage.\n" +
            "\t       The total cost of products in the container include damage = {0}.\n" +
            "\t       The required cost of products for storage in a storage = {1}.";
        private static string idExistRu =
           "[!]    Контейнер с таким id уже существует или id некорректен. Введите другой id: ";
        private static string idExistEn =
           "[!]    Container with same id already exist or id is not correct. Try another id: ";
        private static string idNotExistRu =
           "[!]    Контейнера с таким id не существует. Введите другой id: ";
        private static string idNotExistEn =
           "[!]    Container with same id doesn't exist. Try another id: ";
        private static string deleteIdRu =
           "[>]    Введите id контейнера, который вы хотите удалить: ";
        private static string deleteIdEn =
           "[>]    Input the id of the container you want to delete: ";
        public static string head =
           "[<]    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓";
        public static string bottom =
           "       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛";
        public static string sep =
           "       ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫";

        private static string unknownCommandRu =
            "\n[!] Неизвестная команда.";
        private static string unknownCommandEn =
            "\n[!] Unknown command.";
        private static string unknownErrorRu =
            "\n[!] Неизвестная команда: ";
        private static string unknownErrorEn =
            "\n[!] UnknownError: ";
        /*
        public static string fileInfo =
            "[<]    ┏━━━━━━━━━━━━━━━━━━━━━━━━━━ Ввод данных с файлов ━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\n" +
            "       ┃ Данные считываются с 3-х файлов                                            ┃\n" +
            "       ┃      1. Файл с описанием склада.                                           ┃\n" +
            "       ┃      2. Файл с описанием действий                                          ┃\n" +
            "       ┃      3. Файл с описанием контейнеров                                       ┃\n" +
            "       ┃ Все данные в файлвх обязаны быть корректными.                              ┃\n" +
            "       ┃ Файл с описанием склада должен содержать 2 числа каждый в новой строке:    ┃\n" +
            "       ┃      1. Вместительность склада.                                            ┃\n" +
            "       ┃      2. Цена хранения контейнера на складе.                                ┃\n" +
            "       ┃ Файл с описанием действий должен содержать числа от 1 до 3 по 1 в строке:  ┃\n" +
            "       ┃      1. Добавить контейнер на склад.                                       ┃\n" +
            "       ┃      2. Удалить контейнер со склада, используя его id.                     ┃\n" +
            "       ┃      3. Отсортировать контейнеры на складе по увелечению их id.            ┃\n" +
            "       ┃ Файл с описанием контейнеров должен содержать по 4 значения для 1 команды: ┃\n" +
            "       ┃      1. id нового контейнера.                                              ┃\n" +
            "       ┃      2. Название продукта, который будет лежать в ящике.              ┃" +
            "       ┃ и 1 значения для 2 команды:" +
            "       ┃ Если суммарная строимость ящиков с продуктами в контейнере не превосходит  ┃\n" +
            "       ┃ цену хранения контейнера на складе, такой контейнер на склад не помещается.┃\n" +
            "       ┃ При добавлении контейнера в уже заполенненый склад, со склада удаляется    ┃\n" +
            "       ┃ тот контейнер, который был добавлен раньше всех остальных.                 ┃\n" +
            "       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\n";
        */
        /// <summary>
        /// Print storage features using user language.
        /// </summary>
        /// <param name="flag"></param>
        public static void StorageFeatures(bool flag) {
            if (flag) 
                Console.WriteLine($"[<]    Вместительность склада:   [{Storage.Capacity}]\n" +
                                  $"       Цена хранения контейнера: [{Storage.StorePrice}]\n");
            else
                Console.WriteLine($"[<]    Storage capacity: [{Storage.Capacity}]\n" +
                                  $"       Storage price:    [{Storage.StorePrice}]\n");            
        }
        /// <summary>
        /// Init variable using user language.
        /// </summary>
        /// <param name="flag"></param>
        public static void GetRightOutput(bool flag) {
            if (flag) {
                storageConsoleInfo = storageConsoleInfoRu;
                storageCapacityInfo = storageCapacityInfoRu;
                incorrectStorageCapacity = incorrectStorageCapacityRu;
                storagePriceInfo = storagePriceInfoRu;
                incorrectPrice = incorrectPriceRu;
                greeting = greetingRu;
                inputMethod = inputMethodRu;
                incorrectInput = incorrectInputRu;
                containerAndBoxInfo = containerAndBoxInfoRu;
                listOfCommands = listOfCommandsRu;
                inputCommand = inputCommandRu;
                inputContainerId = inputContainerIdRu;
                newContainerInfo = newContainerInfoRu;
                boxInfo = boxInfoRU;
                boxName = boxNameRu;
                boxWeight = boxWeightRu;
                boxPrice = boxPricetRu;
                incorrectBoxWeight = incorrectBoxWeightRu;
                containerOnStorage = containerOnStorageRu;
                notEnoughtPrice = notEnoughtPriceRu;
                idExist = idExistRu;
                idNotExist = idNotExistRu;
                deleteId = deleteIdRu;
                unknownCommand = unknownCommandRu;
                unknownError = unknownErrorEn;
            }
            else {
                storageConsoleInfo = storageConsoleInfoEn;
                storageCapacityInfo = storageCapacityInfoEn;
                incorrectStorageCapacity = incorrectStorageCapacityEn;
                storagePriceInfo = storagePriceInfoEn;
                incorrectPrice = incorrectPriceEn;
                greeting = greetingEn;
                inputMethod = inputMethodEn;
                incorrectInput = incorrectInputEn;
                containerAndBoxInfo = containerAndBoxInfoEn;
                listOfCommands = listOfCommandsEn;
                inputCommand = inputCommandEn;
                inputContainerId = inputContainerIdEn;
                newContainerInfo = newContainerInfoEn;
                boxInfo = boxInfoEn;
                boxName = boxNameEn;
                boxWeight = boxWeightEn;
                boxPrice = boxPriceEn;
                incorrectBoxWeight = incorrectBoxWeightEn;
                containerOnStorage = containerOnStorageEn;
                notEnoughtPrice = notEnoughtPriceEn;
                idExist = idExistEn;
                idNotExist = idNotExistEn;
                deleteId = deleteIdEn;
                unknownCommand = unknownCommandEn;
                unknownError = unknownErrorEn;
            }
        }
    }
}
