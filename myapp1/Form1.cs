using MySql.Data.MySqlClient;
using System.Data;
using System.Xml;
using System.Xml.Linq;
 

namespace myapp1
{
    public partial class Form1 : Form
    {
        private string dbName;
        private string selectedTableName; // Variable to store selected table name

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
        public class TableMetadata
        {
            public string TableName { get; set; }
            public List<string> AssociatedTables { get; set; }
        }




        private void PopulateTablesTextBox(string dbName)
        {
            string connStr = $"server=localhost;user=root;database={dbName};";
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    DataTable schema = connection.GetSchema("Tables");

                    // Clear existing controls in panel1
                    panel1.Controls.Clear();

                    int panelTop = 60; // Starting top position for panels
                    Label titleLabel = new Label();
                    titleLabel.Text = "Tables";
                    titleLabel.Font = new Font("Arial", 14, FontStyle.Bold); // Example: Adjust font size and style
                    titleLabel.AutoSize = true;
                    titleLabel.Location = new Point(20, 10); // Adjust the X and Y position as needed
                    panel1.Controls.Add(titleLabel);

                    foreach (DataRow row in schema.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();

                        // Create a new panel for each table name
                        Panel tablePanel = new Panel();
                        tablePanel.BackColor = SystemColors.Window;
                        tablePanel.BorderStyle = BorderStyle.FixedSingle;
                        tablePanel.Location = new Point(17, panelTop);
                        tablePanel.Tag = tableName; // Store table name in Tag property

                        // Create a label inside the panel to display table name
                        Label label = new Label();
                        label.Text = tableName;
                        label.AutoSize = true;
                        label.BackColor = SystemColors.Window;
                        label.Location = new Point(10, 10);

                        // Set the size of the tablePanel based on the label's size plus padding
                        tablePanel.Size = new Size(label.Width + 20, label.Height + 20); // Adjust padding as needed

                        // Add label to the panel
                        tablePanel.Controls.Add(label);

                        // Add click event handler to panel
                        tablePanel.Click += TablePanel_Click;

                        // Add panel to panel1
                        panel1.Controls.Add(tablePanel);

                        // Increment top position for the next panel
                        panelTop += tablePanel.Height + 10; // Add some spacing between panels

                        // Determine associated tables (foreign keys)
                        List<string> associatedTables = GetAssociatedTables(connection, dbName, tableName);
                        tablePanel.Tag = new TableMetadata { TableName = tableName, AssociatedTables = associatedTables };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching tables: {ex.Message}");
                }
            }
        }



