using ChatApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ChatApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("CreateAccountPage", typeof(CreateAccountPage));
            Routing.RegisterRoute("ForgotPasswordPage", typeof(ForgotPasswordPage));
            Routing.RegisterRoute("PasswordPage", typeof(PasswordPage));
        }

    }
}
