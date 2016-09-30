using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cidean.GF
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Main;
        }
    }
}
