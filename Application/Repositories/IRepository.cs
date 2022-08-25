using Domain.ProviderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepository
    {
        void Insert(IProduct item);
    }
}
