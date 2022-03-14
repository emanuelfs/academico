using System;
using System.Collections.Generic;

namespace academico.Models
{
    public partial class TbTurma
    {
        public TbTurma()
        {
            TbrAlunoTurmas = new HashSet<TbrAlunoTurma>();
        }

        public int Id { get; set; }
        public int Ano { get; set; }
        public int Semestre { get; set; }
        public int IdDisciplina { get; set; }
        public int IdProfessor { get; set; }

        public virtual TbDisciplina IdDisciplinaNavigation { get; set; } = null!;
        public virtual TbProfessor IdProfessorNavigation { get; set; } = null!;
        public virtual ICollection<TbrAlunoTurma> TbrAlunoTurmas { get; set; }
    }
}
