namespace task2
{
    /// <summary>
    /// Исключение о запрете доступа
    /// </summary>
    public class AccessException : Exception
    {
        /// <summary>
        /// Исключение о запрете доступа
        /// </summary>
        /// <param name="txId">Id исключения</param>
        public AccessException(string txId) : base("Пользователь должен быть старше 18 лет " + txId)
        {
            TransactionId = txId;
        }

        /// <summary>
        /// Исключение о запрете доступа
        /// </summary>
        /// <param name="msg">Текст исключения</param>
        /// <param name="txId">Id исключения</param>
        public AccessException(string msg, string txId) : base(msg)
        {
            TransactionId = txId;
        }

        /// <summary>
        /// Идентификатор транзакции
        /// </summary>
        public string TransactionId { get; }
    }
}
