using System;
using System.IO;

namespace ramdb.src
{
        internal class IOHelper
        {
                private string filename;
                private string folder;
                private string file;
                public IOHelper(string filename, string folder)
                {
                        this.filename = filename;
                        this.folder = folder;
                        this.file = $"{this.folder}/{this.filename}";
                }
                private bool isExist()
                {
                        return File.Exists(this.file);
                }

                public bool makeWhenNotExist()
                {
                        if (!this.isExist())
                        {

                                File.Create(this.file);
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }

                public void WriteFile(string serealized_data)
                {
                        using (var stream = File.Open(this.file, FileMode.Create))
                        {
                                using (var writer = new BinaryWriter(stream, System.Text.Encoding.UTF8, false))
                                {
                                        writer.Write(serealized_data);
                                }
                        }

                }
                public void ReadFile()
                {
                        using (var stream = File.Open(this.file, FileMode.Open))
                        {
                                using (var reader = new BinaryReader(stream, System.Text.Encoding.UTF8, false))
                                {
                                        
                                        Console.WriteLine(reader.ReadString());
                                }
                        }

                }
        }
}