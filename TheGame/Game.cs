using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisUI;

namespace TheGame
{

    public partial class Game : GameBoard
    {
        private Shape _activeShape;
        private List<Shape> _shapes;
        private List<Block> _deadBlocks;
        private Random _random;

        public List<Shape> Shapes { get; } = new List<Shape>();

        public void WithinBounds()
        {

        }

        public Game() : base(500)
        {
            _deadBlocks = new List<Block>();
            //Shapes.Add(new ShapeI(3, 0, ShapeRotation.Zero));
            //Shapes.Add(new ShapeJ(0, 5, ShapeRotation.Zero));
            //Shapes.Add(new ShapeO(0,4));
            //Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Ninety, 0, 0));
            _shapes = new List<Shape>();
            _shapes.Add(new ShapeI(3, 0));
            _shapes.Add(new ShapeJ(3, 0));
            _shapes.Add(new ShapeO(3, 0));
            //_activeShape = new ShapeO(0, 0);
            _random = new Random();

        }

        protected override void UpdateGame()
        {
            if (_activeShape == null)
            {
                CreateShape();
            }
            if (_activeShape.GetBlocks().All(b => b.YPosition < 19))
            {
                _activeShape.YPosition++;
            }
            if (!IsActiveShape())
            {
                foreach (var block in _activeShape.GetBlocks())
                {
                    _deadBlocks.Add(block);
                }

                //foreach (var block in _deadBlocks)
                //{
                //    if (block.YPosition < 0)
                //}

                CreateShape();
                foreach (var shape in _shapes)
                {
                    shape.YPosition = -1;
                    shape.XPosition = 3;
                }
                GameOver();
            }
        }

        protected override void Render(IRender render)
        {
            if (_activeShape == null) return;

            foreach (var block in _activeShape.GetBlocks())
            {
                render.Draw(block.XPosition, block.YPosition, block.Color);
                //if (_activeShape.GetBlocks().Any(b => b.YPosition == 19))
                //{
                //    _deadBlocks.Add(block);
                //}
            }

            foreach (var block in _deadBlocks)
            {
                render.Draw(block.XPosition, block.YPosition, block.Color);
            }
            //throw new NotImplementedException();
        }

        public bool IsActiveShape()
        {

            if (_activeShape.GetBlocks().Any(b => b.YPosition == 19))
            {
                return false;
            }

            foreach (var block in _deadBlocks)
            {
                if (_activeShape.GetBlocks().Any(b => b.YPosition + 1 == block.YPosition && b.XPosition == block.XPosition))
                //&& _activeShape.GetBlocks().Any(b => b.XPosition + 1 == block.XPosition))
                {
                    return false;
                }
                //else if (_activeShape.GetBlocks().Any(b => b.YPosition == 19))
                //{
                //    retur
                //}
            }

            return true;
        }

        public bool WillCollide()
        {
            if (_activeShape.GetBlocks().Any(b => b.YPosition == 19))
            {
                return true;
            }
            foreach (var deadBlock in _deadBlocks)
            {
                if (_activeShape.GetBlocks().Any(b =>
                    b.YPosition + 2 == deadBlock.YPosition && b.XPosition == deadBlock.XPosition))
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanMoveLeft()
        {
            if (_activeShape.GetBlocks().Any(b => b.XPosition == 0))
            {
                return false;
            }
            foreach (var deadBlock in _deadBlocks)
            {
                    if (_activeShape.GetBlocks().Any(b => b.XPosition - 1 == deadBlock.XPosition && b.YPosition == deadBlock.YPosition))
                    {
                        return false;
                    }
            }
            
            return true;
        }

        public bool CanMoveRight()
        {
            if(_activeShape.GetBlocks().Any(b => b.XPosition == 9))
            {
                return false;
            }

            foreach (var deadBlock in _deadBlocks)
            {
                if (_activeShape.GetBlocks().Any(b =>
                    b.XPosition + 1 == deadBlock.XPosition && b.YPosition == deadBlock.YPosition))
                {
                    return false;
                }
            }

            return true;
        }

        public void GameOver()
        {
            foreach (var deadBlock in _deadBlocks)
            {
                if (deadBlock.YPosition == 0)
                {
                    var message = "Game over";
                    MessageBox.Show(message);
                }
            }
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
            while (!WillCollide())
            {
                _activeShape.YPosition++;
            }
            //_activeShape.GetBlocks().All(b => b.YPosition > 19) || _activeShape.GetBlocks().ForEach(b => _deadBlocks.Any(b2 => b2.YPosition + 1 == b.YPosition))
            //_activeShape.YPosition = 18;
            //CreateShape();
            //throw new NotImplementedException("Drop");
        }

        protected override void MoveLeft()
        {
            //foreach (var shape in Shapes)
            //{
            if (IsActiveShape() && CanMoveLeft())
            {
                //if (_activeShape.GetBlocks().All(b => b.XPosition > 0))
                {
                    _activeShape.XPosition--;
                }
            }

            //}
        }

        protected override void MoveRight()
        {
            if (IsActiveShape() && CanMoveRight())
            {
                _activeShape.XPosition++;
            }
            //foreach (var shape in Shapes)
            //{
            //    if (shape.XPosition < 8)
            //    {
            //        shape.XPosition++;
            //    }
            //}

            //if (_activeShape.GetBlocks().All(b => b.XPosition < 9))
            //{
            //    _activeShape.XPosition++;
            //}
        }

        protected void CreateShape()
        {
            //var random = new Random();
            //var index = random.Next(Shapes.Count);
            //_activeShape = Shapes[index];
            _activeShape = _shapes[_random.Next(_shapes.Count)];



            //Shapes.Add(new ShapeI(0, 0, ShapeRotation.Ninety));
            //Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Zero, 0, 0));
        }

    }
}
