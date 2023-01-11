using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Commands
{
    internal class _buttonX: IButtonCommand
    {

        public void Execute(ICommand command)
        {
            command.Execute();
        }
    }
}
