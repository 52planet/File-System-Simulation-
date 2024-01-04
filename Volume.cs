using System;
using System.Collections.Generic;
using System.Text;

namespace file_system_sim
{
    public class Volume
    {
        String Fs_name;
        Cluster m_root;
        LinkedList<Cluster> clusters = new LinkedList<Cluster>();
        List<Fs_File> fs_Files = new List<Fs_File>();
        int m_size;

        public Volume(String name, int size)
        {
            Fs_name = name;
            m_size = size;
            //create LinkedList with the size passed in
            for (int i = 0; i < m_size; i++)
            {
                Cluster cluster = new Cluster(512); //byte arrays of size 512
                clusters.AddFirst(cluster);
            }
            m_root = clusters.First.Value;
        }

        public String getName()
        {
            return Fs_name;
        }

        public void reset()
        {
            clusters.Clear(); //delete all old data in cluster and create a fresh new cluster linkedlist

            for (int i = 0; i < m_size; i++)
            {
                Cluster cluster = new Cluster(512); //byte arrays of size 512
                clusters.AddFirst(cluster);
            }
            m_root = clusters.First.Value;
        }

        public void Dump()
        {
            Console.WriteLine("Volume Name: {0}\n", Fs_name);
            Console.WriteLine("Volume size: {0}\n", m_size);

            //begin to display all the clusters within the volume
            foreach (Cluster node in clusters)
            {
                node.display_properties();
            }


        }

        public void Info()
        {
            int empty_clusters = 0; //store amount of empty clusters       
            
            Console.WriteLine("Volume Name: {0}\n", Fs_name);
            Console.WriteLine("Volume size: {0}\n", m_size);

            //get free space
            for (LinkedListNode<Cluster> node = clusters.First; node != null; node = node.Next)
            {
                //print info about the cluster to the console
                if (node.Value.getOccupied() == false)
                {
                    //increment
                    empty_clusters++;
                }            

            }

            Console.WriteLine("There are: {0} unallocated clusters in the volume\n", empty_clusters);
            Console.WriteLine("There are: {0} files  in the volume\n", fs_Files.Count);

        }

        //FILE COMMANDS

        public void Create(String name)
        {
        
            foreach (Cluster node in clusters)
            {
                //find first available empty cluster
                if (node.getOccupied() == false)
                {
                    //define file
                    Fs_File file = new Fs_File(name, node, true);
                    //insert into list
                    fs_Files.Add(file);
                    //exit loop
                    break;
                }
            }

        }

        public void Write(String name, int start, String data)
        {
            int flag = 0;
            //search for file
            foreach (Fs_File file in fs_Files)
            {
                if (file.getFileName() == name)  //file found
                {
                    //write to the file at offset
                    file.WriteToFile(start, data);
                    flag++;
                }
            }

            if (flag == 0)
            {
                Console.WriteLine("File does not exist!");
            }
        }

        public void read(String name, int start, int end)
        {
            //search for file
            for (int i = 0; i < fs_Files.Count; i++)
            {
                if (fs_Files[i].getFileName() == name)  //file found
                {
                    //read from the file at offset
                    fs_Files[i].readFromFile(start,end);


                }
            }
        }

        public void delete(String name)
        {
            //search for file
            for (int i = 0; i < fs_Files.Count; i++)
            {
                if (fs_Files[i].getFileName() == name)  //file found
                {
                    //free the memory used by the file 
                    fs_Files[i].delete();
                    //Delete file
                    fs_Files.Remove(fs_Files[i]);
                }
            }
        }

        public void file_info(String fn)
        {
            foreach (Fs_File file in fs_Files)
            {
                if (file.getFileName() == fn)
                {
                    file.info(); //print info to the console
                }
            }
        }

        public void set(String fn, bool permission)
        {
            foreach (Fs_File file in fs_Files)
            {
                if (file.getFileName() == fn)
                {
                    file.set(permission); //print info to the console
                }
            }
        }

        public int get_size()
        {
            return m_size;
        }


    }
}
