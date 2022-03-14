using System;
using System.Collections.Generic;

namespace academico.Models
{
    public partial class TbrAlunoTurma
    {
        public TbrAlunoTurma()
        {
            TbAvaliacaos = new HashSet<TbAvaliacao>();
        }

        public int Id { get; set; }
        public string Situacao { get; set; } = null!;
        public string ConceitoFinal { get; set; } = null!;
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }

        public virtual TbAluno IdAlunoNavigation { get; set; } = null!;
        public virtual TbTurma IdTurmaNavigation { get; set; } = null!;
        public virtual ICollection<TbAvaliacao> TbAvaliacaos { get; set; }
    }
}
