using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubDepartmentRepository : DepartmentRepository
    {
        public IEnumerable<Department> get_all_departments_with_products()
        {
            return ObjectMother.ReportingModels.create_department(100);
        }

        public IEnumerable<Department> get_all_the_main_departments_in_the_store()
        {
            return ObjectMother.ReportingModels.create_department(100,
                                                                  x =>
                                                                  {
                                                                      return new Department
                                                                      {
                                                                          Id = x,
                                                                          Name = x.ToString("Main Department 0")
                                                                      };
                                                                  });
        }
    }
}