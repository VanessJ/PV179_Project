using System;
using System.Threading.Tasks;
using Bazaar.DAL.Data;
using Bazaar.DAL.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EFCore.Tests
{
    public class QueryObjectTests
    {
        private DbContextOptions<BazaarDBContext> _options;

        public QueryObjectTests()
        {
           
        }
    }
}