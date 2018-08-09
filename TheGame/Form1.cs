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


    public partial class Form1 : GameBoard
    {
        public List<Shape> Shapes { get; } = new List<Shape>();

        public Form1() : base(1000)
        {
            Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Zero, 0, 0));
            //Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Ninety, 0, 0));
        }

        protected override void UpdateGame()
        {
            foreach (var shape in Shapes)
            {
                shape.YPosition++;
            }
        }

        protected override void Render(IRender render)
        {
            foreach (var shape in Shapes)
            {
                shape.Draw(render);
            }

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
            CreateShape();
            //throw new NotImplementedException("Drop");
        }

        protected override void MoveLeft()
        {
            foreach (var shape in Shapes)
            {
                shape.XPosition--;
            }
        }

        protected override void MoveRight()
        {
            foreach (var shape in Shapes)
            {
                shape.XPosition++;
            }
            //throw new NotImplementedException("Right");
        }

        protected void CreateShape()
        {
            Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Zero, 0, 0));
        }
    }
}
