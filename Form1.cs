using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ITP4915M_Lab05
{
    /// <summary>
    /// Represents the main form of the ITP4915M Lab05 application.
    /// This form displays data from the "Books" and "Users" tables
    /// in two DataGridView controls: dgvBooks and dgvUsers.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The connection string used to establish a connection to the Access database.
        /// Adjust the provider (ACE.OLEDB.12.0 or ACE.OLEDB.16.0) as needed.
        /// </summary>
        private string _connectionString =
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\lib.accdb;";

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the form.  
        /// Fetches data from the "Books" table and the "Users" table,
        /// and displays them in dgvBooks and dgvUsers respectively.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs"/> that contains the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // --- FIRST using block: Fetch Books data ---
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            {
                // conn.Open() establishes a live connection to the database.
                // You must open the connection before executing queries.
                conn.Open();

                // Define the SELECT query for retrieving all records from Books.
                string sqlBooks = "SELECT * FROM Books";

                // Create an adapter to execute the query and fill a DataTable.
                OleDbDataAdapter adapterBooks = new OleDbDataAdapter(sqlBooks, conn);

                // The DataTable that will hold all records from the Books table.
                DataTable booksTable = new DataTable();

                // Fill the DataTable using the adapter.
                adapterBooks.Fill(booksTable);

                // Display the Books data in the dgvBooks DataGridView.
                dgvBooks.DataSource = booksTable;
            }

            // --- SECOND using block: Fetch Users data ---
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            {
                // Again, open the connection so we can query the database.
                conn.Open();

                // Define the SELECT query for retrieving all records from Users.
                string sqlUsers = "SELECT * FROM Users";

                // Create an adapter to execute the query and fill a DataTable.
                OleDbDataAdapter adapterUsers = new OleDbDataAdapter(sqlUsers, conn);

                // The DataTable that will hold all records from the Users table.
                DataTable usersTable = new DataTable();

                // Fill the DataTable using the adapter.
                adapterUsers.Fill(usersTable);

                // Display the Users data in the dgvUsers DataGridView.
                dgvUsers.DataSource = usersTable;
            }
        }
    }
}
