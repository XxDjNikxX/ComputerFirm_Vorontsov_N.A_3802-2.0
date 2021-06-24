using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDBComputers
{
    partial class Customer
    {
        public override string ToString()
        {
            return SecondName + " " + FirstName.Substring(0, 1) + "." + PatherName.Substring(0, 1);
        }
    }
}
