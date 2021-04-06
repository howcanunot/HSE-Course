using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MyStorage {
    /// <summary>
    /// Singleton class.
    /// </summary>
    class Storage {

        // Static variable for single example.
        private static Storage myStorage;
        // List pof pair id of container and container.
        private static List<KeyValuePair<int, Container>> containers = new List<KeyValuePair<int, Container>>();
        // Price for store for evety container.
        public static double StorePrice { get; private set; }
        // Capacity of storage.
        public static int Capacity { get; private set; }

        /// <summary>
        /// Useless constructor.
        /// </summary>
        private Storage() { }
        /// <summary>
        /// Returns private list length.
        /// </summary>
        /// <returns></returns>
        public static int GetLength() {
            return containers.Count;
        }
        /// <summary>
        /// Static method that controls the access to the singleton example.
        /// </summary>
        /// <param name="storePrice">Price for Store.</param>
        /// <returns>Create new example if it doesn't exist.
        /// Or returns existing.
        /// </returns>
        public static Storage GetStorage(int capacity, double storePrice) {
            if (myStorage == null) {
                myStorage = new Storage();
                StorePrice = storePrice;
                Capacity = capacity;
            }
            return myStorage;

        }
        /// <summary>
        /// Mathod adds new container in storage if it profitable.
        /// If storage if full, method delete first container in storage.
        /// </summary>
        /// <param name="newContainer"></param>
        /// <returns>True if store is profitable, else false./returns>
        public static bool AddNewContainer(Container newContainer) {
            if (newContainer.TotalPrice > StorePrice) {
                if (containers.Count == Capacity)
                    containers.RemoveAt(0);
                containers.Add(new KeyValuePair<int, Container>(newContainer.Id, newContainer));
                return true;
            }
            return false;
        }
        /// <summary>
        /// Remove container with key = id if it exists.
        /// </summary>
        /// <param name="id">Id of removing container.</param>
        /// <returns>True if container has removed, else false.</returns>
        public static bool RemoveContainer(int id) {
            for (var i = 0; i < containers.Count; i++)
                if (containers[i].Key == id) {
                    containers.RemoveAt(i);
                    return true;
                }
            return false;
        }

        /// <summary>
        /// Method find container with id = id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if container with same id doesn't exist, else false.</returns>
        public static bool FindId(int id) {
            for (var i = 0; i < containers.Count; i++)
                if (containers[i].Key == id)
                    return false;
            return true;
        }

        /// <summary>
        /// Delete container with wanted id.
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteContainer(int id) {
            for (int i = 0; i < containers.Count; i++)
                if (containers[i].Key == id) {
                    containers.RemoveAt(i);
                    return;
                }

        }

        /// <summary>
        /// Print containers info.
        /// Как же я устал.
        /// </summary>
        public static void Print() {
            Console.WriteLine();
            Console.WriteLine(Constants.head);
            for (var i = 0; i < containers.Count; i++) {
                    Console.WriteLine($"       ┃ Container № {containers[i].Key, 4}\t\t\t\t\t\t        ┃");
                    Console.WriteLine($"       ┃    Total Price - {Math.Round(containers[i].Value.TotalPrice, 2), 18}\t\t\t\t\t┃");
                    Console.WriteLine($"       ┃    Capacity    - {Math.Round(containers[i].Value.Capacity, 2), 18}\t\t\t\t\t┃");
                    Console.WriteLine($"       ┃    Weight      - {Math.Round(containers[i].Value.CurrentWeight, 2), 18}\t\t\t\t\t┃");
                    Console.WriteLine($"       ┃    Damage      - {Math.Round(containers[i].Value.PercentOfDamage, 2), 18}\t\t\t\t\t┃");
                    
                for (var j = 0; j < containers[i].Value.ListOfBoxes.Count; j++) {
                    Console.WriteLine($"       ┃\t\t\t\t\t\t\t\t\t┃");
                    Console.WriteLine($"       ┃    Box №    {j+1, 4}\t\t\t\t\t\t        ┃");
                    Console.WriteLine($"       ┃        Name of product - {containers[i].Value.ListOfBoxes[j].NameOfProduct, 14}\t\t\t\t┃");
                    Console.WriteLine($"       ┃        Price of box    - {containers[i].Value.ListOfBoxes[j].TotalPrice,14}\t\t\t\t┃");
                    Console.WriteLine($"       ┃        Weight of box   - {containers[i].Value.ListOfBoxes[j].Weight,14}\t\t\t\t┃");


                }
                if (i != containers.Count - 1)
                    Console.WriteLine(Constants.sep);
            }
            Console.WriteLine(Constants.bottom);
        }

        public static void Sort(int type) {
            if (type == 1)
                containers = containers.OrderBy(o => o.Key).ToList();
            else if (type == 2)
                containers = containers.OrderBy(o => o.Value.Capacity).ToList();
            else
                containers = containers.OrderBy(o => o.Value.TotalPrice).ToList();
        }
    }
}
