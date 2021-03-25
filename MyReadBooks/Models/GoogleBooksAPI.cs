using System;
using System.Collections.Generic;

namespace MyReadBooks.Models
{
    public class ImageLinks
    {
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
    }

    public class VolumeInfo
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public IList<string> authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public ImageLinks imageLinks { get; set; }
        public string language { get; set; }
    }

    public class Item
    {
        public VolumeInfo volumeInfo { get; set; }
    }

    public class BooksAPI
    {
        public List<Item> items { get; set; }
    }
}
