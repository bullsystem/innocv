using System;
using System.ComponentModel;

namespace Innocv.Data.Models
{
    /// <summary>
    /// Data models base class.
    /// </summary>
    public abstract class BaseModel : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        /// Notify a change in a property value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Free allocated resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }
        /// <summary>
        /// Free allocated resources.
        /// </summary>
        /// <param name="disposing">
        /// Flag for indicating the object has been disposing.
        /// </param>
        protected virtual void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }
        /// <summary>
        /// Notify a property value change.
        /// </summary>
        /// <param name="propertyName">
        /// Property name.
        /// </param>
        protected void RaiseProperyChanged(String propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}