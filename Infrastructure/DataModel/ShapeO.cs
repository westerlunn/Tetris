using TetrisUI;

namespace Infrastructure.DataModel
{
    public class ShapeO : Shape
    {
        //private const ShapeColor _color = ShapeColor.Yellow;

        public ShapeO()
        {
            _shape = new[,]
            {
                {true, true},
                {true, true}
            };

            _color = ShapeColor.Yellow;
        }

        public ShapeO(int xPosition, int yPosition) : base(xPosition, yPosition)
        {
            _shape = new[,]
            {
                {true, true},
                {true, true}
            };

            _color = ShapeColor.Yellow;
        }

        //private bool[,] _shapeO =
        //{
        //    {true, true},
        //    {true, true}
        //};
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
