using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ResizeImageFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseOrigin_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            txtOriginPath.Text = fbd.SelectedPath;
        }

        private void btnBrowseDestiny_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            txtDestinyPath.Text = fbd.SelectedPath;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
            string[] files = GetFilesFrom(txtOriginPath.Text, filters, false);

            //string[] files = Directory.GetFiles(txtOriginPath.Text);//, filters);

            foreach (string item in files)
            {
                using (var image = Image.FromFile(item))
                {
                    string fileName = Path.GetFileNameWithoutExtension(item);

                    Bitmap newImage = ImageProcessingUtility.ScaleImage(image, int.Parse(txtAncho.Text), int.Parse(txtAlto.Text));

                    newImage.Save(string.Format(@"{0}\{1}.bmp", txtDestinyPath.Text, fileName), ImageFormat.Bmp);
                }
            }

            MessageBox.Show("Proceso Terminado", "Redimensionador de imagenes", MessageBoxButtons.OK);
        }

        public String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public static class ImageProcessingUtility
    {
        /// <summary>
        /// Scales an image proportionally.  Returns a bitmap.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        static public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }
    }
}
