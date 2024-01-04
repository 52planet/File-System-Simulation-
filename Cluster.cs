using System;
using System.Collections.Generic;
using System.Text;

namespace file_system_sim
{
    public class Cluster
    {
        bool Occupied;
        long Size;
        bool HasNext;
        Cluster _next;
        byte[] Data;

        public Cluster()
        {
            Occupied = false;
            Size = 512;
            HasNext = false;
            Data = new byte[Size];
        }

        public Cluster(long s)
        {
            Occupied = false;
            Size = s;
            HasNext = false;
            Data = new byte[Size];
        }

        public void display_properties()
        {
            Console.WriteLine("Cluster in use: {0}\n", Occupied);
            Console.WriteLine("Cluster size: {0}\n", Size);
            
            //Go into every cluster and dump the properties of their byte arrays to the screen
        }

        public bool getOccupied()
        {
            return Occupied;
        }

        public void setOccupied()
        {
            Occupied = true;
        }

        public bool getHasNext()
        {
            return HasNext;
        }

        public long getSize()
        {
            return Size;
        }

        public void write(int offset, String data)
        {
            //convert string to byte array
            byte[] data_in_bytes = Encoding.UTF8.GetBytes(data);

            //check size to make sure all data can fit inside the clusters byte array
            if (offset + data_in_bytes.Length > Data.Length)
            {
                //we need to allocate more memeory and store subsequent data there
                //begin by splitting the data array into two sub arrays, one to fill this cluster and then next in the next cluster
                //byte[] array1 = new byte[Data.Length]; 
                //byte[] array2 = new byte[data_in_bytes.Length - offset];



                //Search for another avaialable cluster
                //once found store in _next 
                //store the remainder of the bytes in next cluster and repeat process if its still not enough space
            }

            //copy the data into the clusters byte array
            Array.Copy(data_in_bytes, 0, Data, offset, data_in_bytes.Length);
        }

        public void read(int start, int end)
        {
            // calculate the number of bytes to read
            int numBytesToRead = end - start + 1;

            // create a new byte array to hold the data
            byte[] dataToRead = new byte[numBytesToRead];


            // copy the data from the Data array to the dataToRead array
            Array.Copy(Data, start, dataToRead, 0, numBytesToRead);

            // print the data to the console
            Console.WriteLine("Data from byte " + start + " to byte " + end + ":");

            foreach (byte b in dataToRead)
            {
                char character = Convert.ToChar(b);
                Console.Write(character);
            }
            Console.WriteLine();


        }

        public void delete()
        {
            Occupied = false;
            Cluster cluster = new Cluster();
            HasNext = false;
            _next = cluster;
        }

    }
}
