using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Boteco32.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> RecuperarErros(this ModelStateDictionary modelState)
        {
            var listaDeErros = new List<string>();
            foreach (var item in modelState.Values)
            {
                foreach (var erro in item.Errors)
                {
                    listaDeErros.Add(erro.ErrorMessage);
                }
            }
            return listaDeErros;
        }
    }
}
