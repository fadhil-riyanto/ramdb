
namespace ramdb.src
{
        class volatile_mem
        {
                public static void set(Dictionary<string, string> mem, string keytoset, string valuetoset)
                {
                        mem.Add(keytoset, valuetoset);
                }
                public static string get(Dictionary<string, string> mem, string keytoset)
                {
                        try{
                                return mem[keytoset];
                        } catch (System.Collections.Generic.KeyNotFoundException)
                        {
                                throw new ramdb.Except.KeyNotFoundException();
                        }
                        
                }
        }
}