using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcQuiz.Models;

namespace MvcQuiz.Data
{
    public class MvcQuizContext : DbContext
    {
        public MvcQuizContext (DbContextOptions<MvcQuizContext> options)
            : base(options)
        {
        }

        public DbSet<MvcQuiz.Models.Quiz> Quiz { get; set; } 
    }
}
