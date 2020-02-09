using System.Collections.Generic;

namespace SimpleApi
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}