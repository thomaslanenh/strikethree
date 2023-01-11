using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StrikeThree.Commands;
using System.Diagnostics;
using Apos.Shapes;
using System;

namespace StrikeThree
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ShapeBatch _sb;

        private SpriteFont InGameFont;
        private SpriteFont Varsity;

        private Texture2D CurrentPitch;
        private Texture2D CurrentHit;
        private Texture2D BallField;

        private ICommand _inputCommand;

        private bool Clicked = false;

        private Invoker _Invoker = new Invoker();
        private Invoker _DrawInvoker = new Invoker();

        private float timer = 5;
        const float TIMER = 5;
        private bool drawPitchText = true;

        private static MouseState previousKeyState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _sb = new ShapeBatch(GraphicsDevice, Content);

            InGameFont = Content.Load<SpriteFont>("Fonts/InGameFont");
            Varsity = Content.Load<SpriteFont>("Fonts/Varsity");

            CurrentPitch = Content.Load<Texture2D>("Cards/curveball");
            CurrentHit = Content.Load<Texture2D>("Cards/bunt");
            BallField = Content.Load<Texture2D>("Fields/baseballfield");


            Globals.CurrentPitcherPic = Content.Load<Texture2D>("PlayerPics/PerryVonNuckleer");
            Globals.CurrentHitPic = Content.Load<Texture2D>("PlayerPics/GrandSlam");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Clicked = false;

            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            timer -= elapsedTime;

            if (timer < 0)
            {
                drawPitchText = !drawPitchText;
                timer = TIMER;
                Globals.CurrentPitchStatus = Globals.PitchStatus.NONE;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var mouseState = Mouse.GetState();

            var mousePosition = new Point(mouseState.X, mouseState.Y);

            var clickArea = new Rectangle(375, 408, 33, 10);

            if (clickArea.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed && previousKeyState.LeftButton != ButtonState.Pressed ){
                Debug.WriteLine("IN THE ZONE");
                Debug.WriteLine(Globals.CurrentPitch.CardName);

                // See if Pitch defeats Bat
                _Invoker.SetOnStart(new BuntVersusCurve());
                _Invoker.SetOnFinish(new CheckForOuts());
                _Invoker.PerformActions();
            }
            
            _DrawInvoker.PerformActions();

            previousKeyState = Mouse.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            

            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();

            _spriteBatch.Draw(BallField, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White * 0.4f);
            
            if(Globals.CurrentPitch.Destroyed != true)
            {
                _spriteBatch.Draw(CurrentPitch, new Rectangle(180, 120, 200, 200), null, Color.White);
                foreach (var card in Globals.CurrentPitcherHand)
                {
                    _spriteBatch.DrawString(InGameFont, $"Health: {card.CardHealth}", new Vector2(200.2f, 150f), Color.Black);
                    if (card.SpecialText != null)
                    {
                        _spriteBatch.DrawString(InGameFont, "SPECIAL", new Vector2(250, 250), Color.Red);
                    }
                    _spriteBatch.DrawString(InGameFont, $"Strike Chance: {card.StrikeChance}%", new Vector2(220f, 280f), Color.Black);
                }
            }

            if (Globals.CurrentHit.Destroyed != true)
            {
                _spriteBatch.Draw(CurrentHit, new Rectangle(400, 120, 200, 200), null, Color.White);
                foreach (var batCard in Globals.CurrentBatterHand)
                {
                    _spriteBatch.DrawString(InGameFont, $"Health: {batCard.CardHealth}", new Vector2(420, 150f), Color.Black);
                    if (batCard.SpecialText != null)
                    {
                        _spriteBatch.DrawString(InGameFont, "SPECIAL", new Vector2(470, 250), Color.Red);
                    }
                    _spriteBatch.DrawString(InGameFont, $"Bases: {batCard.Bases}", new Vector2(440, 280), Color.Black);
                }
            }

            _spriteBatch.DrawString(InGameFont, "Pitcher", new Vector2(185, 100.5f), Color.Black);
            _spriteBatch.DrawString(InGameFont, "Batter", new Vector2(410, 100.5f), Color.Black);

            _spriteBatch.DrawString(Varsity,"Strikes:", new Vector2(70, 400), Color.White);
            _spriteBatch.DrawString(Varsity, "Outs:", new Vector2(570, 400), Color.White);

            _sb.Begin();
            _DrawInvoker.SetOnStart(new ShowOuts(_sb));
            _DrawInvoker.SetOnFinish(new ShowStrikes(_sb));
            _sb.End();

            _spriteBatch.DrawString(InGameFont, "Pitch", new Vector2(375, 400), Color.White);

            _spriteBatch.Draw(Globals.CurrentPitcherPic, new Vector2(20,20), Color.White);
            _spriteBatch.Draw(Globals.CurrentHitPic, new Vector2(650, 20), Color.White);

            switch (Globals.CurrentPitchStatus)
            {
                case Globals.PitchStatus.FOUL:
                    
                    if (drawPitchText)
                    {
                        _spriteBatch.DrawString(Varsity, "FOUL BALL!", new Vector2(250, 250), Color.Red);
                    }
                    
                    break;
                case Globals.PitchStatus.STRIKE:
                   
                    if (drawPitchText)
                    {
                        _spriteBatch.DrawString(Varsity, "STRIKE!", new Vector2(250, 250), Color.Red);
                    }
                   
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}