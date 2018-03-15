using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurante_backend.Models
{
    public class Prato
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PratoID { get; set; }
        public string RestauranteNome { get; set; }
        public string PratoNome { get; set; }
        public Double Preco { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
