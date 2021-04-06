using System;

namespace TaskManagerLibrary
{
    /// <summary>
    /// Класс, реализующий сущность Статуса для задачи.
    /// </summary>
    public class Status
    {
        // Типы статусов.
        public string Type { get; }
        public static string Open { get; } = "open";
        public static string Inwork { get; } = "inwork";
        public static string Closed { get; } = "closed";

        public Status(string type)
        {
            type = type.Trim().ToLower();
            if (type != Open && type != Inwork && type != Closed)
                throw new ArgumentException("Incorrect task status");

            Type = type;
        }
    }
}
