using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRL_LAKE.Models
{
    interface IDettaglioPagamento
    {
        double CalcolaCosto();
        string toString();
        int getId();

    }
}
