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



    public class ResultsPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
            

        private Business _selectedItem;
        public Business SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged(() => SelectedItem);
                    //App.Current.MainPage.DisplayAlert("Alert", _selectedItem.Name + "  " + _selectedItem.Address, "Cancel");

                    App.Current.MainPage.Navigation.PushAsync(new BusinessDetailPage(_selectedItem));
                }
            }
        }

    
        private ObservableCollection<Business> _locations;

        public ObservableCollection<Business> Locations
        {
            get {

                if (_locations == null)
                { 
                    _locations = new ObservableCollection<Business>();
                    
                }

                return _locations;
            }
        }




        public void GetBusinesses()
        {

            using (var client = new HttpClient())
            {
                try
                { 
                var response = client.GetAsync("http://10.0.2.2:40099/api/businesses").Result;

                if (response.IsSuccessStatusCode)
                {
                    // by calling .Result you are performing a synchronous call
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string json = responseContent.ReadAsStringAsync().Result;
                    
                    _locations = JsonConvert.DeserializeObject<ObservableCollection<Business>>(json);
                }
                }
                catch(Exception ex)
                {
                    var lo = ex.InnerException;
                    var ll = 0;
                }
            }
       
     }
                

        public RelayCommand RefreshResults
        {
            get
            {

                return new RelayCommand(() =>
                {
                    GetBusinesses();
                    RaisePropertyChanged(() => Locations);
                });
           }
        }

        public RelayCommand ShowAbout
        {
            get
            {
                return new RelayCommand(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new About());
                });
            }

        }
    }
}