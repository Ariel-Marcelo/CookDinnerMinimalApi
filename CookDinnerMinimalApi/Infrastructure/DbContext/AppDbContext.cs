using CookDinnerMinimalApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CookDinnerMinimalApi.Infrastructure.DbContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Recipe> Recipes { get; set; }
}