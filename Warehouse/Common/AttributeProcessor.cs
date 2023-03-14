using System.Reflection;

namespace Common
{
    /// <summary>
    /// Абстрактный класс для работы с аттрибутами различных классов
    /// </summary>
    /// <typeparam name="U">Тип аттрибутов</typeparam>
    /// <typeparam name="T">Тип представления данных</typeparam>
    public abstract class AttributeProcessor<U, T>
        where U : Attribute
        where T : new()
    {
        /// <summary>
        /// Внутренний тип для передачи информации о типе и аттрибуте в абстрактный метод
        /// </summary>
        protected class Info
        {
            /// <summary>
            /// Тип
            /// </summary>
            public Type type;

            /// <summary>
            /// Аттрибут
            /// </summary>
            public U Attribute;
        }

        /// <summary>
        /// Получает аттрибут заданного типа у заданного класса
        /// </summary>
        /// <typeparam name="V">Класс типа V</typeparam>
        /// <param name="type">ссылка на экземпляр</param>
        /// <returns>аттрибут</returns>
        public U GetAttribute<V>(V type)
        {
            return type.GetType().GetCustomAttribute<U>();
        }

        /// <summary>
        /// Получает данные по всем классам с заданным аттрибутом
        /// </summary>
        /// <returns>Список с заданным представлением</returns>
        public List<T> ProcessAttributes()
        {
            var types = Assembly.GetCallingAssembly().GetTypes();

            var activeTypes = types.Select(item => new Info { type = item, Attribute = item.GetCustomAttribute<U>() }).Where(item=>item.Attribute !=null).ToList();

            var res = ProcessTypes(activeTypes);

            return res;
        }

        /// <summary>
        /// Получает данные по каждому классу\аттрибуту
        /// </summary>
        /// <param name="activeTypes">Список типов с аттрибутами</param>
        /// <returns>Список требуемого представления</returns>
        private List<T> ProcessTypes(List<Info> activeTypes)
        {
            var res = new List<T>();

            foreach (var item in activeTypes)
            {
                
                var type = item.type;

                var attr = item.Attribute;

                var inf = processTypeAndAttribute(type, attr);

                res.Add(inf);
            }

            return res;
        }

        /// <summary>
        /// Обрабатывает данные типа\аттрибута
        /// </summary>
        /// <param name="type">Тип</param>
        /// <param name="attr">Аттрибут</param>
        /// <returns>Представление</returns>
        protected abstract T processTypeAndAttribute(Type type, U attr);

    }

}

