using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BMPRozbor
{
    class BMP
    {
        public byte[] byteArray;
        public BMP(byte[] input)
        {
            byteArray = input;
        }
        public string BfType()
        {
            return Convert.ToString(Convert.ToChar(byteArray[0])) + Convert.ToString(Convert.ToChar(byteArray[1]));//ASCII řetězce "BM"
        }
        public int BfSize()
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 2, 4)); //Tyto 4 bajty určují celkovou velikost souboru s obrazovými údaji.

        }
        public int BfOffBits()
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 10, 4));//Posun struktury BMP File Header od začátku vlastních obrazových dat
        }
        public int BiSize()
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 14, 4)); //Tato položka specifikuje celkovou velikost datové struktury Bitmap Information.
        }
        public int BiWidth()
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 18, 4));  //Tato položka udává šířku obrazu zadávanou v pixelech.
        }
        public int BiHeight()
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 22, 4)); //Tato položka udává výšku obrazu zadávanou taktéž v pixelech

        }
        public int BiPlanes()
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 26, 2)); //V této položce je zadaný počet bitových rovin pro výstupní zařízení.V BMP, jakožto formátu nezávislého na zařízení, je zde vždy hodnota 1
        }
        public int BiBitCount() 
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 28, 2)); //Tato položka udává počet bitů na pixel. V BMP jsou povoleny pouze hodnoty 1, 4, 8, 16, 24 a 32.
        }
        public int BiCompression()
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 30, 4)); //Tato položka určuje typ komprese použitého pro uložení obrazových dat. V BMP jsou povoleny pouze hodnoty 0, 1, 2 a 3.
        }
        public int BiSizeImage() 
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 34, 4)); //Tato položka udává velikost obrazových dat v bajtech. Pokud je hodnota 0, pak je velikost obrazových dat určena způsobem, který je popsán v této stránce.
        }
        public int BiXPelsPerMeter()
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 38, 4)); //Udává horizontální rozlišení výstupního zařízení v pixelech na metr. Tato hodnota může být použita například pro výběr obrazu ze skupiny obrazů, který nejlépe odpovídá rozlišení daného výstupního zařízení. Většina aplikací však nemá potřebné informace o výstupním zařízení, a proto do této položky vkládá hodnotu 0.
        }
        public int BiYPelsPerMeter() 
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 42, 4)); //dává vertikální rozlišení výstupního zařízení v pixelech na metr.Opět, jako u předchozí položky, zde většina programů zapisuje hodnotu 0.
        }
        public int BiClrUsed() 
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 46, 4)); //Udává celkový počet barev, které jsou použité v dané bitmapě.Jestliže je tato hodnota nastavena na nulu, znamená to, že bitmapa používá maximální počet barev.Tento počet lze jednoduše zjistit z položky biBitCount. Nenulová hodnota může být použita například při optimalizacích zobrazování.
        }
        public int BiClrImportant() 
        {
            return ByteArrayToWholeValue(SubArray(byteArray, 50, 4));//dává počet barev, které jsou důležité pro vykreslení bitmapy.Pokud je tato hodnota nulová, jsou všechny barvy důležité.Tento údaj je používán při zobrazování na zařízeních, které mají omezený počet současně zobrazitelných barev. Ovladač displeje může upravit systémovou paletu tak, aby zobrazil daný obrázek co nejvěrněji.Také je vhodné upravit paletu metodou seřazení jednotlivých barev podle důležitosti
        }
        public int ScanlineDoplnek()
        {
            decimal nasobek = Convert.ToDecimal(ByteArrayToWholeValue(SubArray(byteArray, 28, 2)) * ByteArrayToWholeValue(SubArray(byteArray, 18, 4)));
            return Convert.ToInt32((Math.Ceiling( nasobek / 32) * 32 - nasobek));
        }




        public T[] SubArray<T>(T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public int ByteArrayToWholeValue(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            for (int i = ba.Length - 1; i >= 0; i--)
            {
                hex.AppendFormat("{0:x2}", ba[i]);
            }
            return int.Parse(hex.ToString(), System.Globalization.NumberStyles.HexNumber);
        }
        public string IntToBinary(int vstup)
        {
            string vystup = "";
            for (int i = 128; i > 0; i /= 2)
            {
                if (vstup - i >= 0)
                {
                    vstup -= i;
                    vystup += 1;
                }
                else
                {
                    vystup += 0;
                }
            }
            return vystup;
        }

    }
}
