using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project_1
{
    /// <summary>
    /// A class to help with collision calculations
    /// </summary>
    public static class CollisionHelper
    {
        /// <summary>
        /// Detects a collision between two BoundingCircles
        /// </summary>
        /// <param name="a">The first BoundingCircle</param>
        /// <param name="b">The second BoundingCircle</param>
        /// <returns>true for collision, false otherwise</returns>
        public static bool Collides(BoundingCircle a, BoundingCircle b)
        {
            return Math.Pow(a.Radius + b.Radius, 2) >= Math.Pow(a.Center.X - b.Center.X, 2) + Math.Pow(a.Center.Y - b.Center.Y, 2);
        }
    }
}
