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
    public class Player : GameObject
    {
        /// <summary>
        /// Игровой персонаж, наследник GameObject. Обрабатывает ввод игрока и обновляет позицию.
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// Создаёт игрока и устанавливает начальную позицию.
        /// </summary>
        /// <param name="inputPosition">Начальная позиция игрока в мировых координатах.</param>
        public Player(Vector2 inputPosition)
        {
            position = inputPosition;
        }

        /// <summary>
        /// Инициализация игрока. Вызывается при загрузке уровня.
        /// </summary>
        public override void Initilize()
        {
            base.Initilize();
        }

        /// <summary>
        /// Загружает ресурсы игрока (текстуры и т.д.).
        /// </summary>
        /// <param name="content">ContentManager для загрузки ресурсов.</param>
        public override void Load(ContentManager content)
        {
            image = TextureLoader.Load("sprite", content);
                base.Load(content);
        }

        /// <summary>
        /// Обновляет состояние игрока каждый кадр (обрабатывает ввод и т.д.).
        /// </summary>
        /// <param name="objects">Список всех игровых объектов в сцене.</param>
        public override void Update(List<GameObject> objects , Map map)
        {
            CheckInput();
            base.Update(objects , map);
        }

        private void CheckInput()
        {
            if (Input.IsKeyDown(Keys.D) == true)
                position.X += 5;
            else if (Input.IsKeyDown(Keys.A) == true)
                position.X -= 5;

            if (Input.IsKeyDown(Keys.S) == true)
                position.Y += 5;
            else if (Input.IsKeyDown(Keys.W) == true)
                position.Y -= 5;
        } 
    }
}
