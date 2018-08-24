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
using Microsoft.EntityFrameworkCore;
using TetrisUI;
using TheGame.EFRepository;
using TheGame.Infrastructure.DataModel;
using TheGame.Infrastructure.Repositories;

namespace TheGame
{
    public partial class Game : GameBoard
    {
        //private Shape _activeShape;
        private List<Shape> _shapes;
        //private List<Block> _deadBlocks;
        private Random _random;
        //private Player _player;
        private bool _running;
        private GameState _gameState;
        private IRepository<GameState> _repository;

        public Game(IRepository<GameState> repository) : base(500)
        {
            _shapes = new List<Shape>();
            _shapes.Add(new ShapeI(3, 0));
            _shapes.Add(new ShapeJ(3, 0));
            _shapes.Add(new ShapeO(3, 0));
            //_activeShape = new ShapeO(0, 0);
            _random = new Random();
            //_gameState = GetLatestGameState();
            _repository = repository;
            _gameState = _repository.GetAll().OrderByDescending(g => g.GameStateId).FirstOrDefault();

            if (_gameState == null)
            {
                CreateNewGameState();
            }

        }

        protected override void UpdateGame()
        {
            if (_running)
            {
                if (_gameState.ActiveShape == null)
                {
                    GetRandomShape();
                    //SaveGameState();
                }

                else if (_gameState.ActiveShape.GetBlocks().All(b => b.YPosition < 19))
                {
                    _gameState.ActiveShape.YPosition++;
                }

                KillShapeGetNewShapeAndBlowRows();
                Update();
            }
        }

        protected override void Render(IRender render)
        {
            if (_gameState.ActiveShape == null) return;

            foreach (var block in _gameState.ActiveShape.GetBlocks())
            {
                render.Draw(block.XPosition, block.YPosition, block.Color);
            }

            foreach (var block in _gameState.DeadBlocks)
            {
                render.Draw(block.XPosition, block.YPosition, block.Color);
            }
        }



        protected override void Rotate()
        {
            if (_gameState.ActiveShape is RotatableShape rotatableShape)
            {
                rotatableShape.Rotate();
            }
        }

        protected override void Drop()
        {
            while (!WillCollide())
            {
                _gameState.ActiveShape.YPosition++;
            }
            KillShapeGetNewShapeAndBlowRows();
        }

        protected override void MoveLeft()
        {
            if (IsActiveShape() && CanMoveLeft())
            {
                _gameState.ActiveShape.XPosition--;
            }
        }

        protected override void MoveRight()
        {
            if (IsActiveShape() && CanMoveRight())
            {
                _gameState.ActiveShape.XPosition++;
            }
        }


        private void CreateNewGameState()
        {
            _gameState = new GameState();
            _repository.Save(_gameState);
            _running = true;
        }

        //private void SaveGameState()
        //{
        //    using (var context = new GameContext())
        //    {
        //        context.GameStates.Add(_gameState);
        //        context.SaveChanges();
        //    }
        //}

        //private void UpdateGameState()
        //{
        //    using (var context = new GameContext())
        //    {
        //        context.GameStates.Update(_gameState);
        //        context.SaveChanges();
        //    }
        //}

        //private GameState GetLatestGameState()
        //{
        //    using (var context = new GameContext())
        //    {
        //        var latestGameState = context.GameStates
        //            .Include(g => g.DeadBlocks)
        //            .Include(g => g.ActiveShape)
        //            .OrderByDescending(g => g.GameStateId).FirstOrDefault();
        //        _running = true;
        //        return latestGameState;
        //    }
        //}

        //private void RecreateDatabase()
        //{
        //    using (var context = new GameContext())
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();
        //    }
        //}
        private void GetRandomShape()
        {
            if (_gameState.ActiveShape != null)
            {
                _gameState.ActiveShape.YPosition = -1;
                _gameState.ActiveShape.XPosition = 3;
            }

            _gameState.ActiveShape = _shapes[_random.Next(_shapes.Count)];
        }

