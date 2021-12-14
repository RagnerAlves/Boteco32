using System.Collections.Generic;

namespace Boteco32.ViewModels.RetornoViewModel
{
    public class RetornoViewModel<T>
    {
        public T Data { get; private set; }

        public List<string> Erros { get; private set; } = new();

        public RetornoViewModel()
        {
        }

        public RetornoViewModel(T data, List<string> erros)
        {
            Data = data;
            Erros = erros;
        }

        public RetornoViewModel(T data)
        {
            Data = data;
        }

        public RetornoViewModel(List<string> erros)
        {
            Erros = erros;
        }

        public RetornoViewModel(string erro)
        {
            Erros.Add(erro);
        }
    }
}
