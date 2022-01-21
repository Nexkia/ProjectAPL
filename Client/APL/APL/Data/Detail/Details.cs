using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.Data.Detail
{
    public interface Details
    {
        int Valutazione { get; init; }
        string Modello { get; init; }
        string[] getDetail();
    }
}
