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

namespace Cidean.GF.ViewModel
{

    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// The <see cref="ClickCount" /> property's name.
        /// </summary>
        public const string ClickCountPropertyName = "ClickCount";

        private int _clickCount;
           

        /// <summary>
        /// Sets and gets the ClickCount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ClickCount
        {
            get
            {
                return _clickCount;
            }
            set
            {
                if (Set(() => ClickCount, ref _clickCount, value))
                {
                    RaisePropertyChanged(() => ClickCountFormatted);
                }

            }
        }

        public string ClickCountFormatted
        {
            get
            {
                return string.Format("The button was clicked {0} time(s)", ClickCount);
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

private RelayCommand _incrementCommand;

        /// <summary>
        /// Gets the IncrementCommand.
        /// </summary>
        public RelayCommand IncrementCommand
        {
            get
            {
                return _incrementCommand
                    ?? (_incrementCommand = new RelayCommand(
                    () =>
                    {
                        ClickCount++;
                    }));
            }
        }

        public RelayCommand ItemClicked
        {
            get
            {
                return new RelayCommand(() => {
                    App.Current.MainPage.DisplayAlert("Clicked", "Item was clicked", "Cancel");
                }
                );

            }
        }

        public void AddNewLocation()
        {
            GetBusinesses();
            RaisePropertyChanged(() => Locations);
        }

        public RelayCommand AddLocation
        {
            get
            {

                return new RelayCommand(() =>
                {
                    AddNewLocation();
                });
           }
        }
    }
}