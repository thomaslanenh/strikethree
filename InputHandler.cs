using Microsoft.Xna.Framework.Input;
using StrikeThree.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree
{
    internal class InputHandler
    {
        private _buttonA _buttonA = new _buttonA();

        private KeyboardState CurrentKeyState = Keyboard.GetState();

        public ICommand HandleInput()
        {
            if (CurrentKeyState.IsKeyDown(Keys.A)) return _buttonA;
            return null;
        }
    }
}
