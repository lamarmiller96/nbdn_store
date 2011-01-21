using System.Web.Compilation;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class WebFormViewFactory : ViewFactory
    {
        ViewPathRegistry view_path_registry;
        WebFormFactory web_form_factory;

        public WebFormViewFactory():this(new StubViewPathRegistry(), 
            BuildManager.CreateInstanceFromVirtualPath)
        {
        }

        public WebFormViewFactory(ViewPathRegistry view_path_registry, WebFormFactory web_form_factory)
        {
            this.view_path_registry = view_path_registry;
            this.web_form_factory = web_form_factory;
        }

        public ViewFor<Model> create_view_that_can_display<Model>(Model model)
        {
            var raw_form = web_form_factory(view_path_registry.get_path_to_view_for<Model>(),
                                            typeof(ViewFor<Model>));

            var concrete_view = (ViewFor<Model>) raw_form;
            concrete_view.model = model;
            return concrete_view;
        }
    }
}