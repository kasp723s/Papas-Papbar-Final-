using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PapasPapbar.Domain;

namespace PapasPapbar.Appli
{
    public class ReservationRepos
    {
        private Reservation reservation = new Reservation();

        public void AddReservation(Reservation reservation)
        {
            reservation.AddReservation(reservation.ReservationDate, reservation.ReservationTime, reservation.CustommerName, reservation.Participant, reservation.ReservationCommant);
        }
        public void DeleteReservation(int reservationId)
        {
            reservation.DeleteReservation(reservation.ReservationId);
        }
    }
}
