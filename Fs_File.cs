using System;
using System.Collections.Generic;
using System.Text;

namespace file_system_sim
{
    class Fs_File
    {
         
        //meta data
        String Filename;        
        bool ReadOnly;
        String DateCreated;
        String TimeCreated;
        String DateLastModified;
        String TimeLastModified;
        //cluster where data is stored
        Cluster memory;

        public Fs_File(String fn, Cluster cluster, bool permissions)
        {
            Filename = fn;          
            ReadOnly = permissions;
            DateCreated = DateTime.Now.ToString("MM/dd/yyyy");
            TimeCreated = DateTime.Now.ToString("HH:mm:ss");
            DateLastModified = DateTime.Now.ToString("MM/dd/yyyy");
            TimeLastModified = DateTime.Now.ToString("HH:mm:ss");
            memory = cluster;
            memory.setOccupied();
        }

        public String getFileName()
        {
            return Filename;
        }

        public void WriteToFile(int offset, String data)
        {
            if (ReadOnly == false)
            {
                memory.write(offset, data);
                DateLastModified = DateTime.Now.ToString("MM/dd/yyyy");
                TimeLastModified = DateTime.Now.ToString("HH:mm:ss");
            }
            else 
            {
                Console.WriteLine("File is ReadOnly!");
            }
            
        }

        public void readFromFile(int start, int end)
        {
            memory.read(start, end);
        }

        public void set(bool perm)
        {
            ReadOnly = perm;
        }

        public void delete()
        {
            memory.delete();
        }

        public void info()
        {
            Console.WriteLine("The Filename is: {0}\n", Filename);
            Console.WriteLine("The file size in bytes is: {0}\n", memory.getSize());
            Console.WriteLine("Read only: {0}\n", ReadOnly);
            Console.WriteLine("Date Created: {0}\n", DateCreated);
            Console.WriteLine("Time Created: {0}\n", TimeCreated);
            Console.WriteLine("Date last Modified: {0}\n", DateLastModified);
            Console.WriteLine("Time last Modified: {0}\n", TimeLastModified);

        }

       
    }
}
