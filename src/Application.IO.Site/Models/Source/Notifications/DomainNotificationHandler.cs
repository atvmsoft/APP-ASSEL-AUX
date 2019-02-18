using Application.IO.Site.Models.Source.Notifications.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Application.IO.Site.Models.Source.Notifications
{
    [NotMapped]
    public class DomainNotificationHandler : IAppNotificationHandler<DomainNotification>
    {
        public DomainNotificationHandler() => Get = new List<DomainNotification>();

        public bool HasNotification => Get.Any();

        public List<DomainNotification> Get { get; private set; }

        public void Add(DomainNotification notification) => Get.Add(notification);

        private void Dispose() => Get = new List<DomainNotification>();

        public override string ToString() => HasNotification ? string.Join(',', Get.Select(s => s.Value)) : string.Empty;
    }
}
