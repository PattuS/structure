using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structure.Services
{
    public class BaseService
    {
        protected ILogger logger;

        public BaseService(ILogger logger)
        {
            this.logger = logger;
        }
        
        /// <summary>
        /// Executes a given function while isolating exception handling
        /// </summary>
        /// <typeparam name="T">The type of the result</typeparam>
        /// <param name="func">The method to execute</param>
        /// <returns><see cref="ServiceResponse<T>"/></returns>
        protected ServiceResponse<T> Execute<T>(Func<T> func)
        {
            var response = new ServiceResponse<T>();
            try
            {
                response.Result = func.Invoke();
                response.HasError = false;
                response.Exception = null;
            }
            catch (Exception ex)
            {
                logger.Error("Structure.Services.Exception", ex);
                response.Result = default(T);
                response.HasError = true;
                response.Exception = ex;
            }
            return response;
        }
    }
}
