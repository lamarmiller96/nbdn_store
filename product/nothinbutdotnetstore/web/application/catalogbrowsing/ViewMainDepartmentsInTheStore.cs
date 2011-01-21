using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        DepartmentRepository department_repository;
        ResponseEngine response_engine;

        public ViewMainDepartmentsInTheStore():this(new DefaultDepartmentRepository(),
            new HttpHandlerResponseEngine())
        {
        }

        public ViewMainDepartmentsInTheStore(DepartmentRepository department_repository, ResponseEngine response_engine)
        {
            this.department_repository = department_repository;
            this.response_engine = response_engine;
        }

        public void run(Request request)
        {
            response_engine.display(department_repository.get_all_the_main_departments_in_the_store());
        }
    }
}