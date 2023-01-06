using Apos.Shapes;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apos.Shapes;
using Microsoft.Xna.Framework;

namespace StrikeThree.Commands
{
    internal class ShowOuts : ICommand
    {
        private ShapeBatch _sb;
        public ShowOuts(ShapeBatch sb)
        {
            this._sb = sb;
        }
        public void Execute()
        {

            switch (Globals.Outs)
            {
                case 0:
                    break;
                case 1:
                    _sb.DrawCircle(new Vector2(650, 420), 15, Color.Red, Color.White, 2f);
                    break;
                case 2:
                    _sb.DrawCircle(new Vector2(650, 420), 15, Color.Red, Color.White, 2f);
                    _sb.DrawCircle(new Vector2(700, 420), 15, Color.Red, Color.White, 2f);
                    break;
                case 3:
                    _sb.DrawCircle(new Vector2(650, 420), 15, Color.Red, Color.White, 2f);
                    _sb.DrawCircle(new Vector2(700, 420), 15, Color.Red, Color.White, 2f);
                    _sb.DrawCircle(new Vector2(750, 420), 15, Color.Red, Color.White, 2f);
                    break;
            }
         

        }
    }
}
