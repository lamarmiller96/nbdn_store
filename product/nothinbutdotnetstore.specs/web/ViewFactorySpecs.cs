using System;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewFactorySpecs
    {
        public class when_creating_a_view_for_a_view_model : BaseConcern
        {
            ViewFor<OurOwnModel> view;
            OurOwnModel the_model;
            ViewFor<OurOwnModel> result;
            ViewFactory sut;
            ViewPathRegistry view_path_registry;
            string path_to_view;

            protected override void arrange()
            {
                path_to_view = "sdfsfsd.aspx";
                view_path_registry = mock<ViewPathRegistry>();
                the_model = new OurOwnModel();
                view = mock<ViewFor<OurOwnModel>>();

                WebFormFactory factory = (x, y) => view;
                view_path_registry.Stub(x => x.get_path_to_view_for<OurOwnModel>())
                    .Return(path_to_view);


                sut = new WebFormViewFactory(view_path_registry,
                    factory);
            }

            protected override void act()
            {
                result = sut.create_view_that_can_display(the_model);
            }

            [Test]
            public void should_create_and_populate_the_view_with_its_model()
            {
                Assert.AreEqual(the_model,result.model);
            }
        } 
    }

    public class OurOwnModel
    {
    }
}