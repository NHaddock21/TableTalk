using ChatApp.Models;
using ChatApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChatApp.Services
{
    internal class LoginService
    {
        static SQLiteAsyncConnection data;
        public static int userID;


        public int getUserID()
        {
            return userID;
        }
        static async Task Init()
        {

            //Checks if data location already assigned
            if (data != null)
                return;

            //Assigns if not
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            data = new SQLiteAsyncConnection(databasePath);

            await data.CreateTableAsync<User>();
            

        }

        public async Task LoginUsername(string email, string pass)
        {
            await Init();
            string userEmail = null;
            string userPass = null;
            //var query = data.QueryAsync<Users>("select email from users where email = ?", email);

            var query = data.Table<User>().Where(s => s.Email.Equals(email));

            var result = await query.ToListAsync();

            if (result.Count != 0)
            {
                userEmail = result[0].Email;
                userPass = result[0].Password;
            }
            //userPass = db.QueryAsync<Users>("select password from users where email = ?", email).ToString();

            Console.WriteLine(userEmail);
            //Console.WriteLine(userPass);

            if (userEmail == null)
            {
                MessagingCenter.Send<LoginService>(this, "Error");
                return;
            }
            else
            {
                if (userPass == pass)
                {
                    userID = result[0].UserID;
                    List<string> emailList = new List<string>();
                    emailList.Add(userEmail);
                    //SendEmail se = new SendEmail();
                    // se.Email(emailList);
                    await Shell.Current.GoToAsync($"//HomePage");
                }
                else
                {
                    MessagingCenter.Send<LoginService>(this, "Error");

                }
            }
        }

        public async Task LoginPassword(string email, string pass)
        {
            await Init();
            string userEmail = null;
            string userPass = null;
            //var query = data.QueryAsync<Users>("select email from users where email = ?", email);

            var query = data.Table<User>().Where(s => s.Email.Equals(email));

            var result = await query.ToListAsync();

            if (result.Count != 0)
            {
                userEmail = result[0].Email;
                userPass = result[0].Password;
            }
            //userPass = db.QueryAsync<Users>("select password from users where email = ?", email).ToString();

            Console.WriteLine(userEmail);
            //Console.WriteLine(userPass);

            if (userEmail == null)
            {
                MessagingCenter.Send<LoginService>(this, "Error");
                return;
            }
            else
            {
                if (userPass == pass)
                {
                    userID = result[0].UserID;
                    List<string> emailList = new List<string>();
                    emailList.Add(userEmail);
                    //SendEmail se = new SendEmail();
                    // se.Email(emailList);
                    await Shell.Current.GoToAsync($"//HomePage");
                }
                else
                {
                    MessagingCenter.Send<LoginService>(this, "Error");

                }
            }
        }

        public async Task UserCreateAccount(string fname, string lname, string email, string password, string securityQuestion, string securityAnswer)
        {
            await Init();
            var user = new User
            {
                FName = fname,
                LName = lname,
                Email = email,
                Password = password,
                SecurityQuestion = securityQuestion,
                SecurityAnswer = securityAnswer
            };
            List<string> emailList = new List<string>();
            emailList.Add(email);
            //SendEmail se = new SendEmail();
            //se.Email(emailList); 
            await data.InsertAsync(user);
        }

        public static async Task ForgotPassword(string email)
        {
            await Init();
        }


    }

}

//Get Each part of an event
// var query = data.Table<Event>().Where(s => s.ID.Equals(ID));