using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuipVid.Core.Repositories
{
    public interface IRepository<TModel> : IReadRepository<TModel> where TModel : class
    {
        Task<TModel> Create(TModel model);
        Task<TModel> Update(TModel model);
        Task<bool> Delete(TModel model);
    }
}
