using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public Post Post { get; set; }

        public override string ToString()
        {
            return $"{Title} {CreationDateTime} {Content}";
        }
    }
}