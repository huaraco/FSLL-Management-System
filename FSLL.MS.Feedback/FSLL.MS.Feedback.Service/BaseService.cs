using FSLL.MS.Feedback.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLL.MS.Feedback.Service
{
    public class BaseService
    {
        private fsll_feedbackEntities _db;

        protected fsll_feedbackEntities _fsllDB
        {
            get
            {
                if (_db == null)
                    _db = new fsll_feedbackEntities();

                return _db;
            }

        }
    }
}
