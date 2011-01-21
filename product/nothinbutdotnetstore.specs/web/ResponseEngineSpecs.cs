using System;
using System.Web;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ResponseEngineSpecs
    {
        public class when_displaying_a_response : BaseConcern
        {
            ViewFor<int> view_that_can_render;
            HttpContext active_context;
            ResponseEngine sut;
            ViewFactory view_factory;
            int model;

            protected override void arrange()
            {
                active_context = ObjectMother.web_items.create_http_context();
                view_that_can_render = mock<ViewFor<int>>();
                view_factory = mock<ViewFactory>();
                model = 23;
                CurrentContextResolver resolver = () => active_context;


                view_factory.Stub(x => x.create_view_that_can_display(model)).Return(view_that_can_render);

                sut = new HttpHandlerResponseEngine(view_factory,resolver);
            }

            protected override void act()
            {
                sut.display(model);
            }

            [Test]
            public void should_tell_the_view_that_can_display_the_response_to_render_in_the_current_context()
            {
                view_that_can_render.AssertWasCalled(x => x.ProcessRequest(active_context));
            }
        }
    }
}