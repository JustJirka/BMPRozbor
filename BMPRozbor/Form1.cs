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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            string bfType = Convert.ToString(Convert.ToChar(byteArray[0])) +Convert.ToString(Convert.ToChar(byteArray[1]));//ASCII řetězce "BM"
            int bfSize = ByteArrayToWholeValue(SubArray(byteArray,2,4)); //Tyto 4 bajty určují celkovou velikost souboru s obrazovými údaji.
            //reserved 4 
            int bfOffBits = ByteArrayToWholeValue(SubArray(byteArray, 10, 4));//Posun struktury BMP File Header od začátku vlastních obrazových dat
            //14
            int biSize = ByteArrayToWholeValue(SubArray(byteArray, 14, 4)); //Tato položka specifikuje celkovou velikost datové struktury Bitmap Information.
            int biWidth = ByteArrayToWholeValue(SubArray(byteArray, 18, 4));  //Tato položka udává šířku obrazu zadávanou v pixelech.
            int biHeight = ByteArrayToWholeValue(SubArray(byteArray, 22, 4)); //Tato položka udává výšku obrazu zadávanou taktéž v pixelech
            int biPlanes = ByteArrayToWholeValue(SubArray(byteArray, 26, 2)); //V této položce je zadaný počet bitových rovin pro výstupní zařízení.V BMP, jakožto formátu nezávislého na zařízení, je zde vždy hodnota 1
            int biBitCount = ByteArrayToWholeValue(SubArray(byteArray, 28, 2)); //Tato položka udává počet bitů na pixel. V BMP jsou povoleny pouze hodnoty 1, 4, 8, 16, 24 a 32.
            int biCompression = ByteArrayToWholeValue(SubArray(byteArray, 30, 4)); //Tato položka určuje typ komprese použitého pro uložení obrazových dat. V BMP jsou povoleny pouze hodnoty 0, 1, 2 a 3.
            int biSizeImage = ByteArrayToWholeValue(SubArray(byteArray, 34, 4)); //Tato položka udává velikost obrazových dat v bajtech. Pokud je hodnota 0, pak je velikost obrazových dat určena způsobem, který je popsán v této stránce.
            int biXPelsPerMeter = ByteArrayToWholeValue(SubArray(byteArray, 38, 4)); //Udává horizontální rozlišení výstupního zařízení v pixelech na metr. Tato hodnota může být použita například pro výběr obrazu ze skupiny obrazů, který nejlépe odpovídá rozlišení daného výstupního zařízení. Většina aplikací však nemá potřebné informace o výstupním zařízení, a proto do této položky vkládá hodnotu 0.
            int biYPelsPerMeter = ByteArrayToWholeValue(SubArray(byteArray, 42, 4)); //dává vertikální rozlišení výstupního zařízení v pixelech na metr.Opět, jako u předchozí položky, zde většina programů zapisuje hodnotu 0.
            int biClrUsed = ByteArrayToWholeValue(SubArray(byteArray, 46, 4)); //Udává celkový počet barev, které jsou použité v dané bitmapě.Jestliže je tato hodnota nastavena na nulu, znamená to, že bitmapa používá maximální počet barev.Tento počet lze jednoduše zjistit z položky biBitCount. Nenulová hodnota může být použita například při optimalizacích zobrazování.
            int biClrImportant = ByteArrayToWholeValue(SubArray(byteArray, 50, 4));//dává počet barev, které jsou důležité pro vykreslení bitmapy.Pokud je tato hodnota nulová, jsou všechny barvy důležité.Tento údaj je používán při zobrazování na zařízeních, které mají omezený počet současně zobrazitelných barev. Ovladač displeje může upravit systémovou paletu tak, aby zobrazil daný obrázek co nejvěrněji.Také je vhodné upravit paletu metodou seřazení jednotlivých barev podle důležitosti
            
            txtBx_info.Text += "bfType: " + bfType + Environment.NewLine + "bfSize: " + bfSize+ Environment.NewLine + "bfOffBits: " + bfOffBits + Environment.NewLine + "biSize: " + biSize + Environment.NewLine + "biWidth: " + biWidth + Environment.NewLine + "biHeight: " + biHeight + Environment.NewLine + "biPlanes: " + biPlanes+ Environment.NewLine + "biBitCount: " + biBitCount + Environment.NewLine + "biCompression: " + biCompression + Environment.NewLine + "biSizeImage: " + biSizeImage + Environment.NewLine + "biXPelsPerMeter: " + biXPelsPerMeter + Environment.NewLine + "biYPelsPerMeter: " + biYPelsPerMeter+ Environment.NewLine + "biClrUsed: " + biClrUsed + Environment.NewLine + "biClrImportant: " + biClrImportant;
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
