using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder parametros = new StringBuilder();

            //label1
            parametros.Append("012|");
            parametros.Append("2014|");
            parametros.Append("9|");
            parametros.Append("19|");
            parametros.Append("1|");
            parametros.Append("Samsung SCX-3200 Series Class Driver|");

            executeIt.ShellExecuteA(0, "OPEN", @"C:\Users\SILVERIO\Source\Repos\Comisiones_MH\ReporteZ\OrkIdea.MH.ReporteZ.ConsoleUI\bin\Debug\OrkIdea.MH.ReporteZ.ConsoleUI.exe", '"' + parametros.ToString() + '"', "", 1);

            //"012", new DateTime(2014, 9, 19), "1", "Samsung SCX-3200 Series Class Driver"
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

}
