using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public string Explanation { get; set; }
        public DateTime PublishDate { get; set; }
        public int UsersId { get; set; }
        public bool Status { get; set; }
        public Users Users { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Interactions> Interactions { get; set; }
    }
}
