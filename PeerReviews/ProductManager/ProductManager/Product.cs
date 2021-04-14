using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    [Serializable]
    public class Product
    {
        string name;
        string code;
        string price;
        int count;
        public string Name
        {
            get => name;
            set
            {
                if (value.Length > 30)
                    throw new ArgumentException("Название слишком длинное. Используйте сокращения");
                name = value;
            }
        }
        public string Code { get => code; set { code = value; } }
        public string Price { get => price; set { price = value; } }
        public int Count { get => count; set { count = value; } }

    }
}
