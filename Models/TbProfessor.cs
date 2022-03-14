using System;
using System.Collections.Generic;

namespace academico.Models
{
    public partial class TbProfessor
    {
        public TbProfessor()
        {
            TbTurmas = new HashSet<TbTurma>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<TbTurma> TbTurmas { get; set; }
    }
}
