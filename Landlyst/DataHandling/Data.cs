using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling
{
    public class Data
    {
        public GetDBData GetDBData = new GetDBData();
        public SaveDBData SaveDBData = new SaveDBData();

        public Data()
        {
            GetDBData = new GetDBData();
            SaveDBData = new SaveDBData();
        }
    }
}
