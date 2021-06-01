using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Inspector
        : User
    {
        public Inspector(int userId, string name, int districtId)
            : base(userId, name, districtId, nameof(Inspector))
        {
        }
    }
}
