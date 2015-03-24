using System;
using System.Collections.Generic;
using System.Text;
using Com.SharpZebra.Printing;
using System.Drawing;
using System.IO;
using System.Globalization;

namespace Com.SharpZebra.Commands
{
    public partial class ZPLCommands
    {
        public static byte[] ClearPrinter(Printing.PrinterSettings settings)
        {
            //^MMT: Tear off Mode.  ^PRp,s,b: print speed (print, slew, backfeed) (2,4,5,6,8,9,10,11,12).  
            //~TA###: Tear off position (must be 3 digits).  ^LHx,y: Label home. ^SD##x: Set Darkness (00 to 30). ^PWx: Label width
            //^XA^MMT^PR4,12,12~TA000^LH0,12~SD19^PW750
            stringCounter = 0;
            printerSettings = settings;
            return Encoding.GetEncoding(850).GetBytes(string.Format("^XA^MMT^PR{0},12,12~TA{1:000}^LH{2},{3}~SD{4:00}^PW{5}", settings.PrintSpeed,
                settings.AlignTearOff, settings.AlignLeft, settings.AlignTop, settings.Darkness, settings.Width + settings.AlignLeft));
        }

        public static byte[] PrintBuffer(int copies)
        {
            return Encoding.GetEncoding(850).GetBytes(copies > 1 ? string.Format("^PQ{0}^XZ", copies) : "^XZ");
        }

        public static byte[] BarCodeWrite(int left, int top, int height, ElementDrawRotation rotation, Barcode barcode, bool readable, string barcodeData)
        {
            string encodedReadable = readable ? "Y" : "N";
            char encodedRotation = Rotation.ZPLRotationMap[(int)rotation];
            switch (barcode.Type)
            {
                case BarcodeType.CODE39_STD_EXT:
                    return Encoding.GetEncoding(850).GetBytes(string.Format("^FO{0},{1}^BY{2}^B3{3},,{4},{5}^FD{6}^FS", left, top,
                        barcode.BarWidthNarrow, encodedRotation, height, encodedReadable, barcodeData));
                case BarcodeType.CODE128_AUTO:
                    return Encoding.GetEncoding(850).GetBytes(string.Format("^FO{0},{1}^BY{2}^BC{3},{4},{5}^FD{6}^FS", left, top,
                        barcode.BarWidthNarrow, encodedRotation, height, encodedReadable, barcodeData));
                case BarcodeType.UPC_A:
                    return Encoding.GetEncoding(850).GetBytes(string.Format("^FO{0},{1}^BY{2}^BU{3},{4},{5}^FD{6}^FS", left, top,
                        barcode.BarWidthNarrow, encodedRotation, height, encodedReadable, barcodeData));
                case BarcodeType.EAN13:
                    return Encoding.GetEncoding(850).GetBytes(string.Format("^FO{0},{1}^BY{2}^BE{3},{4},{5}^FD{6}^FS", left, top,
                        barcode.BarWidthNarrow, encodedRotation, height, encodedReadable, barcodeData));
                default:
                    throw new ApplicationException("Barcode not yet supported by SharpZebra library.");
            }
        }

        public static byte[] TextWrite(int left, int top, ElementDrawRotation rotation, ZebraFont font, int height, int width, string text, int codepage)
        {
            return Encoding.GetEncoding(codepage).GetBytes(string.Format("^FO{0},{1}^A{2}{3},{4},{5}^FD{6}^FS", left, top, (char)font,
                Rotation.ZPLRotationMap[(int)rotation], height, width, text));
        }

        public static byte[] TextWrite(int left, int top, ElementDrawRotation rotation, ZebraFont font, int height, int width, string text)
        {
            return TextWrite(left, top, rotation, font, height, width, text, 850);
        }

        public static byte[] TextWrite(int left, int top, ElementDrawRotation rotation, string fontName, char storageArea, int height, string text, int codepage)
        {
            return Encoding.GetEncoding(codepage).GetBytes(string.Format("^A@{0},{1},{1},{2}:{3}^FO{4},{5}^FD{6}^FS",
                Rotation.ZPLRotationMap[(int)rotation], height, storageArea, fontName, left, top, text));
        }

        public static byte[] TextWrite(int left, int top, ElementDrawRotation rotation, string fontName, char storageArea, int height, string text)
        {
            return TextWrite(left, top, rotation, fontName, storageArea, height, text, 850);
        }

        public static byte[] TextWrite(int left, int top, ElementDrawRotation rotation, int height, string text, int codepage)
        {
            //uses last specified font
            return Encoding.GetEncoding(codepage).GetBytes(string.Format("^A@{0},{1}^FO{2},{3}^FD{4}^FS", Rotation.ZPLRotationMap[(int)rotation],
                height, left, top, text));
        }

        public static byte[] TextWrite(int left, int top, ElementDrawRotation rotation, int height, string text)
        {
            return TextWrite(left, top, rotation, height, text, 850);
        }

