using ramdb;

namespace ramdb.Test
{
        class Test
        {
                public static void Main()
                {
                        Ramdb rdb = new Ramdb("database.db", "/home/fadhil_riyanto/BALI64/ram-database/ramdb.Test/data");
                        rdb.setDb(0).set("hai", "fadhil");

                        Console.WriteLine(rdb.setDb(0).get("hai"));
                        
                        try{
                                Console.WriteLine(rdb.setDb(1).get("hai"));
                        } catch (ramdb.Except.KeyNotFoundException)
                        {
                                Console.WriteLine("err");
                        }
                        // int[] pp = new int[3];
                        // pp[1] = 9;

                        // Console.WriteLine(pp[1]);

                }
        }
}