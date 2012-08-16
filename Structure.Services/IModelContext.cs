namespace Structure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IModelContext : IDisposable
    {
        System.Linq.IQueryable<T> AsQueryable<T>(params string[] includes) where T : Structure.Models.Entity;
        bool Delete<T>(int id) where T : Structure.Models.Entity;
        bool Delete<T>(T entity) where T : Structure.Models.Entity;
        T Find<T>(int id, params string[] includes) where T : Structure.Models.Entity;
        T Get<T>(int id, params string[] includes) where T : Structure.Models.Entity;
        T Save<T>(T entity) where T : Structure.Models.Entity;
    }
}
