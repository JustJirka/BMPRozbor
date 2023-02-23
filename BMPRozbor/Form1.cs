using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPRozbor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()!= DialogResult.OK) return;
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            var memoryStream = new MemoryStream();
            // Use the .CopyTo() method and write current filestream to memory stream
            fs.CopyTo(memoryStream);
            // Convert Stream To Array
            byte[] byteArray = memoryStream.ToArray();
            //get bmp header
            byte[] bmpHeader = new byte[14];
            Array.Copy(byteArray, 0, bmpHeader, 0, 14);
            //get bmp info
            byte[] bmpInfo = new byte[40];
            Array.Copy(byteArray, 14, bmpInfo, 0, 40);
            
            
        }
    }
}
