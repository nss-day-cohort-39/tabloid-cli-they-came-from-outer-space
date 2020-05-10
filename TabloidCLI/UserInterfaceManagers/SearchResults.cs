using System;
using System.Collections.Generic;

namespace TabloidCLI.UserInterfaceManagers
{
    public class SearchResults<T>
    {
        private List<T> _results = new List<T>();

        public string Title { get; set; } = "Search Results";

        public bool NoResultsFound
        {
            get
            {
                return _results.Count == 0;
            }
        }

        public void Add(T result)
        {
            _results.Add(result);
        }

        public void Display()
        {
            Console.WriteLine(Title);

            foreach (T result in _results)
            {
                Console.WriteLine(" " + result);
            }

            Console.WriteLine();
        }
    }
}
