using System;
using System.Collections.Generic;

namespace file_system_sim
{
    class Program
    {
        static void Main(string[] args)
        {
            Filesystem fs = new Filesystem();

            //create UI for the system
            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("TYPE A COMMAND: ");

                string input = Console.ReadLine();

                if (input == "Allocate")  //create new volume
                {
                    Console.WriteLine("ENTER THE VOLUMES NAME: ");
                    string VolumeName = Console.ReadLine();
                    Console.WriteLine("ENTER THE VOLUMES SIZE: ");
                    string VolumeSize = Console.ReadLine();

                    int number = int.Parse(VolumeSize);

                    fs.Allocate(VolumeName, number);
                }

                else if (input == "Deallocate")  //delete volume
                {
                    Console.WriteLine("ENTER THE VOLUMES NAME: ");
                    string VolumeName = Console.ReadLine();
                    fs.Deallocate(VolumeName);
                }

                else if (input == "Truncate")  //Truncate volume
                {
                    Console.WriteLine("ENTER THE VOLUMES NAME: ");
                    string VolumeName = Console.ReadLine();
                    int s = fs.Truncate(VolumeName);
                    if (s != -1)
                    {
                        fs.Allocate(VolumeName, s);
                        fs.UnMount();
                    }
                    else 
                    {
                        Console.WriteLine("Volume does not exist: ");
                    }
                    
                }

                else if (input == "Dump") //Dump volume 
                {
                    Console.WriteLine("ENTER THE VOLUMES NAME: ");
                    string VolumeName = Console.ReadLine();
                    fs.Dump(VolumeName);
                }

                else if (input == "Mount") //Mount volume
                {
                    Console.WriteLine("ENTER THE VOLUMES NAME: ");
                    string VolumeName = Console.ReadLine();
                    fs.Mount(VolumeName);
                }

                else if (input == "UnMount") //UnMount volume
                {
                    fs.UnMount();
                }

                else if (input == "Info")
                {
                    fs.Info();
                }

                //File system commands in the mounted volume

                else if (input == "Create")
                {
                    if (fs.getMountedStatus() == true)
                    {
                        Console.WriteLine("ENTER THE FILES NAME: ");
                        string filename = Console.ReadLine();
                        fs.getMountedVolume().Create(filename);
                    }
                    else
                    {
                        Console.WriteLine("NO VOLUME IS MOUNTED, PLEASE MOUNT A VOLUME FIRST! ");
                    }
                }

                else if (input == "Write") //write to file
                {
                    if (fs.getMountedStatus() == true)
                    {
                        Console.WriteLine("ENTER THE FILES NAME: ");
                        string filename = Console.ReadLine();

                        Console.WriteLine("ENTER THE FILES START: ");
                        string start = Console.ReadLine();
                        int number = int.Parse(start);

                        Console.WriteLine("ENTER THE FILES CONTENTS: ");
                        string data = Console.ReadLine();

                        fs.getMountedVolume().Write(filename, number, data);
                    }
                    else
                    {
                        Console.WriteLine("NO VOLUME IS MOUNTED, PLEASE MOUNT A VOLUME FIRST! ");
                    }
                }

                else if (input == "Read") //read from file
                {
                    if (fs.getMountedStatus() == true)
                    {
                        Console.WriteLine("ENTER THE FILES NAME: ");
                        string filename = Console.ReadLine();

                        Console.WriteLine("ENTER THE FILES START: ");
                        string start = Console.ReadLine();
                        int number = int.Parse(start);

                        Console.WriteLine("ENTER THE FILES END: ");
                        string end = Console.ReadLine();
                        int end_number = int.Parse(end);

                        fs.getMountedVolume().read(filename, number, end_number);
                    }
                    else
                    {
                        Console.WriteLine("NO VOLUME IS MOUNTED, PLEASE MOUNT A VOLUME FIRST! ");
                    }
                }

                else if (input == "Delete") //delete file
                {
                    if (fs.getMountedStatus() == true)
                    {
                        Console.WriteLine("ENTER THE FILES NAME: ");
                        string filename = Console.ReadLine();
                        fs.getMountedVolume().delete(filename);
                       
                    }
                    else
                    {
                        Console.WriteLine("NO VOLUME IS MOUNTED, PLEASE MOUNT A VOLUME FIRST! ");
                    }
                }
                else if (input == "Truncate File") //truncate file
                {
                    if (fs.getMountedStatus() == true)
                    {
                        Console.WriteLine("ENTER THE FILES NAME: ");
                        string filename = Console.ReadLine();
                        //delete
                        fs.getMountedVolume().delete(filename);
                        //create again with same name
                        fs.getMountedVolume().Create(filename);


                    }
                    else
                    {
                        Console.WriteLine("NO VOLUME IS MOUNTED, PLEASE MOUNT A VOLUME FIRST! ");
                    }
                }
                else if (input == "File Info") //display file information
                {
                    if (fs.getMountedStatus() == true)
                    {
                        Console.WriteLine("ENTER THE FILES NAME: ");
                        string filename = Console.ReadLine();
                        fs.getMountedVolume().file_info(filename);

                    }
                    else
                    {
                        Console.WriteLine("NO VOLUME IS MOUNTED, PLEASE MOUNT A VOLUME FIRST! ");
                    }
                }
                else if (input == "Set") //set file permission
                {
                    if (fs.getMountedStatus() == true)
                    {
                        Console.WriteLine("ENTER THE FILES NAME: ");
                        string filename = Console.ReadLine();
                        Console.WriteLine("ENTER THE FILES PERMSSION T OF F: ");
                        string perm = Console.ReadLine();
                        if (perm == "T")
                        {
                            fs.getMountedVolume().set(filename, true);
                        }
                        else if (perm == "F")
                        {
                            fs.getMountedVolume().set(filename, false);
                        }
                        else 
                        {
                            Console.WriteLine("Bad input! ");
                        }
                        

                    }
                    else
                    {
                        Console.WriteLine("NO VOLUME IS MOUNTED, PLEASE MOUNT A VOLUME FIRST! ");
                    }
                }

                else if (input == "Exit") //exit loop
                {
                    exit = true;
                }



            }



        }
    }
}
