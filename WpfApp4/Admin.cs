using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class Admin
    {
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        public Admin()
        {
            conn = new SQLiteConnection("data source=products.db3");
            conn.Open();
            cmd = new SQLiteCommand(conn);
        }
        public void insert(String productName,int productID,int amount,double price)
        {
            cmd.CommandText = "INSERT INTO ProductTable(productName,productID,Amount,Price)" +
                       " VALUES('"+productName+"'," + productID+ ", " + amount+ ", " + price+ ")";
            cmd.ExecuteNonQuery();
        }
        public void delete(String productName)
        {
            cmd.CommandText = "DELETE FROM ProductTable WHERE productName ='"+productName+"'";
            cmd.ExecuteNonQuery();
        }
        public void updateProductName(String oldName,String newName)
        {
            cmd.CommandText = "UPDATE ProductTable set productName= '" + newName + "' where productName='" + oldName + "'";
            cmd.ExecuteNonQuery();
        }
        public void updateProductAmount(String productName, int number)
        {   String query = "UPDATE ProductTable set Amount = " + number + " where productName='" + productName + "'"; ;
            cmd.CommandText = query;
            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
        }
        public DataTable selectStar()
        {


            cmd.CommandText = "SELECT * FROM productTable";

            SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
           
        }
        public double getPrice(String productName)
        {
            cmd.CommandText = "SELECT Price FROM ProductTable WHERE productName='"+productName+"'";
            cmd.ExecuteNonQuery();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                double price = 0;
                while (reader.Read())
                {
                    return Convert.ToDouble(reader["price"]);
                }
                return price;
            }
        }
        public bool validAmount(String productName,int amount)
        {
            cmd.CommandText = "SELECT Amount FROM ProductTable WHERE productName='" + productName + "'";
            cmd.ExecuteNonQuery();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                int productAmount= 0;
                while (reader.Read())
                {
                    productAmount = Convert.ToInt32(reader["amount"]);
                    break;
                }
                if (amount <= productAmount)
                    return true;
                else
                    return false;
                
            }
        }

    }
}
