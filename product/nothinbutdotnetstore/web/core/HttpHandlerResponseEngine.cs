using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class HttpHandlerResponseEngine : ResponseEngine
    {
        ViewFactory view_factory;

        CurrentContextResolver current_context_resolver;

        public HttpHandlerResponseEngine() : this(new WebFormViewFactory(), () => HttpContext.Current)
        {
        }

        public HttpHandlerResponseEngine(ViewFactory view_factory, CurrentContextResolver current_context_resolver)
        {
            this.view_factory = view_factory;
            this.current_context_resolver = current_context_resolver;
        }

        public void display<DisplayModel>(DisplayModel display_model)
        {
            view_factory.create_view_that_can_display(display_model).ProcessRequest(current_context_resolver());
        }
    }
}