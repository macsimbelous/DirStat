using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirStat
{
    class Program
    {
        static void Main(string[] args)
        {
            string dest_dir = @"D:\Pictures\AnimeArt\UnSorted\";
            List<dirinfo> dirstat = new List<dirinfo>();
            string[] dirs = Directory.GetDirectories(args[0]);
            foreach (string dir in dirs)
            {
                dirinfo di = new dirinfo();
                di.full_name = dir;
                di.name = Path.GetFileName(dir);
                string[] files = Directory.GetFiles(dir);
                di.files_count = files.Length;
                foreach (string file in files)
                {
                    System.IO.FileInfo f = new System.IO.FileInfo(file);
                    di.files_size = di.files_size + f.Length;
                }
                dirstat.Add(di);
            }
            foreach (dirinfo di in dirstat)
            {
                if (di.files_count < 101)
                {
                    Directory.Move(di.full_name, dest_dir + di.name);
                    Console.WriteLine("{0} MOVE TO {1}", di.name, dest_dir);
                }
            }
            return;
            foreach (dirinfo di in dirstat)
            {
                if (di.files_count != 0)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", di.name, di.files_count, di.files_size, (di.files_size / di.files_count));
                }
                else { Console.WriteLine("{0}, {1}, {2}, {3}", di.name, di.files_count, di.files_size, 0); }
            }
        }
    }
    public class dirinfo
    {
        public string full_name;
        public string name;
        public int files_count;
        public long files_size;
    }
}
