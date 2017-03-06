using Innocv.Data.Models;
using System.Configuration;
using System.Data.Entity;

namespace Innocv.Data
{
    /// <summary>
    /// Database context.
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Initialize class instance.
        /// </summary>
        public Context() : base(ConfigurationManager.ConnectionStrings["Innocv"].ConnectionString)
        {
        }

        /// <summary>
        /// Get all entities of table Users.
        /// </summary>
        public virtual DbSet<UserModel> Users { get; set; }
    }
}