using System;
using System.Collections.Generic;
using TetrisUI;

namespace TheGame
{
    public abstract class Shape
    {
        //public ShapeType Type { get; }
        public ShapeColor Color { get; }
        //public ShapeRotation Rotation { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public bool[,] ShapeGrid { get; set; }
        public List<Block> Blocks { get; set; }
        
        protected Shape(int xPosition, int yPosition) 
        {
            //Type = type; ShapeType type,
            //Rotation = rotation;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public abstract void Draw(IRender render); 

        public void DrawShapeGrid(IRender render, bool[,] shapeGrid, ShapeColor color) 
        {
            for (var m = 0; m < shapeGrid.GetLength(1); m++)
            {
                for (var n = 0; n < shapeGrid.GetLength(0); n++)
                {
                    if (shapeGrid[m, n])
                    {
                        render.Draw(n + XPosition, m + YPosition, color);
                    }
                }
            }
        }

        public void GetBlock(bool[,] shapeGrid, ShapeColor color)
        {
            var Blocks = new List<Block>();
            for (var m = 0; m < shapeGrid.GetLength(1); m++)
            {
                for (var n = 0; n < shapeGrid.GetLength(0); n++)
                {
                    if (shapeGrid[m, n])
                    {
                        Blocks.Add(new Block(n + XPosition, m + YPosition, color));
                    }
                }
            }
        }

        public bool IsAllowedPosition(bool[,] shapeGrid)
        {
            for (var m = 0; m < shapeGrid.GetLength(1); m++)
            {
                for (var n = 0; n < shapeGrid.GetLength(0); n++)
                {
                    if (m + XPosition < 10 && m + XPosition >= 0 && n + YPosition < 20 && n + YPosition >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        //public void Rotate()
        //{
        //    if (LastRotationMode())
        //    {
        //        Rotation = ShapeRotation.Zero;
        //    }
        //    else
        //    {
        //        Rotation++;
        //    }
        //}

        //private bool LastRotationMode()
        //{
        //    return Rotation == ShapeRotation.TwoSeventy;
        //}


        //switch (Type)
        //{
        //    case ShapeType.I:
        //        DrawI(render);
        //        break;
        //    case ShapeType.J:
        //        break;
        //    case ShapeType.L:
        //        break;
        //    case ShapeType.O:
        //        break;
        //    case ShapeType.S:
        //        break;
        //    case ShapeType.T:
        //        break;
        //    case ShapeType.Z:
        //        break;
        //}
        //public void DrawI(IRender render)
        //{
        //    switch (Rotation)
        //    {
        //        case ShapeRotation.Zero:
        //            DrawIZero(render);
        //            break;
        //        case ShapeRotation.Ninety:
        //            DrawINinety(render);
        //            break;
        //        case ShapeRotation.OneEighty:
        //            DrawIOneEighty(render);
        //            break;
        //        case ShapeRotation.TwoSeventy:
        //            DrawITwoSeventy(render);
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}

        //private void DrawIZero(IRender render)
        //{
        //    render.Draw(XPosition + 3, YPosition + 1, ShapeColor.Cyan);
        //    render.Draw(XPosition + 4, YPosition + 1, ShapeColor.Cyan);
        //    render.Draw(XPosition + 5, YPosition + 1, ShapeColor.Cyan);
        //    render.Draw(XPosition + 6, YPosition + 1, ShapeColor.Cyan);
        //}

        //private void DrawINinety(IRender render)
        //{
        //    render.Draw(XPosition + 5, YPosition + 0, ShapeColor.Cyan);
        //    render.Draw(XPosition + 5, YPosition + 1, ShapeColor.Cyan);
        //    render.Draw(XPosition + 5, YPosition + 2, ShapeColor.Cyan);
        //    render.Draw(XPosition + 5, YPosition + 3, ShapeColor.Cyan);
        //}

        //private void DrawIOneEighty(IRender render)
        //{
        //    render.Draw(XPosition + 3, YPosition + 2, ShapeColor.Cyan);
        //    render.Draw(XPosition + 4, YPosition + 2, ShapeColor.Cyan);
        //    render.Draw(XPosition + 5, YPosition + 2, ShapeColor.Cyan);
        //    render.Draw(XPosition + 6, YPosition + 2, ShapeColor.Cyan);
        //}

        //private void DrawITwoSeventy(IRender render)
        //{
        //    render.Draw(XPosition + 4, YPosition + 0, ShapeColor.Cyan);
        //    render.Draw(XPosition + 4, YPosition + 1, ShapeColor.Cyan);
        //    render.Draw(XPosition + 4, YPosition + 2, ShapeColor.Cyan);
        //    render.Draw(XPosition + 4, YPosition + 3, ShapeColor.Cyan);
        //}

        //render.Draw(0, 1, ShapeColor.Orange);
        //render.Draw(1, 1, ShapeColor.Orange);
        //render.Draw(2, 1, ShapeColor.Orange);
        //render.Draw(2, 0, ShapeColor.Orange);

        //render.Draw(3, 8, ShapeColor.Blue);
        //render.Draw(3, 9, ShapeColor.Blue);
        //render.Draw(4, 9, ShapeColor.Blue);
        //render.Draw(5, 9, ShapeColor.Blue);
    }
}
