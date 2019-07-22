using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bagdxk.Profile.Service.Api.Services
{
    public class ValuesService : IValuesService
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
