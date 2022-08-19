using SOL_LUIS_ROJAS.DATA.Context;
using SOL_LUIS_ROJAS.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SOL_LUIS_ROJAS.WEB.Seeder
{
    public class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if(!context.Books.Any())
            {
                var bookLst = new List<Book>()
                {
                    new Book { ISBN = "111", Name = "Harry Potter y la Piedra Filosofal", Author = "JK Rowling", Country = "Reino Unido", Category = "Fantasía", Publisher = "Publicador 3000", IssueDate = DateTime.Parse("1990-10-10")},
                    new Book { ISBN = "222", Name = "El Señor de los Anillos", Author = "JRR Tolkien", Country = "Reino Unido", Category = "Fantasía", Publisher = "Publicador 4000", IssueDate = DateTime.Parse("1995-01-08")},
                    new Book { ISBN = "333", Name = "El Arte de la Guerra", Author = "Sun Tzu", Country = "China", Category = "Filosofía", Publisher = "Publicador 5000", IssueDate = DateTime.Parse("1990-10-10")},
                    new Book { ISBN = "444", Name = "Libro de Prueba", Author = "UPC", Country = "Peru", Category = "Romance", Publisher = "Editorial Planeta", IssueDate = DateTime.Parse("2012-12-11")},
                };
                context.Books.AddRange(bookLst);
                await context.SaveChangesAsync();
            }

            if(!context.Users.Any())
            {
                var usrLst = new List<User>()
                {
                    new User { DNI = "12345678", Email = "alumno1@upc.edu.pe", FirstName = "Eduardo", LastName = "Arias", Role = "Alumno", PhoneNumber = "999999999", Status = true },
                    new User { DNI = "12345668", Email = "alumno2@upc.edu.pe", FirstName = "Eduardo", LastName = "Pablo", Role = "Zosimo", PhoneNumber = "999999999", Status = true },
                    new User { DNI = "12345778", Email = "docente1@upc.edu.pe", FirstName = "Docente", LastName = "Docente", Role = "Docente", PhoneNumber = "999999999", Status = true },
                };
                context.Users.AddRange(usrLst);
                await context.SaveChangesAsync();
            }
        }
    }
}