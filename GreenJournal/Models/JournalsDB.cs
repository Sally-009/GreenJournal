using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

// This is operations of database

namespace GreenJournal.Models
{
    public class JournalsDB
    {
        private readonly SQLiteAsyncConnection _database;

        // A constructor for the DB (Create a table)
        public JournalsDB(String dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Journals>().Wait();
        }

        // Return a list of the journals
        public Task<List<Journals>> GetJournalsAsync()
        {
            return _database.Table<Journals>().ToListAsync();
        }

        // Return one journal according to ID
        public Task<Journals> GetJournalByIDAsync(int id)
        {
            return _database.Table<Journals>().Where(j => j.Id == id).FirstOrDefaultAsync();
        }

        // Store a new data into the DB
        public Task<int> SaveJournalAsync(Journals journals)
        {
            return _database.InsertAsync(journals);
        }

        // Used for debug: Delete all data and recreate table
        public async Task DeleteAllData()
        {
            // Delete Table
            await _database.DropTableAsync<Journals>().ConfigureAwait(false);
            // Create Table
            await _database.CreateTableAsync<Journals>().ConfigureAwait(false);

        }

        // Return the largest ID
        public async Task<int> GetMaxJournalIDAsync()
        {
            var result = await _database.Table<Journals>().OrderByDescending(j => j.Id).FirstOrDefaultAsync();
            return result?.Id ?? 0;
        }

        // Delete the selected Journal
        public async Task DeleteJournalAsync(int id)
        {
            var journalToDelete = await _database.Table<Journals>().Where(j => j.Id == id).FirstOrDefaultAsync();
            if (journalToDelete != null)
            {
                await _database.DeleteAsync(journalToDelete);
            }
        }


    }
}
