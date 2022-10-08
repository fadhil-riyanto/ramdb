using ramdb.src;
namespace ramdb;
public class Ramdb
{
        private Dictionary<string, string> mem; 

        public Ramdb(string filename, string folder)
        {
                IOHelper ih = new IOHelper(filename, folder);
                ih.makeWhenNotExist();
                this.mem = new Dictionary<string, string>();
        }
        public void set(string key, string value)
        {
                volatile_mem.set(this.mem, key, value);
        }
        public string get(string key)
        {
                return volatile_mem.get(this.mem, key);
        }
}
