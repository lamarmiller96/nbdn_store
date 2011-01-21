using System;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        DepartmentRepository department_repository;
        DisplayEngine display_engine;

        public ViewMainDepartmentsInTheStore(DepartmentRepository department_repository, DisplayEngine display_engine)
        {
            this.department_repository = department_repository;
            this.display_engine = display_engine;
        }

        public void run(Request request)
        {
            display_engine.display(department_repository.get_all_the_main_departments_in_the_store());
        }
    }
}