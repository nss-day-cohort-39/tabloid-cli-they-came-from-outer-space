using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI
{
    public class JournalManager
    {
        private readonly string _connectionString;
        private readonly UIManager _ui;

        public JournalManager(string connectionString, UIManager ui)
        {
            _connectionString = connectionString;
            _ui = ui;
        }

    }
}