        public static byte[] LineWrite(int left, int top, int lineThickness, int right, int bottom)
        {
            int height = top - bottom;
            int width = right - left;
            char diagonal = height * width < 0 ? 'L' : 'R';
            int l = Math.Min(left, right);
            int t = Math.Min(top, bottom);
            height = Math.Abs(height);
            width = Math.Abs(width);

            //zpl requires that straight lines are drawn with GB (Graphic-Box)
            if (width < lineThickness)
                return BoxWrite(left - ((int)(lineThickness / 2)), top, lineThickness, width, height, 0);
            else if (height < lineThickness)
                return BoxWrite(left, top - ((int)(lineThickness / 2)), lineThickness, width, height, 0);
            else
                return Encoding.GetEncoding(850).GetBytes(string.Format("^FO{0},{1}^GD{2},{3},{4},{5},{6}^FS", l, t, width, height,
                    lineThickness, "", diagonal));
        }

        public static byte[] BoxWrite(int left, int top, int lineThickness, int width, int height, int rounding)
        {
            return Encoding.GetEncoding(850).GetBytes(string.Format("^FO{0},{1}^GB{2},{3},{4},{5},{6}^FS", left, top,
                Math.Max(width, lineThickness), Math.Max(height, lineThickness), lineThickness, "", rounding));
        }
        /*
        public static string FormDelete(string formName)
        {
            return string.Format("FK\"{0}\"\n", formName);
        }

        public static string FormCreateBegin(string formName)
        {
            return string.Format("{0}FS\"{1}\"\n", FormDelete(formName), formName);
        }

        public static string FormCreateFinish()
        {
            return string.Format("FE\n");
        }
        */

        public static byte[] WriteLogo()
        {
            string[] imagen = ZPLCommands.GraphicWrite(255, 15, @"C:\tmp\Imagenes\LOGO.bmp");

            return Encoding.GetEncoding(850).GetBytes(imagen[0]);
        }

        public static byte[] WriteLabel()
        {
            string[] imagen = ZPLCommands.GraphicWrite(255, 15, @"C:\tmp\Imagenes\LOGO.bmp");

            StringBuilder pep = new StringBuilder();

            pep.AppendLine("^XA");
            //pep.AppendLine(imagen[1]);


            pep.AppendLine("^CF0,15");
            pep.AppendLine("^FO15,25^7701749470439^FS");
            pep.AppendLine("^FO15,45^FDRef.: MS.VJ.1348^FS");
            pep.AppendLine("^FO15,65^FDColor: ROJO^FS");
            pep.AppendLine("^FO15,85^FDTalla: UNICA^FS");
            pep.AppendLine("^FO15,105^FDNECESAR VANITY^FS");
            pep.AppendLine("^FO15,125^FDM^FS");
            pep.AppendLine("^FO15,145^FDPrecio: $00.00^FS");
            pep.AppendLine("^FX EAN13 BarCode");
            pep.AppendLine("^FO200,135^BY2");
            pep.AppendLine("^BEN,50,N,Y");
            pep.AppendLine("^FD7701749544024^FS");

            pep.AppendLine("^CF0,15");
            pep.AppendLine("^FO450,25^7701749470439^FS");
            pep.AppendLine("^FO450,45^FDRef.: MS.VJ.1348^FS");
            pep.AppendLine("^FO450,65^FDColor: ROJO^FS");
            pep.AppendLine("^FO450,85^FDTalla: UNICA^FS");
            pep.AppendLine("^FO450,105^FDNECESAR VANITY^FS");
            pep.AppendLine("^FO450,125^FDM^FS");
            pep.AppendLine("^FO450,145^FDPrecio: $00.00^FS");
            pep.AppendLine("^FX EAN13 BarCode");
            pep.AppendLine("^FO600,135^BY2");
            pep.AppendLine("^BEN,50,N,Y");
            pep.AppendLine("^FD7701749544024^FS");
            //pep.AppendLine("^XZ");

            //uses last specified font
            return Encoding.GetEncoding(850).GetBytes(pep.ToString());
        }

