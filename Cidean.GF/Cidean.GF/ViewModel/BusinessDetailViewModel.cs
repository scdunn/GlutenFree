using Cidean.GF.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Data.Json;
using Xamarin.Forms;

namespace Cidean.GF.ViewModel
{



    public class BusinessDetailViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Business _business;

        public BusinessDetailViewModel(Business business)
        {
            this._business = business;
        }


        public Business Business
        {
            get
            {
                return _business;
            }
        }
    }
}