using System.Security.Cryptography;
using System.Text;

namespace Ephesto.Service.Services
{
    public class SenhaService
    {
        public static string AcertarSenha(string _senha)
        {
            var senha = new StringBuilder();

            var md5 = MD5.Create();
            var entrada = Encoding.ASCII.GetBytes(_senha);
            var hash = md5.ComputeHash(entrada);
            //StringBuilder sb = new StringBuilder();
            foreach (var t in hash)
            {
                senha.Append(t.ToString("X2"));
            }
            return senha.ToString();
        }
    }
}