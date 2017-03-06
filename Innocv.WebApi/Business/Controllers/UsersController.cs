using Innocv.Data.Models;
using Innocv.Data.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Innocv.Business.Controllers
{
    /// <summary>
    /// Users web controller.
    /// </summary>
    public class UsersController : ApiController
    {
        /// <summary>
        /// Create a user.
        /// </summary>
        /// <param name="request">
        /// Request information.
        /// </param>
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<UserModel>(request.Content.ReadAsStringAsync().Result);

                using (var repository = new UsersRepository())
                {
                    user = repository.Insert(user);
                }

                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(user)),
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch
            {
                // TODO Log Exception

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
        /// <summary>
        /// Get a user.
        /// </summary>
        /// <param name="id">
        /// User identifier.
        /// </param>
        [HttpGet]
        public HttpResponseMessage Get(Int32 id)
        {
            try
            {
                var user = default(UserModel);

                using (var repository = new UsersRepository())
                {
                    user = repository.Select(id);
                }

                if (user == null)
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NoContent
                    };
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(user)),
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }
            catch
            {
                // TODO Log Exception

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
        /// <summary>
        /// Get all users.
        /// </summary>
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var users = default(IEnumerable<UserModel>);

                using (var repository = new UsersRepository())
                {
                    users = repository.Select();
                }

                if ((users == null) || (users.Count() == 0))
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NoContent
                    };
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(users)),
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }
            catch
            {
                // TODO Log Exception

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
        /// <summary>
        /// Remove a user.
        /// </summary>
        /// <param name="id">
        /// User identifier.
        /// </param>
        [HttpDelete]
        public void Remove(Int32 id)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    using (var repository = new UsersRepository())
                    {
                        var user = repository.Select(id);

                        if (user != null)
                        {
                            repository.Delete(user);
                        }
                    }
                }
                catch
                {
                    // TODO Log Exception
                }
            });
        }
        /// <summary>
        /// Update a user.
        /// </summary>
        /// <param name="id">
        /// User identifier.
        /// </param>
        /// <param name="request">
        /// Request information.
        /// </param>
        [HttpPut]
        public HttpResponseMessage Update(Int32 id, HttpRequestMessage request)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<UserModel>(request.Content.ReadAsStringAsync().Result);
                {
                    user.Id = id;
                }

                using (var repository = new UsersRepository())
                {
                    user = repository.Update(user);
                }

                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(user)),
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch(Exception ex)
            {
                // TODO Log Exception

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