        public static void WriteLabel(string labelsReceived)
        {
            StringBuilder labelBegin = new StringBuilder();
            StringBuilder labelBody1 = new StringBuilder();
            StringBuilder labelBody2 = new StringBuilder();

            labelBegin.AppendLine("^XA");
            labelBegin.AppendLine("^CF0,15");

            using (var printerSettings = new PrinterSettings())
            {
                string[] labels = labelsReceived.Split('~');
                List<byte> page = new List<byte>();

                printerSettings.PrinterName = labels[2];
                printerSettings.Width = 50;
                printerSettings.AlignLeft = -10;
                printerSettings.Darkness = 90;

                page.AddRange(Encoding.GetEncoding(850).GetBytes(labelBegin.ToString()));

                for (int i = 0; i < 2; i++)
                {
                    string[] labelContent = labels[i].Split('|');

                    switch (i)
                    {
                        case 0:
                            #region Left Label
                            //label.AppendLine(string.Format("^FO15,25^{0}^FS", labelContent[0]));
                            labelBody1.AppendLine(string.Format("^FO55,90^FDRef.:{0}^FS", labelContent[0]));
                            labelBody1.AppendLine(string.Format("^FO55,110^FDColor:{0}^FS", labelContent[1]));
                            labelBody1.AppendLine(string.Format("^FO55,130^FDTalla:{0}^FS", labelContent[2]));
                            labelBody1.AppendLine(string.Format("^FO55,150^FDDesc.:{0}^FS", labelContent[3]));
                            labelBody1.AppendLine(string.Format("^FO55,170^FD{0}^FS", labelContent[4]));
                            labelBody1.AppendLine(string.IsNullOrEmpty(labelContent[5]) ? "" : string.Format("^FO55,190^FDPrecio: {0}^FS", int.Parse(labelContent[5]).ToString("C0", CultureInfo.CreateSpecificCulture("en-EN"))));
                            labelBody1.AppendLine("^FX EAN13 BarCode");
                            labelBody1.AppendLine("^FO125,20^BY2");
                            labelBody1.AppendLine("^BEN,40,Y,N");
                            labelBody1.AppendLine(string.Format("^FD{0}^FS", labelContent[6].Trim()));

                            page.AddRange(Encoding.GetEncoding(850).GetBytes(labelBody1.ToString()));

                            //imagen
                            #region Imagen
                            if (File.Exists(labelContent[7]))
                            {
                                List<byte> image1bytes = new List<byte>();
                                image1bytes.AddRange(ZPLCommands.ClearPrinter(printerSettings));
                                image1bytes.AddRange(ZPLCommands.GraphicDelete('E', "IMG1"));
                                image1bytes.AddRange(ZPLCommands.GraphicStore(new Bitmap(labelContent[7]), 'E', "IMG1"));
                                new SpoolPrinter(printerSettings).Print(image1bytes.ToArray());

                                page.AddRange(Encoding.GetEncoding(850).GetBytes(labelBody1.ToString()));
                                page.AddRange(ZPLCommands.GraphicWrite(290,110, "IMG1", 'E'));
                            }
                            #endregion
                            #endregion

                            break;
                        case 1:
                            #region Right Label
                            if (labelContent[0].Length > 1)
                            {
                                labelBody2.AppendLine(string.Format("^FO445,90^FDRef.:{0}^FS", labelContent[0]));
                                labelBody2.AppendLine(string.Format("^FO445,110^FDColor:{0}^FS", labelContent[1]));
                                labelBody2.AppendLine(string.Format("^FO445,130^FDTalla:{0}^FS", labelContent[2]));
                                labelBody2.AppendLine(string.Format("^FO445,150^FDDesc.:{0}^FS", labelContent[3]));
                                labelBody2.AppendLine(string.Format("^FO445,170^FD{0}^FS", labelContent[4]));
                                labelBody2.AppendLine(string.IsNullOrEmpty(labelContent[5]) ? "" : string.Format("^FO445,190^FDPrecio: {0}^FS", int.Parse(labelContent[5]).ToString("C0", CultureInfo.CreateSpecificCulture("en-EN"))));
                                labelBody2.AppendLine("^FX EAN13 BarCode");
                                labelBody2.AppendLine("^FO515,20^BY2");
                                labelBody2.AppendLine("^BEN,40,Y,N");
                                labelBody2.AppendLine(string.Format("^FD{0}^FS", labelContent[6].Trim()));

                                page.AddRange(Encoding.GetEncoding(850).GetBytes(labelBody2.ToString()));
                            }
                            //imagen
                            #region imagen
                            if (File.Exists(labelContent[7]))
                            {
                                List<byte> image2Bytes = new List<byte>();
                                image2Bytes.AddRange(ZPLCommands.ClearPrinter(printerSettings));
                                image2Bytes.AddRange(ZPLCommands.GraphicDelete('E', "IMG2"));
                                image2Bytes.AddRange(ZPLCommands.GraphicStore(new Bitmap(labelContent[7]), 'E', "IMG2"));
                                new SpoolPrinter(printerSettings).Print(image2Bytes.ToArray());

                                page.AddRange(Encoding.GetEncoding(850).GetBytes(labelBody2.ToString()));
                                page.AddRange(ZPLCommands.GraphicWrite(675, 110, "IMG2", 'E'));
                            }
                            #endregion
                            #endregion
                            break;
                        default:
                            break;
                    }
                }

                //page.AddRange(Encoding.GetEncoding(850).GetBytes(labelBody1.ToString()));
                page.AddRange(Encoding.GetEncoding(850).GetBytes("^XZ"));

                page.AddRange(ZPLCommands.PrintBuffer(1));
                new SpoolPrinter(printerSettings).Print(page.ToArray());
            }
        }
    }

    //public class LabelContent
    //{
    //    public string codigoProducto { get; set; }
    //    public string color { get; set; }
    //    public string talla { get; set; }
    //    public string descripcionProducto { get; set; }
    //    public string desconocido { get; set; }
    //    public double precio { get; set; }
    //}
}
