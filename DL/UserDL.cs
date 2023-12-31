﻿using Buisness_Application.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Application.DL
{
    class UserDL
    {
        
        public static bool RemoveUserFromList(string name)
        {
            bool flag = false;
            for (int i = 0; i < Admin.GetUserList().Count; i++)
            {
                User u = Admin.GetUserList()[i];
                if (name == u.GetUsername())
                {
                    if (u is Hostelite)
                    {
                        Admin.GetUserList().RemoveAt(i);
                        flag = true;
                    }
                }
            }

            
            
            return flag;
        }
        public static void StoreUsersInFile(string path)
        {
            StreamWriter file = new StreamWriter(path, false);
            foreach(User i in Admin.GetUserList())
            {
                if(i is Hostelite)
                {
                    Hostelite h = (Hostelite)i;
                    file.WriteLine(i.GetUsername() + "," + i.GetPassword() +  "," + i.returnRole() + "," + h.GetRollNumber()+ "," + h.GetCnic() + "," + h.GetCity() + "," + h.GetRoomNumber());
                }
                if(i is Admin)
                {
                    Admin a = (Admin)i;
                    file.WriteLine(i.GetUsername() + "," + i.GetPassword() + "," + i.returnRole() + "," + a.GetContact());
                }
                if(i is Finance)
                {
                    Finance f = (Finance)i;
                    file.WriteLine(i.GetUsername() + "," + i.GetPassword() + "," + i.returnRole() + "," + f.GetEmployeeNumber());
                }
            }
            file.Flush();
            file.Close();
        }

        public static void LoadUsersFromFile(string path)
        {
            if (File.Exists(path))
            {

                StreamReader file = new StreamReader(path);
                string record;

                while ((record = file.ReadLine()) != null)
                {
                    string name = Parsing(record, 1);
                    string password = Parsing(record, 2);
                    string role = Parsing(record, 3);
                    string rollNumber = Parsing(record, 4);

                    if (role == "hostelite")
                    {
                        
                        string cnic = Parsing(record, 5);
                        string city = Parsing(record, 6);
                        string roomNumber = Parsing(record, 7);
                        Hostelite h = new Hostelite(name, cnic, city, rollNumber, password, role, roomNumber);
                        Admin.AdddInList(h);
                    }
                    else if(role == "admin")
                    {
                        Admin a = new Admin(name, password, rollNumber, role);
                        Admin.AdddInList(a);
                    }

                    else if(role == "Finance")
                    {
                        Finance f = new Finance(name, password, role, rollNumber);
                        Admin.AdddInList(f);
                    }
                }
                file.Close();

            }
        }

        public static string Parsing(string record, int field)
        {
            int count = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    count++;
                }
                else if (count == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }

    }
}
