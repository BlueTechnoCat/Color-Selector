using BlueTechno;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Selector_de_Colores
{
    public partial class Form1 : Form
    {
        private readonly DialogResult dialogResult = new DialogResult();

        public Form1()
        {
            InitializeComponent();
            dialogResult = MessageBox.Show("Do you speak Spanish?","Language",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
           
            if (dialogResult == DialogResult.Yes)
            {
                Text = "Selector de Colores";
                button1.Text = "Colorear";
            }
            else if (dialogResult == DialogResult.No)
            {
                Text = "Color Selector";
                button1.Text = "Paint";
            }

            label1.Text = "";
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MaximizeBox = false;
        }

        private void TextBoxHandler(TextBox textBox)
        {
            try
            {
                if (textBox.Text == "")
                {
                    return;
                }

                if (Convert.ToInt32(textBox.Text) > 255)
                {
                    textBox.Text = "255";
                }
            }

            catch (Exception)
            {
                textBox.Clear();
            }
        }

        private void EnterPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int A, B, C;
            string AA, BB, CC;

            try
            {

                A = Convert.ToInt32(textBox1.Text);
                B = Convert.ToInt32(textBox2.Text);
                C = Convert.ToInt32(textBox3.Text);

            }

            catch (Exception)
            {
                return;
            }

            pictureBox1.BackColor = Color.FromArgb(A, B, C);

            AA = Converters.DecimalToHexadecimal(A);
            BB = Converters.DecimalToHexadecimal(B);
            CC = Converters.DecimalToHexadecimal(C);

            label1.Text = AA + BB + CC;
        }

        #region TextChanged

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextBoxHandler(textBox1);
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            TextBoxHandler(textBox2);
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            TextBoxHandler(textBox3);
        }

        #endregion

        #region Key Down

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            EnterPress(sender, e);
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            EnterPress(sender, e);
        }

        private void TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            EnterPress(sender, e);
        }

        private void Button1_KeyDown(object sender, KeyEventArgs e)
        {
            EnterPress(sender, e);
        }

        #endregion

    }
}
