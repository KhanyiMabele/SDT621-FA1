using System;
using System.Linq;
using System.Windows.Forms;

namespace Q3_FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Wire up button and control events (Designer wasn't wired)
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            textBox1.KeyDown += TextBox1_KeyDown;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            // Start with remove disabled until an item is selected
            btnRemove.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text?.Trim();
            if (string.IsNullOrEmpty(text))
            {
                label2.Text = $"Nothing to add - {DateTime.Now:G}";
                return;
            }

            // Prevent duplicates (case-insensitive)
            bool exists = listBox1.Items
                .Cast<object>()
                .Any(i => string.Equals(i?.ToString(), text, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                label2.Text = $"\"{text}\" already in the list - {DateTime.Now:G}";
                textBox1.SelectAll();
                textBox1.Focus();
                return;
            }

            listBox1.Items.Add(text);
            listBox1.SelectedIndex = listBox1.Items.Count - 1; // select new item
            label2.Text = $"Added \"{text}\" at {DateTime.Now:G}";
            textBox1.Clear();
            textBox1.Focus();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                label2.Text = $"No selection to remove - {DateTime.Now:G}";
                return;
            }

            var item = listBox1.SelectedItem?.ToString() ?? "<item>";
            int removedIndex = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(removedIndex);

            // adjust selection after removal
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = Math.Min(removedIndex, listBox1.Items.Count - 1);
            }

            label2.Text = $"Removed \"{item}\" at {DateTime.Now:G}";
            btnRemove.Enabled = listBox1.SelectedIndex >= 0;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                BtnAdd_Click(sender, EventArgs.Empty);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = listBox1.SelectedIndex >= 0;

            if (listBox1.SelectedIndex >= 0)
            {
                label2.Text = $"Selected \"{listBox1.SelectedItem}\" at {DateTime.Now:G}";
            }
        }
    }
}
