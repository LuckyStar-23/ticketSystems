using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Windows.Forms; // Added to ensure Form and MessageBox are recognized

namespace ticketSystems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string haradan = comboBox1.Text;
            string haraya = comboBox2.Text;
            string tarix = maskedTextBox1.Text;
            string saat = maskedTextBox2.Text;
            string yer = textBox1.Text;
            string adSoyad = textBox2.Text;
            string fin = textBox3.Text;
            string telefon = maskedTextBox3.Text;
            string email = textBox4.Text;

            if (string.IsNullOrWhiteSpace(adSoyad) ||
                string.IsNullOrWhiteSpace(fin) ||
                string.IsNullOrWhiteSpace(telefon) ||
                string.IsNullOrWhiteSpace(email) ||
                comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(tarix) ||
                string.IsNullOrWhiteSpace(saat) ||
                string.IsNullOrWhiteSpace(yer))
            {
                MessageBox.Show("Zəhmət olmasa bütün xanaları doldurun!", "Xəta");
                return;
            }
            if (!FinYoxla(fin) || !EmailYoxla(email))
            {
                return;
            }

            string info = $"Marsrut: {haradan} → {haraya} | Tarix: {tarix} | Saat: {saat} | " +
                            $"Yer: {yer} | Sərnisin: {adSoyad} | FİN: {fin} | Tel: {telefon} | Email: {email}";
            listBox1.Items.Add(info);

            MessageBox.Show("Bilet uğurla əlavə olundu!", "Məlumat");

            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        } 

        private bool FinYoxla(string fin)
        {
            if (fin.Length != 7)
            {
                MessageBox.Show("FİN 7 simvoldan ibarət olmalıdır!", "Xəta");
                return false;
            }
            foreach (char c in fin)
            {
                if (!char.IsUpper(c) && !char.IsDigit(c))
                {
                    MessageBox.Show("FİN yalnız böyük hərf və rəqəmlərdən ibarət ola bilər!", "Xəta");
                    return false;
                }
            }
            return true;
        }
        private bool EmailYoxla(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                MessageBox.Show("Email düzgün formatda deyil! (nümunə: example@mail.com)", "Xəta");
                return false;
            }
            return true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                MessageBox.Show("Seçilmiş bilet siyahıdan silindi.", "Məlumat");
            }
            else
            {
                MessageBox.Show("Zəhmət olmasa silmək üçün siyahıdan bilet seçin!", "Xəta");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox1.Text) &&
                !string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                string temp = comboBox1.Text;
                comboBox1.Text = comboBox2.Text;
                comboBox2.Text = temp;
            }
            else
            {
                MessageBox.Show("Zəhmət olmasa hər iki məntəqəni seçin!", "Xəta");
            }
        }
    }
}