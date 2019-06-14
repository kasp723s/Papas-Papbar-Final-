using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapasPapbar.Domain
{
    public class Reservation : Connection
    {
       
        public string ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public string CustommerName { get; set; }
        public string Participant { get; set; }
        public int ReservationTable { get; set; }
        public string ReservationCommant { get; set; }
        public int ReservationId { get; set; }

        public Reservation() { }

        public Reservation(string reservationDate, string reservationTime, string custommerName, string participant, int reservationTable, string reservationCommant, int reservationId)
        {
            ReservationDate = reservationDate;
            ReservationTime = reservationTime;
            CustommerName = custommerName;
            Participant = participant;
            ReservationTable = reservationTable;
            ReservationCommant = reservationCommant;
            ReservationId = reservationId;
        }

        public void AddReservation(string reservationDate, string reservationTime, string custommerName, string participant, string reservationCommant)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("InsertReservation", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rerservation_Date", reservationDate);
                cmd.Parameters.AddWithValue("@Reservation_Time", reservationTime);
                cmd.Parameters.AddWithValue("@Customer_Name", custommerName);
                cmd.Parameters.AddWithValue("@Participant", participant);
                cmd.Parameters.AddWithValue("@Comments", reservationCommant);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteReservation(int reservationId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("DeleteReservation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReservationId", reservationId);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
