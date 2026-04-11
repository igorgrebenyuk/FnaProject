using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ArcanoidFnaProject
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1() // Это конструктор. Данная функция вызывается при создании класса игры.
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Эта функция автоматически вызывается при запуске игры для инициализации любых неграфических переменных.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Автоматически вызывается при запуске игры для загрузки игровых ресурсов (графика, аудио и т.д.)
        /// </summary>
        protected override void LoadContent()
        {
            // Создание нового SpriteBatch, который можно использовать для отрисовки текстур.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// Вызывается каждый кадр для обновления состояния игры. Игры обычно работают при 60 кадрах в секунду.
        /// Каждый кадр функция Update выполняет логику: обновление мира, проверку столкновений, сбор ввода и воспроизведение звука.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            // Обновление процессов, которые FNA обрабатывает "под капотом":
            base.Update(gameTime);
        }

        /// <summary>
        /// Вызывается каждый кадр, когда игра готова к отрисовке на экране.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            // Это будет очищать экран в каждом кадре. Если не очищать, изображение на экране превратится в кашу:
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Отрисовка того, что FNA обрабатывает "под капотом":
            base.Draw(gameTime);
        }
    }
}
