namespace LibraryApi.Models
{
    public class Books
    {
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Артикул
        /// </summary>
        public string VendorCode { get; set; }
        /// <summary>
        /// Дата издания
        /// </summary>
        public DateTime YearOfPublication { get; set; }
        /// <summary>
        /// Экземпляры
        /// </summary>
        public int Instances { get; set; }
        /// <summary>
        /// Статус состояния книги
        /// </summary>
        public StatusBook Status { get; set; }
        public enum StatusBook
        {
            Active,
            Archive
        }
    }
}
