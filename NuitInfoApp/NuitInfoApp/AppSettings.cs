using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;


namespace NuitInfoApp
{
    public static class AppSettings
    {
        private static ISettings _AppSettings => CrossSettings.Current;

        public static string Token
        {
            get => _AppSettings.GetValueOrDefault(TokenKey, string.Empty);
            set => _AppSettings.AddOrUpdateValue(TokenKey, value);
        }
        private const string TokenKey = "login_token";
    }
}
