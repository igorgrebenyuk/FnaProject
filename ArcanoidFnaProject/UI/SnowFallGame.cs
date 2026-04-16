using System;
using System.Collections.Generic;
using FnaProject.BL;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FnaProject.UI
{
    /// <summary>
    /// Слой представления. Отвечает за жизненный цикл окна, обработку ввода и отрисовку графики.
    /// </summary>
    public class SnowFallGame : Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        private SpriteBatch renderer;
        private Texture2D backgroundTexture;
        private Texture2D snowflakeTexture;
        private List<SnowflakeModel> snowflakes;
        private Random randomGenerator;

        /// <summary>
        /// Создаёт экземпляр игрового окна и настраивает параметры графики по умолчанию.
        /// </summary>
        public SnowFallGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphicsDeviceManager.PreferredBackBufferWidth = GlobalSettings.DefaultWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = GlobalSettings.DefaultHeight;
            graphicsDeviceManager.IsFullScreen = true;
        }

        /// <summary>
        /// Выполняет инициализацию игровых данных и компонентов перед запуском игрового цикла.
        /// </summary>
        protected override void Initialize()
        {
            snowflakes = new List<BL.SnowflakeModel>();
            randomGenerator = new Random();
            base.Initialize();
        }

        /// <summary>
        /// Загружает контент (текстуры, ресурсы) используемые в игре.
        /// </summary>
        protected override void LoadContent()
        {
            renderer = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("Snow_Village");
            snowflakeTexture = Content.Load<Texture2D>("BLACK_png_snowflake");
            var screenWidth = GraphicsDevice.Viewport.Width;
            for (var i = 0; i < GlobalSettings.SnowflakeCount; i++)
            {
                snowflakes.Add(new SnowflakeModel(randomGenerator, screenWidth));
            }
        }

        /// <summary>
        /// Обновляет состояние игры один раз за кадр.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var screenWidth = GraphicsDevice.Viewport.Width;
            var screenHeight = GraphicsDevice.Viewport.Height;

            foreach (var snowflake in snowflakes)
            {
                snowflake.Update(deltaTime, screenWidth, screenHeight);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Выполняет отрисовку текущего состояния игры.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            renderer.Begin();

            var screenBounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            renderer.Draw(backgroundTexture, screenBounds, Color.White);

            var origin = new Vector2(snowflakeTexture.Width / 2f, snowflakeTexture.Height / 2f);

            foreach (var snowflake in snowflakes)
            {
                var currentPosition = new Vector2(snowflake.X, snowflake.Y);
                renderer.Draw(snowflakeTexture, currentPosition, null, Color.White, 0f, origin, snowflake.Scale, SpriteEffects.None, 0f);
            }

            renderer.End();
            base.Draw(gameTime);
        }
    }
}