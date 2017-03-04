using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTakerApp.Data
{
    public class Data
    {
        private static IssueTakerContex contex;

        public static IssueTakerContex Contex
        {
            get { return contex ?? (contex = new IssueTakerContex()); }
        }
    }
}
