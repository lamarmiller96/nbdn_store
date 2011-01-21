using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestCommandSpecs
    {
        public class when_determining_if_it_can_process_a_request : BaseConcern
        {
            bool result;
            RequestCommand sut;
            Request request;
            Request request_used;

            protected override void arrange()
            {
                request = mock<Request>();
                sut = new DefaultRequestCommand(x =>
                {
                    request_used = x;
                    return true;
                },null);
            }

            protected override void act()
            {
                result = sut.can_process(request);
            }

            [Test]
            public void should_make_the_determination_by_using_the_request_criteria()
            {
                Assert.IsTrue(result);
                Assert.AreEqual(request, request_used);
            }
        }
        public class when_running_the_request : BaseConcern
        {
            RequestCommand sut;
            Request request;
            ApplicationCommand application_command;

            protected override void arrange()
            {
                request = mock<Request>();
                application_command = mock<ApplicationCommand>();
                sut = new DefaultRequestCommand(x => true, application_command);
            }

            protected override void act()
            {
               sut.run(request); 
            }

            [Test]
            public void should_delegate_the_processing_to_the_application_specific_command()
            {
                application_command.AssertWasCalled(x => x.run(request));
            }
        }
    }
}