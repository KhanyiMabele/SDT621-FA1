using System;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HomeAffairsDigitalidentityProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate citizenship dropdown
            cmbCitizen.Items.Add("South African");
            cmbCitizen.Items.Add("Permanent Resident");
            cmbCitizen.Items.Add("Foreigner");
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (ValidateID(id, out int age))
            {
                label4.Text = $"Valid ID. Citizen is {age} years old.";
            }
            else
            {
                label4.Text = "Invalid ID format.";
            }
        }

        private void btnGenerateProfile_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string id = txtID.Text;
            string citizen = cmbCitizen.SelectedItem?.ToString();

            if (ValidateID(id, out int age))
            {
                richTextBox1.Text =
                    "==== DIGITAL CITIZEN SUMMARY ====\n" +
                    $"Name: {name}\n" +
                    $"ID Number: {id}\n" +
                    $"Age: {age}\n" +
                    $"Citizenship: {citizen}\n" +
                    $"Validation: Valid ID. Citizen is {age} years old.\n" +
                    "Processed at: Home Affairs Digital Desk\n" +
                    $"Timestamp: {DateTime.Now}";
            }
            else
            {
                richTextBox1.Text = "Profile generation failed. Invalid ID.";
            }
        }

        private bool ValidateID(string id, out int age)
        {
            age = 0;
            if (id.Length != 13 || !long.TryParse(id, out _))
                return false;

            // Extract birthdate from first 6 digits (YYMMDD)
            string birthDateStr = id.Substring(0, 6);
            if (!DateTime.TryParseExact(birthDateStr, "yyMMdd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime birthDate))
                return false;

            // Calculate age
            age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--;

            return true;
        }
    }
}
