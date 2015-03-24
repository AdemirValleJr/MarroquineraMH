using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.SharpZebra.Commands;

namespace CSSPrintZebraLabel
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
                ZPLCommands.WriteLabel(args[0]);
        }
    }
}
