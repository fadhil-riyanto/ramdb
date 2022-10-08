using ramdb;
namespace ramdb.Test
{
        class Test
        {
                public static void Main()
                {
                        Ramdb rdb = new Ramdb("database.db", "/home/fadhil_riyanto/BALI64/ram-database/ramdb.Test/data");
                        rdb.set("hai", "kang");

                        Console.WriteLine(rdb.get("hai"));

                }
        }
}