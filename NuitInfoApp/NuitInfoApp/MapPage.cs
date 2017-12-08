using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NuitInfoApp
{
    public class MapPage : ContentPage
    {
        Map map;
        public Api RestApi = new Api("https://cordonbleu.erfani.fr/");
        public MapPage()
        {
            map = new Map
            {
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));
            
            var report = new Button { Text = "Report incident" };
            report.Clicked += HandleClicked;
            var segments = new StackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { report }
            };
            map.MapType = MapType.Street;
            var reports = RestApi.Request("reports/nearby?latitude=\"48.583442\"&longitude=\"7.749987\"").Result;

            dynamic DynamicJson = JsonConvert.DeserializeObject(reports);
            List<string> Names = new List<string>();

            foreach (var item in DynamicJson)
            {
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(item.latitude, item.longitude),
                    Label = item.type,
                };
            }

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(segments);
            Content = stack;


            map.PropertyChanged += (sender, e) =>
            {
                Debug.WriteLine(e.PropertyName + " just changed!");
                if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
                    CalculateBoundingCoordinates(map.VisibleRegion);
            };
        }

        async void HandleClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportPage());
        }


        static void CalculateBoundingCoordinates(MapSpan region)
        {
            var center = region.Center;
            var halfheightDegrees = region.LatitudeDegrees / 2;
            var halfwidthDegrees = region.LongitudeDegrees / 2;

            var left = center.Longitude - halfwidthDegrees;
            var right = center.Longitude + halfwidthDegrees;
            var top = center.Latitude + halfheightDegrees;
            var bottom = center.Latitude - halfheightDegrees;

            if (left < -180) left = 180 + (180 + left);
            if (right > 180) right = (right - 180) - 180;

            Debug.WriteLine("Bounding box:");
            Debug.WriteLine("                    " + top);
            Debug.WriteLine("  " + left + "                " + right);
            Debug.WriteLine("                    " + bottom);
        }
    }
}