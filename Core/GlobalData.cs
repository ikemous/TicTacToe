using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core
{
    class GlobalData
    {
        static public string UserSymbol { get; set; } = "X";
        static public string UserName { get; set; } = "";
        static public string ComputerSymbol { get; set; } = "O";
        static public bool UserFirst { get; set; } = true;
    }
}
