using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PP;
using 虾皮PP;

namespace PP
{
    public partial class PP : Form
    {
        int[][] location = new int[10][];

        AccessJson ai = new AccessJson();
        private string path;
        private static FileManager fileTrans = new FileManager();
        private string filepath;
        private static Bitmap firstBitmap;
        private Bitmap bitmap;
        private static PhotoManger photomanger = new PhotoManger();
        private string jsontext = null;
        private static Gauss gauss = new Gauss();
        private int facenum = 0;
        private string text;


        public  PP()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)//打开图片
        {
            //获得选中的文件的路径
            filepath = fileTrans.fileConvert();
            label9.Text = "人数：";
            textBox2.Text = filepath;
            try
            {
                //创建两个bitmap变量来读取文件
                System.Drawing.Bitmap bmp = new Bitmap(filepath);
                Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppRgb);
                Graphics draw = Graphics.FromImage(bmp2);
                draw.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
                //读取bmp2到picturebox 
                pictureBox1.Image = bmp2;
                //设定返回与还原所需图源
                bitmap = (Bitmap)(pictureBox1.Image.Clone());
                firstBitmap = (Bitmap)(pictureBox1.Image.Clone());
                //释放bmp文件资源
                draw.Dispose();
                bmp.Dispose();
            }
            catch (Exception) { }
        }


        Point start; //画框的起始点
        Point end;//画框的结束点<br>
        bool blnDraw =false;//判断是否绘制<br>
        Rectangle rect;
        Rectangle[] rect2=new Rectangle[10];
        int px;
        int py;
        int sx;
        int sy;


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            pictureBox1.Invalidate();
            blnDraw = true;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDraw)
            {
                
                if (e.Button != MouseButtons.Left)//判断是否按下左键
                    return;
                Point tempEndPoint = e.Location; //记录框的位置和大小
                px = Math.Min(start.X, tempEndPoint.X);
                py = Math.Min(start.Y, tempEndPoint.Y);
                sx = Math.Abs(start.X - tempEndPoint.X);
                sy = Math.Abs(start.Y - tempEndPoint.Y);
                rect.Location = new Point(px,py);
                rect.Size = new Size(sx,sy);
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
     //       blnDraw = false; //结束绘制
        }
        
        //高斯模糊
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (emptyPicBoxCheck())
            {
                label2.Text = Convert.ToString(trackBar1.Value);
                if (rect.IsEmpty)
                {
                    bitmap= gauss.GaussianFilt(bitmap, trackBar1.Value, 0, 0, bitmap.Width, bitmap.Height);
                    pictureBox1.Image = bitmap;
                    bitmap = bitmap;
                }
                else
                    bitmap = gauss.GaussianFilt(bitmap, trackBar1.Value, px, py, sx, sy);
                    pictureBox1.Image = bitmap;
                    bitmap = bitmap;
            }
            rect.Width = 0;
            rect.Height = 0;
        }



        //旋转即使未保存也会储存进度
        private void storeProcess()
        {
            pictureBox1.Image = bitmap;
        }

        //顺时针旋转
        private void button1_Click(object sender, EventArgs e)
        {
            if (emptyPicBoxCheck())
            {
                bitmap = photomanger.rotPicClo(bitmap);
                storeProcess();
            }
        }
        //逆时针旋转
        private void button2_Click(object sender, EventArgs e)
        {
            if (emptyPicBoxCheck())
            {
                bitmap = photomanger.rotPicUnClo(bitmap);
                storeProcess();
            }
        }
        //裁剪
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (rect.IsEmpty)
            {
                MessageBox.Show("还未选定区域");
            }
            else
            {
                Bitmap b = new Bitmap(sx, sy);
                for (int i = 0; i < bitmap.Width; i++)
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        if (i > px && i < px + sx && j > py  && j < py + sy )
                        {

                            Color fColor = bitmap.GetPixel(i,j);
                            b.SetPixel(i-px, j-py, fColor);
                        }

                    }
                pictureBox1.Image = b;
                bitmap = b;
                rect.Width = 0;
                rect.Height = 0;
            }
        }

        //保存
        private void button5_Click(object sender, EventArgs e)
        {
            fileTrans.fileSave(bitmap);
        }
        //撤销
        private void button6_Click(object sender, EventArgs e)
        {
            bitmap.Dispose();
            bitmap = new Bitmap(firstBitmap.Width,firstBitmap.Height);
            for (int i = 0; i < firstBitmap.Width; i++)
            {
                for (int j = 0; j < firstBitmap.Height; j++)
                {
                    Color c = firstBitmap.GetPixel(i, j);
                    bitmap.SetPixel(i, j,c);
                }
            }
            pictureBox1.Image = bitmap;
            label9.Text = "人数：";
        }
        //显示颜值分数
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //保存图片
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("保存将覆盖原图，你确定么？","保存文件", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                //确定按钮的方法
                pictureBox1.Image.Save(filepath);
            }

            

        }
        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileTrans.fileSave(bitmap);
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bitmap = firstBitmap;
            pictureBox1.Image = bitmap;
            label9.Text = "人数：";
        }

        private void 裁剪大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(sx, sy);
            if (rect.IsEmpty)
            {
                MessageBox.Show("还未选定区域");
            }
            else
            {
                for (int i = 0; i < bitmap.Width; i++)
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        if (i > px && i < px + sx && j > py && j < py + sy)
                        {

                            Color fColor = bitmap.GetPixel(i, j);
                            b.SetPixel(i - px, j - py, fColor);
                        }

                    }
                pictureBox1.Image = b;
                bitmap = b;
            }
        }

        private void 旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (emptyPicBoxCheck())
            {
                bitmap = photomanger.rotPicClo(bitmap);
                storeProcess();
            }
        }

        private void 逆时针旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (emptyPicBoxCheck())
            {
                bitmap = photomanger.rotPicUnClo(bitmap);
                storeProcess();
            }
        }

        private void 高斯模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (emptyPicBoxCheck())
            {
                label2.Text = Convert.ToString(trackBar1.Value);
                if (rect.IsEmpty)
                {
                    bitmap = gauss.GaussianFilt(bitmap, trackBar1.Value, 0, 0, bitmap.Width, bitmap.Height);
                    pictureBox1.Image = bitmap;
                    bitmap = bitmap;
                }
                else
                    bitmap = gauss.GaussianFilt(bitmap, trackBar1.Value, px, py, sx, sy);
                pictureBox1.Image = bitmap;
                bitmap = bitmap;
            }
            rect.Width = 0;
            rect.Height = 0;
        }


        private void 亮度ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 马赛克ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (emptyPicBoxCheck())
            {
                label4.Text = Convert.ToString(trackBar2.Value);


                if (rect.IsEmpty)
                {
                    for (int heightOfffset = 0; heightOfffset < bitmap.Height; heightOfffset += trackBar2.Value)
                    {
                        for (int widthOffset = 0; widthOffset < bitmap.Width; widthOffset += trackBar2.Value)
                        {
                            int avgR = 0, avgG = 0, avgB = 0;
                            int blurPixelCount = 0;

                            for (int x = widthOffset; (x < widthOffset + trackBar2.Value && x < bitmap.Width); x++)
                            {
                                for (int y = heightOfffset; (y < heightOfffset + trackBar2.Value && y < bitmap.Height); y++)
                                {
                                    System.Drawing.Color pixel = bitmap.GetPixel(x, y);

                                    avgR += pixel.R;
                                    avgG += pixel.G;
                                    avgB += pixel.B;

                                    blurPixelCount++;
                                }
                            }

                            // 计算范围平均

                            avgR = avgR / blurPixelCount;
                            avgG = avgG / blurPixelCount;
                            avgB = avgB / blurPixelCount;

                            // 所有范围内都设定此值
                            for (int x = widthOffset; (x < widthOffset + trackBar2.Value && x < bitmap.Width); x++)
                            {
                                for (int y = heightOfffset; (y < heightOfffset + trackBar2.Value && y < bitmap.Height); y++)
                                {

                                    System.Drawing.Color newColor = System.Drawing.Color.FromArgb(avgR, avgG, avgB);
                                    bitmap.SetPixel(x, y, newColor);
                                }
                            }
                        }
                    }
                    pictureBox1.Image = bitmap;

                }
                else
                {
                    for (int heightOfffset = 0; heightOfffset < bitmap.Height; heightOfffset++)
                    {
                        for (int widthOffset = 0; widthOffset < bitmap.Width; widthOffset++)
                        {
                            if (heightOfffset >= py && heightOfffset <= py + sy && widthOffset >= px && widthOffset <= px + sx)
                            {
                                for (heightOfffset = py; heightOfffset < py + sy; heightOfffset += trackBar2.Value)
                                {
                                    for (widthOffset = px; widthOffset < px + sx; widthOffset += trackBar2.Value)
                                    {
                                        int avgR = 0, avgG = 0, avgB = 0;
                                        int blurPixelCount = 0;

                                        for (int x = widthOffset; (x < widthOffset + trackBar2.Value && x < bitmap.Width); x++)
                                        {
                                            for (int y = heightOfffset; (y < heightOfffset + trackBar2.Value && y < bitmap.Height); y++)
                                            {
                                                System.Drawing.Color pixel = bitmap.GetPixel(x, y);

                                                avgR += pixel.R;
                                                avgG += pixel.G;
                                                avgB += pixel.B;

                                                blurPixelCount++;
                                            }
                                        }

                                        // 计算范围平均

                                        avgR = avgR / blurPixelCount;
                                        avgG = avgG / blurPixelCount;
                                        avgB = avgB / blurPixelCount;

                                        // 所有范围内都设定此值
                                        for (int x = widthOffset; (x < widthOffset + trackBar2.Value && x < bitmap.Width); x++)
                                        {
                                            for (int y = heightOfffset; (y < heightOfffset + trackBar2.Value && y < bitmap.Height); y++)
                                            {

                                                System.Drawing.Color newColor = System.Drawing.Color.FromArgb(avgR, avgG, avgB);
                                                bitmap.SetPixel(x, y, newColor);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Color pixel2 = bitmap.GetPixel(widthOffset, heightOfffset);
                                Color newColor2 = pixel2;
                                bitmap.SetPixel(widthOffset, heightOfffset, newColor2);
                            }
                        }
                    }
                    pictureBox1.Image = bitmap;
                }

            }
        }

        //检查picturebox是否为空
        private bool emptyPicBoxCheck()
        {
            if (bitmap != null)
                return true;
            else
            {
                MessageBox.Show("请先打开一张图片");
                return false;
            }
        }
        //进入智能分析
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //将图片转换成BASE64编码
                Image bmp = pictureBox1.Image;
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);

                //显示数据

                jsontext = AccessJson.Detect(strbaser64);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ImgToBase64String 转换失败\nException:" + ex.Message);
            }

            //解析JSON数据
            RootObject people = JsonConvert.DeserializeObject<RootObject>(jsontext);
            facenum = Convert.ToInt32(people.result.face_num);

            
                //获取值
                text = "转换结果：";
                text += people.error_msg + "\r\n";
            //location存着每一个人脸的x,y坐标，长宽四个信息，二维数组
            for(int i=0; i<facenum; i++)
            {
                location[i] = new int[4] { Convert.ToInt32(Convert.ToSingle(people.result.face_list[i].location.left)),
                    Convert.ToInt32(Convert.ToSingle(people.result.face_list[i].location.top)) ,
                     Convert.ToInt32(Convert.ToSingle(people.result.face_list[i].location.width)),
                     Convert.ToInt32(Convert.ToSingle(people.result.face_list[i].location.height))
                };
                rect2[i].Location = new Point(location[i][0], location[i][1]);
                rect2[i].Size = new Size(location[i][2], location[i][3]);

            }



            text += "这是一张人脸的概率：";
                text += people.result.face_list[0].face_probability + "\r\n";

                text += "年龄：";
                text += people.result.face_list[0].age + "\r\n" ;

                text += "颜值：";
                text += people.result.face_list[0].beauty + "\r\n";

                text += "表情：";
                text += people.result.face_list[0].expression.probability + "概率是";
                string expression_type = people.result.face_list[0].expression.type;
                if (expression_type == "none") { expression_type = "冷漠脸"; }
                else if (expression_type == "smile") { expression_type = "微笑"; }
                else if (expression_type == "laugh") { expression_type = "大笑"; }
                else { expression_type = "都不知道你什么表情"; }
                text += expression_type + "\r\n" + "\r\n";

                //square: 正方形 triangle:三角形 oval: 椭圆 heart: 心形 round: 圆形
                text += "脸型：";
                text += people.result.face_list[0].face_shape.probability + "概率是";
                string faceShape = people.result.face_list[0].face_shape.type;
                if (faceShape == "square") { faceShape = "正方形"; }
                else if (faceShape == "triangle") { faceShape = "三角形"; }
                else if (faceShape == "oval") { faceShape = "椭圆"; }
                else if (faceShape == "heart") { faceShape = "心形"; }
                else if (faceShape == "round") { faceShape = "圆形"; }
                else { faceShape = "都不知道你什么头"; }
                text += faceShape + "\r\n" + "\r\n";

                //male:男性 female:女性
                text += "性别：";
                text += people.result.face_list[0].gender.probability + "概率是";
                string sex = people.result.face_list[0].gender.type;
                if (sex == "male") { sex = "男性"; }
                else if (sex == "female") { sex = "女性"; }
                else { sex = "都不知道你什么性别"; }
                text += sex + "\r\n" + "\r\n";

                //none:无眼镜，common:普通眼镜，sun:墨镜
                text += "眼镜类型：";
                text += people.result.face_list[0].glasses.probability + "概率是";
                string glasse = people.result.face_list[0].glasses.type;
                if (glasse == "none") { glasse = "无眼镜"; }
                else if (glasse == "common") { glasse = "普通眼镜"; }
                else if (glasse == "sun") { glasse = "墨镜"; }
                else { faceShape = "眼呢？"; }
                text += glasse + "\r\n" + "\r\n";

                //yellow: 黄种人 white: 白种人 black:黑种人 arabs: 阿拉伯人
                text += "种族：";
                text += people.result.face_list[0].race.probability + "概率是";
                string race = people.result.face_list[0].race.type;
                if (race == "yellow") { race = "黄种人"; }
                else if (race == "white") { race = "白种人"; }
                else if (race == "black") { race = "黑种人"; }
                else if (race == "arabs") { race = "阿拉伯人"; }
                else { race = "人呢？"; }
                text += race + "\r\n" + "\r\n";

            textBox2.Text = "已成功进入智能分析";

            
            }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (blnDraw)
            {
                if (pictureBox1.Image != null)
                {
                    if (rect != null && rect.Width > 0 && rect.Height > 0)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Yellow, 2), rect);//重新绘制颜色为黄色
                    }
                }
            }
        }

        private void 变暗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap = photomanger.setBrightness(-10, bitmap);
                storeProcess();

            }
        }

         private void 变亮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap = photomanger.setBrightness(10, bitmap);
                storeProcess();
            }

        }
        //圣诞帽
        protected void btn_WaterMark_Click(object sender, EventArgs e)
        {
            
            
            Image bmp233 = Image.FromFile(@"../debug/1.png");
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for(int i=0;i<facenum;i++)
                {
                    g.DrawImage(bmp233, new Rectangle(location[i][0] - 6,
                                 location[i][1] - location[i][3] + 6,
                                 Convert.ToInt32(location[i][2] / 1.1),
                                 Convert.ToInt32(location[i][3] / 1.8)),
                                 0, 0, bmp233.Width, bmp233.Height, GraphicsUnit.Pixel);
                }
            }
            pictureBox1.Image = bitmap;
           
            
        }

        //马赛克
        
        public void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {

            if (emptyPicBoxCheck())
            {
                label4.Text = Convert.ToString(trackBar2.Value);
               

                if (rect.IsEmpty)
                {
                    for (int heightOfffset = 0; heightOfffset < bitmap.Height; heightOfffset += trackBar2.Value)
                    {
                        for (int widthOffset = 0; widthOffset < bitmap.Width; widthOffset += trackBar2.Value)
                        {
                            int avgR = 0, avgG = 0, avgB = 0;
                            int blurPixelCount = 0;

                            for (int x = widthOffset; (x < widthOffset + trackBar2.Value && x < bitmap.Width); x++)
                            {
                                for (int y = heightOfffset; (y < heightOfffset + trackBar2.Value && y < bitmap.Height); y++)
                                {
                                    System.Drawing.Color pixel = bitmap.GetPixel(x, y);

                                    avgR += pixel.R;
                                    avgG += pixel.G;
                                    avgB += pixel.B;

                                    blurPixelCount++;
                                }
                            }

                            // 计算范围平均

                            avgR = avgR / blurPixelCount;
                            avgG = avgG / blurPixelCount;
                            avgB = avgB / blurPixelCount;

                            // 所有范围内都设定此值
                            for (int x = widthOffset; (x < widthOffset + trackBar2.Value && x < bitmap.Width); x++)
                            {
                                for (int y = heightOfffset; (y < heightOfffset + trackBar2.Value && y < bitmap.Height); y++)
                                {

                                    System.Drawing.Color newColor = System.Drawing.Color.FromArgb(avgR, avgG, avgB);
                                    bitmap.SetPixel(x, y, newColor);
                                }
                            }
                        }
                    }
                    pictureBox1.Image = bitmap;
                
                }
                else
                {
                    for (int heightOfffset = 0; heightOfffset < bitmap.Height; heightOfffset++)
                    {
                        for (int widthOffset = 0; widthOffset < bitmap.Width; widthOffset++)
                        {
                            if (heightOfffset >= py && heightOfffset <= py + sy && widthOffset >= px && widthOffset <= px + sx)
                            {
                                for (heightOfffset = py; heightOfffset < py + sy; heightOfffset += trackBar2.Value)
                                {
                                    for (widthOffset = px; widthOffset < px + sx; widthOffset += trackBar2.Value)
                                    {
                                        int avgR = 0, avgG = 0, avgB = 0;
                                        int blurPixelCount = 0;

                                        for (int x = widthOffset; (x < widthOffset + trackBar2.Value && x < bitmap.Width); x++)
                                        {
                                            for (int y = heightOfffset; (y < heightOfffset + trackBar2.Value && y < bitmap.Height); y++)
                                            {
                                                System.Drawing.Color pixel = bitmap.GetPixel(x, y);

                                                avgR += pixel.R;
                                                avgG += pixel.G;
                                                avgB += pixel.B;

                                                blurPixelCount++;
                                            }
                                        }

                                        // 计算范围平均

                                        avgR = avgR / blurPixelCount;
                                        avgG = avgG / blurPixelCount;
                                        avgB = avgB / blurPixelCount;

                                        // 所有范围内都设定此值
                                        for (int x = widthOffset; (x < widthOffset + trackBar2.Value && x < bitmap.Width); x++)
                                        {
                                            for (int y = heightOfffset; (y < heightOfffset + trackBar2.Value && y < bitmap.Height); y++)
                                            {

                                                System.Drawing.Color newColor = System.Drawing.Color.FromArgb(avgR, avgG, avgB);
                                                bitmap.SetPixel(x, y, newColor);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Color pixel2 = bitmap.GetPixel(widthOffset, heightOfffset);
                                Color newColor2 = pixel2;
                                bitmap.SetPixel(widthOffset, heightOfffset, newColor2);
                            }
                        }
                    }

                    pictureBox1.Image = bitmap;

                }

            }
            rect.Width = 0;
            rect.Height = 0;
        }
        //人脸识别
        private void button9_Click(object sender, EventArgs e)
        {
            if (facenum == 1)
            {
                textBox2.Text = text;
            }
            else
            {
                textBox2.Text = "画面中不止一个人脸或没有人脸！";
            }
        }
        //人数分析
        private void button10_Click(object sender, EventArgs e)
        {
            label9.Text = "人数：" + facenum;
            Image imgSrc = bitmap;
            using (Graphics g = Graphics.FromImage(imgSrc))
            {
                for (int i = 0; i < facenum; i++)
                {
                    g.DrawRectangle(new Pen(Color.Red, 2), rect2[i]);
                }
            }
            pictureBox1.Image = imgSrc;

        }
        //智能马赛克
        private void button11_Click(object sender, EventArgs e)
        {
            //遍历人脸
            for (int i = 0; i < facenum; i++)
            {
                //遍历整张图片长宽
                for (int heightOfffset = 0; heightOfffset < bitmap.Height; heightOfffset++)
                {
                    for (int widthOffset = 0; widthOffset < bitmap.Width; widthOffset++)
                    {
                        //判断范围
                        if (heightOfffset >= location[i][1] && heightOfffset <= location[i][1] + location[i][3] && widthOffset >= location[i][0] && widthOffset <= location[i][0] + location[i][2])
                        {
                            //遍历范围内像素
                            for (heightOfffset = location[i][1]; heightOfffset < location[i][1] + location[i][3]; heightOfffset += 5)
                            {
                                for (widthOffset = location[i][0]; widthOffset < location[i][0] + location[i][2]; widthOffset += 5)
                                {
                                    int avgR = 0, avgG = 0, avgB = 0;
                                    int blurPixelCount = 0;
                                    //遍历每个马赛克方格
                                    for (int x = widthOffset; (x < widthOffset + 5 && x < bitmap.Width); x++)
                                    {
                                        for (int y = heightOfffset; (y < heightOfffset + 5 && y < bitmap.Height); y++)
                                        {
                                            System.Drawing.Color pixel = bitmap.GetPixel(x, y);

                                            avgR += pixel.R;
                                            avgG += pixel.G;
                                            avgB += pixel.B;

                                            blurPixelCount++;
                                        }
                                    }

                                    // 计算范围平均

                                    avgR = avgR / blurPixelCount;
                                    avgG = avgG / blurPixelCount;
                                    avgB = avgB / blurPixelCount;

                                    // 所有范围内都设定此值
                                    for (int x = widthOffset; (x < widthOffset + 5 && x < bitmap.Width); x++)
                                    {
                                        for (int y = heightOfffset; (y < heightOfffset + 5 && y < bitmap.Height); y++)
                                        {

                                            System.Drawing.Color newColor = System.Drawing.Color.FromArgb(avgR, avgG, avgB);
                                            bitmap.SetPixel(x, y, newColor);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Color pixel2 = bitmap.GetPixel(widthOffset, heightOfffset);
                            Color newColor2 = pixel2;
                            bitmap.SetPixel(widthOffset, heightOfffset, newColor2);
                        }
                    }
                }

               
            }
            pictureBox1.Image = bitmap;
            bitmap = bitmap;
            rect.Width = 0;
            rect.Height = 0;
        }



        private void button12_Click(object sender, EventArgs e)
        {
            rect.Width = 0;
            rect.Height = 0;
            pictureBox1.Image = bitmap;
        }
    }
    }

    

