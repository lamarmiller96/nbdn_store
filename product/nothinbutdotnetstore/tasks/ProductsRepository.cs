using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface ProductsRepository
    {
        IEnumerable<Product> get_all_products_in(Department department);
    }
}