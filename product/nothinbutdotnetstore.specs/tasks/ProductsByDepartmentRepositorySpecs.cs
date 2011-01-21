using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.tasks
{
    class ProductsByDepartmentRepositorySpecs
    {
        IEnumerable<Product> products;

        [Test]
        public void should_return_all_of_the_products_for_a_department()
        {
            var DepartmentID = 9814;
            var sut = new DefaultProductsRepository(ObjectMother.database_items.create_db_gateway(),
                                                                new ProductMapper());
            products = sut.get_all_products_in(new Department {Id = 9814});
            Assert.IsTrue(products.Count() > 0);
        }
    }
}