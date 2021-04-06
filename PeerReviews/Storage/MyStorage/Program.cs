using System;
using System.Text;

namespace MyStorage {
    class Program {
        public static bool russianLang;
        public static bool consoleInput;
        static void Main(string[] args) {

            // Choose encoding and language.
            Console.OutputEncoding = Encoding.UTF8;
            russianLang = Logics.SelectLanguage();
            Constants.GetRightOutput(russianLang);
            Console.Clear();

            //consoleInput = Logics.SelectInput();
            //Console.Clear();
            // Start program.
            try {
                Logics.Start();
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
