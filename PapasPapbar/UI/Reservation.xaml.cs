using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PapasPapbar.UI
{
    /// <summary>
    /// Interaction logic for Reservation.xaml
    /// </summary>
    public partial class Reservation : Window
    {
        public Reservation()
        {
            InitializeComponent();
        }

        public Appli.ReservationRepos reservationRepo = new Appli.ReservationRepos();
        private Domain.Reservation reservation = new Domain.Reservation();
        private int reservationId;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowData_Reservation();
            DataGrid3.Columns[4].Visibility = Visibility.Collapsed;
        }

        private void AddReservation_Click(object sender, RoutedEventArgs e)
        {
            reservation.ReservationDate = txtReservationDate.Text.ToString();

            if (txtReservationTime != null && txtCustomerName != null && txtParticipant != null && txtReservationComment != null)
            {
                reservation.ReservationDate = txtReservationDate.Text;
                reservation.ReservationTime = txtReservationTime.Text;
                reservation.CustommerName = txtCustomerName.Text;
                reservation.Participant = txtReservationComment.Text;

                reservationRepo.AddReservation(reservation);
                MessageBox.Show("Reservation er tilføjet");
                ShowData_Reservation();
                Reset_Reservation();
            }
            else
            {
                MessageBox.Show("Noget gik galt");
            }
        }

        private void DeleteReservation_Click(object sender, RoutedEventArgs e)
        {
            reservationRepo.DeleteReservation(reservation.ReservationId);
            this.Close();
        }

        private void UpdateReservation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetReservation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reset_Reservation()
        {
            txtReservationId.Text = "";
            txtReservationDate.Text = "";
            txtReservationTime.Text = "";
            txtCustomerName.Text = "";
            txtParticipant.Text = "";
            txtReservationComment.Text = "";
            txtReservationTable.Text = "";
            txtCustomerName.Focus();
            UpdateReservation.IsEnabled = false;
            DeleteReservation.IsEnabled = false;
            AddReservation.IsEnabled = true;
        }

        private void DataGrid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = (DataGrid)sender;
                DataRowView rowSelected = dg.SelectedItem as DataRowView;
                if (rowSelected != null)
                {
                    txtReservationId.Text = rowSelected[6].ToString();
                    txtReservationDate.Text = rowSelected[0].ToString();
                    txtReservationTime.Text = rowSelected[1].ToString();
                    txtCustomerName.Text = rowSelected[2].ToString();
                    txtParticipant.Text = rowSelected[3].ToString();
                    txtReservationComment.Text = rowSelected[4].ToString();
                    txtReservationTable.Text = rowSelected[5].ToString();
                }
                UpdateReservation.IsEnabled = true;
                DeleteReservation.IsEnabled = true;
                AddReservation.IsEnabled = false;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private SqlCommand cmd;
        private SqlDataReader rdr;
        public string connectionString =
                    "Server=EALSQL1.eal.local; " +
                    "Database= C_DB13_2018; " +
                    "User Id=C_STUDENT13; " +
                    "Password=C_OPENDB13;";

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                cmd = new SqlCommand("Select Reservation_ID, Rerservation_Date, Reservation_Time, Customer_Name, Participant, Comments, Table_Group_Id From Reservation " +
                    "Where Rerservation_Date Like '%" + txtSearch.Text.Trim() + "%' OR Reservation_Time Like '%" + txtSearch.Text.Trim() + "%' OR Customer_Name Like '%" + 
                    txtSearch.Text.Trim() + "%' OR Participant Like '%" + txtSearch.Text.Trim() + "%' OR Comments Like '%" + txtSearch.Text.Trim() + "%' Order By Reservation_ID Desc", con);
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                DataGrid3.ItemsSource = dt.DefaultView;
                con.Close();
                DataGrid3.Columns[4].Visibility = Visibility.Collapsed;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void ShowData_Reservation()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Select Reservation_ID, Rerservation_Date, Reservation_Time, Customer_Name, Participant, Comments, Table_Group_Id From Reservation", con);
                    rdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    DataGrid3.ItemsSource = dt.DefaultView;
                    con.Close();
                    DataGrid3.Columns[4].Visibility = Visibility.Collapsed;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }

        private void Reservation_Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Switch = new MainWindow();
            Switch.Show();
            Close();
        }
    }
}
