namespace DataObjects.BaseItems.Notification
{
    /// <summary>
    /// Базовое уведомление об успешности
    /// </summary>
    /// <typeparam name="T">Тип базового запроса</typeparam>
    public class BaseSuccessNotification<T> : BaseNotification<T>
        where T : BaseRequest
    {
        public T OriginalRequest;
    }
}
