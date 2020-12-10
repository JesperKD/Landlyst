using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling
{
    public class Data
    {
        public GetDBData GetDBData = new GetDBData();
        public UpdateDBData UpdateDBData = new UpdateDBData();

        public Data()
        {
            GetDBData = new GetDBData();
            UpdateDBData = new UpdateDBData();
        }
    }
}
