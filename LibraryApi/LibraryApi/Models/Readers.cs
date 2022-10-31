namespace LibraryApi.Models
{
    public class Readers
    {
        public int Id { get; set; }  // Идентификатор
        public string? Reader { get; set; } // ФИО читателя
        public DateTime DateBirth { get; set; } // Дата рождения
        public string? NumberPhone { get; set; } // Номер телефона читателя
        public string? Email { get; set; }  // Электронная почта читателя
        public string? Address { get; set; } // Адрес прописки читателя
        public int Status { get; set; } // Статус состояния читателя 
    }
}
