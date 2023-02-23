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
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            var memoryStream = new MemoryStream();
            // Use the .CopyTo() method and write current filestream to memory stream
            fs.CopyTo(memoryStream);
            // Convert Stream To Array
            byte[] byteArray = memoryStream.ToArray();
            //Get file lenght
            int delkaSouboru = ByteArrayToWholeValue(SubArray(byteArray,2,4));
            int zacatekObrazku = ByteArrayToWholeValue(SubArray(byteArray, 10, 4));
            txtBx_info.Text += "Delka souboru: " + delkaSouboru + " byte"+ Environment.NewLine;
            txtBx_info.Text += "Zacatek obrazku: " + zacatekObrazku + Environment.NewLine;
        }
        public int ByteArrayToWholeValue(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            for (int i = ba.Length-1; i >=0 ; i--)
            {
                hex.AppendFormat("{0:x2}", ba[i]);
            }
            return int.Parse(hex.ToString(), System.Globalization.NumberStyles.HexNumber);
        }
        public T[] SubArray<T>(T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }
    }
}
