using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CursoModel
    {
        public int id_curso { get; set; }
        public string nome { get; set; }
        public DateTime criado_em { get; set; }
        public DateTime actualizado_em { get; set; }
    }
}
