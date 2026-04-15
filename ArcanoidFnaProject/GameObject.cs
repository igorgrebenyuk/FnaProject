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
    public class GameObject
    {
        /// <summary>
        /// Базовый класс для всех игровых объектов. Содержит базовые свойства для позиции, изображения,
        /// отрисовки и жизненного цикла (инициализация, загрузка, обновление, отрисовка).
        /// Наследники могут переопределять методы Initilize, Load, Update и Draw.
        /// </summary>
        protected Texture2D image;
        /// <summary>
        /// Наша позиция - это центр нашего изображения. Это означает, что если мы хотим отрисовать изображение в верхнем левом углу экрана, нам нужно установить позицию в (image.Width / 2, image.Height / 2).
        /// </summary>
        public Vector2 position;
        /// <summary>
        /// Цвет, используемый при отрисовке спрайта.
        /// </summary>
        public Color drawColor = Color.White;
         
        public float scale = 1f , rotation = 0f;

        public float layerDepth = .5f;

        public bool active = true;

        protected Vector2 center;

        public bool collidable = true;
        protected int boundingBoxWidth ,boundingBoxHeight;
        protected Vector2 boundingBoxOffset;
        Texture2D boundingBoxImage;
        const bool drawBoundingBox = true;

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)(position.X + boundingBoxOffset.X),
                    (int)(position.Y + boundingBoxOffset.Y),
                    boundingBoxWidth,
                    boundingBoxHeight);
            }
        }


        /// <summary>
        /// Создаёт новый экземпляр GameObject.
        /// </summary>
        public GameObject()
            {

        
            }

        public virtual void Initilize()
        {

        }

        public virtual void Load(ContentManager content)
        {
            boundingBoxImage = TextureLoader.Load("pixel", content);
            CalculateCenter();

            if (image != null) 
            {
                boundingBoxWidth = image.Width;
                boundingBoxHeight = image.Height;
            }
        }

        public virtual void Update(List<GameObject> objects , Map map )
        {

        }


        public virtual bool CheckCollision(Rectangle input)
        {
            return BoundingBox.Intersects(input);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (boundingBoxImage != null && drawBoundingBox == true && active == true)
            {
                spriteBatch.Draw(boundingBoxImage, new Vector2(BoundingBox.X, BoundingBox.Y), BoundingBox, new Color(120, 120 ,120 ), 0f, Vector2.Zero, 1f, SpriteEffects.None, .1f);
            }

            if (image != null && active == true)
            {
                spriteBatch.Draw(image, position, null, drawColor, rotation, center, scale, SpriteEffects.None, layerDepth);
            }
        }

        private void CalculateCenter()
        {
            if (image == null)
                return;

            center.X = image.Width / 2;
            center.Y = image.Height / 2;
        }


    }
}
