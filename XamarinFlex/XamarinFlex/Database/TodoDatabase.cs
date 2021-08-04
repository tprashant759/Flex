using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Shared;
using SQLite;
using XamarinFlex.DataModel;

namespace XamarinFlex.Database
{
    public class TodoDatabase
    {

        #region Database initialization

        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<TodoDatabase> Instance = new AsyncLazy<TodoDatabase>(async () =>
       {
           var instance = new TodoDatabase();
           CreateTableResult result = await Database.CreateTableAsync<ToDoItem>();
           return instance;
       });

        #endregion

        #region Constructors

        public TodoDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.Constants.DatabaseFilename, Constants.Constants.Flags);
        }

        #endregion


        #region To Do items actions


        public Task<List<ToDoItem>> GetAllItemsAsync()
        {
            return Database.Table<ToDoItem>().ToListAsync();
        }

        public Task<List<ToDoItem>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<ToDoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<ToDoItem> GetItemByIdAsync(Guid id)
        {
            return Database.Table<ToDoItem>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveOrUpdateItemAsync(ToDoItem item)
        {
            if (item.id != Guid.Empty)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                item.id = Guid.NewGuid();
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ToDoItem item)
        {
            return Database.DeleteAsync(item);
        }

        #endregion

    }




}
