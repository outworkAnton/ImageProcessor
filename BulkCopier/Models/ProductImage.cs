using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopier.Models
{
    internal class ProductImage
    {
        public ProductImage(string id, string path, int count = 1, bool processed = false)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Count = count;
            Processed = processed;
        }

        public string Id { get; private set; }
        public string Path { get; private set; }
        public int Count { get; set; }
        public bool Processed { get; set; }
    }
}
