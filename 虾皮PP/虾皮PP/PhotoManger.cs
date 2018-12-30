using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 虾皮PP
{
    class PhotoManger
    {

        //顺时针旋转图片
        public Bitmap rotPicClo(Bitmap tempmap)
        {
            int Height = tempmap.Height;
            int Width = tempmap.Width;
            Bitmap bitmap = new Bitmap(Height, Width, PixelFormat.Format32bppArgb);
            Bitmap MyBitmap = tempmap;

            BitmapData oldData = tempmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData newData = bitmap.LockBits(new Rectangle(0, 0, Height, Width), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* pin = (byte*)oldData.Scan0.ToPointer();
                byte* pout = (byte*)newData.Scan0.ToPointer();
                for (int y = 0; y < oldData.Height; y++)
                {
                    pout = pout + (newData.Width - 1 - y) * 4;
                    for (int x = 0; x < oldData.Width; x++)
                    {
                        for (int i = 0; i < 4; i++)
                            pout[i] = pin[i];
                        pin = pin + 4;
                        pout = pout + newData.Stride;
                    }
                    pout = (byte*)(newData.Scan0.ToPointer());
                }
                bitmap.UnlockBits(newData);
                MyBitmap.UnlockBits(oldData);
                return bitmap;
            }
        }
        //逆时针旋转图片
        public Bitmap rotPicUnClo(Bitmap tempmap)
        {
            int Height = tempmap.Height;
            int Width = tempmap.Width;
            Bitmap bitmap = new Bitmap(Height, Width, PixelFormat.Format32bppArgb);
            Bitmap MyBitmap = tempmap;

            BitmapData oldData = MyBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData newData = bitmap.LockBits(new Rectangle(0, 0, Height, Width), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* pin = (byte*)(oldData.Scan0.ToPointer());
                byte* pout = (byte*)(newData.Scan0.ToPointer());
                for (int y = 0; y < oldData.Height; y++)
                {
                    pout += y * 4 + (newData.Height - 1) * newData.Stride;
                    for (int x = 0; x < oldData.Width; x++)
                    {
                        for (int i = 0; i < 4; i++)
                            pout[i] = pin[i];
                        pin = pin + 4;
                        pout = pout - newData.Stride;
                    }
                    pout = (byte*)(newData.Scan0.ToPointer());
                }
                bitmap.UnlockBits(newData);
                MyBitmap.UnlockBits(oldData);
                return bitmap;
            }
        }
        //设置亮度值
        public Bitmap setBrightness(int Index, Bitmap tempmap)
        {
            int Height = tempmap.Height;
            int Width = tempmap.Width;
            Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            Bitmap MyBitmap = tempmap;

            BitmapData oldData = MyBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData newData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* pin = (byte*)(oldData.Scan0.ToPointer());
                byte* pout = (byte*)(newData.Scan0.ToPointer());
                for (int y = 0; y < oldData.Height; y++)
                {
                    for (int x = 0; x < oldData.Width; x++)
                    {
                        for (int i = 0; i < 3; i++)
                            pout[i] = (byte)Math.Max(0, Math.Min(pin[i] + Index, 255));
                        pin = pin + 3;
                        pout = pout + 3;
                    }
                    pin += oldData.Stride - oldData.Width * 3;
                    pout += newData.Stride - newData.Width * 3;
                }

                bitmap.UnlockBits(newData);
                MyBitmap.UnlockBits(oldData);
                return bitmap;
            }
        }



    }
}
