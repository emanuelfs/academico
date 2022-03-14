using System;
using System.Collections.Generic;

namespace academico.Models
{
    public partial class TbDisciplina
    {
        public TbDisciplina()
        {
            TbTurmas = new HashSet<TbTurma>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<TbTurma> TbTurmas { get; set; }
    }
}
