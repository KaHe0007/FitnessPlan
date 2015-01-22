using System;

namespace FitnessLibrary.Extension
{
    public class DataErrorsChangedEventArgs : EventArgs
    {
        private readonly string propertyName;

        public virtual string PropertyName()
        { 
            return propertyName;
        }

        public DataErrorsChangedEventArgs(string propertyName)
        {
            this.propertyName = propertyName;
        }
    }
}