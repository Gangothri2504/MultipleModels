using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleModels.Models
{
    public class EmpDeptModel
    {
        public List<Employee> employees { get; set; }
        public List<Dept> departmnet { get; set; }
        
    }
}