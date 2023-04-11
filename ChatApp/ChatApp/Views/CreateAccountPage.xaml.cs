﻿using System;
using System.Collections.Generic;
using System.Linq;
using ChatApp.Models;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChatApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;


namespace ChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        public User User { get; } = new User(); 


        public CreateAccountPage()
        {
            InitializeComponent();
            resultImage.Source = "test_profile.png";
            

        }

        async void Profile_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please Pick a Photo"
            });

            var stream = await result.OpenReadAsync();

            

            resultImage.Source = ImageSource.FromStream(() => stream);



        }

        public bool ValidFirstName(string fname)
        {
            var firstname = fname;
            var firstnamePattern = new Regex("^[A-Z][a-zA-Z]*$");
            if (firstnamePattern.IsMatch(firstname))
            {
                return true;
            }
            else return false;
        }

        public bool ValidLastName(string lname)
        {
            var lastname = lname;
            var lastnamePattern = new Regex("^[A-Z][a-zA-Z]*$");
            if (lastnamePattern.IsMatch(lastname))
            {
                return true;
            }
            else return false;
        }

        public bool ValidEmail(string email)
        {
            var emailtxt = email;
            var emailPattern = new Regex("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])");
            if (emailPattern.IsMatch(email) && email.Contains("@snhu.edu"))
            {
                return true;
            }
            else return false;
        }

        public bool ValidPassword(string p1)
        {
            var password = p1;
            var passwordPattern = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (passwordPattern.IsMatch(password))
            {
                return true;
            }
            else return false;

        }

        public bool PasswordMatch(string p1, string p2)
        {
            if (p1 == p2)
            {
                return true;
            }
            else return false;
        }

        private async void SubmitClicked(object sender, EventArgs e)
        {
            string firstName = "";
            string lastName = "";
            string email = "";
            string password = "";
            string securityQuestion = "";
            string securityAnswer = "";
            if (FirstNametxt.Text == null)
            {
                FirstNameError.Text = "Error First Name Required";
            }
            else if (!ValidFirstName(FirstNametxt.Text))
            {
                FirstNameError.Text = "Error Invalid First Name";
            }
            else
            {
                FirstNameError.Text = "";
            }
            if (LastNametxt.Text == null)
            {
                LastNameError.Text = "Error Last Name Required";
            }
            else if (!ValidLastName(LastNametxt.Text))
            {
                LastNameError.Text = "Error Invalid Last Name";
            }
            else
            {
                LastNameError.Text = "";
            }
            if (Emailtxt.Text == null)
            {
                EmailError.Text = "Error Email is Required";
            }
            else if (!ValidEmail(Emailtxt.Text))
            {
                EmailError.Text = "Error Email Must be a valid SNHU Email";
            }
            else
            {
                EmailError.Text = "";
            }
            if (Passwordtxt.Text == null)
            {
                PasswordError.Text = "Error Password is Required";

            }
            else if (!ValidPassword(Passwordtxt.Text))
            {
                PasswordError.TextColor = Color.Red;
                PasswordError.Text = "Invalid Password!";
            }
            else
            {
                PasswordError.Text = "";
            }
            if (PasswordMatchtxt.Text == null)
            {
                PasswordMatchError.Text = "Password Confirmation Required";
            }
            else if (!PasswordMatch(Passwordtxt.Text, PasswordMatchtxt.Text))
            {
                PasswordMatchError.Text = "Error Passwords do not Match";
            }
            else
            {
                PasswordMatchError.Text = "";
            }
            
            if (FirstNametxt.Text != null && LastNametxt.Text != null && Emailtxt != null && Passwordtxt != null && PasswordMatchtxt != null && ValidFirstName(FirstNametxt.Text) == true &&
                ValidLastName(LastNametxt.Text) == true && ValidEmail(Emailtxt.Text) == true && ValidPassword(Passwordtxt.Text) == true && PasswordMatch(Passwordtxt.Text, PasswordMatchtxt.Text) == true)
            {
                firstName = FirstNametxt.Text;
                lastName = LastNametxt.Text;
                email = Emailtxt.Text;
                password = Passwordtxt.Text;
                //securityQuestion = Questiontxt.Text;
                securityAnswer = Answertxt.Text;

                LoginService data = new LoginService();
                await data.UserCreateAccount(firstName, lastName, email, password, securityQuestion, securityAnswer);
                await Shell.Current.GoToAsync($"//UsernamePage");
                //MessagingCenter.Send<CreateAccountPage>(this, "Hi");
            }
            
        }

    }
}