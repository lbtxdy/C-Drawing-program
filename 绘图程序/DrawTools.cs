
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace 绘图程序
{
  
    /// 绘图工具包括直线，矩形，铅笔，圆形，橡皮
    
    class DrawTools
    {
        public Graphics DrawTools_Graphics;//目标绘图板
        private Pen p;
        private Image orginalImg;//原始画布，用来保存已完成的绘图过程
        private Color drawColor = Color.Black;//绘图颜色
        private Graphics newgraphics;//中间画板
        private Image finishingImg;//中间画布，用来保存绘图过程中的痕迹

        
        /// 绘图颜色
       
        public Color DrawColor
        {
            get { return drawColor; }
            set
            {
                drawColor = value;
                p.Color = value;
            }
        }

        
        /// 原始画布
       
        public Image OrginalImg
        {
            get { return orginalImg; }
            set
            {
                finishingImg = (Image)value.Clone();
                orginalImg = (Image)value.Clone();
            }
        }


       
        /// 表示是否开始绘图
       
        public bool startDraw = false;

        
        /// 绘图起点
       
        public PointF startPointF;

     
        /// 初始化绘图工具
        public DrawTools(Graphics g, Color c, Image img)
        {
            DrawTools_Graphics = g;
            drawColor = c;
            p = new Pen(c, 1);
            finishingImg = (Image)img.Clone();
            orginalImg = (Image)img.Clone();
        }

      
        /// 绘制直线，矩形，圆形

        public void Draw(MouseEventArgs e, string sType)
        {
            if (startDraw)
            {
                Image img = (Image)orginalImg.Clone();//为防止直接改写原始画布，我们定义一个新的image去得到原始画布
                newgraphics = Graphics.FromImage(img);//实例化中间画板
                switch (sType)
                {
                    case "Line":
                        {//画直线
                            newgraphics.DrawLine(p, startPointF, new PointF(e.X, e.Y)); break;
                        }
                    case "Rect":
                        {//画矩形
                            float width = Math.Abs(e.X - startPointF.X);//确定矩形的宽
                            float heigth = Math.Abs(e.Y - startPointF.Y);//确定矩形的高
                            PointF rectStartPointF = startPointF;
                            if (e.X < startPointF.X)
                            {
                                rectStartPointF.X = e.X;
                            }
                            if (e.Y < startPointF.Y)
                            {
                                rectStartPointF.Y = e.Y;
                            }
                            newgraphics.DrawRectangle(p, rectStartPointF.X, rectStartPointF.Y, width, heigth);
                            break;
                        }
                    case "Circle":
                        {//画圆形
                            newgraphics.DrawEllipse(p, startPointF.X, startPointF.Y, e.X - startPointF.X, e.Y - startPointF.Y); break;
                        }
                    case "FillRect":
                        {//画实心矩形
                            float width = Math.Abs(e.X - startPointF.X);//确定矩形的宽
                            float heigth = Math.Abs(e.Y - startPointF.Y);//确定矩形的高
                            PointF rectStartPointF = startPointF;
                            if (e.X < startPointF.X)
                            {
                                rectStartPointF.X = e.X;
                            }
                            if (e.Y < startPointF.Y)
                            {
                                rectStartPointF.Y = e.Y;
                            }
                            newgraphics.FillRectangle(new SolidBrush(drawColor), rectStartPointF.X, rectStartPointF.Y, width, heigth);
                            break;
                        }
                    case "FillCircle":
                        {//画实心圆
                            newgraphics.FillEllipse(new SolidBrush(drawColor), startPointF.X, startPointF.Y, e.X - startPointF.X, e.Y - startPointF.Y); break;
                        }
                }
                newgraphics.Dispose();//绘图完毕释放中间画板所占资源
                newgraphics = Graphics.FromImage(finishingImg);//另建一个中间画板,画布为中间图片
                newgraphics.DrawImage(img, 0, 0);//将图片画到中间图片
                newgraphics.Dispose();
                DrawTools_Graphics.DrawImage(img, 0, 0);//将图片画到目标画板上
                img.Dispose();
            }

        }

        public void EndDraw()
        {
            startDraw = false;
            //为了让完成后的绘图过程保留下来，要将中间图片绘制到原始画布上
            newgraphics = Graphics.FromImage(orginalImg);
            newgraphics.DrawImage(finishingImg, 0, 0);
            newgraphics.Dispose();
        }

        
        /// 橡皮方法
       
        public void Eraser(MouseEventArgs e)
        {
            if (startDraw)
            {
                newgraphics = Graphics.FromImage(finishingImg);
                newgraphics.FillRectangle(new SolidBrush(Color.White), e.X, e.Y, 20, 20);
                newgraphics.Dispose();
                DrawTools_Graphics.DrawImage(finishingImg, 0, 0);
            }
        }

       
        /// 铅笔方法
       
        public void DrawDot(MouseEventArgs e)
        {
            if (startDraw)
            {
                newgraphics = Graphics.FromImage(finishingImg);
                PointF currentPointF = new PointF(e.X, e.Y);
                newgraphics.DrawLine(p, startPointF, currentPointF);
                startPointF = currentPointF;
                newgraphics.Dispose();
                DrawTools_Graphics.DrawImage(finishingImg, 0, 0);
            }
        }

        
        /// 清除变量，释放内存
     
        public void ClearVar()
        {
            DrawTools_Graphics.Dispose();
            finishingImg.Dispose();
            orginalImg.Dispose();
            p.Dispose();
        }

    }
}
