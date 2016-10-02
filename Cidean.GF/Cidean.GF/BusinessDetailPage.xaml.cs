using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cidean.GF.Models;
using Xamarin.Forms;
using Cidean.GF.ViewModel;

namespace Cidean.GF
{
    public partial class BusinessDetailPage : ContentPage
    {
        private Business _business;

        public BusinessDetailPage(Business business)
        {
            InitializeComponent();
            BindingContext = new BusinessDetailViewModel(business);
        }

    }
}
