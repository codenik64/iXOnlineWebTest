using iXOnline.Core.Interfaces;
using iXOnlineWeb.Core.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnlineWeb.Core.FactoryLayer
{
    public class MemberFactory
    {
        public static IMember CreateMemberLibrary()
        {
            return new MembersBLL();
        }
    }
}
