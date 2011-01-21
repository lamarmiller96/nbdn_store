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
    public class ViewProductsInADepartmentSpecs
    {
        public class when_run : BaseConcern
        {
            ResponseEngine response_engine;
            IEnumerable<Product> the_products_in_a_department;
            ApplicationCommand sut;
            Request request;
            ProductsRepository product_repository;
            Department department;

            protected override void arrange()
            {
                request = mock<Request>();
                response_engine = mock<ResponseEngine>();
                product_repository = mock<ProductsRepository>();
                department = new Department();
                the_products_in_a_department = new List<Product>();

                request.Stub(x => x.map<Department>()).Return(department);
                product_repository.Stub(x => x.get_all_products_in(department)).Return(the_products_in_a_department);

                sut = new ViewProductsInADepartment(product_repository, response_engine);
            }

            protected override void act()
            {
                sut.run(request);
            }

            [Test]
            public void should_display_the_products_in_the_department()
            {
                response_engine.AssertWasCalled(x => x.display(the_products_in_a_department));
            }
        }
    }
}