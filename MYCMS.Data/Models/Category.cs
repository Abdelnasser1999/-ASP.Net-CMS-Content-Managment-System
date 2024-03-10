using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Data.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Post> Posts { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
