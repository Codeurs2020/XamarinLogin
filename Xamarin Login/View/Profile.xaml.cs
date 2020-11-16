using Akavache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            Akavache.Registrations.Start("XamarinLogin");
        }

        protected override async void OnAppearing()
        {
            firstnameLabel.Text = await BlobCache.UserAccount.GetObject<string>("firstname");
            lastnameLabel.Text = await BlobCache.UserAccount.GetObject<string>("lastname");
            usernameLabel.Text = await BlobCache.UserAccount.GetObject<string>("username");
            emailLabel.Text = await BlobCache.UserAccount.GetObject<string>("email");

            base.OnAppearing();
        }

        private void Logout_Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
}