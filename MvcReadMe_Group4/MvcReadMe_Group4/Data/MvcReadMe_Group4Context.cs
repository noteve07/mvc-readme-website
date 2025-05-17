using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcReadMe_Group4.Models;

namespace MvcReadMe_Group4.Data
{
    public class MvcReadMe_Group4Context : DbContext
    {
        public MvcReadMe_Group4Context (DbContextOptions<MvcReadMe_Group4Context> options)
            : base(options)
        {
        }

        public DbSet<MvcReadMe_Group4.Models.Book> Books { get; set; } = default!;
        public DbSet<MvcReadMe_Group4.Models.User> Users { get; set; } = default!;
        public DbSet<MvcReadMe_Group4.Models.BookAccess> BookAccesses { get; set; } = default!;

    }
}
