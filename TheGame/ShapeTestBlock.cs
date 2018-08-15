using TetrisUI;

namespace TheGame
{
    public class ShapeTestBlock : Shape
    {
        public ShapeTestBlock(int xPosition, int yPosition) : base(xPosition, yPosition, ShapeColor.Orange)
        {
            _shape = new[,]
            {
                {true}
            };
        }


        //public override void Draw(IRender render)
        //{
        //    DrawShapeGrid(render, _shape, ShapeColor.Purple);
        //}
    }
}
