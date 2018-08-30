using TetrisUI;

namespace Infrastructure.DataModel
{
    public class ShapeI : RotatableShape
    {
        //private const ShapeColor _color = ShapeColor.Cyan;

        public ShapeI()
        {
            _shape = new[,]
            {
                {false, false, false, false},
                {true, true, true, true},
                {false, false, false, false},
                {false, false, false, false}
            };

            _color = ShapeColor.Cyan;
        }

        public ShapeI(int xPosition, int yPosition, ShapeRotation rotation = ShapeRotation.Zero) : base(xPosition, yPosition, rotation)
        {
            _shape = new[,]
            {
                {false, false, false, false},
                {true, true, true, true},
                {false, false, false, false},
                {false, false, false, false}
            };

            _color = ShapeColor.Cyan;
        }

        //private bool[,] _shapeI0 = 
        //{
        //    {false, false, false, false},
        //    {true, true, true, true},
        //    {false, false, false, false},
        //    {false, false, false, false}
        //};

        //private bool[,] _shapeI90 =
        //{
        //    {false, false, true, false },
        //    {false, false, true, false },
        //    {false, false, true, false },
        //    {false, false, true, false }
        //};

        //private bool[,] _shapeI180 =
        //{
        //    {false, false, false, false},
        //    {false, false, false, false},
        //    {true, true, true, true},
        //    {false, false, false, false}
        //};

        //private bool[,] _shapeI270 =
        //{
        //    {false, true, false, false},
        //    {false, true, false, false},
        //    {false, true, false, false},
        //    {false, true, false, false}
        //};

        //protected override bool[,] DrawGrid0(IRender render)
        //{
        //    for (var y = 0; y < _shapeI0.GetLength(1); y++)
        //    {
        //        for (var x = 0; x < _shapeI0.GetLength(0); x++)
        //        {
        //            if (_shapeI0[x, y])
        //            {
        //                render.Draw(x, y, ShapeColor.Orange);
        //            }
        //        }
        //    }

        //    return ShapeGrid;
        //}
        //protected override void DrawZero(IRender render) //, bool[,] shapeGrid
        //{
        //    //render.Draw(3 + XPosition, 0 + YPosition, ShapeColor.Purple);
        //    DrawShapeGrid(render, _shapeI0, ShapeColor.Cyan);
        //    //, XPosition, YPosition
        //    //Draw(render, _shapeI0);
        //    //render.Draw(XPosition, YPosition, ShapeColor.Cyan);

        //    //for (var y = 0; y < _shapeI0.GetLength(1); y++)
        //    //{
        //    //    for (var x = 0; x < _shapeI0.GetLength(0); x++)
        //    //    {
        //    //        if (_shapeI0[x, y])
        //    //        {
        //    //            render.Draw(x, y, ShapeColor.Orange);
        //    //        }
        //    //    }
        //    //}

        //    //render.Draw(XPosition + 3, YPosition + 1, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 4, YPosition + 1, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 5, YPosition + 1, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 6, YPosition + 1, ShapeColor.Cyan);
        //}

        //protected override void DrawNinety(IRender render)
        //{
        //    DrawShapeGrid(render, _shapeI90, ShapeColor.Cyan);

        //    //render.Draw(XPosition + 5, YPosition + 0, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 5, YPosition + 1, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 5, YPosition + 2, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 5, YPosition + 3, ShapeColor.Cyan);
        //}

        //protected override void DrawOneEighty(IRender render)
        //{
        //    DrawShapeGrid(render, _shapeI180, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 3, YPosition + 2, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 4, YPosition + 2, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 5, YPosition + 2, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 6, YPosition + 2, ShapeColor.Cyan);
        //}

        //protected override void DrawTwoSeventy(IRender render)
        //{
        //    DrawShapeGrid(render, _shapeI270, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 4, YPosition + 0, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 4, YPosition + 1, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 4, YPosition + 2, ShapeColor.Cyan);
        //    //render.Draw(XPosition + 4, YPosition + 3, ShapeColor.Cyan);
        //}
    }
}
