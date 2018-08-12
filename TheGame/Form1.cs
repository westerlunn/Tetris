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

        public bool[,] ShapeGrid = new bool[3,3]
        {
            {false, true, false},
            {false, false, false},
            {false, true, false }
        };


        //public Boolean[,] Grid = new bool[,]
        //    {
        //    {0, 0} = true,
        //};

public Form1() : base(1000)
        {
            Shapes.Add(new ShapeI(0, 0, ShapeRotation.Zero)); //ShapeType.I, 
            //Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Ninety, 0, 0));
        }

        protected override void UpdateGame()
        {
            foreach (var shape in Shapes)
            {
                if (shape.YPosition < 18)
                {
                shape.YPosition++;

                }
            }
        }

        protected override void Render(IRender render)
        {
            //foreach (var shape in Shapes)
            //{
            //    shape.Draw(render);
            //}
            

            var boolArray = new[,]
            {
                {true, false},
                {false, true}
            };

            var newBool = boolArray[1, 1];

            for (var y = 0; y < boolArray.GetLength(1); y++)
            {
                for (var x = 0; x < boolArray.GetLength(0); x++)
                {
                    if (boolArray[x, y])
                    {
                        render.Draw(x, y, ShapeColor.Orange);
                    }
                }
            }

            //throw new NotImplementedException();
        }

        protected override void Rotate()
        {
            foreach (var shape in Shapes)
            {
                if(shape is RotatableShape rotatableShape)
                {
                    rotatableShape.Rotate();
                }
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
            Shapes.Add(new ShapeI(0, 0, ShapeRotation.Ninety));
            //Shapes.Add(new Shape(ShapeType.I, ShapeRotation.Zero, 0, 0));
        }
    }
}
