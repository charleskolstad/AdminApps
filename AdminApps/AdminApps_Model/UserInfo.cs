﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApps_Model
{
    public class UserInfo
    {
        public int UserInfoID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<UserGroups> GroupUsers { get; set; }
    }
}