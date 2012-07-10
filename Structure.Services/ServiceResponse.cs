namespace Structure.Services
{
    using System;
    
    /// <summary>
    /// Provides a common response interface for all service requests
    /// </summary>
    public class ServiceResponse<T>
    {
        
        /// <summary>
        /// Gets a value indicating if the service call threw an exception while executing
        /// </summary>
        public bool HasError { get; internal set; }

        /// <summary>
        /// Gets the exception that was thrown, if any
        /// </summary>
        public object Exception { get; internal set; }

        /// <summary>
        /// Gets the result of the service call
        /// </summary>
        public T Result { get; internal set; }

    }
}
