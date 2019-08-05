using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.BLL
{
    public class PLCDataClear
    {
        public async Task<bool> ClearBSL(OPC_ToPLC opc)
        {
            bool x = await opc.ClearPLCDataBSL();
            return x;
        }

        public async Task<bool> ClearFB(OPC_ToPLC opc)
        {
            bool x = await opc.ClearPLCDataFB();
            return x;
        }
    }
}
