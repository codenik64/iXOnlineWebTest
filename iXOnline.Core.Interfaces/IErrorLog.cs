using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnline.Core.Interfaces
{
    public interface IErrorLog
    {
        void InsertError(Exception ErrorException);
    }
}
