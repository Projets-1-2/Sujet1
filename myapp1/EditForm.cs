/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myapp1
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }
    }
}
*/
























using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace myapp1
{
    public partial class EditForm : Form
    {
        private int primaryKeyValue;
        private string selectedTableName;
        private string dbName;

        public EditForm(int primaryKeyValue, string selectedTableName, string dbName)
        {
            InitializeComponent();

            // Initialisez les variables de classe avec les valeurs passées depuis Form1
            this.primaryKeyValue = primaryKeyValue;
            this.selectedTableName = selectedTableName;
            this.dbName = dbName;

            // Récupérez les données pour la ligne à éditer et pré-remplissez les contrôles
            PopulateFormData();
        }

        private void PopulateFormData()
        {
            // Exemple: Récupérer les données pour la ligne sélectionnée à partir de la base de données
            DataTable table = FetchDataFromDatabase();

            if (table.Rows.Count > 0)
            {
                  ////textBox1.Text = table.Rows[0]["Column1"].ToString();
                  //comboBox1.SelectedItem = table.Rows[0]["Column2"].ToString();
                // Pré-remplissez d'autres contrôles si nécessaire
            }
        }

        private DataTable FetchDataFromDatabase()
        {
            // Exemple: Requête pour récupérer les données de la ligne sélectionnée
            string query = $"SELECT * FROM {selectedTableName} WHERE id = @id";
            DataTable table = new DataTable();

            using (MySqlConnection connection = new MySqlConnection($"server=localhost;user=root;database={dbName};"))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", primaryKeyValue);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la récupération des données : {ex.Message}");
                }
            }

            return table;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Optionnel: Ajoutez des méthodes pour valider et enregistrer les modifications

    }
}