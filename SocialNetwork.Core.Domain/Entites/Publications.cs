﻿using SocialNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Domain.Entites
{
    public class Publications : BaseEntity
    {
        public string Content { get; set; }

        //Navigation propierties 
        public string UserID { get; set; }

        public int ComentID { get; set; }
        public ICollection<Coments> Coments { get; set; }
    }
}
