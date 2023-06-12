using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module18
{
    class Sender
    {
        Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }
        // Выполнить
        public void Run()
        {
            _command.Run();
        }
    }
}
