using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SfSchedule_MVVM_WPF
{
   public class ScheduleModel : ScheduleAppointment, INotifyPropertyChanged
    {
           #region Public Properties

        public ScheduleModel()
        {
            AppointmentSelectionBrush = new SolidColorBrush(Colors.Transparent);
        }
 
        private Brush _appselbrush;
        public Brush AppointmentSelectionBrush
        {
            get
            {
                return _appselbrush;
            }
            set
            {
                _appselbrush = value;
                OnPropertyChanged("AppointmentSelectionBrush");
            }
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
      
    }
}
