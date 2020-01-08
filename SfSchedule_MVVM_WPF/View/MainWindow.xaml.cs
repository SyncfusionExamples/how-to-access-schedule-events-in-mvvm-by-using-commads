using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SfSchedule_MVVM_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ScheduleViewModel _svm;
        public ScheduleViewModel SVM
        {
            get { return _svm; }
            set
            {
                _svm = value;
            }
        }
       
        public MainWindow()
        {
            InitializeComponent();

            SVM = new ScheduleViewModel();
            this.DataContext = SVM;
        }
    }

  
}
