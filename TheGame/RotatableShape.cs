﻿using System;
using TetrisUI;

namespace TheGame
{
    public abstract class RotatableShape : Shape
    {
        public ShapeRotation Rotation { get; private set; }

        protected RotatableShape(int xPosition, int yPosition, ShapeRotation rotation) : base(xPosition, yPosition)
        {
            Rotation = rotation;
        }

        public void Rotate()
        {
            if (IsLastRotationState())
            {
                Rotation = ShapeRotation.Zero;
            }
            else
            {
                Rotation++;
            }
        }

        private bool IsLastRotationState()
        {
            return Rotation == ShapeRotation.TwoSeventy;
        }

        public override void Draw(IRender render) //, bool[,] shapeGrid
        {
            switch (Rotation)
            {
                case ShapeRotation.Zero:
                    //DrawGrid0(render);
                    DrawZero(render);
                    break;
                case ShapeRotation.Ninety:
                    DrawNinety(render);
                    break;
                case ShapeRotation.OneEighty:
                    DrawOneEighty(render);
                    break;
                case ShapeRotation.TwoSeventy:
                    DrawTwoSeventy(render);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected abstract void DrawZero(IRender render);
        //, bool[,] shapeGrid
        //protected abstract void DrawGrid0(IRender render);

        protected abstract void DrawNinety(IRender render);

        protected abstract void DrawOneEighty(IRender render);

        protected abstract void DrawTwoSeventy(IRender render);
    }
}