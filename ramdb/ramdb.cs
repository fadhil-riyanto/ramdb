using ramdb.src;
using Newtonsoft.Json;
using ramdb.Except;


namespace ramdb;
public class Ramdb
{
        private Dictionary<string, string>[] mem;
        private int dbnum;
        private int max_db = 100;
        private IOHelper ih;

        public Ramdb(string filename, string folder)
        {
                IOHelper ih = new IOHelper(filename, folder);
                this.ih = ih;

                ih.makeWhenNotExist();

                // load from file
                try
                {
                        this.mem = this.loadfromfile(); // load first
                }
                catch (System.ArgumentNullException) // if file is blank / new file
                {
                        this.mem = new Dictionary<string, string>[max_db];
                        for (int a = 0; a < max_db; a++)
                        {
                                this.mem[a] = new Dictionary<string, string>();
                        }
                }
        }
        private void makeInit()
        {


        }
        private Dictionary<string, string>[] loadfromfile()
        {
                return JsonConvert.DeserializeObject<Dictionary<string, string>[]>(this.ih.ReadFile());
        }
        public Ramdb setDb(int db)
        {
                if (db > this.max_db)
                {
                        throw new MaxDbReached("maximal only " + this.max_db);
                }
                this.dbnum = db;
                return this;
        }
        public void set(string key, string value)
        {
                try
                {
                        volatile_mem.set(this.mem[dbnum], key, value);
                }
                catch (System.ArgumentException)
                {
                        this.mem[dbnum][key] = value;
                }

        }
        public string get(string key)
        {
                return volatile_mem.get(this.mem[dbnum], key);
        }
        public void commit()
        {

                this.ih.WriteFile(JsonConvert.SerializeObject(this.mem));
                return;
        }
}
