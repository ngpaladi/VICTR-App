using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Net;

namespace VICTR
{
    [Activity(Label = "VICTR", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        bool VICTRrunning(string ip)
        {
            string url = ip + "/gameData.json";
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }
        bool validateIPaddress(string ip)
        {
            string ipPattern = "/^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/";
            if (Regex.IsMatch(ip, ipPattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void StartChoiceScreen(string ip)
        {

        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            EditText text = FindViewById<EditText>(Resource.Id.IPinput);
                
            button.Click += delegate { if (validateIPaddress(text.Text)) { StartChoiceScreen(text.Text); } else { }; };
        }
    }
}

