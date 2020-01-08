using SfSchedule_MVVM_WPF.Commands;
using Syncfusion.UI.Xaml.Schedule;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SfSchedule_MVVM_WPF
{
   public class ScheduleViewModel:INotifyPropertyChanged
   {
       #region SfSchedule event commands

       #region Appointment Editor Opening 

       ICommand _editorOpeningCommand;

       public ICommand EditorOpeningCommand
       {
           get { return _editorOpeningCommand; }
       }
       public void editorOpening(AppointmentEditorOpeningEventArgs arg)
       {
           arg.Cancel = true;
           MessageBox.Show("Triggered from VM and editor opening was cancelled");
       } 
       #endregion

       #region AppointmentEditor Closed

       ICommand _editorClosedCommand;

       public ICommand EditorClosedCommand
       {
           get { return _editorClosedCommand; }
       }
       public void EditorClosed(AppointmentEditorClosedEventArgs arg)
       {
           arg.Handled = true;
           MessageBox.Show("Triggered from VM and editor Closed was Triggered");
       } 

       #endregion

       #region ContextMenu Opening Event

       ICommand _contextmenuOpening;


       public ICommand ContextMenuOpeningCommand
       {
           get { return _contextmenuOpening; }
       }
       public void ContextmenuOpening(ContextMenuOpeningEventArgs arg)
       {
           MessageBox.Show("Triggered from VM and Context Menu Opening Event was cancelled");
       } 
       #endregion

       #region Context menu Closed

       ICommand _contextmenuClosing;

       public ICommand ContextMenuClosingCommand
       {
           get { return _contextmenuClosing; }
       }
       public void ContextmenuClosing(ContextMenuClosedEventArgs arg)
       {
           MessageBox.Show("Triggered from VM and Context Menu closed Event was Triggerd");
       } 

       #endregion

       #region Visible Date Changing

       ICommand _visibleDateChanging;

       public ICommand VisibleDateChangingCommand
       {
           get { return _visibleDateChanging; }
       }
       public void VisibleDateChanging(VisibleDatesChangingEventArgs arg)
       {
           var oldValue = arg.OldValue;
           var newValue = arg.NewValue;
           if (oldValue != null)
           MessageBox.Show("Visible date EventTriggered from VM");
       } 

       #endregion

       #endregion

       #region AppointmentCollection

       private ScheduleAppointmentCollection _collection = new ScheduleAppointmentCollection();
        public ScheduleAppointmentCollection Collection
        {
            get
            {
                return _collection;
            }
            set
            {
                this._collection = value;
                OnPropertyChanged("Collection");

            }
        }
           #endregion
       
      
        public ScheduleViewModel()
        {
            _editorOpeningCommand = new Syncfusion.UI.Xaml.Schedule.DelegateCommand<AppointmentEditorOpeningEventArgs>(editorOpening);
            _editorClosedCommand = new Syncfusion.UI.Xaml.Schedule.DelegateCommand<AppointmentEditorClosedEventArgs>(EditorClosed);
            _contextmenuOpening = new Syncfusion.UI.Xaml.Schedule.DelegateCommand<ContextMenuOpeningEventArgs>(ContextmenuOpening);
            _contextmenuClosing = new Syncfusion.UI.Xaml.Schedule.DelegateCommand<ContextMenuClosedEventArgs>(ContextmenuClosing);
            _visibleDateChanging = new Syncfusion.UI.Xaml.Schedule.DelegateCommand<VisibleDatesChangingEventArgs>(VisibleDateChanging);
            
            this._collection.Add(new ScheduleModel()
            {
                StartTime = DateTime.Now.Date.AddHours(12),
                EndTime = DateTime.Now.Date.AddHours(15),
                Subject = "Conference",
                Location = "Chennai",
            });
            this._collection.Add(new ScheduleModel()
            {
                StartTime = DateTime.Now.Date.AddDays(3).AddHours(1),
                EndTime = DateTime.Now.Date.AddDays(3).AddHours(4),
                Subject = "My B'day",
            });
            this._collection.Add(new ScheduleModel()
            {
                StartTime = DateTime.Now.Date.AddDays(2).AddHours(9),
                EndTime = DateTime.Now.Date.AddDays(2).AddHours(12),
                Subject = "Meeting",
            });
        }

        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
           
    }
       public class EditorOpeningCommand:AppointmentEditorOpeningCommand<ScheduleViewModel,AppointmentEditorOpeningCommandBehavior<ScheduleViewModel>>
       {
           
       }
    }



