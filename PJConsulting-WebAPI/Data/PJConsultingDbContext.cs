using System;
using Microsoft.EntityFrameworkCore;

namespace PJConsulting_WebAPI.Data;

public class PJConsultingDbContext(DbContextOptions<PJConsultingDbContext> options ) : DbContext(options)
{
    public DbSet<Consultancy> Consultancies { get; set; }

    public DbSet<Service> Services { get; set; }
}
