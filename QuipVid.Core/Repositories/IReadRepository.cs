using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuipVid.Core.Repositories
{
    public interface IReadRepository<TModel> where TModel : class
    {
        Task<ICollection<TModel>> GetAll();
        Task<TModel> GetById(Guid id);
    }
}
