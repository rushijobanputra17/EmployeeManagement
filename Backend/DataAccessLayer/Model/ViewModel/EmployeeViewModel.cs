using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; } = 0;

        private string _Name;
        [Required]
        public string Name
        {
            get { return _Name; }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    _Name = value.Trim();
                }
            }
        }

        public int? DeptId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime JoiningDate { get; set; }

        [Required]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
