using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TvControl.API.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Lazy loading data by using virtual to state that this is a navigation property
       
        public virtual IList<Contributor> Contributors { get; set; }
    }
}
