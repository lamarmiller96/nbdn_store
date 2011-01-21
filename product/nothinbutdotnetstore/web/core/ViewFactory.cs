namespace nothinbutdotnetstore.web.core
{
    public interface ViewFactory
    {
        ViewFor<Model> create_view_that_can_display<Model>(Model model);
    }
}