using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    //Tanımlanan Interfacelerin servis kayıtlarını sağlayan Interface
    public interface IServiceManager
    {
        IAuthorService AuthorService { get; }
        ICategoryService CategoryService { get; }
    }
}
