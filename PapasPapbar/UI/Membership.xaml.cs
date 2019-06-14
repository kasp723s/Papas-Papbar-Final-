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
using PapasPapbar.Appli;

namespace PapasPapbar.UI
{
    /// <summary>
    /// Interaction logic for Membership.xaml
    /// </summary>
    public partial class Membership : Window
    {

        public MembershipRepos membershipRepos = new MembershipRepos();
        private Domain.Membership membership = new Domain.Membership();
        private int memberNo;

        public Membership()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowData_Membership();
            DataGrid2.Columns[4].Visibility = Visibility.Collapsed;
        }

        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            membership.MemberName = txtMemberName.Text.ToString();

            if (txtEmail != null && txtSubDate != null && txtEndDate != null)
            {
                membership.MemberName = txtMemberName.Text;
                membership.MemberEmail = txtEmail.Text;
                membership.SubDate = txtSubDate.Text;
                membership.EndDate = txtEndDate.Text;

                membershipRepos.InsertMembership(membership);
                MessageBox.Show("Medlem er tilføjet");
                ShowData_Membership();
                Reset_Member();
            }
            else
            {
                MessageBox.Show("Noget gik galt");
            }
        }

        private void DeleteMember_Click(object sender, RoutedEventArgs e)
        {
            membershipRepos.DeleteMembership(memberNo);
            ShowData_Membership();
            Reset_Member();
        }

        private void UpdateMember_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail != null && txtSubDate != null && txtEndDate != null)
            {
                membership.MemberName = txtMemberName.Text;
                membership.MemberEmail = txtEmail.Text;
                membership.SubDate = txtSubDate.Text;
                membership.EndDate = txtEndDate.Text;

                membershipRepos.UpdateMembership(membership);
                MessageBox.Show("Brætspil er opdateret");
                ShowData_Membership();
                Reset_Member();
            }
            else
            {
                MessageBox.Show("Noget gik galt, prøv igen");
            }
        }

        private void ResetMember_Click(object sender, RoutedEventArgs e)
        {
            Reset_Member();
        }

        private void Reset_Member()
        {
            txtMemberName.Text = "";
            txtEmail.Text = "";
            txtSubDate.Text = "";
            txtEndDate.Text = "";
            txtMemberName.Focus();
            UpdateMember.IsEnabled = false;
            DeleteMember.IsEnabled = false;
            AddMember.IsEnabled = true;
        }

        private void DataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = (DataGrid)sender;
                DataRowView rowSelected = dg.SelectedItem as DataRowView;
                if (rowSelected != null)
                {
                    txtMemberNo.Text = rowSelected[6].ToString();
                    txtMemberName.Text = rowSelected[0].ToString();
                    txtEmail.Text = rowSelected[1].ToString();
                    txtSubDate.Text = rowSelected[2].ToString();
                    txtEndDate.Text = rowSelected[3].ToString();
                }
                UpdateMember.IsEnabled = true;
                DeleteMember.IsEnabled = true;
                AddMember.IsEnabled = false;
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
                cmd = new SqlCommand("Select Member_No, Member_Name, Member_Email, Sub_Date, End_Date From Membership Where Member_Name Like '%" + 
                    txtSearch.Text.Trim() + "%' OR Member_Email Like '%" + txtSearch.Text.Trim() + "%' OR Sub_Date Like '%" + txtSearch.Text.Trim() + 
                    "%' OR End_Date Like '%" + txtSearch.Text.Trim() + "%' Order By Member_No Desc", con);
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                DataGrid2.ItemsSource = dt.DefaultView;
                con.Close();
                DataGrid2.Columns[4].Visibility = Visibility.Collapsed;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void ShowData_Membership()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Select Member_No, Member_Name, Member_Email, Sub_Date, End_Date From Game_Library", con);
                    rdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    DataGrid2.ItemsSource = dt.DefaultView;
                    con.Close();
                    DataGrid2.Columns[4].Visibility = Visibility.Collapsed;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }

        private void Member_Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Switch = new MainWindow();
            Switch.Show();
            Close();
        }

    }
}
