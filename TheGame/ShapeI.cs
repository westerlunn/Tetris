using System;
using TetrisUI;

namespace TheGame
{
    public class ShapeI : RotatableShape
    {
        public ShapeI(int xPosition, int yPosition, ShapeRotation rotation) : base(xPosition, yPosition, rotation)
        {
        }

        protected override void DrawZero(IRender render)
        {
            render.Draw(XPosition + 3, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 6, YPosition + 1, ShapeColor.Cyan);
        }

        protected override void DrawNinety(IRender render)
        {
            render.Draw(XPosition + 5, YPosition + 0, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 3, ShapeColor.Cyan);
        }

        protected override void DrawOneEighty(IRender render)
        {
            render.Draw(XPosition + 3, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 5, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 6, YPosition + 2, ShapeColor.Cyan);
        }

        protected override void DrawTwoSeventy(IRender render)
        {
            render.Draw(XPosition + 4, YPosition + 0, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 1, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 2, ShapeColor.Cyan);
            render.Draw(XPosition + 4, YPosition + 3, ShapeColor.Cyan);
        }

        public Boolean[,] ShapeGrid = new bool[,]
        {
            {false, true},
            {true, false}
        };
    }
}
