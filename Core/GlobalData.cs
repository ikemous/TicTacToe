using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core
{
    class GlobalData
    {
        static public string UserSymbol { get; set; }
        static public string UserName { get; set; }
        static public string ComputerSymbol { get; set; }
        static public bool UserFirst { get; set; } = true;
    }
}
