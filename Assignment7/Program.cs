using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter sda;
        public static DataSet ds;
        public static string constr = "server=DESKTOP-MONMK0F;database=Assignment7;trusted_connection=true;";
        static void Main(string[] args)
        {
            {
                try
                {
                    con = new SqlConnection(constr);
                    cmd = new SqlCommand("select * from Books", con);
                    sda = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    con.Open();
                    sda.Fill(ds, "Books");
                    con.Close();
                    Console.WriteLine("Book ID \t Title\t\t\t\t Author \t\t Genre\t\tQuantity");
                    foreach (DataRow row in ds.Tables["Books"].Rows)
                    {
                        Console.Write(row["BookId"] + "\t\t ");
                        Console.Write(row["Title"] + "\t\t\t\t");
                        Console.Write(row["Author"] + "\t\t ");
                        Console.Write(row["Genre"] + " \t");
                        Console.Write(row["Quantity"] + " \t");
                        Console.WriteLine("\n");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!!!" + ex.Message);
                }
                finally
                {
                    Console.ReadKey();
                }
            }
            //Insert
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from Books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "Books");
                DataTable dt = ds.Tables["Books"];
                DataRow dr = dt.NewRow();
                Console.WriteLine("Enter Book Details to insert");
                Console.WriteLine("enter Book Id");
                dr["BookId"] = Console.ReadLine();
                Console.WriteLine("Enter Book Title");
                dr["Title"] = Console.ReadLine();
                Console.WriteLine("Enter Author Name");
                dr["Author"] = Console.ReadLine();
                Console.WriteLine("Enter Genre");
                dr["Genre"] = Console.ReadLine();
                Console.WriteLine("Enter Quantity");
                dr["Quantity"] = int.Parse(Console.ReadLine());
                dt.Rows.Add(dr);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                sda.Update(ds, "Books");
                Console.WriteLine("Book Record Inserted!!!");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
            //Update
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from Books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "Books");
                Console.WriteLine("Enter Title to Update the Book");
                string BTitle = Console.ReadLine();
                DataRow dr = null;
                foreach (DataRow row in ds.Tables["Books"].Rows)
                {
                    if ((String)row["Title"] == BTitle)
                    {
                        dr = row;
                        break;
                    }
                }
                if (dr == null)
                {
                    Console.WriteLine($"No such Book {BTitle} exist in Books Table");
                }
                else
                {
                    Console.WriteLine("Enter New Quantity");
                    dr["Quantity"] = int.Parse(Console.ReadLine());

                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    sda.Update(ds, "Books");
                    Console.WriteLine("Record Updated!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
