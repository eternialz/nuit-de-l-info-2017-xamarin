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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            BindingContext = new UserModel();
		}

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            UserModel user = (UserModel)(sender as Button).BindingContext;
            Api RestApi = new Api("https://cordonbleu.erfani.fr/");
            var json = JsonConvert.SerializeObject(user);
            var result = await RestApi.Post(JsonConvert.SerializeObject(user).ToString(), "users/auth");
            dynamic DynamicJson = JsonConvert.DeserializeObject(result);

            AppSettings.Token = DynamicJson.token;

            await Navigation.PushAsync(new MapPage());


            
        }

        private async void RegisterPageOpen(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
	}
}