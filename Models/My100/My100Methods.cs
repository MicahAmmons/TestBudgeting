using System.Data;
using Dapper;


namespace TestBudgeting.Models.My100
{
    public class My100Methods
    {

        private readonly IDbConnection _conn;

        public My100Methods(IDbConnection conn)
        {
            this._conn = conn;
        }
        public void AddItem(My100 my100)
        {
            _conn.Execute("INSERT INTO my100 (ThingToDo, Number) VALUES (@ThingToDo, @Number)",
                        new
                        {
                            ThingToDo = my100.ThingToDo,
                            Number = my100.Number,
                        }); ;
        }
        public void RemoveItem(int id)
        {
            _conn.Execute("DELETE my100 WHERE ID = @id ",
              new
              {
                  id = id,
              }); 
        }

        public My100Enum ViewItems() 
        {
            My100Enum my = new My100Enum();
            my.My100s = _conn.Query<My100>("SELECT * FROM my100");
            return my;
        }
        public void EditItem(My100 my100)
        {
            _conn.Execute("UPDATE my100 SET ThingToDo = @ThingToDo, Number = @Number WHERE ID = @id",
                new
                {
                    ThingToDo = my100.ThingToDo,
                    Number = my100.Number,
                    id = my100.ID
                });
        }
        public void CompleteItem(int id)
        {
            _conn.Execute("UPDATE my100 SET Completed = CASE WHEN Completed = 1 THEN 0 WHEN Completed = 0 THEN 1 END WHERE ID = @id",
                new
                {
                    id = id,
                });
        }


        // add an item
        // edit an item
        // toggle completetions 




    }
}
