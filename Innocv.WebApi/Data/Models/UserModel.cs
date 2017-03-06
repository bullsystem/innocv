using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innocv.Data.Models
{
    /// <summary>
    /// Users data model.
    /// </summary>
    [Table("Users")]
    public class UserModel : BaseModel
    {
        private DateTime birthdate;
        private Int32 id;
        private String name;

        /// <summary>
        /// Initialize class instance.
        /// </summary>
        public UserModel()
        {
            this.birthdate = default(DateTime);
            this.id = 0;
            this.name = String.Empty;
        }

        /// <summary>
        /// Get or set the user birthdate.
        /// </summary>
        [Column("Birthdate")]
        public DateTime Birthdate
        {
            get { return this.birthdate; }
            set { this.birthdate = value; this.RaiseProperyChanged("Birthdate"); }
        }
        /// <summary>
        /// Get or set the user identifier.
        /// </summary>
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id
        {
            get { return this.id; }
            set { this.id = value; this.RaiseProperyChanged("Id"); }
        }
        /// <summary>
        /// Get or set the user name.
        /// </summary>
        [Column("Name")]
        public String Name
        {
            get { return this.name; }
            set { this.name = value; this.RaiseProperyChanged("Name"); }
        }
    }
}