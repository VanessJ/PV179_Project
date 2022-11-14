using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.DAL.Data
{
    public sealed class Settings
    {
        public const string SectionName = "Settings";
        public string ConnectionString { get; set; }
    }
}
