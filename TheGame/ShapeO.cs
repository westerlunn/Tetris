using TetrisUI;

namespace TheGame
{
    public class ShapeO : Shape
    {
        public ShapeO(int xPosition, int yPosition) : base(xPosition, yPosition)
        {
        }

        private bool[,] _shapeO =
        {
            {true, true},
            {true, true}
        };
        public override void Draw(IRender render)
        {
            if (IsAllowedPosition(_shapeO))
            {
                //GetBlock(_shapeO, ShapeColor.Yellow);
                DrawShapeGrid(render, _shapeO, ShapeColor.Yellow);
            }

        }
    }
}
