using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Commands
{

    internal class Invoker
    {
        private ICommand _onStart;

        private ICommand _onFinish;

        public void SetOnStart(ICommand onStart)
        {
            _onStart = onStart;
        }

        public void SetOnFinish(ICommand onFinish)
        {
            _onFinish = onFinish;
        }

        public void PerformActions()
        {
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }

            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }
}