        private bool IsActiveShape()
        {

            if (_gameState.ActiveShape.GetBlocks().Any(b => b.YPosition == 19))
            {
                return false;
            }

            foreach (var block in _gameState.DeadBlocks)
            {
                if (_gameState.ActiveShape.GetBlocks().Any(b =>
                        b.YPosition + 1 == block.YPosition && b.XPosition == block.XPosition))
                {
                    return false;
                }
            }
            return true;
        }

        private bool WillCollide()
        {
            if (_gameState.ActiveShape.GetBlocks().Any(b => b.YPosition == 19))
            {
                return true;
            }
            foreach (var deadBlock in _gameState.DeadBlocks)
            {
                if (_gameState.ActiveShape.GetBlocks().Any(b =>
                    b.YPosition + 1 == deadBlock.YPosition && b.XPosition == deadBlock.XPosition))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CanMoveLeft()
        {
            if (_gameState.ActiveShape.GetBlocks().Any(b => b.XPosition == 0))
            {
                return false;
            }
            foreach (var deadBlock in _gameState.DeadBlocks)
            {
                if (_gameState.ActiveShape.GetBlocks().Any(b => b.XPosition - 1 == deadBlock.XPosition && b.YPosition == deadBlock.YPosition))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CanMoveRight()
        {
            if (_gameState.ActiveShape.GetBlocks().Any(b => b.XPosition == 9))
            {
                return false;
            }

            foreach (var deadBlock in _gameState.DeadBlocks)
            {
                if (_gameState.ActiveShape.GetBlocks().Any(b =>
                    b.XPosition + 1 == deadBlock.XPosition && b.YPosition == deadBlock.YPosition))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsGameOver()
        {
            if (_gameState.DeadBlocks.Any(b => b.YPosition == 0))
            {
                _running = false;
                ShowGameOverMessage();
                CreateNewGameState();
                AskToSeedDatabase();
                return true;
            }

            return false;
            //foreach (var deadBlock in _deadBlocks)
            //{
            //    if (deadBlock.YPosition == 0)
            //    {
            //        ShowGameOverMessage();
            //    }
            //}

        }
        private void ShowGameOverMessage()
        {
            var result = MessageBox.Show($"Game over! Your score was: {_gameState.Score}");
            if (result == DialogResult.OK)
            {
                _gameState.DeadBlocks.RemoveAll(b => b.YPosition != -10);
                _running = true;
            }
        }

        private void AskToSeedDatabase()
        {
            var result = MessageBox.Show("Seed Database?", "Seed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _repository.Seed(_gameState);
            }
        }

        private List<int> GetFullRows()
        {
            var gameLength = 19;
            var result = new List<int>();

            for (var y = gameLength; y > 0; y--)
            {
                if (_gameState.DeadBlocks.Where(b => b.YPosition == y).ToList().Count == 10)
                {
                    result.Add(y);
                }
            }

            return result;
        }

        private void BlowRow(int row)
        {
            _gameState.DeadBlocks.RemoveAll(b => b.YPosition == row);

            foreach (var block in _gameState.DeadBlocks)
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
                foreach (var block in _gameState.ActiveShape.GetBlocks())
                {
                    _gameState.DeadBlocks.Add(block);
                }

                GetRandomShape();
            }

            IsGameOver();

            GetPointsForBlownRow();

            Update();

            //var fullRows = GetFullRows();
            //if (fullRows.Count > 0)
            //{

            //    fullRows.ForEach(BlowRow);
            //}
            //IsGameRunning();
        }

        private long GetPointsForBlownRow()
        {
            var fullRows = GetFullRows();
            if (fullRows.Count > 0)
            {
                if (fullRows.Count == 1)
                {
                    _gameState.Score += 40;
                }
                else if (fullRows.Count == 2)
                {
                    _gameState.Score += 100;
                }
                else if (fullRows.Count == 3)
                {
                    _gameState.Score += 300;
                }
                else if (fullRows.Count == 4)
                {
                    _gameState.Score += 1200;
                }
                fullRows.ForEach(BlowRow);
            }

            return _gameState.Score;
        }
    }
}
