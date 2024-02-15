using Dapper;
using System.Data;
using TestBudgeting.Models.Home.Expense;

namespace TestBudgeting.Models.NTSE
{
    public class NTSEMethods
    {
        private readonly IDbConnection _conn;
        public NTSEMethods(IDbConnection conn)
        {
            _conn = conn;
        }

        public NTSEExpanded GetInventory()
        {
            NTSEExpanded ntse = new NTSEExpanded();
            ntse.ListOfNTSE = _conn.Query<NTSE>("SELECT * FROM ntse;");
            return ntse;
        }
        public void UpdateItem(NTSE item)
        {
            _conn.Execute(@"UPDATE ntse 
                    SET Category = @Category, 
                        Quantity = @Quantity, 
                        StyleNumber = @StyleNumber, 
                        Size = @Size, 
                        Color = @Color 
                    WHERE ID = @ID",
                            new
                            {
                                Category = item.Category,
                                Quantity = item.Quantity,
                                StyleNumber = item.StyleNumber,
                                Size = item.Size,
                                Color = item.Color,
                                ID = item.ID
                            });
        }
        public void InsertItem(NTSE item)
        {
            _conn.Execute(@"INSERT INTO ntse (Category, Quantity, StyleNumber, Size, Color) 
                    VALUES (@Category, @Quantity, @StyleNumber, @Size, @Color)",
                            new
                            {
                                Category = item.Category,
                                Quantity = item.Quantity,
                                StyleNumber = item.StyleNumber,
                                Size = item.Size,
                                Color = item.Color
                            });
        }
        public void DeleteItem(int id)
        {
            _conn.Execute("DELETE FROM ntse WHERE ID = @ID", new { ID = id });
        }


    }
}
