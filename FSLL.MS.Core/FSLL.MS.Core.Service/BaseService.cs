using FSLL.MS.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLL.MS.Core.Service
{
    public class BaseService
    {
        private fsll_coreEntities _db;

        protected fsll_coreEntities _fsllDB
        {
            get
            {
                if (_db == null)
                    _db = new fsll_coreEntities();

                return _db;
            }

        }
    }
}
