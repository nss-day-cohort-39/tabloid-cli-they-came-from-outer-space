using System;

namespace TabloidCLI.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }

        public override string ToString()
        {
            return $@"
{Title} ({CreateDateTime.ToShortDateString()})
{Content}
";
        }
    }
}
