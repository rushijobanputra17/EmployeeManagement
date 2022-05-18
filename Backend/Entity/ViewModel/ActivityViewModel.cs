using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
    public class ActivityViewModel
    {
        public int Id { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string ActivityDescription { get; set; }
        public string ProjectStatus { get; set; }
        public Nullable<int> TaskId { get; set; }
        public string TaskStatus { get; set; }
        public string Operation { get; set; }
        public System.DateTime ActivityDate { get; set; }
    }
}
