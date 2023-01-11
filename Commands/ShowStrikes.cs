using Apos.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Commands
{
    internal class ShowStrikes:ICommand
    {
        private ShapeBatch _sb;
        public ShowStrikes(ShapeBatch sb)
        {
            this._sb = sb;
        }
        public void Execute()
        {

            switch (Globals.Strikes)
            {
                case 0:
                    break;
                case 1:
                    _sb.DrawCircle(new Vector2(90, 420), 15, Color.White, Color.White, 2f);
                    break;
                case 2:
                    _sb.DrawCircle(new Vector2(90, 420), 15, Color.White, Color.White, 2f);
                    _sb.DrawCircle(new Vector2(110, 420), 15, Color.White, Color.White, 2f);
                    break;
                case 3:
                    _sb.DrawCircle(new Vector2(90, 420), 15, Color.White, Color.White, 2f);
                    _sb.DrawCircle(new Vector2(110, 420), 15, Color.White, Color.White, 2f);
                    _sb.DrawCircle(new Vector2(130, 420), 15, Color.White, Color.White, 2f);
                    break;
            }


        }
    }
}
