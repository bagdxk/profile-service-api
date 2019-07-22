using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bagdxk.Profile.Service.Api.Services
{
    public interface IValuesService
    {
        IEnumerable<string> Get();
    }
}
