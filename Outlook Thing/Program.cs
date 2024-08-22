using Microsoft.IdentityModel.Tokens;
using Outlook_Calendar_Manager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using Microsoft.Identity.Client;

namespace Outlook_Calendar_Manager
{
    //thanks to cmastkas.com
    internal static class Program
    {
        public static string CLIENT_ID;
        public static string TENANT_ID;
        public static string[] Scopes = { "User.Read", "Calendars.Read", "Calendars.ReadWrite", "Calendars.ReadBasic" };

        private static IPublicClientApplication clientApp;

        [STAThread]
        static void Main()
        {
            LoadInfo();
            InitAuth();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
        public static IPublicClientApplication PublicClientApp { get { return clientApp; } }
        public static void LoadInfo()
        {
            string relPath = "Data/AuthInfo.json";
            string absPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relPath);
            string json = File.ReadAllText(absPath);
            using (JsonDocument jsondoc = JsonDocument.Parse(json)) 
            {
                JsonElement root = jsondoc.RootElement;
                CLIENT_ID = root.GetProperty("clientId").ToString();
                TENANT_ID = root.GetProperty("tenantId").ToString();
            }
        }
        public static void InitAuth()
        {
            clientApp = PublicClientApplicationBuilder.Create(CLIENT_ID)
                .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
                .WithAuthority(AzureCloudInstance.AzurePublic, TENANT_ID)
                .Build();
        }
    }
}
