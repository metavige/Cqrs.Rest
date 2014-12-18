using System.Collections.Generic;

namespace Cqrs.Rest.Api
{
    public interface ICrudApiController<TModel, in TIdentity> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        TModel Get(TIdentity id);
        TModel Post(TModel model);
        TModel Put(TIdentity id, TModel model);
        void Delete(TIdentity id);
    }

    public interface ICrudApiController<TModel, in TIdentity1, in TIdentity2> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        TModel Get(TIdentity1 id1, TIdentity2 id2);
        TModel Post(TModel model);
        TModel Put(TIdentity1 id1, TIdentity2 id2, TModel model);
        void Delete(TIdentity1 id1, TIdentity2 id2);
    }
}
