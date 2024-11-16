namespace LibraryManagement.Model
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

    }
}
