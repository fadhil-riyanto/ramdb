using ramdb;

namespace ramdb.Test
{
        class Test
        {
                public static void Main()
                {
                        Ramdb rdb = new Ramdb("database.db", "/home/fadhil_riyanto/BALI64/ram-database/ramdb.Test/data");
                        rdb.setDb(0).set("hai", "ngueeeng");
                        rdb.setDb(0).set("hai2", "fadhil");
                        // rdb.setDb(0).set("hai3", "fadhil");
                        rdb.setDb(3).set("hai4", "fadhil");
                        // rdb.setDb(3).set("hai5", "fadhil");

                        Console.WriteLine(rdb.setDb(3).get("hai4"));
                        
                        // try{
                        //         Console.WriteLine(rdb.setDb(1).get("hai"));
                        // } catch (ramdb.Except.KeyNotFoundException)
                        // {
                        //         Console.WriteLine("err");
                        // }

                        rdb.commit();
                        // int[] pp = new int[3];
                        // pp[1] = 9;

                        // Console.WriteLine(pp[1]);

                }
        }
}