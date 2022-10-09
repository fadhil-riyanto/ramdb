using ramdb;

namespace ramdb.Test
{
        class Test
        {
                public static void Main()
                {
                        Console.WriteLine("run");
                        Ramdb rdb = new Ramdb("database.db", "/home/fadhil_riyanto/BALI64/ram-database/ramdb.Test/data");
                        
                        // for(int i = 0; i < 80000; i++)
                        // {
                        //         rdb.setDb(0).set("hai" + i, "ngueeeng").DeleteAfter(60);
                        // }
                        // rdb.setDb(0).set("hai2", "ngueeeng").DeleteAfter(20);
                        //rdb.setDb(4).set("hai3", "ngueeeng").DeleteAfter(30);
                        try{
                                Console.Write(rdb.setDb(0).get("hai63888"));
                        } catch {
                                Console.WriteLine("key not found");
                        }
                        
                        rdb.commit();
                }
        }
}