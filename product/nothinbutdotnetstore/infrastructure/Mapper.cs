namespace nothinbutdotnetstore.infrastructure
{
    public interface Mapper<Input,Output>
    {
        Output map_from<Input, Output>(Input input);
    }
}