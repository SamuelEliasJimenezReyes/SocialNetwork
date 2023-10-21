using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Domain.Common
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
