using System;
using ChatApp.Views;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatsPage : ContentPage
    {
        public ChatsPage()
        {
            InitializeComponent();
        }

        
    }
}