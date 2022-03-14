using System;
using System.Collections.Generic;

namespace academico.Models
{
    public partial class TbAvaliacao
    {
        public int Id { get; set; }
        public string Conceito { get; set; } = null!;
        public int IdAlunoTurma { get; set; }

        public virtual TbrAlunoTurma IdAlunoTurmaNavigation { get; set; } = null!;
    }
}
