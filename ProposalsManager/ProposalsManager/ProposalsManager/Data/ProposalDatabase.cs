using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using ProposalsManager.Models;

namespace ProposalsManager.Data
{
    public class ProposalDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ProposalDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Proposal>().Wait();
        }

        public Task<List<Proposal>> GetProposalsAsync()
        {
            return _database.Table<Proposal>().ToListAsync();
        }

        public Task<int> SaveProposalAync(Proposal proposal)
        {
            if (proposal.ID != 0) return _database.UpdateAsync(proposal);
            else return _database.InsertAsync(proposal);
        }

        public Task<int> DeleteProposalAsync(Proposal proposal)
        {
            return _database.DeleteAsync(proposal);
        }
    }
}
