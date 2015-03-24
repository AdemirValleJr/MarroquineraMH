using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using OrkIdea.MH.ReporteZ.Business;

namespace OrkIdea.MH.ReporteZ.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!string.IsNullOrEmpty(args[0]))
            {
                string[] parameters = args[0].Split('|');
                Console.WriteLine("Parametros recibidos");

                BizReporteZ.ImprimirReporte(parameters[0], new DateTime(int.Parse(parameters[1]), int.Parse(parameters[2]), int.Parse(parameters[3])), parameters[4], parameters[5]);
            }

            //BizReporteZ.ImprimirReporte("012", new DateTime(2014, 9, 19), "1", "Samsung SCX-3200 Series Class Driver");
        }
    }
}
