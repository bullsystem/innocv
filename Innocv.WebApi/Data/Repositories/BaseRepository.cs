using System;

namespace Innocv.Data.Repositories
{
    /// <summary>
    /// Repository base class.
    /// </summary>
    public abstract class BaseRepository : IDisposable
    {
        private Context context;

        /// <summary>
        /// Initialize class instance.
        /// </summary>
        protected BaseRepository()
        {
            this.context = new Context();
        }

        /// <summary>
        /// Get database context.
        /// </summary>
        protected Context Context
        {
            get { return this.context; }
        }

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
    }
}