using System;
using System.Globalization;
using System.Windows.Forms;

namespace HomeAffairsDigitalidentityProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            btnValidate.Click += btnValidate_Click;
            btnGenerateProfile.Click += btnGenerateProfile_Click;
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
            string id = txtID.Text.Trim();

            if (ValidateID(id, out int age))
            {
                label5.Text = $"Valid ID. Citizen is {age} years old.";
                label5.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label5.Text = "Invalid ID format.";
                label5.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnGenerateProfile_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string id = txtID.Text.Trim();
            string citizen = cmbCitizen.SelectedItem?.ToString() ?? "Not selected";

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

            // Must be 13 digits
            if (id.Length != 13 || !long.TryParse(id, out _))
                return false;

            // Extract birthdate from first 6 digits (YYMMDD)
            string birthDateStr = id.Substring(0, 6);
            if (!DateTime.TryParseExact(birthDateStr, "yyMMdd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime birthDate))
                return false;

            // Adjust century if needed (IDs often use 19xx or 20xx)
            if (birthDate > DateTime.Now)
                birthDate = birthDate.AddYears(-100);

            // Calculate age
            age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--;

            return true;
        }
    }
}
