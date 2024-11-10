using CookDinnerMinimalApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CookDinnerMinimalApi.Infrastructure.Services;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes { get; set; }
}