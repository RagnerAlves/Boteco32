using System.Text.RegularExpressions;

namespace Boteco32.Util
{
    public static class Valida
    {
        public static bool ValidaEmail(string email)
        {
            Regex rgEmail = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rgEmail.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ValidaFone(string fone)
        {
            if (Regex.Match(fone, @"^(\+[0-9])$").Success) {
                return true;
            }
            else
            {
                return false;
            }
              
        }
    }
}
