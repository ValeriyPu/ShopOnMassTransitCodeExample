using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.BaseItems.Notification
{
    public class BaseNotification<T>
        where T : BaseRequest
    {

        /// <summary>
        /// Id основного обьекта
        /// </summary>
        public Guid MainObjectId;
    }
}
