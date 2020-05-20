using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using USDA.Models;

namespace USDA.Data
{
    public class UsdaDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UsdaDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TimeAttendance>().Wait();
        }

        public Task<List<TimeAttendance>> GetTimeAttendancesAsync()
        {
            return _database.Table<TimeAttendance>().ToListAsync();
        }
        
        public Task<int> SaveTimeAttendanceAsync(TimeAttendance timeAttendance)
        {
            if (timeAttendance.ID != 0)
            {
                return _database.UpdateAsync(timeAttendance);
            }
            else
            {
                return _database.InsertAsync(timeAttendance);
            }
        }


        public Task<int> DeleteNoteAsync(TimeAttendance timeAttendance)
        {
                return _database.DeleteAsync(timeAttendance);
        }

    }
}
