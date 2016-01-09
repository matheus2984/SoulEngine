using FluentNHibernate.Mapping;
using Soul.Engine.Data.Domain;

namespace Soul.Engine.Data.Mapping
{
    public class AlunoMap : ClassMap<Aluno>
    {
        public AlunoMap()
        {
            Id(x => x.ID);
            Map(x => x.Tag);
            Map(x => x.Nome);
            Map(x => x.Turma);
            Table("aluno");
        }
    }
}