namespace DataObjects.BaseItems.Notification
{
    /// <summary>
    /// Базовое уведомление об ошибке
    /// </summary>
    /// <typeparam name="T">Тип базового запроса</typeparam>
    public class BaseFailNotification<T> : BaseNotification<T>
        where T : BaseRequest
    {
        public T OriginalRequest;
    }
}
