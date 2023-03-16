using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Entities
{
    public class Upload : BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

    }
}
