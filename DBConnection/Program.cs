using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Margorita", "margo@test.pl", "555555555");
            try
            {
                
                //InsertInDB(person);
                //deleteFromDB(4);
                //updateDB(3,person);
                ReadFromDB();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void updateDB(int id, Person person)
        {
            string connectionString = @"Data Source=DESKTOP-NNO1SAJ\SQLEXPRESS;Initial Catalog=test;Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection is opened");
                //*****************************************
                string query = $"UPDATE Person SET name = '{person.Name}',email = '{person.Email}',phone = '{person.Phone}' WHERE id = {id};";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    Console.WriteLine($"Successfully updated {command.ExecuteNonQuery()} line(s)");
                }
                //*****************************************
                connection.Close();
                Console.WriteLine("Connection is closed");
            }
        }

        private static void deleteFromDB(int id)
        {
            string connectionString = @"Data Source=DESKTOP-NNO1SAJ\SQLEXPRESS;Initial Catalog=test;Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection is opened");
                //*****************************************
                string query = $"DELETE FROM person WHERE id={id};";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    Console.WriteLine($"Successfully deleeted {command.ExecuteNonQuery()} line(s)");
                }
                //*****************************************
                connection.Close();
                Console.WriteLine("Connection is closed");
            }
        }

        private static void InsertInDB(Person person)
        {
            string connectionString = @"Data Source=DESKTOP-NNO1SAJ\SQLEXPRESS;Initial Catalog=test;Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection is opened");
                //*****************************************
                string query = $"INSERT INTO Person (name,email,phone) VALUES ('{person.Name}','{person.Email}','{person.Phone}');";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    Console.WriteLine($"Successfully added {command.ExecuteNonQuery()} line(s)");
                }
                //*****************************************
                connection.Close();
                Console.WriteLine("Connection is closed");
            }
        }

        static void ReadFromDB()
        {
            string connectionString = @"Data Source=DESKTOP-NNO1SAJ\SQLEXPRESS;Initial Catalog=test;Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection is opened");
                //*****************************************
                string query = "SELECT * FROM person";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader sqlDataReader = command.ExecuteReader())
                    {
                        string str;
                        Console.WriteLine("id   name        phone       email");
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine($"{sqlDataReader["id"]}    {sqlDataReader["name"]}     {sqlDataReader["phone"]}    {sqlDataReader["email"]}");
                        }
                    }

                }
                //*****************************************
                connection.Close();
                Console.WriteLine("Connection is closed");
            }
        }
    }
}
