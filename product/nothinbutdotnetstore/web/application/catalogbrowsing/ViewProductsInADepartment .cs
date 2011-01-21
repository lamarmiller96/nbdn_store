using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewProductsInADepartment : ApplicationCommand
    {
        ProductsRepository product_repository;
        ResponseEngine response_engine;

        public ViewProductsInADepartment(ProductsRepository product_repository, ResponseEngine response_engine)
        {
            this.product_repository = product_repository;
            this.response_engine = response_engine;
        }

        public void run(Request request)
        {
            response_engine.display(product_repository.get_all_products_in(request.map<Department>()));
        }
    }
}