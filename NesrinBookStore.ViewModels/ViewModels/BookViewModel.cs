﻿namespace NesrinBookStore.API.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }
        
        public string Price { get; set; }

        public string Rating { get; set; }

        public string Description { get; set; }
    }
}
