using System;

namespace FichaCadastral.Models
{
    public class LoginResult : BaseResult
    {
        public Guid usuarioGuid { get; internal set; }
    }
}
