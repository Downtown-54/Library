namespace LibraryApi.Models
{
    public class IssuedBooks
    {
        public int Id { get; set; } // Идентификатор
        public DateTime IssuedDate { get; set; } // Дата выдачи книги
        public int NameBook { get; set; } // Идентификатор книги
        public int Reader { get; set; } // Идентификатор читателя
        public DateTime DateOfDelivery { get; set; } // Дата окончания выдачи книги
        public int StatusIssuedBook { get; set; }  // Статус состояния выданной книги 
    }
}
