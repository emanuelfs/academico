using System;
using System.Collections.Generic;

namespace academico.Models
{
    public partial class TbAluno
    {
        public TbAluno()
        {
            TbrAlunoTurmas = new HashSet<TbrAlunoTurma>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<TbrAlunoTurma> TbrAlunoTurmas { get; set; }
    }
}
