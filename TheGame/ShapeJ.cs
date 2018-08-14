using TetrisUI;

namespace TheGame
{
    public class ShapeJ : RotatableShape
    {
        public ShapeJ(int xPosition, int yPosition, ShapeRotation rotation) : base(xPosition, yPosition, rotation)
        {
        }

        //private Block[,] _shapeJ =
        //{
        //    {new Block {IsFilled = true}, false, false},
        //    {true, true, true},
        //    {false, false, false}
        //};

        private bool[,] _shapeJ0 =
        {
            {true, false, false},
            {true, true, true},
            {false, false, false}
        };

        private bool[,] _shapeJ90 =
        {
            {false, true, true},
            {false, true, false},
            {false, true, false}
        };

        private bool[,] _shapeJ170 =
        {
            {false, false, false},
            {true, true, true},
            {false, false, true}
        };

        private bool[,] _shapeJ270 =
        {
            {false, true, false},
            {false, true, false},
            {true, true, false}
        };

        protected override void DrawZero(IRender render)
        {
            DrawShapeGrid(render, _shapeJ0, ShapeColor.Blue);
        }

        protected override void DrawNinety(IRender render)
        {
            DrawShapeGrid(render, _shapeJ90, ShapeColor.Blue);
        }

        protected override void DrawOneEighty(IRender render)
        {
            DrawShapeGrid(render, _shapeJ170, ShapeColor.Blue);
        }

        protected override void DrawTwoSeventy(IRender render)
        {
            DrawShapeGrid(render, _shapeJ270, ShapeColor.Blue);
        }
    }
}
