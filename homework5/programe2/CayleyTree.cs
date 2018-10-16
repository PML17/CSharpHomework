using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace programe2
{
    class CayleyTree

    {
            public double Th1 { get; set; }                 //子树1的倾角 
            public double Th2 { get; set; }                 //子树2的倾角 
            public double Per1 { get; set; }                //子树1的长度衰减量 
            public double Per2 { get; set; }                //子树2的长度衰减量 
            public double RootHeight { get; set; }          //根树1的长度 
            public int LayerNum { get; set; }               //数的层数 
            public double K { get; set; }                      //两子树的位置系数 


            public CayleyTree()
            {
                Th1 = 30 * Math.PI / 180;
                Th2 = 20 * Math.PI / 180;
                Per1 = 0.6;
                Per2 = 0.7;
                RootHeight = 100;
                LayerNum = 10;
                K = 1;
            }
            public void Draw(int x0, int y0, Graphics graphics)
            {
                DrawCayleyTree(LayerNum, x0, y0, RootHeight, -Math.PI / 2, graphics);
            }
            private void DrawCayleyTree(int n, double x0, double y0, double leng, double th, Graphics graphics)
            {
                if (n == 0) return;
                double x1 = x0 + leng * Math.Cos(th);
                double y1 = y0 + leng * Math.Sin(th);
                double x2 = x0 + leng * Math.Cos(th) * K;
                double y2 = y0 + leng * Math.Sin(th) * K;
                graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x2, (int)y2);
                DrawCayleyTree(n - 1, x1, y1, Per1 * leng, th + Th1, graphics);
                DrawCayleyTree(n - 1, x2, y2, Per2 * leng, th - Th2, graphics);
            }

        }
    }

