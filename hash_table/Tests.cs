using System;
using NUnit.Framework;

namespace hash_table
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void TestThreeElements()
        {
            var table = new HashTable(3);

            table.PutPair("Pushkin", "The captain's daughter");
            table.PutPair("Lermontov", "A hero of our time");
            table.PutPair("Tolstoy", "War and peace");

            Assert.AreEqual("The captain's daughter", table.GetValueByKey("Pushkin"));
            Assert.AreEqual("A hero of our time", table.GetValueByKey("Lermontov"));
            Assert.AreEqual("War and peace", table.GetValueByKey("Tolstoy"));
        }

        [Test]
        public void TestAddingTheSameElement()
        {
            var table = new HashTable(2);

            table.PutPair("Pushkin", "The captain's daughter");
            table.PutPair("Pushkin", "Dubrovsky");

            Assert.AreEqual("Dubrovsky", table.GetValueByKey("Pushkin"));
        }

        [Test]
        public void TestSearchingOneElement()
        {
            var rnd = new Random();
            var table = new HashTable(10000);
            var toFindKey = RandomString(10);
            var toFindValue = RandomString(10);

            var put = rnd.Next(0, 1000);

            for (int i = 0; i < 10000; i++)
            {
                if (i == put)
                    table.PutPair(toFindKey, toFindValue);
                else
                    table.PutPair(RandomString(5), RandomString(5));
            }
            Assert.AreEqual(toFindValue, table.GetValueByKey(toFindKey));
        }

        [Test]
        public void TestSearching()
        {
            var table = new HashTable(10000);
            for (int i = 0; i < 10000; i++)
                table.PutPair(RandomString(10), RandomString(10));

            for (int i = 0; i < 1000; i++)
                Assert.AreEqual(null, table.GetValueByKey(i));
        }

        private string RandomString(int size)
        {
            var rnd = new Random();
            string randomString = "";
            char letter;
            int randomNumber;
            for (int i = 0; i < size; i++)
            {
                randomNumber = rnd.Next(0, 11);
                if (randomNumber % 2 == 0)
                    letter = Convert.ToChar(rnd.Next(97, 123));
                else
                    letter = Convert.ToChar(rnd.Next(65, 91));
                randomString += letter;
            }
            return randomString;
        }
    }
}
