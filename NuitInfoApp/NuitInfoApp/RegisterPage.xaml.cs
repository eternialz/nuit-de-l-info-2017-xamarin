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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
            BindingContext = new UserModel();
		}

        private void RegisterButtonClicked(object sender, EventArgs e)
        {
            UserModel user = (UserModel)(sender as Button).BindingContext;
            if (user.Password != user.ConfirmPassword)
            {
                DisplayAlert("Error", "Passwords don't match", "Ok");
            }
            
        }
	}
}