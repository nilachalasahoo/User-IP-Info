using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using IP_Tracking.Models;

namespace IP_Tracking.DAL
{
    public class Address_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();

        // Get All Address
        public List<Address> GetAllAddress()
        {
            List<Address> addressList = new List<Address>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM IP_Tracking", connection);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtAddress = new DataTable();

                connection.Open();
                sqlDA.Fill(dtAddress);
                connection.Close();

                foreach (DataRow dr in dtAddress.Rows)
                {
                    addressList.Add(new Address
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        ITR_Section = Convert.ToString(dr["ITR_Section"]),
                        IP_Address = Convert.ToString(dr["IP_Address"]),
                        MAC_Address = Convert.ToString(dr["MAC_Address"]),
                        Employee_Name = Convert.ToString(dr["Employee_Name"]),
                        Location = Convert.ToString(dr["Location"]),
                        IO_Number = Convert.ToInt32(dr["IO_Number"]),
                        Switchport_No = Convert.ToInt32(dr["Switchport_No"]),
                        Domain_Name = Convert.ToString(dr["Domain_Name"])
                    });
                }
            }

            return addressList;
        }

        // Insert Data
        public bool InsertData(Address address)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = "INSERT INTO IP_Tracking (ITR_Section, IP_Address, MAC_Address, Employee_Name, Location, IO_Number, Switchport_No, Domain_Name) " +
                               "VALUES (@ITR_Section, @IP_Address, @MAC_Address, @Employee_Name, @Location, @IO_Number, @Switchport_No, @Domain_Name)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ITR_Section", address.ITR_Section);
                command.Parameters.AddWithValue("@IP_Address", address.IP_Address);
                command.Parameters.AddWithValue("@MAC_Address", address.MAC_Address);
                command.Parameters.AddWithValue("@Employee_Name", address.Employee_Name);
                command.Parameters.AddWithValue("@Location", address.Location);
                command.Parameters.AddWithValue("@IO_Number", address.IO_Number);
                command.Parameters.AddWithValue("@Switchport_No", address.Switchport_No);
                command.Parameters.AddWithValue("@Domain_Name", address.Domain_Name);

                try
                {
                    connection.Open();
                    id = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Get Address By ID
        public List<Address> GetAddressByID(int AddressID)
        {
            List<Address> addressList = new List<Address>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT [ID], [ITR_Section], [IP_Address], [MAC_Address], [Employee_Name], [Location], [IO_Number], [Switchport_No], [Domain_Name] FROM IP_Tracking WHERE ID = @AddressID";
                command.Parameters.AddWithValue("@AddressID", AddressID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    addressList.Add(new Address
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        ITR_Section = Convert.ToString(reader["ITR_Section"]),
                        IP_Address = Convert.ToString(reader["IP_Address"]),
                        MAC_Address = Convert.ToString(reader["MAC_Address"]),
                        Employee_Name = Convert.ToString(reader["Employee_Name"]),
                        Location = Convert.ToString(reader["Location"]),
                        IO_Number = Convert.ToInt32(reader["IO_Number"]),
                        Switchport_No = Convert.ToInt32(reader["Switchport_No"]),
                        Domain_Name = Convert.ToString(reader["Domain_Name"])
                    });
                }

                reader.Close();
            }

            return addressList;
        }

        // Update Data
        public bool UpdateData(Address address)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = "UPDATE IP_Tracking " +
                               "SET ITR_Section = @ITR_Section, " +
                               "    IP_Address = @IP_Address, " +
                               "    MAC_Address = @MAC_Address, " +
                               "    Employee_Name = @Employee_Name, " +
                               "    Location = @Location, " +
                               "    IO_Number = @IO_Number, " +
                               "    Switchport_No = @Switchport_No, " +
                               "    Domain_Name = @Domain_Name " +
                               "WHERE ID = @AddressID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AddressID", address.ID);
                command.Parameters.AddWithValue("@ITR_Section", address.ITR_Section);
                command.Parameters.AddWithValue("@IP_Address", address.IP_Address);
                command.Parameters.AddWithValue("@MAC_Address", address.MAC_Address);
                command.Parameters.AddWithValue("@Employee_Name", address.Employee_Name);
                command.Parameters.AddWithValue("@Location", address.Location);
                command.Parameters.AddWithValue("@IO_Number", address.IO_Number);
                command.Parameters.AddWithValue("@Switchport_No", address.Switchport_No);
                command.Parameters.AddWithValue("@Domain_Name", address.Domain_Name);

                try
                {
                    connection.Open();
                    i = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete Data
        public int DeleteData(int addressid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    string q = "DELETE FROM IP_Tracking WHERE ID=@addressid";
                    SqlCommand command = new SqlCommand(q, connection);
                    command.Parameters.AddWithValue("@addressid", addressid);

                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
                return -1;
            }
        }









    }
}
