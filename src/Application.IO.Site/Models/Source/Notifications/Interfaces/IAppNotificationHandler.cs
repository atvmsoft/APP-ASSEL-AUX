using System.Collections.Generic;

namespace Application.IO.Site.Models.Source.Notifications.Interfaces
{
    public interface IAppNotificationHandler<TAppNotification> where TAppNotification : IAppNotification
    {
        void Add(TAppNotification notification);
        List<TAppNotification> Get { get; }
        bool HasNotification { get; }
        string ToString();
    }
}
