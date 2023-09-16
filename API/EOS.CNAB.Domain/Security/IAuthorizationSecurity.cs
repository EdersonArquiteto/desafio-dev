using EOS.CNAB.Domain.Entities;

namespace EOS.CNAB.Domain.Security
{
    public interface IAuthorizationSecurity
    {
        string CreateToken(Usuario usuario);
    }
}
