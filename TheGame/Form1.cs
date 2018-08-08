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
using Type = System.Type;

namespace TheGame
{


    public partial class Form1 : GameBoard
    {
        public List<Shape> Shapes { get; } = new List<Shape>();

        public delegate void GameUpdatedEventHandler(object source, EventArgs args);
        public event GameUpdatedEventHandler GameUpdated;

        protected virtual void OnGameUpdated()
        {
            if (GameUpdated != null)
            {
                GameUpdated(this, EventArgs.Empty);
            }
        }

        public Form1() : base(1000)
        {
            Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Zero, ShapeColor.Cyan, 0, 0));
            Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Ninety, ShapeColor.Red, 0, 0));
        }

        protected override void UpdateGame()
        {
            foreach (var shape in Shapes)
            {
                shape.YPosition++;
            }
        }

        protected void UpdateGame(IRender render)
        {
            MessageBox.Show("sda");
            //OnGameUpdated();
            //shape.YPosition++;
            //Render(shapeI);
            //shapeI.Draw(render);
            //UpdatePosition();
            //throw new NotImplementedException();
        }

        protected void UpdatePosition(IRender render, Shape shapeI)
        {
            MessageBox.Show("hej");
            shapeI.YPosition++;
            shapeI.Draw(render);
            UpdateGame();
        }

        protected void MoveDownInSpeedOfGame(object source, EventArgs args)
        {
            //shapeI.YPosition++;
        }
        protected override void Render(IRender render)
        {
            foreach (var shape in Shapes)
            {
                shape.Draw(render);
            }

            //var i = 10;
            //render.Draw(3, 3 + i, ShapeColor.Cyan);
            //render.Draw(3, 4 + i, ShapeColor.Cyan);
            //render.Draw(3, 5 + i, ShapeColor.Cyan);
            //render.Draw(3, 6 + i, ShapeColor.Cyan);

            //render.Draw(3, 0, ShapeColor.Cyan);
            //render.Draw(4, 0, ShapeColor.Cyan);
            //render.Draw(5, 0, ShapeColor.Cyan);
            //render.Draw(6, 0, ShapeColor.Cyan);

            //render.Draw(0, 1, ShapeColor.Orange);
            //render.Draw(1, 1, ShapeColor.Orange);
            //render.Draw(2, 1, ShapeColor.Orange);
            //render.Draw(2, 0, ShapeColor.Orange);

            //render.Draw(3, 8, ShapeColor.Blue);
            //render.Draw(3, 9, ShapeColor.Blue);
            //render.Draw(4, 9, ShapeColor.Blue);
            //render.Draw(5, 9, ShapeColor.Blue);
            
            //render.Draw(9,19, ShapeColor.Red);

            //var shapeI = new Shape(ShapeType.I, ShapeRotation.Zero, ShapeColor.Cyan, 0, 0);
            //var shapeI90 = new Shape(ShapeType.I, ShapeRotation.Ninety, ShapeColor.Cyan, 0, 0);
            //var shapeI180 = new Shape(ShapeType.I, ShapeRotation.OneEighty, ShapeColor.Cyan, 0, 0);
            //var shapeI270 = new Shape(ShapeType.I, ShapeRotation.TwoSeventy, ShapeColor.Cyan, 0, 0);
            //shapeI.XPosition++;
            //shapeI.YPosition++;
            //shapeI.Draw(render);
            //shapeI90.Draw(render);
            //shapeI180.Draw(render);
            //UpdatePosition(render, shapeI);
            //GameUpdated += MoveDownInSpeedOfGame;
            
            //shapeI270.Draw(render);
            //throw new NotImplementedException();
        }

        protected override void Rotate()
        {
            foreach (var shape in Shapes)
            {
                shape.Rotate();
            }
        }

        protected override void Drop()
        {
            throw new NotImplementedException("Drop");
        }

        protected override void MoveLeft()
        {
            
            throw new NotImplementedException("Left");
        }

        protected override void MoveRight()
        {
            var shape = new Shape();
            shape.XPosition++;
            //throw new NotImplementedException("Right");
        }
    }
}
