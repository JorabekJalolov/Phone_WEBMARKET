using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phone_WEBMARKET.Models
{
    public class IdentityRole
    {
        public virtual TKey Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string NormalizedName { get; set; }
        public virtual string ConcurrencyStamp { get; set; }
    }
}
