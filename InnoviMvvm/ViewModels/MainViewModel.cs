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
using System.Windows.Input;

namespace InnoviMvvm.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public static BitmapImage LayoutGallery
        {
            get
            {
                return (new BitmapImage(new Uri(@"~\..\..\..\images\switch_off.png", UriKind.Relative)));
            }
        }
        public static BitmapImage LayoutList
        {
            get
            {
                return (new BitmapImage(new Uri(@"~\..\..\..\images\switch_on.png", UriKind.Relative)));
            }
        }
        private readonly BackgroundWorker worker;
        public event PropertyChangedEventHandler PropertyChanged;

        public static ChangeLayoutCommand ChangeLayoutcmd { get; set; }

        public MainViewModel()
        {
            ChangeLayoutcmd = new ChangeLayoutCommand(this);
            this.worker = new BackgroundWorker();
            this.worker.DoWork += this.DoWork;
            this.DoWork(this, null);
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            this.lstUsers = UsersService.Instance.GetAll();
        }


        //Changes the Switch iMage accordinly to the Layout State
        private static bool _iSGallery = true;
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

        //Source of SwitchUC Image
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
        private static string _VerOrHorz = "Horizontal";
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

        private static string _WindowSize;
        public string WindowSize
        {
            get
            { return _WindowSize; }
            set
            {
                _WindowSize = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("WindowSize"));
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
            { return _lstUsers; }
            set
            {
                _lstUsers = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("lstUsers"));
                }

            }
        }



        public void ChangeView()
        {



            if (iSGallery)
            {
                WindowSize = "400";
                Source = LayoutGallery;
                VerOrHorz = "Vertical";


            }

            else
            {
                WindowSize = "auto";
                Source = LayoutList;
                VerOrHorz = "Horizontal";


            }


            this.iSGallery = !this.iSGallery;

        }


    }


}
