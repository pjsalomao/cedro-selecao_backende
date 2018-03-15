using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restaurante_backend.Models;

namespace restaurante_backend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RestauranteContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Restaurantes.Any())
            {
                return;   // DB has been seeded
            }

            var restaurantes = new Restaurante[]
            {
            new Restaurante{RestauranteNome="Praia food"},
            new Restaurante{RestauranteNome="Boa livre"},
            new Restaurante{RestauranteNome="Food Park"},
            new Restaurante{RestauranteNome="Brasa na carne"},
            new Restaurante{RestauranteNome="Peixe na telha"},
            new Restaurante{RestauranteNome="Cupim"},
            new Restaurante{RestauranteNome="Mexicali"},
            new Restaurante{RestauranteNome="Paris 8"},
            new Restaurante{RestauranteNome="Comida Caseira"}
            };
            foreach (Restaurante r in restaurantes)
            {
                context.Restaurantes.Add(r);
            }
            context.SaveChanges();

            var pratos = new Prato[]
            {
            new Prato{RestauranteNome="Praia food", PratoNome="Carne assada", Preco=20.50},
            new Prato{RestauranteNome="Boa livre", PratoNome="arroz carreteiro", Preco=18.50},
            new Prato{RestauranteNome="Food Park", PratoNome="hor dog", Preco=22.50},
            new Prato{RestauranteNome="Brasa na carne", PratoNome="picanhca", Preco=40.50},
            new Prato{RestauranteNome="Peixe na telha", PratoNome="tilapia", Preco=30.50},
            new Prato{RestauranteNome="Cupim", PratoNome="cpim assada", Preco=20.50},
            new Prato{RestauranteNome="Mexicali", PratoNome="burrito", Preco=20.50},
            new Prato{RestauranteNome="Paris 8", PratoNome="quiche", Preco=20.50},
            new Prato{RestauranteNome="Comida Caseira", PratoNome="galinhada", Preco=20.50}
            };
            foreach (Prato p in pratos)
            {
                context.Pratos.Add(p);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{RestauranteID=1,PratoID=1050,Grade=Grade.A},
            new Enrollment{RestauranteID=1,PratoID=1060,Grade=Grade.C},
            new Enrollment{RestauranteID=1,PratoID=1070,Grade=Grade.B},
            new Enrollment{RestauranteID=2,PratoID=1080,Grade=Grade.B},
            new Enrollment{RestauranteID=2,PratoID=1090,Grade=Grade.F},
            new Enrollment{RestauranteID=2,PratoID=1011,Grade=Grade.F},
            new Enrollment{RestauranteID=3,PratoID=1050},
            new Enrollment{RestauranteID=4,PratoID=1050},
            new Enrollment{RestauranteID=4,PratoID=1012,Grade=Grade.F},
            new Enrollment{RestauranteID=5,PratoID=1054,Grade=Grade.C},
            new Enrollment{RestauranteID=6,PratoID=1060},
            new Enrollment{RestauranteID=7,PratoID=1058,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
