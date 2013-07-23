using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity;

namespace LiveLinkMVC.Models
{
    public class LiveLinkContext : DbContext
    {
        public DbSet<LiveLink> LiveLinks { get; set; }
    }



}
