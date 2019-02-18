using System.Collections.Generic;

namespace Application.IO.Site.Models.Source
{
    public class ReturnAction
    {
        public List<string> Mensagens { get; set; }

        public object objRetorno { get; set; }

        private bool _valido = true;
        public bool Valido
        {
            get => (Mensagens.Count > 0 ? false : (_valido ? true : false));
            set => _valido = value;
        }

        public ReturnAction()
        {
            Mensagens = new List<string>();
        }

        public ReturnAction(List<string> mensagens)
        {
            Mensagens = mensagens;
        }
    }
}
