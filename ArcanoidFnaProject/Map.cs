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
    /// <summary>
    /// Представляет игровой уровень или карту. Должен содержать данные о стенах, столкновениях и объектной логике уровня.
    /// Класс пока пустой и должен быть расширен по мере добавления функциональности уровня.
    /// </summary>
    public class Map   
    {
        public List<Wall> walls = new List<Wall>();
        Texture2D wallImage;
        public Map() { }
        public int mapWidth = 15;
        public int mapHeight = 9;
        public int tileSize = 128;


        public void Load(ContentManager content)
        {
            wallImage = TextureLoader.Load("pixel", content);
        }

        public Rectangle CheckCollision(Rectangle input)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i] != null && walls[i].wall.Intersects(input) == true)
                    return walls[i].wall;
            }
            return Rectangle.Empty;
        }

        public void DrawWalls(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i] != null && walls[i].active == true )
                    spriteBatch.Draw(wallImage, new Vector2(walls[i].wall.X , walls[i].wall.Y), walls[i].wall, Color.Black , 0f , Vector2.Zero, 1f, SpriteEffects.None, 7f);
            }
        }
    }
    /// <summary>
    /// Представляет стену или блок на карте. Используется для определения границ и столкновений.
    /// Пока пустой и может быть расширен свойствами позиции, размеров и коллайдера.
    /// </summary>
    public class Wall
        
    {
        public Rectangle wall;
        public bool active = true;

        public Wall() 
        {

        }
        public Wall(Rectangle inputRectangle)
        {
            wall = inputRectangle;
        }
    }

}
