using EOS.CNAB.Domain.Entities;
using EOS.CNAB.Domain.Interfaces;
using EOS.CNAB.InfraStructure.Context;
using EOS.CNAB.InfraStructure.Helpers;

namespace EOS.CNAB.InfraStructure.Repository
{
    public class UsuarioRepository : Repository<Usuario, Guid>, IUsuarioRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public UsuarioRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Usuario GetByEmail(string email)
        {
            return _sqlServerContext.Usuario.FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            senha = MD5Helper.Encrypt(senha);

            return _sqlServerContext.Usuario
                .FirstOrDefault(u => u.Email.Equals(email)
                                  && u.Senha.Equals(senha));
        }
        public override void Create(Usuario entity)
        {
            entity.Senha = MD5Helper.Encrypt(entity.Senha);
            base.Create(entity);
        }
    }
}
