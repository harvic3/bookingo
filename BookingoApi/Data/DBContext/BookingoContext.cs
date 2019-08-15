namespace BookingoApi.Data.DBContext
{
    public class BookingoContext : BookingoEntities
    {
        private BookingoContext _dbBookingo;
        private BookingoContext DBBookingo
        {
            get
            {
                _dbBookingo = _dbBookingo ?? new BookingoContext();
                return _dbBookingo;
            }
        }

        public BookingoContext DataBase()
        {
            return DBBookingo;
        }

        public BookingoContext NewDataBase()
        {
            return new BookingoContext();
        }
    }
}