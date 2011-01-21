using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface DepartmentRepository
    {
        IEnumerable<Department> get_all_departments_with_products();
        IEnumerable<Department> get_all_the_main_departments_in_the_store();
    }
}