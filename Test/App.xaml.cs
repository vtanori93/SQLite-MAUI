using SQLite;
using System.Diagnostics;

namespace Test
{
    public partial class App : Application
    {
        #region Variables
        public static SQLiteAsyncConnection? Database;
        #endregion
        #region Constructor
        public App()
        {
            InitializeComponent();
            DependencyService.Register<SQLiteDB.SQLiteDB>();
            InitSQLiteDB();
            MainPage = new AppShell();
        }
        #endregion
        #region Methods
        private async void InitSQLiteDB()
        {
            try
            {
                if (Database is not null)
                {
                    return;
                }
                Database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Test1.db3"));
                await Database.CreateTableAsync<Models.SQLiteDB.Department>();
                await Database.CreateTableAsync<Models.SQLiteDB.Employee>();
                await Database.CreateTableAsync<Models.SQLiteDB.Salary>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}
