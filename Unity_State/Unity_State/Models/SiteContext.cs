using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Unity_State.Models 
{
    public class SiteContext : DbContext
    {
        

        public SiteContext(DbContextOptions<SiteContext> options) : base(options) 
        {

        }

        public DbSet<ClientModel> Users { get; set; }
    }
}
