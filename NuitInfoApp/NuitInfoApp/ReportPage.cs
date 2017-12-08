using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NuitInfoApp
{
	public class ReportPage : ContentPage
	{
        public ListView TypesList;
        public object SelectedType;
        public Api RestApi = new Api("https://cordonbleu.erfani.fr/");

        public ReportPage ()
		{
            var Types = RestApi.Request("reports/types").Result;

            dynamic DynamicJson = JsonConvert.DeserializeObject(Types);
            List<string> Names = new List<string>();

            foreach (var item in DynamicJson)
            {
                Names.Add(item.name);
            }
            TypesList = new ListView();
            TypesList.ItemsSource = Names;
            TypesList.ItemSelected += (sender, e) => {
                SelectedType = ((ListView)sender).SelectedItem;
            };
            StackLayout Layouts = new StackLayout
            {
                Spacing = 0
            };

            Button Submit = new Button { Text = "Submit" };
            Submit.Clicked += SubmitClicked;
            Layouts.Children.Add(TypesList);
            Layouts.Children.Add(Submit);
            Content = Layouts;
		}

        private async void SubmitClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Item Selected", SelectedType.ToString(), "Ok");
            Report rep = new Report();
            rep.latitude = 0.0;
            rep.longitude = 0.0;
            rep.report_name = SelectedType.ToString();
            string code = await RestApi.Post(JsonConvert.SerializeObject(rep), "reports/createbyname");
        }
    }
}