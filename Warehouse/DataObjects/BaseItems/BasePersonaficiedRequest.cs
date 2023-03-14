using System;

namespace DataObjects.BaseItems
{
    /// <summary>
    /// Базовый персонализированный запрос
    /// </summary>
    public class BasePersonaficiedRequest : BaseRequest
    {
        /// <summary>
        /// Очередь для ответа, используется для работы с пользователями (обычно user:{guid})
        /// </summary>
        public Uri ResponseQueueUri { get; set; }
    }
}
