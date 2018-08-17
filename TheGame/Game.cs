﻿using System;
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
        private Player _player;
        private bool _running;

        public List<Shape> Shapes { get; } = new List<Shape>();

        public void IsGameRunning()
        {
            if (IsGameOver())
            {
                _running = false;
            }
            _running = true;
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
            _player = new Player("Bollkalle");
        }

        protected override void UpdateGame()
        {
            IsGameRunning();
            if (_running)
            {
                if (_activeShape == null)
                {
                    GetRandomShape();
                }

                if (_activeShape.GetBlocks().All(b => b.YPosition < 19))
                {
                    _activeShape.YPosition++;
                }

                KillShapeGetNewShapeAndBlowRows();
            }

        }

        protected override void Render(IRender render)
        {
            if (_activeShape == null) return;

            foreach (var block in _activeShape.GetBlocks())
            {
                render.Draw(block.XPosition, block.YPosition, block.Color);
            }

            foreach (var block in _deadBlocks)
            {
                render.Draw(block.XPosition, block.YPosition, block.Color);
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
            KillShapeGetNewShapeAndBlowRows();
        }

        protected override void MoveLeft()
        {
            if (IsActiveShape() && CanMoveLeft())
            {
                _activeShape.XPosition--;
            }
        }

        protected override void MoveRight()
        {
            if (IsActiveShape() && CanMoveRight())
            {
                _activeShape.XPosition++;
            }
        }

        protected void GetRandomShape()
        {
            if (_activeShape != null)
            {
                _activeShape.YPosition = -1;
                _activeShape.XPosition = 3;
            }

            _activeShape = _shapes[_random.Next(_shapes.Count)];
        }
        public bool IsActiveShape()
        {

            if (_activeShape.GetBlocks().Any(b => b.YPosition == 19))
            {
                return false;
            }

            foreach (var block in _deadBlocks)
            {
                if (_activeShape.GetBlocks().Any(b =>
                        b.YPosition + 1 == block.YPosition && b.XPosition == block.XPosition))
                {
                    return false;
                }
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
                    b.YPosition + 1 == deadBlock.YPosition && b.XPosition == deadBlock.XPosition))
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
            if (_activeShape.GetBlocks().Any(b => b.XPosition == 9))
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

        private bool IsGameOver()
        {
            if (_deadBlocks.Any(b => b.YPosition == 0))
            {
                ShowGameOverMessage();
                return true;
            }
            //foreach (var deadBlock in _deadBlocks)
            //{
            //    if (deadBlock.YPosition == 0)
            //    {
            //        ShowGameOverMessage();
            //    }
            //}

            return false;
        }
        private void ShowGameOverMessage()
        {
            var message = "Game over! Your score was: ";
            var score = _player.Score;

            MessageBox.Show(message + score);
        }

        private List<int> GetFullRows()
        {
            var gameLength = 19;
            var result = new List<int>();

            for (var y = gameLength; y > 0; y--)
            {
                if (_deadBlocks.Where(b => b.YPosition == y).ToList().Count == 10)
                {
                    result.Add(y);
                }
            }

            return result;
        }

        private void BlowRow(int row)
        {
            _deadBlocks.RemoveAll(b => b.YPosition == row);

            foreach (var block in _deadBlocks)
            {
                if (block.YPosition < row)
                {
                    block.YPosition++;
                }
            }
        }

        private void KillShapeGetNewShapeAndBlowRows()
        {
            if (!IsActiveShape())
            {
                foreach (var block in _activeShape.GetBlocks())
                {
                    _deadBlocks.Add(block);
                }

                GetRandomShape();
            }

            IsGameOver();

            GetPointsForBlownRow();
            //var fullRows = GetFullRows();
            //if (fullRows.Count > 0)
            //{

            //    fullRows.ForEach(BlowRow);
            //}
            IsGameRunning();
        }

        private long GetPointsForBlownRow()
        {
            var fullRows = GetFullRows();
            if (fullRows.Count > 0)
            {
                if (fullRows.Count == 1)
                {
                    _player.Score += 40;
                }
                else if (fullRows.Count == 2)
                {
                    _player.Score += 100;
                }
                else if (fullRows.Count == 3)
                {
                    _player.Score += 300;
                }
                else if (fullRows.Count == 4)
                {
                    _player.Score += 1200;
                }
                fullRows.ForEach(BlowRow);
            }

            return _player.Score;
        }
    }
}
