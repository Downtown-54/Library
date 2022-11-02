namespace LibraryApi.Models
{
    public class IssuedBooks
    {
        /// <summary>
        /// Идентификатор выдачи книги
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата выдачи книги
        /// </summary>
        public DateTime IssuedDate { get; set; }
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public int NameBook { get; set; }
        /// <summary>
        /// Идентификатор читателя
        /// </summary>
        public int Reader { get; set; }
        /// <summary>
        /// Дата окончания выдачи книги
        /// </summary>
        public DateTime DateOfDelivery { get; set; }
        /// <summary>
        /// Статус состояния выданной книги 
        /// </summary>
        public int StatusIssuedBook { get; set; }
    }
}
