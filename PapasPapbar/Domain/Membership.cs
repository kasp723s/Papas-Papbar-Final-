using PapasPapbar.Appli;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace PapasPapbar.Domain
{
    public class Membership : Connection
    {
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string SubDate { get; set; }
        public string EndDate { get; set; }
        public int MemberNo { get; set; }

        public Membership() { }


        public Membership(string memberName, string memberEmail, string subDate, string endDate, int memberNo)
        {
            MemberName = memberName;
            MemberEmail = memberEmail;
            SubDate = subDate;
            EndDate = endDate;
            MemberNo = memberNo;
        }

        public void AddMembership(string memberName, string memberEmail, string subDate, string endDate)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("InsertMembership", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Member_Name", memberName);
                cmd.Parameters.AddWithValue("@Member_Email", memberEmail);
                cmd.Parameters.AddWithValue("@Sub_Date", subDate);
                cmd.Parameters.AddWithValue("@End_Date", endDate);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateMembership(string memberName, string memberEmail, string subDate, string endDate, int memberNo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UpdateMembership", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Member_Name", memberName);
                cmd.Parameters.AddWithValue("@Member_Email", memberEmail);
                cmd.Parameters.AddWithValue("@Sub_Date", subDate);
                cmd.Parameters.AddWithValue("@End_Date", endDate);
                cmd.Parameters.AddWithValue("@Member_No", memberNo);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteMembership(int memberNo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteMembership", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Member_No", memberNo);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
