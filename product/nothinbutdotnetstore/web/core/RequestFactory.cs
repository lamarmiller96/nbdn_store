using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface RequestFactory
    {
        Request create_a_request_from(HttpContext the_actual_http_context);
    }
}