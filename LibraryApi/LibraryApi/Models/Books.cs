namespace LibraryApi.Models
{
    public class Books
    {
        public int Id { get; set; } // Идентификатор
        public string? Name { get; set; }  // Название книги
        public string? Author { get; set; } // Автор
        public string? VendorCode { get; set; } // Артикул
        public DateTime YearOfPublication { get; set; } // Дата издания
        public int Instances { get; set; } // Экземпляры
        public int Status { get; set; } // Статус состояния книги
    }
}
