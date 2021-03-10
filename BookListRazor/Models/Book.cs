using System.ComponentModel.DataAnnotations;

namespace BookListRazor.Models
{
    public class Book
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "襙你媽不可以為空")] public string Name { get; set; }
        public string Author { get; set; }


        public string ISBN { set; get; }
    }
}
