using System;
using System.Collections.Generic;
using System.Linq;
using FNAClassCode;
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
        /// <summary>
        /// Главный класс игры. Управляет циклом игры, загрузкой контента, отрисовкой и списком объектов сцены.
        /// </summary>
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// Список всех игровых объектов в текущем уровне.
        /// </summary>
        public List<GameObject> objects = new List<GameObject>();
        public Map map = new Map();

        public Game1() // Это конструктор. Данная функция вызывается при создании класса игры.
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
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

            map.Load(Content);

            LoadLevel(); 

        }

        /// <summary>
        /// Вызывается каждый кадр для обновления состояния игры. Игры обычно работают при 60 кадрах в секунду.
        /// Каждый кадр функция Update выполняет логику: обновление мира, проверку столкновений, сбор ввода и воспроизведение звука.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            UpdateObjects();
            
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

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            DrawObjects();
            map.DrawWalls(spriteBatch);

            spriteBatch.End();

            // Отрисовка того, что FNA обрабатывает "под капотом":
            base.Draw(gameTime);
        }

        public void LoadLevel()
        {
            objects.Add(new Player(new Vector2(640, 360)));

            //add Walls 
            map.walls.Add(new Wall(new Rectangle(256, 256, 256, 256)));
            map.walls.Add(new Wall(new Rectangle(0, 650, 1280, 128)));

            LoadObjects();
        }

        /// <summary>
        /// Загружает каждый объект в списке (инициализация и загрузка контента).
        /// </summary>
        public void LoadObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Initilize();
                objects[i].Load(Content);
            }
        }
        /// <summary>
        /// Вызывает Update для каждого объекта в списке.
        /// </summary>
        public void UpdateObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(objects , map);
            }
        }
        /// <summary>
        /// Вызывает Draw для каждого объекта и передаёт им spriteBatch.
        /// </summary>
        public void DrawObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(spriteBatch);
            }
        }
    }
}
