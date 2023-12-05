using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

// This is the dataset of Journal

namespace GreenJournal.Models
{
    public class Journals
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }


        // Set date to now
        public Journals()
        {
            Date = DateTime.Now;
        }

    }
}
