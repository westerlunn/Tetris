using System;
using TetrisUI;

namespace TheGame
{
    public enum ShapeType
    {
        I,
        J,
        L,
        O,
        S,
        T,
        Z
    }

    public enum ShapeRotation
    {
        Zero,
        Ninety,
        OneEighty,
        TwoSeventy
    }

    public class Shape
    {
        public ShapeType Type { get; }
        public ShapeColor Color { get; }
        public ShapeRotation Rotation { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public Shape()
        {
        }

        public Shape(ShapeType type, ShapeRotation rotation, int xPosition, int yPosition)
        {
            Type = type;
            Rotation = rotation;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public void Rotate()
        {
            if (Rotation == ShapeRotation.TwoSeventy)
            {
                Rotation = ShapeRotation.Zero;
            }
            else
            {
                Rotation++;
            }
        }

        public void Draw(IRender render)
        {
            switch (Type)
            {
                case ShapeType.I:
                    DrawI(render);
                    break;
                case ShapeType.J:
                    break;
                case ShapeType.L:
                    break;
                case ShapeType.O:
                    break;
                case ShapeType.S:
                    break;
                case ShapeType.T:
                    break;
                case ShapeType.Z:
                    break;
            }
        }

        private void DrawI(IRender render)
        {
            switch (Rotation)
            {
                case ShapeRotation.Zero:
                    DrawIZero(render);
                    break;
                case ShapeRotation.Ninety:
                    DrawINinety(render);
                    break;
                case ShapeRotation.OneEighty:
                    DrawIOneEighty(render);
                    break;
                case ShapeRotation.TwoSeventy:
                    DrawITwoSeventy(render);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ShapePosition(IRender render)
        {

        }
        private void DrawIZero(IRender render)
        {
            render.Draw(XPosition + 3, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 6, YPosition + 1, ShapeColor.Cyan);
        }

        private void DrawINinety(IRender render)
        {
            render.Draw(XPosition + 5, YPosition + 0, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 3, ShapeColor.Cyan);
        }

        private void DrawIOneEighty(IRender render)
        {
            render.Draw(XPosition + 3, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 6, YPosition + 2, ShapeColor.Cyan);
        }

        private void DrawITwoSeventy(IRender render)
        {
            render.Draw(XPosition + 4, YPosition + 0, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 3, ShapeColor.Cyan);
        }
    }
}
