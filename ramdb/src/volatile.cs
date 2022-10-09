
namespace ramdb.src
{
        class volatile_mem
        {
                public static void set(Dictionary<string, object[]> mem, string keytoset, object[] data)
                {
                        mem.Add(keytoset, data);
                }
                public static string get(Dictionary<string, object[]> mem, string keytoget)
                {
                        try{
                                return (string)mem[keytoget][0];
                        } catch (System.Collections.Generic.KeyNotFoundException)
                        {
                                throw new ramdb.Except.KeyNotFoundException("key not found");
                        }
                        
                }
                public static bool del(Dictionary<string, object[]> mem, string keytodel)
                {
                        try{
                                return mem.Remove(keytodel);
                        } catch (System.Collections.Generic.KeyNotFoundException)
                        {
                                throw new ramdb.Except.KeyNotFoundException("key not found");
                        }
                        
                }
        }
}