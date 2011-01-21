namespace nothinbutdotnetstore.web.core
{
    public interface DisplayEngine
    {
        void display<DisplayModel>(DisplayModel display_model);
    }
}