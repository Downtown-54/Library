namespace LibraryApi.Models
{
    public class Readers
    {
        /// <summary>
        /// Идентификатор читателя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ФИО читателя
        /// </summary>
        public string Reader { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateBirth { get; set; }
        /// <summary>
        /// Номер телефона читателя
        /// </summary>
        public string NumberPhone { get; set; }
        /// <summary>
        /// Электронная почта читателя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Адрес прописки читателя
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Статус состояния читателя 
        /// </summary>
        public StatusReader Status { get; set; }
        public enum StatusReader
        {
            Active,
            Archive
        }
    }
}
