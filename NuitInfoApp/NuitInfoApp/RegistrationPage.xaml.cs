using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NuitInfoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
            InitializeComponent();
            BindingContext = new UserModel();
		}

        private async void RegisterButtonClicked(object sender, EventArgs e)
        {
            UserModel user = (UserModel)(sender as Button).BindingContext;
            if (user.password != user.ConfirmPassword)
            {
                await DisplayAlert("Error", "Passwords don't match", "Ok");
            } else {
                Api RestApi = new Api("https://cordonbleu.erfani.fr/");
                var json = JsonConvert.SerializeObject(user);
                string code = await RestApi.Post(json, "users/register");
                await Navigation.PushAsync(new MapPage());
            }
        }
            
	}
}