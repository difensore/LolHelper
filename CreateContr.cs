using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LolHelper
{
    class CreateContr
    {
        public int id { get; set; }
        public IPrint printer { get; set; }
        public CreateContr(IPrint print, int id)
        {
            this.printer = print;
            this.id = id;
        }
        public async Task AsyncPrint()
        {
            await printer.Asyncprint(id);
        }
    }
}
