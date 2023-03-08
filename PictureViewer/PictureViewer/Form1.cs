using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class PictureViewer : System.Windows.Forms.Form
    {
        public PictureViewer()
        {
            InitializeComponent();
            // Allows for "Open with..."
            // File is args[1]
            string[] args = Environment.GetCommandLineArgs();

            this.Text = "Picture Viewer | " + "No file selected";

            // If a file has been specified
            if (args.Length > 1)
            {
                // Check if it is a valid file type and open it. Otherwise, no file selected.
                switch (Path.GetExtension(args[1]).ToLower())
                {
                    case ".jpg":
                    case ".bmp":
                    case ".png":
                    case ".jpeg":
                        this.Text = "Picture Viewer | " + args[1];
                        pictureBox1.Load(args[1]);
                        break;
                }
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog and load the selected image file to the picture box
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Open image and change window title
                this.Text = "Picture Viewer | " + openFileDialog1.FileName;
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the picture
            pictureBox1.Image = null;
            this.Text = "Picture Viewer | " + "No file selected";
        }
        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            // Close the form
            Close();
        }
        private void stretchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stretchCheckBox.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
    }
}
