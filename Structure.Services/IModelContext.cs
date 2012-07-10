using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structure.Services
{
    public interface IModelContext
    {
        System.Linq.IQueryable<T> AsQueryable<T>() where T : Structure.Models.Entity;
        bool Delete<T>(int id) where T : Structure.Models.Entity;
        bool Delete<T>(T entity) where T : Structure.Models.Entity;
        T Find<T>(int id) where T : Structure.Models.Entity;
        T Get<T>(int id) where T : Structure.Models.Entity;
    }
}
