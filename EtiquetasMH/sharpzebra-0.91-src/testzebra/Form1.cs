using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.SharpZebra.Printing;
using Com.SharpZebra.Commands;
using Com.SharpZebra;
using System.Globalization;
using System.Runtime.InteropServices;
using System.IO;


namespace testzebra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PrinterSettings ps = new PrinterSettings();
            using (var ps = new PrinterSettings())
            {
                ps.PrinterName = "ZDesigner GT800 (ZPL)";
                //ps.PrinterName = "Generic / Text Only";
                ps.Width = 50;
                ps.AlignLeft = -10;
                ps.Darkness = 30;

                List<byte> page = new List<byte>();
            
                ////*****************
                List<byte> res = new List<byte>();
                res.AddRange(ZPLCommands.ClearPrinter(ps));
                res.AddRange(ZPLCommands.GraphicDelete('E', "SAMPLE"));
                //res.AddRange(ZPLCommands.WriteLogo());
                res.AddRange(ZPLCommands.GraphicStore(new Bitmap(@"C:\tmp\Imagenes\MS.BL.1306.bmp"), 'E', "SAMPLE"));
                //res.AddRange(ZPLCommands.PrintBuffer(1));
                new SpoolPrinter(ps).Print(res.ToArray());
                //*****************


                //string inicio = "^XA";
                string fin = "^XZ";

                //page.AddRange(Encoding.GetEncoding(850).GetBytes(inicio));
                //page.AddRange(ZPLCommands.GraphicWrite(250, 15, "SAMPLE", 'E'));
                //page.AddRange(Encoding.GetEncoding(850).GetBytes(fin));
                //page.AddRange(ZPLCommands.GraphicWrite(650, 15, "SAMPLE", 'E'));
                
                
                page.AddRange(ZPLCommands.WriteLabel());
                page.AddRange(ZPLCommands.GraphicWrite(210, 15, "SAMPLE", 'E'));
                page.AddRange(ZPLCommands.GraphicWrite(620, 15, "SAMPLE", 'E'));
                page.AddRange(Encoding.GetEncoding(850).GetBytes(fin));


                page.AddRange(ZPLCommands.PrintBuffer(1));
                new SpoolPrinter(ps).Print(page.ToArray());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string printerName = "Generic / Text Only";// "ZDesigner GT800 (EPL)";
            //string printerName = "ZDesigner GT800 (ZPL)";
            StringBuilder pep;

            if (printerName == null)
            {
                throw new ArgumentNullException("printerName");
            }

            pep = new StringBuilder();
            //pep.AppendLine("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD15^JUS^LRN^CI0^XZ");
            pep.AppendLine("^XA");
            pep.AppendLine("^CF0,15");
            pep.AppendLine("^FO15,25^FDInternational Shipping, Inc.^FS");
            pep.AppendLine("^FO15,45^FD1000 Shipping Lane^FS");
            pep.AppendLine("^FO15,65^FDShelbyville TN 38102^FS");
            pep.AppendLine("^FO15,85^FDUnited States (USA)^FS");
            pep.AppendLine("^FX EAN13 BarCode");
            pep.AppendLine("^FO15,125^BY2");
            pep.AppendLine("^BEN,50,N,Y");
            pep.AppendLine("^FD7701749544024^FS");
                        
            pep.AppendLine("^CF0,15");
            pep.AppendLine("^FO450,25^FDInternational Shipping, Inc.^FS");
            pep.AppendLine("^FO450,45^FD1000 Shipping Lane^FS");
            pep.AppendLine("^FO450,65^FDShelbyville TN 38102^FS");
            pep.AppendLine("^FO450,85^FDUnited States (USA)^FS");
            pep.AppendLine("^FX EAN13 BarCode");
            pep.AppendLine("^FO450,125^BY2");
            pep.AppendLine("^BEN,50,N,Y");
            pep.AppendLine("^FD7701749544024^FS");
            pep.AppendLine("^XZ");

            RawPrinterHelper.SendStringToPrinter(printerName, pep.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
          StringBuilder parametros = new StringBuilder();

            //label1
            parametros.Append("MS.VJ.1348|");
            parametros.Append("ROJO|");
            parametros.Append("UNICA|");
            parametros.Append("PRODUCTO IZQUIERDA|");
            parametros.Append("M|");
            parametros.Append("50000|");
            parametros.Append("7701749544024|");
            parametros.Append(@"C:\tmp\Imagenes\MS.VJ.1348.bmp");
            parametros.Append("~");

            //LABEL2
            parametros.Append("MS.VJ.1350|");
            parametros.Append("ROJO|");
            parametros.Append("UNICA|");
            parametros.Append("PRODUCTO DERECHA|");
            parametros.Append("M|");
            parametros.Append("48000|");
            parametros.Append("7701749544024|");
            parametros.Append(@"C:\tmp\Imagenes\MS.VJ.1348.bmp");
            parametros.Append("~");
            parametros.Append("Generic / Text Only (Copiar 1)");
            ZPLCommands.WriteLabel(parametros.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {

            StringBuilder parametros = new StringBuilder();

            //label1
            parametros.Append("MS.VJ.1348|");
            parametros.Append("ROJO|");
            parametros.Append("UNICA|");
            parametros.Append("PRODUCTO IZQUIERDA|");
            parametros.Append("M|");
            parametros.Append("50000|");
            parametros.Append("7701749544024|");
            parametros.Append(@"C:\tmp\Imagenes\MS.VJ.1348.bmp");
            parametros.Append("~");

            //LABEL2
            parametros.Append("MS.BL.1306|");
            parametros.Append("ROJO|");
            parametros.Append("UNICA|");
            parametros.Append("PRODUCTO DERECHA|");
            parametros.Append("M|");
            parametros.Append("5000|");
            parametros.Append("7701749140257            |");
            parametros.Append(@"C:\tmp\Imagenes\MS.BL.1306.bmp");
            parametros.Append("~");
            parametros.Append("ZDesigner GT800 (ZPL)");
            //ZPLCommands.WriteLabel(parametros.ToString());

            executeIt.ShellExecuteA(0, "OPEN", @"C:\Users\Aguila1\Source\Repos\MarroquineraMH\EtiquetasMH\sharpzebra-0.91-src\CSSPrintZebraLabel\bin\Debug\CSSPrintZebraLabel.exe", '"' + parametros.ToString() + '"', "", 1);
        }
    }



    class executeIt
    {
        /*
        Public Declare Function ShellExecute _
        Lib "shell32.dll" _
        Alias "ShellExecuteA" ( _
        ByVal hwnd As Long, _
        ByVal lpOperation As String, _
        ByVal lpFile As String, _
        ByVal lpParameters As String, _
        ByVal lpDirectory As String, _
        ByVal nShowCmd As Long) _
        As Long
        */

        [System.Runtime.InteropServices.DllImport("shell32.dll", EntryPoint = "ShellExecute")]
        public static extern int ShellExecuteA(int hwnd, string
        lpOperation, string lpFile, string lpParameters, string lpDirectory,
        int nShowCmd);
    }


    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}
