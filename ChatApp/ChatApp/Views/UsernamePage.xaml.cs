using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsernamePage : ContentPage
    {
        public UsernamePage()
        {
            InitializeComponent();
        }

       
        private async void SignUpClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//UsernamePage/CreateAccountPage");
        }

        private async void NextButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//UsernamePage/PasswordPage");
        }

    }
}