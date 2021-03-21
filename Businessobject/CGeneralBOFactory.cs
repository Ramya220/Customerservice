using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customerservice.Businessobject
{
    public abstract class CGeneralBOFactory
    {
        public static IGeneralDataBO CreateGeneralDataBO()
        {
            return new GeneralBO();
        }
    }
}