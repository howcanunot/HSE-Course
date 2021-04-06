using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager {
    partial class Program {


        static string greetings = "\n--- Welcome to my own File Manager ---\n";
        static string help = "[Info] Please, read the list of available commands, this is very important:";
        static string description = "[Info] This is simple file manager.\n" +
            "       It can do simple operations on files and \n" +
            "       directories using the commands described below.\n" +
            "       You can use / or \\ for all platforms.\n" +
            "       You will start from disk " + GetCurrentDisk() + ", but you can change the current disk at any time.\n" +
            "       Use extension in names of files(.txt) otherwise programm will not handle names correctly.\n" +
            "       If you work on Mac OS, use / in the beginning of your path for absolute path.\n" +
            "       By the way, the program may behave odd on Mac OS, because i didn't have occasion to test it.\n";

        static string avaliableEncodings = "[Info] List of available encodings:\n" +
            "       UTF-8\n" +
            "       Unicode(UTF-16)\n" +
            "       Ascii\n" +
            "       Default\n";

        static string commands = "\t <argument> - required argument\n" +
                                 "\t [argument] - not required argument\n\n" +
                                 "\t" + @"If something has more than 2 words, use "" "". For instans ""Program files""." + "\n\n" +
                                 "\t > disks\n" +
                                 "\t     Get list of available disks.\n" +
                                 "\t" + @"     To change disk enter cd <name_of_disk>:\ .+" + "\n\n" +
                                 "\t > cd <directory_path>\n" +
                                 "\t     Go to directory <directory_path>. You can use absolute\n" +
                                 "\t     Or relative path(from current directory).\n" +
                                 "\t     Use <directory_path>='..' to go back.\n\n" +
                                 "\t > dir [directory_path]\n" +
                                 "\t     Get [directory_path] content. Use absolute path.\n" +
                                 "\t     Use this command without argument to get content of current directory.\n\n" +
                                 "\t > print <file_name.txt> [encoding]\n" +
                                 "\t     Print file content in the current directory using encoding=[encoding].\n" +
                                 "\t     Use this command without second argument to get file content using UTF-8.\n\n" +
                                 "\t > copy <file_name.txt> [directory_path]\n" +
                                 "\t     Copy file from current directory to the [directory_path]. Use absolute path and extension.\n" +
                                 "\t     Use this command without second argument to copy file in current directory.\n\n" +
                                 "\t > move <file_name> <directory_path>\n" +
                                 "\t     Move file from current directory to <directory_name>.\n" +
                                 "\t     Use extension to move file or not to move directory.\n\n" +
                                 "\t > del <file_name>\n" +
                                 "\t     Delete file from current directory.\n" +
                                 "\t     Use extension to delete file or not to delete directory.\n\n" +
                                 "\t > new <file_name> [encoding]\n" +
                                 "\t     Create empty file(or directory) in current directory\n" +
                                 "\t     Using encoding=[encoding](for txt file).\n" +
                                 "\t     Use extension create file or not to create empty directory.\n" +
                                 "\t     Use this command without second argument to create txt file using UTF-8.\n" +
                                 "\t     If you create txt file, input your text after command. Write //null to end input.\n\n" +
                                 "\t > merge <list_of_file_name.txt> <file_name.txt>\n" +
                                 "\t     Merge list of txt files and save it in <file_name.txt>(in current directory) using UTF-8.\n" +
                                 "\t     You can merge 2 or more files. Use extension.\n" +
                                 "\t     Enter names of files using space.\n" +
                                 "\t     You can use absolute path or file in your current directory.\n" +
                                 "\t     You should enter absolute path correctly.\n\n" +
                                 "\t > clean\n" +
                                 "\t     Clean console\n\n" +
                                 "\t > exit\n" +
                                 "\t     Exit the programm.\n\n";

        static string note = "[Info] Use command 'help' to get list of available commands.\n";
        static string IncorrectPath = "[!] Could not find this path";
        static string IncorrectArguments = "[!] Incorrect arguments\n";


    }
}
