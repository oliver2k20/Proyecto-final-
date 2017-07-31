using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    /// <summary>
    /// Esta la clase que pone data de prueba a la BD
    /// </summary>
    public static class DbInitializer
    {
        //Este metodo entrara data de prueba a la aplicacion
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();
            try {
                //Revisa si hay categorias
                if (!context.Categories.Any())
                {
                    //Inserta data de prueba
                    var habitacionSencilla = new Category()
                    {
                        CategoryName = "Sala normal",
                        Description = "Película en modo normal",
                        Hotels = new List<Hotel>()
                    {
                        new Hotel() {Name = "Transformers the last knight", ShortDescription="Cientos de años atrás, en el 484 d.C, el Rey Arturo....", LongDescription="Cientos de años atrás, en el 484 d.C, el Rey Arturo (Liam Garrigan) lleva a sus caballeros y hombres a una batalla que no pueden esperar ganar. Al darse cuenta de esto, se alista con la ayuda del mago Merlín (Stanley Tucci), que es un borracho. Sir Edmund Burton (Anthony Hopkins) dice que la magia si existe, fue encontrada hace mucho en una nave alienigena que se estrello.",Price=150m,ImageUrl="/Images/transformers.jpg", Reserved = false},
                        new Hotel() {Name = "Super papá", ShortDescription="Película dominicana", LongDescription="Película dominicana dirigita por Roberto Salcedo",Price=150m,ImageUrl="/Images/superpapa.jpg", Reserved = false}
                    }
                    };
                    //Añadir al contexto de  la bd
                    context.Add(habitacionSencilla);
                    context.AddRange(habitacionSencilla.Hotels);
                    var habitacionDoble = new Category()
                    {
                        CategoryName = "Sala 3D",
                        Description = "Película en modo 3D con gafas",
                        Hotels = new List<Hotel>()
                    {
                        new Hotel() {Name = "Dunkirk", ShortDescription="Dunkerque es una ciudad francesa que sirvió como...",LongDescription="Dunkerque es una ciudad francesa que sirvió como escenario para la célebre operación militar de los Aliados entre mayo y junio de 1940 en la que se centrará la película.",Price=250M,ImageUrl="/Images/dunkirk.jpg", Reserved = false},
                        new Hotel() {Name = "Desplicable me 3", ShortDescription="3ra parte de mi villano favorito", LongDescription="Hay caos en Egipto, la gran pirámide de Guiza fue robada y reemplazada por una réplica inflable, todo por culpa de un malvado villano. ",Price=250M,ImageUrl="/Images/desplicable.jpg", Reserved = false}
                    }
                    };
                    context.Add(habitacionDoble);
                    context.AddRange(habitacionDoble.Hotels);
                    var habitacionMatrimonial = new Category()
                    {
                        CategoryName = "Sala 4DX",
                        Description = "Sala para los más entusiastas",
                        Hotels = new List<Hotel>()
                    {
                        new Hotel() {Name ="Spiderman homecoming", ShortDescription="El regreso de Spiderman", LongDescription="Dos meses después de los acontecimientos en Capitán América: Civil War, Peter Parker, con la ayuda de su maestro Tony Stark y su mejor amigo Ned Leeds, trata de equilibrar su vida como un estudiante de secundaria en Queens, y su lucha contra el crimen como Spider-Man6​ mientras se enfrenta a una nueva amenaza, el Buitre.", Price=400M, ImageUrl="/Images/spiderman.png",Reserved = false},
                        new Hotel() {Name ="Cars 3", ShortDescription="Tercera parte de cars",LongDescription="Después de que Jackson Storm (Armie Hammer) un nuevo corredor diseñado con alta tecnología, llega a la pista, el público se pregunta cuando se retirará el ahora veterano y campeón experimentado de siete Copas Pistón, el Rayo McQueen (Owen Wilson). Este quiere demostrar que aún no le hace falta retirarse, pero luego de su última carrera de la temporada", Price=400m, ImageUrl="/Images/cars3.jpg",Reserved = false}
                    }
                    };
                    context.Add(habitacionMatrimonial);
                    context.AddRange(habitacionMatrimonial.Hotels);

                    var habitacionSuite = new Category()
                    {
                        CategoryName = "Sala 4DX vip",
                        Description = "Sala para los entusiastas de peliculas VIP",
                        Hotels = new List<Hotel>()
                    {
                        new Hotel() {Name ="La guerra del Planeta de los Simios", ShortDescription="Después de que los humanos de la colonia de San Francisco...", LongDescription="Después de que los humanos de la colonia de San Francisco pidiesen ayuda a una base militar en el norte durante el ataque de Koba en Dawn of the Planet of the Apes, el clan de simios dirigido por César, es atacado en el bosque por la facción militar Alfa-Omega", Price=600M, ImageUrl="/Images/planetasimios.jpg",Reserved = false},
                        new Hotel() {Name ="Baby driver", ShortDescription="aún no disponible", LongDescription="por el momento no está disponible", Price=600M, ImageUrl="/Images/babydriver.jpg",Reserved = false}
                    }
                    };
                    context.Add(habitacionSuite);
                    context.AddRange(habitacionSuite.Hotels);

                    context.SaveChanges();

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        


    }


}
