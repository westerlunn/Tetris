using TetrisUI;

namespace Infrastructure.DataModel
{
    public abstract class RotatableShape : Shape
    {
        public ShapeRotation Rotation { get; private set; }

        protected RotatableShape(int xPosition, int yPosition, ShapeColor color, ShapeRotation rotation = ShapeRotation.Zero) : base(xPosition, yPosition, color)
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

            RotateShape();
        }

        private void RotateShape()
        {
            var xLength = _shape.GetLength(1);
            var yLength = _shape.GetLength(0);

            var rotated = new bool[yLength, xLength];

            for (var y = 0; y < yLength; y++)
            {
                for (var x = 0; x < xLength; x++)
                {
                    rotated[y, x] = _shape[xLength - x - 1, y];
                }
            }

            _shape = rotated;
        }

        private bool IsLastRotationState()
        {
            return Rotation == ShapeRotation.TwoSeventy;
        }

        //public override void Draw(IRender render)
        //{
        //    switch (Rotation)
        //    {
        //        case ShapeRotation.Zero:
        //            DrawZero(render);
        //            break;
        //        case ShapeRotation.Ninety:
        //            DrawNinety(render);
        //            break;
        //        case ShapeRotation.OneEighty:
        //            DrawOneEighty(render);
        //            break;
        //        case ShapeRotation.TwoSeventy:
        //            DrawTwoSeventy(render);
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}

        //protected abstract void DrawZero(IRender render);

        //protected abstract void DrawNinety(IRender render);

        //protected abstract void DrawOneEighty(IRender render);

        //protected abstract void DrawTwoSeventy(IRender render);
    }
}