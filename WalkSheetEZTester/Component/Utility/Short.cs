using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TiaraFramework.Component
{
    public class Short
    {
        public static Point Pt() { return new Point(); }
        public static Point Pt(int x, int y) { return new Point(x, y); }

        public static Vector2 Vec() { return Vector2.Zero; }
        public static Vector2 Vec(float x, float y) { return new Vector2(x, y); }
        public static Vector2 VecX(float x) { return new Vector2(x, 0); }
        public static Vector2 VecY(float y) { return new Vector2(0, y); }

        public static Rectangle Rect() { return Rectangle.Empty; }
        public static Rectangle Rect(int x, int y, int width, int height) { return new Rectangle(x, y, width, height); }
        public static Rectangle Rect(int width, int height) { return new Rectangle(0, 0, width, height); }
    }
}
