using Soul.Engine.Data.Repository;

namespace Soul.Engine.Data
{
    public static class DataContext
    {
        private static AlunoRepository aluno;

        public static AlunoRepository Aluno
        {
            get { return aluno ?? (aluno = new AlunoRepository()); }
        }
    }
}
