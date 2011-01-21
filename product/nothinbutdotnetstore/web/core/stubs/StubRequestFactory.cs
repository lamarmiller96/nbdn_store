using System.Web;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_a_request_from(HttpContext the_actual_http_context)
        {
            return new StubRequest();
        }
    }

    public class StubRequest : Request
    {
        public InputModel map<InputModel>()
        {
            object department = new Department {Id = 9814};
            return (InputModel) department;
        }
    }
}