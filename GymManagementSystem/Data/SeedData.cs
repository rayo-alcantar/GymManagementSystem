using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GymManagementSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GymContext(
                serviceProvider.GetRequiredService<DbContextOptions<GymContext>>()))
            {
                // Buscar si hay datos
                if (context.Members.Any())
                {
                    return;   // La base de datos ya está poblada
                }

                context.Members.AddRange(
                    new Member
                    {
                        Name = "Juan Pérez",
                        Email = "juan.perez@example.com",
                        MembershipDate = DateTime.Now
                    },
                    new Member
                    {
                        Name = "Ana García",
                        Email = "ana.garcia@example.com",
                        MembershipDate = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
