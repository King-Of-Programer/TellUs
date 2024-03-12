using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Org.Apache.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TellUsApp.Droid;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(RatingDialog))]
namespace TellUsApp.Droid
{
    public class RatingDialog : IAlert
    {

        public void ShowRatingDialog()
        {
            var activity = MainActivity.mainActivity;
            var dialogView = activity.LayoutInflater.Inflate(Resource.Layout.rating_dialog, null);
            var ratingBar = dialogView.FindViewById<RatingBar>(Resource.Id.rating_bar);
            var dialog = new AlertDialog.Builder(activity)
                .SetView(dialogView)
                .SetTitle("Please rate us")
                .SetPositiveButton("Ok", async (s, e) => {
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        if (ratingBar.Rating > 3)
                        {
                            try
                            {
                                string url = @"https://play.google.com/";
                                await Browser.OpenAsync(url, BrowserLaunchMode.External);
                            }
                            catch (MethodNotSupportedException ex)
                            {

                            }
                        }
                        else ShowFeedbackDialog();
                    }
                })
                .SetNegativeButton("Cancel", (s, e) => { })
                .Create();

            dialog.Show();
        }
        private void ShowFeedbackDialog()
        {
            var dialogView = MainActivity.mainActivity.LayoutInflater.Inflate(Resource.Layout.feedback, null);
            var dialog = new AlertDialog.Builder(MainActivity.mainActivity)
               .SetView(dialogView)
               .SetTitle("Please leave feedback")
               .SetPositiveButton("Ok", (s, e) => { })
               .SetNegativeButton("Cancel", (s, e) => { })
               .Create();

            dialog.Show();
        }
    }
}