using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Situacao;
using Application.IO.Site.Services.Business.Insert;
using Application.IO.Site.Services.Business.Updade;
using System;

namespace Application.IO.Site.Services.Business.Core
{
    public class SituacaoCore
    {
        public ReturnAction Save(SituacaoModel model, Guid id)
        {
            if (model.Id != 0)
                return new SituacaoUpdate().Save(model, id);
            else
                return new SituacaoInsert().Save(model, id);
        }
    }
}