        private List<string> GetAssociatedTables(MySqlConnection connection, string dbName, string tableName)
        {
            List<string> associatedTables = new List<string>();

            string query = $@"
            SELECT TABLE_NAME
            FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
            WHERE REFERENCED_TABLE_SCHEMA = '{dbName}'
            AND REFERENCED_TABLE_NAME = '{tableName}';
        ";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string associatedTable = reader["TABLE_NAME"].ToString();
                    associatedTables.Add(associatedTable);
                }
            }

            return associatedTables;
        }

        private void TablePanel_Click(object sender, EventArgs e)
        {
            // Retrieve table name and associated tables from the clicked panel's Tag property
            if (sender is Panel clickedPanel && clickedPanel.Tag is TableMetadata tableMetadata)
            {
                // Store the selected table name
                selectedTableName = tableMetadata.TableName;

                // Load data for the clicked table into panel2
                LoadTableDataIntoPanel(dbName, tableMetadata.TableName, panel2);

                // Clear panel8 first
                panel8.Controls.Clear();


                // Optionally, load data for associated tables into panel8
                if (tableMetadata.AssociatedTables != null && tableMetadata.AssociatedTables.Count > 0)
                {
                    foreach (string associatedTable in tableMetadata.AssociatedTables)
                    {
                        LoadTableDataIntoPanel(dbName, associatedTable, panel8);
                    }
                }
                else
                {
                    // If there are no associated tables, ensure panel8 is empty
                    panel8.Controls.Clear();
                }
            }
        }
        /*
        private void LoadTableDataIntoPanel(string dbName, string tableName, Panel targetPanel)
        {
            string connStr = $"server=localhost;user=root;database={dbName};";
            string query = $"SELECT * FROM {tableName};";

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Clear existing controls in the target panel
                    targetPanel.Controls.Clear();

                    // Display table data in the target panel (example: using a DataGridView)
                    DataGridView dgv = new DataGridView();
                    dgv.DataSource = table;
                    dgv.Dock = DockStyle.Fill;
                    targetPanel.Controls.Add(dgv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading table data: {ex.Message}");
                }
            }
        }
        */
        /*
        private void LoadTableDataIntoPanel(string dbName, string tableName, Panel targetPanel)
        {
            string connStr = $"server=localhost;user=root;database={dbName};";
            string query = $"SELECT * FROM {tableName};";

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Clear existing controls in the target panel
                    targetPanel.Controls.Clear();

                    // Display table data in the target panel (example: using a DataGridView)
                    DataGridView dgv = new DataGridView();
                    dgv.DataSource = table;
                    dgv.Dock = DockStyle.Fill;

                    // Customize DataGridView appearance
                    dgv.DefaultCellStyle.BackColor = Color.LightYellow; // Example color for cell background
                    dgv.DefaultCellStyle.ForeColor = Color.Black; // Example color for cell text
                    dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue; // Example color for row background

                    targetPanel.Controls.Add(dgv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading table data: {ex.Message}");
                }
            }
        }
        
        */
        private DataGridView dgv; // Declare a DataGridView at the class level for access in other methods

        private void LoadTableDataIntoPanel(string dbName, string tableName, Panel targetPanel)
        {
            string connStr = $"server=localhost;user=root;database={dbName};";
            string query = $"SELECT * FROM {tableName};";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Clear existing controls in the target panel
                    targetPanel.Controls.Clear();

                    // Initialize DataGridView
                    dgv = new DataGridView();
                    dgv.DataSource = table;
                    dgv.Dock = DockStyle.Fill;

                    // Customize DataGridView appearance
                    dgv.DefaultCellStyle.BackColor = Color.LightYellow; // Example color for cell background
                    dgv.DefaultCellStyle.ForeColor = Color.Black; // Example color for cell text
                    dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue; // Example color for row background

                    // Allow editing in DataGridView
                    dgv.ReadOnly = false; // Set to false to allow editing
                    dgv.EditMode = DataGridViewEditMode.EditOnEnter; // Edit mode when cell is clicked

                    // Add DataGridView to the panel
                    targetPanel.Controls.Add(dgv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading table data: {ex.Message}");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a table is selected
            if (!string.IsNullOrEmpty(selectedTableName))
            {
                // Check if there is a DataGridView in panel2
                DataGridView dgv = panel2.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dgv != null)
                {
                    // Check if a row is selected in the DataGridView
                    if (dgv.SelectedRows.Count > 0)
                    {
                        // Get the selected row
                        DataGridViewRow selectedRow = dgv.SelectedRows[0];

                        // Get the column name with AUTO_INCREMENT
                        string autoIncrementColumn = GetAutoIncrementColumn(selectedTableName);

                        if (!string.IsNullOrEmpty(autoIncrementColumn))
                        {
                            // Get the primary key value of the selected row for AUTO_INCREMENT column
                            int primaryKeyValue = Convert.ToInt32(selectedRow.Cells[autoIncrementColumn].Value);

                            // Delete row from the database
                            DeleteRowFromDatabase(selectedTableName, autoIncrementColumn, primaryKeyValue);

                            // Remove row from DataGridView (panel2)
                            dgv.Rows.Remove(selectedRow);

                            MessageBox.Show($"Row with primary key {primaryKeyValue} deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show($"No AUTO_INCREMENT column found for table '{selectedTableName}'.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a row to delete.");
                    }
                }
                else
                {
                    MessageBox.Show("No data to delete.");
                }
            }
            else
            {
                MessageBox.Show("Please select a table first.");
            }
        }

        private string GetAutoIncrementColumn(string tableName)
        {
            string connStr = $"server=localhost;user=root;database={dbName};";
            string query = $@"SHOW COLUMNS FROM {tableName} WHERE Extra = 'auto_increment';";
            string autoIncrementColumn = "";

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            autoIncrementColumn = reader["Field"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving auto_increment column for table '{tableName}': {ex.Message}");
                }
            }

            return autoIncrementColumn;
        }

        private void DeleteRowFromDatabase(string tableName, string autoIncrementColumn, int primaryKeyValue)
        {
            string connStr = $"server=localhost;user=root;database={dbName};";
            string deleteQuery = $"DELETE FROM {tableName} WHERE {autoIncrementColumn} = @id";

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                    cmd.Parameters.AddWithValue("@id", primaryKeyValue);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Row deleted from table '{tableName}' with {autoIncrementColumn} {primaryKeyValue}.");
                    }
                    else
                    {
                        MessageBox.Show($"No rows deleted from table '{tableName}'.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting row from table '{tableName}': {ex.Message}");
                }
            }
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        //////////////////////////////////private void button2_Click(object sender, EventArgs e)

        private void button2_Click(object sender, EventArgs e)
        {
            // Vérifier si une table est sélectionnée
            if (!string.IsNullOrEmpty(selectedTableName))
            {
                // Vérifier s'il y a un DataGridView dans panel2
                DataGridView dgv = panel2.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dgv != null)
                {
                    // Vérifier s'il y a une ligne sélectionnée dans le DataGridView
                    if (dgv.SelectedRows.Count > 0)
                    {
                        // Obtenir la valeur de la clé primaire de la ligne sélectionnée
                        DataGridViewRow selectedRow = dgv.SelectedRows[0];
                        int primaryKeyValue = Convert.ToInt32(selectedRow.Cells["id"].Value);

                        // Appeler la méthode pour éditer la ligne
                        EditRow(primaryKeyValue);
                    }
                    else
                    {
                        MessageBox.Show("Veuillez sélectionner une ligne à éditer.");
                    }
                }
                else
                {
                    MessageBox.Show("Aucune donnée à éditer.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez d'abord sélectionner une table.");
            }
        }
        
        private void EditRow(int primaryKeyValue)
        {
            // Ouvrir le formulaire de modification pour la ligne sélectionnée dans Form2
            using (var editForm = new EditForm(primaryKeyValue, selectedTableName, dbName))
            {
                var result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Les données ont été mises à jour avec succès dans le formulaire de modification
                    MessageBox.Show("Ligne mise à jour avec succès.");

                    // Recharger les données dans panel2 après la mise à jour (si nécessaire)
                    LoadTableDataIntoPanel(dbName, selectedTableName, panel2);
                }
                else
                {
                    // Optionnel : Gérer l'annulation ou les erreurs du formulaire de modification
                    MessageBox.Show("Opération de modification annulée ou échouée.");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbName = textBox1.Text.Trim(); // Assuming textBox1 contains the database name

            if (!string.IsNullOrEmpty(dbName))
            {
                PopulateTablesTextBox(dbName);
            }
            else
            {
                MessageBox.Show("Please enter a database name.");
            }
        }

    }

}
