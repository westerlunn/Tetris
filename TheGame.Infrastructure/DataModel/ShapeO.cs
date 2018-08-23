using TetrisUI;

namespace TheGame.Infrastructure.DataModel
{
    public class ShapeO : Shape
    {
        private const ShapeColor _color = ShapeColor.Yellow;

        public ShapeO(int xPosition, int yPosition) : base(xPosition, yPosition, _color)
        {
            _shape = new[,]
            {
                {true, true},
                {true, true}
            };
        }

        private bool[,] _shapeO =
        {
            {true, true},
            {true, true}
        };
        //public override void Draw(IRender render)
        //{
        //    //if (IsAllowedPosition(_shape))
        //    {
        //        //GetBlock(_shapeO, ShapeColor.Yellow);
        //        DrawShapeGrid(render, _shapeO, ShapeColor.Yellow);
        //    }

        //}
    }
}
