using System;
using System.Collections.Generic;
using System.Text;

namespace MyStorage {
    class UserInput {

        /// <summary>
        /// Method returns double number by user.
        /// </summary>
        /// <param name="message">Message for output.</param>
        /// <returns>Correct double number.</returns>
        public static double ReadDouble(string message, string incorrect) {
            Console.Write(message + ": ");
            double number;
            string line = Console.ReadLine();
            while (!double.TryParse(line, out number) || number <= 0) {
                Console.Write(incorrect);
                line = Console.ReadLine();
            }
            return number;
        }

        /// <summary>
        /// Method returns integer number by user.
        /// </summary>
        /// <param name="message">Message for output.</param>
        /// <returns>Correct integer number.</returns>
        public static int ReadInteger(string message, string incorrect) {
            Console.Write(message + ": ");
            int number;
            string line = Console.ReadLine();
            while (!int.TryParse(line, out number) || number <= 0) {
                Console.Write(Constants.incorrectStorageCapacity + ": ");
                line = Console.ReadLine();
            }
            return number;
        }
    }
}
