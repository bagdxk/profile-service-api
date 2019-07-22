using Bagdxk.Profile.Service.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bagdxk.Profile.Service.Api.Services
{
    public interface ILayoutRepository
    {
        Task<Layout> GetAsync(string id);
        Task<Layout> SaveAsync(Layout layout);
    }
}
