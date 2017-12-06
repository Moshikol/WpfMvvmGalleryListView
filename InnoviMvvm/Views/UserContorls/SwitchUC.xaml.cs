using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InnoviMvvm.ViewModels;

namespace InnoviMvvm.Views.UserContorls
{
    /// <summary>
    /// Interaction logic for SwitchUC.xaml
    /// </summary>
    public partial class SwitchUC : UserControl
    {
        public SwitchUC()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
