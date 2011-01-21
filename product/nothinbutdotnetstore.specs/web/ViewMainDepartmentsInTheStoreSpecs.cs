using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public class when_run : BaseConcern
        {
            DisplayEngine display_engine;
            IEnumerable<Department> the_main_departments;
            ApplicationCommand sut;
            Request request;
            DepartmentRepository department_repository;

            protected override void arrange()
            {
                display_engine = mock<DisplayEngine>();
                department_repository = mock<DepartmentRepository>();
                the_main_departments = new List<Department>();

                department_repository.Stub(x => x.get_all_the_main_departments_in_the_store())
                    .Return(the_main_departments);

                sut = new ViewMainDepartmentsInTheStore(department_repository, display_engine);
            }

            protected override void act()
            {
                sut.run(request);
            }

            [Test]
            public void should_tell_the_display_engine_to_display_the_main_departments_in_the_store()
            {
               display_engine.AssertWasCalled(x => x.display(the_main_departments));
            } 
        } 
    }
}