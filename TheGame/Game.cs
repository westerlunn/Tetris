using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisUI;

namespace TheGame
{

    public partial class Game : GameBoard
    {
        private Shape _activeShape;
        private List<Block> _deadBlocks;

        //public List<Shape> Shapes { get; } = new List<Shape>();

        //public bool[,] ShapeGrid = new bool[,]
        //{
        //    {false, true, false, true},
        //    {false, false, false, false},
        //    {false, true, false, false },
        //    {true, false, false, false }
        //};


        //public Boolean[,] Grid = new bool[,]
        //    {
        //    {0, 0} = true,
        //};

        //public bool IsLocationLeftWithinBounds(Shape shape)
        //{
        //    var xCoordinate = shape.XPosition;
        //    for (int i = 0; i < shape.ShapeGrid.GetLength(0); i++)
        //    {
        //        if (shape.ShapeGrid[i, shape.ShapeGrid.GetLength(0) - 1])
        //        {
        //            xCoordinate++;
        //        }
        //    }

        //    return xCoordinate > 0;
        //}

        public void WithinBounds()
        {

        }

        public Game() : base(1000)
        {
            _deadBlocks = new List<Block>();
            //Shapes.Add(new ShapeI(3, 0, ShapeRotation.Zero));
            //Shapes.Add(new ShapeJ(0, 5, ShapeRotation.Zero));
            //Shapes.Add(new ShapeO(0,4));
            //Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Ninety, 0, 0));
            _activeShape = new ShapeJ(0, 0);
        }

        protected override void UpdateGame()
        {
            if (_activeShape.GetBlocks().All(b => b.YPosition < 19))
            {
                _activeShape.YPosition++;
            }
        }

        protected override void Render(IRender render)
        {
            foreach (var block in _activeShape.GetBlocks())
            {
                render.Draw(block.XPosition, block.YPosition, block.Color);
            }

            foreach (var block in _deadBlocks)
            {
                render.Draw(block.XPosition, block.YPosition, block.Color);
            }
            
            //throw new NotImplementedException();
        }

        protected override void Rotate()
        {
            if (_activeShape is RotatableShape rotatableShape)
            {
                rotatableShape.Rotate();
            }
        }

        protected override void Drop()
        {
            //CreateShape();
            //throw new NotImplementedException("Drop");
        }

        protected override void MoveLeft()
        {
            //foreach (var shape in Shapes)
            //{

                if (_activeShape.GetBlocks().All(b => b.XPosition > 0))
                {
                    _activeShape.XPosition--;
                }
            //}
        }

        protected override void MoveRight()
        {
            //foreach (var shape in Shapes)
            //{
            //    if (shape.XPosition < 8)
            //    {
            //        shape.XPosition++;
            //    }
            //}
            
            if (_activeShape.GetBlocks().All(b => b.XPosition < 9))
            {
                _activeShape.XPosition++;
            }
        }

        protected void CreateShape()
        {
            //Shapes.Add(new ShapeI(0, 0, ShapeRotation.Ninety));
            //Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Zero, 0, 0));
        }

    }
}
