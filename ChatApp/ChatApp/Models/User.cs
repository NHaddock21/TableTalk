﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChatApp.Models
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }

        string fName;
        public string FName
        {
            get { return fName; }
            set { fName = value; OnPropertyChanged(nameof(FName)); }
        }
        string lName;
        public string LName
        {
            get { return lName; }
            set { lName = value; OnPropertyChanged(nameof(LName)); }
        }
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }
        string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(nameof(Password)); }
        }

        string securityAnswer;

        public string SecurityAnswer
        {
            get { return securityAnswer; }
            set { securityAnswer = value; OnPropertyChanged(nameof(SecurityAnswer)); }
        }

        public string profilePicture;
        public string ProfilePicture
        {
            get { return profilePicture; }
            set { profilePicture = value; OnPropertyChanged(nameof(ProfilePicture)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void ClearFields()
        {
            FName = string.Empty;
            LName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;

        }


    }
}
