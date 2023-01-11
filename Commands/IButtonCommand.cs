using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Commands
{
    internal interface IButtonCommand
    {
        void Execute(ICommand command);
    }
}
