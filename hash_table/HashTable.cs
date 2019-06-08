using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_table
{
    class HashTable
    {
        private Dictionary<int, object> table;
        public HashTable(int size)
        {
            table = new Dictionary<int, object>(size);
        }

        public void PutPair(object key, object value)
        {
            var hash = key.GetHashCode();
            if (table.ContainsKey(hash))
                table[hash] = value;
            else
                table.Add(hash, value);
        }

        public object GetValueByKey(object key)
        {
            var hash = key.GetHashCode();
            if (table.ContainsKey(hash))
                return table[hash];
            return null;
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Чтобы работало");
        }
    }
}
