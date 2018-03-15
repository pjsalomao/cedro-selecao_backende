using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurante_backend.Models
{
    public class Restaurante
    {
        public int ID { get; set; }
        public string RestauranteNome { get; set; }
        

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
