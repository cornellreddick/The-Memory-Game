using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Memory_Game
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
           "f", "f", "b", "b", "h","h", "j", "j",
           "o", "o", "p","p", "q", "q", "u", "u"
        };

        Label firstClicked, secondClicked;

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquared();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
            {
                return;
            }

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
            {
                return;
            }

            if (clickedLabel.ForeColor == Color.Black)
            {
                return;
            }

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckForWinner();

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }
            else
            {
                timer1.Start();
            }
            
        }

        private void CheckForWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                {
                    return;
                }
            }
            MessageBox.Show("You mathced all the icons! Your a Winner!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;

        }

        private void AssignIconsToSquared()
        {
            Label label;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }
                else
                {
                    continue;
                }

                randomNumber = random.Next(0, icons.Count());
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
                
            }
        }
    }
}
