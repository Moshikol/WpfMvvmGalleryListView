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
using System.Globalization;

namespace InnoviMvvm.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public static BitmapImage LayoutGallery
        {
            get
            {
                return (new BitmapImage(new Uri(@"~\..\..\..\images\switch_on.png",UriKind.Relative)));
            }
        }
        public static BitmapImage LayoutList
        {
            get
            {
                return (new BitmapImage(new Uri(@"~\..\..\..\images\switch_off.png", UriKind.Relative)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static ChangeLayoutCommand ChangeLayoutcmd { get; set; }

        public MainViewModel()
        {
            ChangeLayoutcmd = new ChangeLayoutCommand(this);
        }


        //Changes the Switch iMage accordinly to the Layout State
        private  static bool _iSGallery;
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


        public static BitmapImage _Source = LayoutGallery;
        public BitmapImage Source
        {
            get
            { return _Source; }
            set
            {
                _Source = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Source"));
                }


            }
        }


        //Defining the Layout State
        private static string _VerOrHorz = "Vertical";
        public string VerOrHorz
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

        private static string _ImgVisiblty = "Hidden";
        public string ImgVisiblty
        {
            get
            { return _ImgVisiblty; }
            set
            {
                _ImgVisiblty = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ImgVisiblty"));
                }


            }
        }


        private static string _ImgVisibltyOff = "Visible";
        public string ImgVisibltyOff
        {
            get
            { return _ImgVisibltyOff; }
            set
            {
                _ImgVisibltyOff = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ImgVisibltyOff"));
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

            

            if (iSGallery)
            {
                Source = LayoutGallery;
                VerOrHorz = "Vertical";
                ImgVisibltyOff = "Visible";
                ImgVisiblty = "Collapsed";
                //  BitmapImage bitmapuri = new BitmapImage(new Uri(@"~\..\..\..\images\switch_on.png", UriKind.Relative));
                // Image image = GetImage(switchViewUC);
                //image.Source = bitmapuri;
            }
            else
            {
                Source = LayoutList;
                VerOrHorz = "Horizontal";
                ImgVisibltyOff = "Collapsed";
                ImgVisiblty = "Visible";
                //  BitmapImage bitmapuri = new BitmapImage(new Uri(@"~\..\..\..\images\switch_off.png", UriKind.Relative));
                //Image image = (Image)switchViewUC.btnSwitch.GetTemplateChild("imgSwitch", switchViewUC.btnSwitch); 
                //  image.Source = bitmapuri;
            }



            this.iSGallery = !this.iSGallery;
            Debug.WriteLine("tESTRRRRRRRRRRRR");
        }


    }

  
}
