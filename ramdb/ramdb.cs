using ramdb.src;
namespace ramdb;
public class Ramdb
{
        private Dictionary<string, string>[] mem; 
        private int dbnum;

        public Ramdb(string filename, string folder)
        {
                IOHelper ih = new IOHelper(filename, folder);
                ih.makeWhenNotExist();
                this.mem = new Dictionary<string, string>[10];
                for(int a = 0; a<10; a++)
                {
                        this.mem[a] = new Dictionary<string, string>();
                }
                
        }
        public Ramdb setDb(int db)
        {
                this.dbnum = db;
                return this;
        }
        public void set(string key, string value)
        {
                volatile_mem.set(this.mem[dbnum], key, value);
        }
        public string get(string key)
        {
                return volatile_mem.get(this.mem[dbnum], key);
        }
}
