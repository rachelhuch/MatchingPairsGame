using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MatchingPairsGame
{
    public partial class MatchingPairs : Form
    {
        Label firstClicked = null;//keeping track of first and second labels that have been clicked
        Label secondClicked = null;

        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!","N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"

        };




        public MatchingPairs()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {

                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    iconLabel.ForeColor = iconLabel.BackColor;//makes it the same color as background color so you can't see it

                    icons.RemoveAt(randomNumber);
                }
            }


        }

        private void label_click(object sender, EventArgs e)
        {
            if(timer1.Enabled ==true)
            {
                return;
            }
            
            //class label w/ local variable clickedLabel
            Label clickedLabel = sender as Label; //sender identifies which label was clicked

            //if the clickedlabel has been converted from an object to label control 
            if(clickedLabel != null)
            {
                if(clickedLabel.ForeColor == Color.Black)//icon has been chosen and method is done
                {
                    return;//stop executing the code
                }

                if(firstClicked ==null)
                {
                    //if the first clicked is null- it hasn't been clicked, then turn the icon black and this is 
                    //the first icon
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                //clickedLabel.ForeColor = Color.Black; //if it hasn't been chosen then change the text color to black

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                
                CheckForWinner();
                
                if (firstClicked.Text == secondClicked.Text)//if identical then reset
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                        
                }
                timer1.Start();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();//stop the timer and reset
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
          
        }

        public void CheckForWinner()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if(iconLabel !=null)
                {
                    if(iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("Congratulations, you win!");
            Close();
        }
    }
}
