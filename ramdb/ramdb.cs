using ramdb.src;
using Newtonsoft.Json;
using ramdb.Except;
using System;


namespace ramdb;
public class Ramdb
{
        private Dictionary<string, object[]>[] mem;
        private int dbnum;
        private int max_db = 100;
        private IOHelper ih;
        private string tempkey;

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
                        this.mem = new Dictionary<string, object[]>[max_db];
                        for (int a = 0; a < max_db; a++)
                        {
                                this.mem[a] = new Dictionary<string, object[]>();
                        }
                }
        }
        private void makeInit()
        {


        }
        private Dictionary<string, object[]>[] loadfromfile()
        {
                return JsonConvert.DeserializeObject<Dictionary<string, object[]>[]>(this.ih.ReadFile());
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
        public Ramdb set(string key, string value)
        {
                this.tempkey = key;
                try
                {
                        object[] data = {
                                value, (long)0
                        };
                        volatile_mem.set(this.mem[dbnum], key, data);
                }
                catch (System.ArgumentException)
                {
                        this.mem[dbnum][key][0] = value;
                }
                return this;

        }
        public void DeleteAfter(long? second)
        {
                if (second != 0 && second != null)
                {
                        DateTime foo = DateTime.Now;
                        long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
                        this.mem[dbnum][this.tempkey][1] = unixTime + second;
                }


        }
        public string get(string key)
        {
                middleware.deleteAutoAfter(this.mem, dbnum);
                return volatile_mem.get(this.mem[dbnum], key);
        }
        public bool del(string key)
        {
                return volatile_mem.del(this.mem[dbnum], key);
        }
        public void commit()
        {

                this.ih.WriteFile(JsonConvert.SerializeObject(this.mem));
                return;
        }
}
