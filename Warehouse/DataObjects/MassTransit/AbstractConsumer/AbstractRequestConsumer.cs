using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DataObjects.MassTransit.AbstractConsumer
{
    /// <summary>
    /// Базовый класс для обработки сообщений (с 1 сервисом)
    /// </summary>
    /// <typeparam name="T">сообщения</typeparam>
    /// <typeparam name="U">Тип сервиса 1</typeparam>
    public abstract class AbstractRequestConsumer<T, U> : IConsumer<T>
        where T : class
        where U : class
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private readonly ILogger<T> _logger;

        /// <summary>
        /// Сервис, способный работать в режиме многопоточности
        /// </summary>
        private U _service;

        /// <summary>
        /// Конструктор абстрактного обработчика сообщений с 1 сервисом
        /// </summary>
        /// <param name="logger">логгер</param>
        /// <param name="service">сервис 1</param>
        public AbstractRequestConsumer(ILogger<T> logger, U service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Метод интерфейса IConsumer, вызываемый для обработки
        /// </summary>
        /// <param name="context">контекст с сообщением</param>
        /// <returns>задача, обрабатывающая запрос</returns>
        public Task Consume(ConsumeContext<T> context)
        {
            var obj = new TaskLaunchObj<T, U>()
            {
                Service = _service,
                context = context,
                Logger = _logger
            };

            var msg = context.Message;

            return new Task(processTask, obj);
        }

        /// <summary>
        /// Описывает задачу, запускаемую при получении сообщения
        /// </summary>
        /// <param name="arg">обьект содержащий все необходимое</param>
        private void processTask(object arg)
        {
            var srcData = (TaskLaunchObj<T, U>)arg;
            var msg = srcData.context.Message;

            var service = srcData.Service;

            var logger = srcData.Logger;

            try
            {
                ProcessRequest(srcData.context, msg, service, logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                //В MassTransit Consumer не падает полностью при возникновении исключения.
                //Сообщение переходит в очередь _error
                throw;
            }
        }

        /// <summary>
        /// Метод, обрабатывающий сообщение
        /// </summary>
        /// <param name="context">контекст</param>
        /// <param name="msg">сообщение</param>
        /// <param name="service">сервис</param>
        /// <param name="logger">логгер</param>
        protected abstract void ProcessRequest(ConsumeContext<T> context, T msg, U service, ILogger<T> logger);

        /// <summary>
        /// Класс, содержащий запрос и ссылки на все нужные сервисы для данных подписчиков
        /// </summary>
        /// <typeparam name="T">Тип запроса</typeparam>
        internal class TaskLaunchObj<T, U>
            where T : class
            where U : class
        {
            /// <summary>
            /// Сервис для работы с БД хранилища
            /// </summary>
            public U Service;

            /// <summary>
            /// Логгер
            /// </summary>
            public ILogger<T> Logger;

            /// <summary>
            /// Ссылка на запрос и контекст
            /// </summary>
            public ConsumeContext<T> context;
        }
    }
}