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
    public class Character : GameObject
    {
        public Vector2 velocity;
        //Customize  the feel of our movement
        protected float decel = 1.2f;
        protected float accel = .78f;
        protected float maxSpeed = 5f;

        const float gravity = 1f;
        const float jumpVelocity = 16f;
        const float jumpFallVelocity = 32;

        protected bool jumping;
        public static bool applyGravity = false;


        public override void Initilize()
        {
            velocity = Vector2.Zero;
            jumping = false;
            base.Initilize();
        }

        public override void Update(List<GameObject> objects, Map map)
        {
            base.Update(objects, map);
        }


        protected virtual bool CheckCollisions(Map map, List<GameObject> objects, bool xAxis)
        {
            Rectangle futureBindingBox = BoundingBox;

            int maxX = (int)maxSpeed;
            int maxY = (int)maxSpeed;

            if (applyGravity == true)
            {
                maxY = (int)jumpVelocity;
            }

            if (xAxis == true && velocity.X != 0)
            {
                if (velocity.X > 0)
                {
                    futureBindingBox.X += maxX;
                }
                else
                    futureBindingBox.X -= maxX;
            }
            else if (xAxis == false && velocity.Y != 0)
            {
                if (velocity.Y > 0)
                {
                    futureBindingBox.Y += maxY;
                }
                else
                    futureBindingBox.Y -= maxY;
            }
            Rectangle wallCollision = map.CheckCollision(futureBindingBox);

            if (wallCollision != Rectangle.Empty)
            {
                if (applyGravity == true && velocity.Y >= gravity && (futureBindingBox.Bottom > wallCollision.Top - maxSpeed) && (futureBindingBox.Bottom <= wallCollision.Top + velocity.Y))
                {
                    return true;
                }
                else return true;
            }
            //check object collision 
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i] != this && objects[i].active == true && objects[i].collidable == true && objects[i].CheckCollision(futureBindingBox) == true) ;
                return true;
            }
            return false;
        }

        public void LandResponse(Rectangle wallCollision)
        {
            position.Y = wallCollision.Top - (boundingBoxHeight);
            velocity.Y = 0;
            jumping = false;
        }
    }
}
