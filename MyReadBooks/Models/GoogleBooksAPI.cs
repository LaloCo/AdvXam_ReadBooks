using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;

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
        [JsonIgnore]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private VolumeInfo _volumeInfo;
        [Ignore]
        public VolumeInfo volumeInfo
        {
            get
            {
                return _volumeInfo;
            }
            set
            {
                _volumeInfo = value;

                title = _volumeInfo.title;
                publisher = _volumeInfo.publisher;
                publishedDate = _volumeInfo.publishedDate;
                if(_volumeInfo.authors != null)
                {
                    for (int i = 0; i < _volumeInfo.authors.Count; i++)
                    {
                        authors += _volumeInfo.authors[i];
                        if (i < _volumeInfo.authors.Count - 1)
                            authors += ", ";
                    }
                }
                if (_volumeInfo.imageLinks != null)
                    thumbnail = _volumeInfo.imageLinks.thumbnail;
            }
        }

        public string title { get; set; }
        public string authors { get; set; }
        public string thumbnail { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
    }

    public class BooksAPI
    {
        public List<Item> items { get; set; }
    }
}
