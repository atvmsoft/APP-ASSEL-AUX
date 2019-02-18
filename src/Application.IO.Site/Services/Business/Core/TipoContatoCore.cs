using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.TipoContato;
using Application.IO.Site.Services.Business.Insert;
using Application.IO.Site.Services.Business.Updade;
using System;

namespace Application.IO.Site.Services.Business.Core
{
    public class TipoContatoCore
    {
        public ReturnAction Save(TipoContatoModel model, Guid id)
        {
            if (model.Id != 0)
                return new TipoContatoUpdate().Save(model, id);
            else
                return new TipoContatoInsert().Save(model, id);
        }
    }
}
