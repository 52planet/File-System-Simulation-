using System;
using System.Collections.Generic;
using System.Text;

namespace file_system_sim
{
    class Filesystem
    {
        List<Volume> volumes = new List<Volume>();

        Volume m_mount; //volume that is currently mounted

        bool volume_is_mounted;

        public bool Allocate(String name, int size)
        {
            //check to see if volume of same name exists
            foreach (Volume v in volumes)
            {
                if (name == v.getName())
                {
                    //A volume of the same name exists
                    Console.WriteLine("Cant allocate, volume already exists!");
                    return false;
                }
            }
            
            //create new volume
            Volume vol = new Volume(name, size);
            volumes.Add(vol);

            return true;

        }

        public bool Deallocate(String name)
        {
            //check to see if volume of same name exists
            for (int i = 0; i < volumes.Count; i++)
            {
                if (name == volumes[i].getName())
                {
                    //A volume of the same name exists so we delete
                    volumes.Remove(volumes[i]);
                    return true;
                }
            }

            //volume of the same name not found
            return false;
        }

        public int Truncate(String name)
        {
            //check to see if volume of same name exists
            foreach (Volume v in volumes)
            {
                if (name == v.getName())
                {
                    int size = v.get_size();
                    //A volume of the same name exists so we delete
                    volumes.Remove(v);
                    return size;
                }
            }

            //volume of the same name not found
            return -1;
        }

        public void Dump(String name)
        {
            //check to see if volume of same name exists
            for (int i = 0; i < volumes.Count; i++)
            {
                if (name == volumes[i].getName())
                {
                    //A volume of the same name exists so display its contents
                    volumes[i].Dump();
                }
            }
        }

        public void Mount(String name)
        {
            int flag = 0;
            //check to see if volume of same name exists
            for (int i = 0; i < volumes.Count; i++)
            {
                if (name == volumes[i].getName())
                {
                    //A volume of the same name exists so we can mount it
                    m_mount = volumes[i];

                    volume_is_mounted = true;

                    Console.WriteLine("Volume has been mounted!");
                    flag++;

                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Volume does not exist!");
            }
        }

        public void UnMount()
        {
            //unmount
            volume_is_mounted = false;
            Console.WriteLine("Volume has been unmounted!");
        }

        public Volume getMountedVolume()
        {          
                return m_mount;          
        }

        public bool getMountedStatus()
        {
            return volume_is_mounted;
        }

        public void Info()
        {
            if (volume_is_mounted == true)
            {
                m_mount.Info();
            }
            else 
            {
                Console.WriteLine("No volume mounted!");
            }
            
        }

      


    }
}
