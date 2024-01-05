﻿using Aseguradora.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Aseguradora.Data.Seed
{
    public static class SeedIdentityUserData
    {
        public static void SeedUserIdentityData(this ModelBuilder modelBuilder)
        {
            //Agregar el rol "Administrador a la tabla AspNetRoles
            string AdministradorGeneralRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = AdministradorGeneralRoleId,
                Name = "Administrador",
                NormalizedName = "Administrador".ToUpper()
            });
            //Agregar el rol "Administrador a la tabla AspNetRoles
            string AjustadorGeneralRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = AjustadorGeneralRoleId,
                Name = "Ajustador",
                NormalizedName = "Ajustador".ToUpper()
            });
            //Agregar el rol "Administrador a la tabla AspNetRoles
            string EjecutivoGeneralRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = EjecutivoGeneralRoleId,
                Name = "Ejecutivo",
                NormalizedName = "Ejecutivo".ToUpper()
            });

            var ConductorId = Guid.NewGuid().ToString();
            modelBuilder.Entity<CustomIdentityUser>().HasData(
                new CustomIdentityUser
                {
                   
                }
            );

            //Aplicamos la relación entre el usuario y el rol en la tabla AspNetUserRoles
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = AdministradorGeneralRoleId,
                    UserId = ConductorId
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = AjustadorGeneralRoleId,
                    UserId = ConductorId
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = EjecutivoGeneralRoleId,
                    UserId = ConductorId
                }
            );
        }
    }
}
