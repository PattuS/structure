using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structure.Services
{
    public class ModelService : BaseService
    {
        private IModelContext context;

        /// <summary>
        /// Constructs a new instance of <see cref="ModelService"/>
        /// </summary>
        /// <param name="context">An instance of an <see cref="IModelContext"/></param>
        /// <param name="log">An instance of an <see cref="ILog"/></param>
        public ModelService(IModelContext context, ILog log) : base(log)
        {
            this.context = context;
        }


    }
}
