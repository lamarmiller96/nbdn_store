namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewPathRegistry : ViewPathRegistry
    {
        public string get_path_to_view_for<ViewModel>()
        {
            return "~/views/DepartmentBrowser.aspx";
        }
    }
}