using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oppimispäiväkirja.Models;

namespace Oppimispäiväkirja.Data
{
    public class TopicsContext : DbContext
    {
        public TopicsContext (DbContextOptions<TopicsContext> options)
            : base(options)
        {
        }

        public DbSet<Oppimispäiväkirja.Models.Topic> Topic { get; set; }
    }
}
