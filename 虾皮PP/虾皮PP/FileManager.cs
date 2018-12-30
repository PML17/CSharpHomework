using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
    class FileManager
    {
        //打开文件
        public string fileConvert()
        {
            OpenFileDialog filename = new OpenFileDialog
            {
                Filter = "All files(*.*)|*.*|png files(*.png)|*.png|jpg files(*.jpg)|*.jpg",
                FilterIndex = 3,
                RestoreDirectory = true
            };
            if (filename.ShowDialog() == DialogResult.OK)
            {
                string path = filename.FileName.ToString();
                string name = path.Substring(path.LastIndexOf("\\") + 1);
                Console.WriteLine("选择文件目录为:" + path);
                Console.WriteLine("选择文件名称为:" + path);
                return path;
            }
            return null;
        }
        //另存为
        public string fileSave(Bitmap bbb)
        {
            Bitmap bmpp = new Bitmap(bbb);
            SaveFileDialog filename = new SaveFileDialog
            {
                Filter = "All files(*.*)|*.*|png files(*.png)|*.png|jpg files(*.jpg)|*.jpg",
                FilterIndex = 3,
                RestoreDirectory = true
            };
            if (filename.ShowDialog() == DialogResult.OK)
            {
                string path = filename.FileName.ToString();
                bmpp.Save(path);
                MessageBox.Show("保存成功");
                return path;
            }
            return null;
        }
    }
}
