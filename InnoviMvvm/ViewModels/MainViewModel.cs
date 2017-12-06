using Innovi.Exercise.Service.Implementation;
using Innovi.Exercise.Service.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using InnoviMvvm.ViewModels.Commands;
using System;
using System.Windows.Media.Imaging;
using InnoviMvvm.Views.UserContorls;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace InnoviMvvm.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public static Uri LayoutGallery
        {
            get
            {
                return (new Uri(@"~\..\..\..\images\switch_on.png", UriKind.Relative));
            }
        }
        public static Uri LayoutList
        {
            get
            {
                return (new Uri(@"~\..\..\..\images\switch_Off.png", UriKind.Relative));
            }
        }

        public  event PropertyChangedEventHandler PropertyChanged;

        public static ChangeLayoutCommand ChangeLayoutcmd { get; set; }

        public MainViewModel()
        {
            ChangeLayoutcmd = new ChangeLayoutCommand(this);
        }


        //Changes the Switch iMage accordinly to the Layout State
        private bool _iSGallery;
        public bool iSGallery
        {
            get
            { return _iSGallery; }
            set
            {
                _iSGallery = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("iSGallery"));
                }

            }
        }
        //Setting the Switch Image Source


        private Uri _SwitchImageSource = LayoutGallery;
        public Uri SwitchImageSource
        {
            get
            { return _SwitchImageSource; }
            set
            {
                _SwitchImageSource = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SwitchImageSource"));
                }


            }
        }


        //Defining the Layout State
        private static string _VerOrHorz ="Vertical";
        public  string VerOrHorz
        {
            get
            { return _VerOrHorz; }
            set
            {
                _VerOrHorz = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("VerOrHorz"));
                }


            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            
                handler(this, new PropertyChangedEventArgs(name));
            
        }

        //Sets user list on UserContorl On View
        private IEnumerable<User> _lstUsers;
        public IEnumerable<User> lstUsers
        {
            get
            { return GetUsers(); }
            set
            {
                _lstUsers = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("lstUsers"));
                }

            }
        }
        //Get users From Api
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> lstUsers;
            lstUsers = UsersService.Instance.GetAll();



            return lstUsers;
        }



        public void ChangeView()
        {
            SwitchViewUC switchViewUC = new SwitchViewUC();

         
            if (iSGallery)
            {
                VerOrHorz = "Vertical";

                SwitchImageSource = LayoutGallery;
                BitmapImage bitmapuri = new BitmapImage(new Uri(@"~\..\..\..\images\switch_on.png", UriKind.Relative));
               // Image image = GetImage(switchViewUC);
                //image.Source = bitmapuri;
            }
            else
            {
                VerOrHorz = "Horizontal";
                SwitchImageSource = LayoutList;

                BitmapImage bitmapuri = new BitmapImage(new Uri(@"~\..\..\..\images\switch_off.png", UriKind.Relative));
                //Image image = (Image)switchViewUC.btnSwitch.GetTemplateChild("imgSwitch", switchViewUC.btnSwitch); 
              //  image.Source = bitmapuri;
            }
               


            this.iSGallery = !this.iSGallery;
            Debug.WriteLine("tESTRRRRRRRRRRRR");
        }


        private static DependencyObject RecursiveVisualChildFinder<Image>(DependencyObject rootObject)
        {
            var child = VisualTreeHelper.GetChild(rootObject, 0);
            if (child == null) return null;

            return child.GetType() == typeof(Image) ? child : RecursiveVisualChildFinder<Image>(child);
        }

        private static Image GetImage(SwitchViewUC switchViewUC)
        {
            return (Image)switchViewUC.btnSwitch.Template.FindName("imgSwitch", switchViewUC.btnSwitch);
        }
    }
}
