using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.ViewModel
{
    public class ProjectViewModel
    {
       public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public string Status { get; set; }

        public Boolean IsActive { get; set; }


    }
}
