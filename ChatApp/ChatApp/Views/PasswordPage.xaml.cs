﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordPage : ContentPage
    {
        public PasswordPage()
        {
            InitializeComponent();
        }

        private async void ForgotPasswordClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//UsernamePage/PasswordPage/ForgotPasswordPage");
        }

        private async void SignInClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//ChatsPage");
        }

    }
}