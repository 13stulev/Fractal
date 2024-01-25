using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals
{
    public partial class Form1 : Form
    {
        public float modifier = 1;
        public string rules = "";
        static void setRule(int n, ref string result)
        {
            result = "XF";
            for (int i = 0; i < n; i++)
            {
                result = result.Replace("X", "X+yF++yF-FX--FXFX-yF+");
                result = result.Replace("Y", "-FX+YFYF++YF+FX--FX-Y");
                result = result.Replace("y", "Y");
            }
        }
        
        public Form1()
        {
            InitializeComponent();
           
        }    
          private void Draw(object sender, EventArgs e)
          {
        
              Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        
              Pen blackPen = new Pen(Color.Black, 2);
        
              setRule(trackBar1.Value, ref rules);
        
              // Create points that define line.
              PointF point1 = new PointF(pictureBox1.Width - 700, pictureBox1.Height - 700);
              PointF point2 = new PointF(pictureBox1.Width - 700, pictureBox1.Height - 700);
              
              using (var graphics = Graphics.FromImage(bmp))
              {
                  int h = 6;
                  int angle = 0;
                  foreach (char c in rules)
                  {
                      switch (c)
                      {
                          case 'F':
                              point2.X = point2.X + (float)(h * Math.Cos(angle * Math.PI / 180));
                              point2.Y = point2.Y + (float)(h * Math.Sin(angle * Math.PI / 180));
                              graphics.DrawLine(blackPen, point1, point2);
                              point1.X = point2.X;
                              point1.Y = point2.Y;
                              break;
                          case '+':
                              angle += 60;
                              break;
                          case '-':
                              angle -= 60;
                              break;
                      }
                  }
                  
              }
              pictureBox1.Image = bmp;
          }
    }
}
