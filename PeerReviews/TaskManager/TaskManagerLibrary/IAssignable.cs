using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerLibrary
{
    /// <summary>
    /// Интерфейс, который релизует ограничение количество исполнителей у каждой задачи.
    /// </summary>
    public interface IAssignable
    {
        // Список пользователей - исполнителей.
        List<User> Users { get; }

        /// <summary>
        /// Метод добавления пользователя в список исполнителей.
        /// </summary>
        /// <param name="user">Пользователь</param>
        void AddUser(User user);

        /// <summary>
        /// Удаление пользователя из списка исполнителей.
        /// </summary>
        /// <param name="user"></param>
        void RemoveUser(User user);
    }
}
