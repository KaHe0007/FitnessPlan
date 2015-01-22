using System.ComponentModel;
using System.Diagnostics;
using FitnessClientLibrary.Common;
using FitnessClientLibrary.Constants;

namespace FitnessClientLibrary.Base
{
    public class ModelBase : EnableLogging, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public static void ShowMessage(MessageType type, string message)
        {
            //MessageBox.Show(message);
            Debug.WriteLine(message);
        }

        //public static void ShowMessage(MessageType type, string message, object name, Exception ex)
        //{
        //    if (type == MessageType.Info)
        //        MessageBox.Show(message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        //    else if (type == MessageType.Success)
        //        MessageBox.Show(message, "Erfolgsmeldung", MessageBoxButton.OK, MessageBoxImage.None);
        //    else if (type == MessageType.Error)
        //    {
        //        MessageBox.Show(message, string.Format("Fehler aufgetreten bei: {0}", name), MessageBoxButton.OK, MessageBoxImage.Error);
        //        Log.ErrorFormat(message, name, ex);
        //    }
        //}
    }
}
