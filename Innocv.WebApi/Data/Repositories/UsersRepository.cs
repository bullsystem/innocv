using Innocv.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Innocv.Data.Repositories
{
    /// <summary>
    /// Repository of table Users.
    /// </summary>
    public class UsersRepository : BaseRepository
    {
        /// <summary>
        /// Delete a data model.
        /// </summary>
        /// <param name="model">
        /// Data model to delete.
        /// </param>
        public UserModel Delete(UserModel model)
        {
            this.Context.Entry(model).State = EntityState.Deleted;
            this.Context.SaveChanges();

            return model;
        }
        /// <summary>
        /// Insert a data model.
        /// </summary>
        /// <param name="model">
        /// Data model to insert.
        /// </param>
        public UserModel Insert(UserModel model)
        {
            var user = this.Context.Users.Create();
            {
                user.Birthdate = model.Birthdate;
                user.Name = model.Name;
            }

            this.Context.Entry(user).State = EntityState.Added;
            this.Context.SaveChanges();

            return user;
        }
        /// <summary>
        /// Select all data models.
        /// </summary>
        public IEnumerable<UserModel> Select()
        {
            return this.Context.Users.ToList();
        }
        /// <summary>
        /// Select a data model.
        /// </summary>
        /// <param name="id">
        /// Id of data model to select.
        /// </param>
        public UserModel Select(Int32 id)
        {
            return this.Context.Users.SingleOrDefault(user => user.Id == id);
        }
        /// <summary>
        /// Update a data model.
        /// </summary>
        /// <param name="model">
        /// Data model to update.
        /// </param>
        public UserModel Update(UserModel model)
        {
            this.Context.Entry(model).State = EntityState.Modified;
            this.Context.SaveChanges();

            return model;
        }
    }
}