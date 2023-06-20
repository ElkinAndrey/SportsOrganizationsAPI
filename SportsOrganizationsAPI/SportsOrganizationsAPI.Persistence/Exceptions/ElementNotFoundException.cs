namespace SportsOrganizationsAPI.Persistence.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если элемент не найден
	/// </summary>
	public sealed class ElementNotFoundException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если элемент не найден
        /// </summary>
        public ElementNotFoundException() :
            base($"Не удалось найти элемент по ключу")
        {

        }

        /// <summary>
        /// Ошибка, возникающая если элемент не найден
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        public ElementNotFoundException(string key) :
            base($"Не удалось найти элемент по ключу \"{key}\"")
        {

        }

        /// <summary>
        /// Ошибка, возникающая если элемент не найден
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <param name="type">Тип сущности</param>
        public ElementNotFoundException(string key, string type) :
            base($"Не удалось найти элемент по ключу \"{key}\" в сущности \"{type}\"")
        {

        }

        /// <summary>
        /// Ошибка, возникающая если элемент не найден
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <param name="type">Тип сущности</param>
        public ElementNotFoundException(string key, Type type) :
            this(key, type.Name)
        {

        }
    }
}
