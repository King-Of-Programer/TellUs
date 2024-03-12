using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TellUsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TellUsPage : ContentPage
    {
        private int _countOfLogin { get; set; } = 8;
        public TellUsPage()
        {
            InitializeComponent();
            checkCountOfLogin();
        }
        public void checkCountOfLogin()
        {
            object count = null;
            App.Current.Properties.TryGetValue("countOfLogin", out count);
            if (count != null)
            {
                _countOfLogin = (int)count;
            }
            countOfLogin.Text = _countOfLogin.ToString();
            if (_countOfLogin == 10)
            {
                DependencyService.Get<IAlert>().ShowRatingDialog();

            }
            _countOfLogin++;
            App.Current.Properties["countOfLogin"] = _countOfLogin;
        }
    }
}