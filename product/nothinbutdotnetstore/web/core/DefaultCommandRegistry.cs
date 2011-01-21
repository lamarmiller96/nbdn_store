using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        readonly IEnumerable<RequestCommand> all_available_commands;

        public DefaultCommandRegistry() : this(new StubSetOfAvailableCommands())
        {
        }

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_available_commands)
        {
            this.all_available_commands = all_available_commands;
        }

        public RequestCommand get_the_command_that_can_run(Request request)
        {
            return all_available_commands.FirstOrDefault(x => x.can_process(request))
                ?? new MissingRequestCommand();
        }
    }
}