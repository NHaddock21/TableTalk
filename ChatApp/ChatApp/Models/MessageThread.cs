using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChatApp.Models
{
    class Message_Thread
    {
        [PrimaryKey, AutoIncrement]
        public int Message_Thread_id { get; set; }


        string thread_name;
        public string Thread_Name
        {
            get { return thread_name; }
            set { thread_name = value; OnPropertyChanged(nameof(Thread_Name)); }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void ClearFields()
        {
            Thread_Name = string.Empty;
        }
    }
}