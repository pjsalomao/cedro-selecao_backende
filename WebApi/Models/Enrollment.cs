using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurante_backend.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int PratoID { get; set; }
        public int RestauranteID { get; set; }
        public Grade? Grade { get; set; }

        public Prato Prato { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
