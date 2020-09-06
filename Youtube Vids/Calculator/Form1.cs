using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double dblDisplay;
        private double dblDisplayRadian;
        private string action;
        private string action2;
        private double no1;
        private object resources;
        private Image prevImage;
        private Color prevBCol;

        public Form1()
        {
            InitializeComponent();
            reset("0");
        }

        private void reset(string zero="", string act="")
        {
            lblDisplay.Text = zero;
            dblDisplay = 0;
            lblAction.Text = act;
        }

        private void NumberClick(object sender, EventArgs e)
        {
            var o = ((Button)sender).Text;

            if (o == "." && lblDisplay.Text.Contains(".") == false)
            {
                lblDisplay.Text += o;
            }
            else if (o == "+/-")
            {
                lblDisplay.Text = dblDisplay > 0 ? "-" + lblDisplay.Text : (-1 * dblDisplay).ToString();
            }
            else
            {
                if (lblDisplay.Text == "0" ) lblDisplay.Text = "";
                if (lblDisplay.Text == "∞")
                {
                    setDisplayValue();
                    lblAction.Text = "";
                    action = "";
                }
                if (action == "+" || action == "-" || action == "x" || action == "÷" ||                    action2 != "")
                {
                    setDisplayValue();
                    action = "";
                    setAction2();
                }
                if (action == "Sqrt" || action == "x²" || action == "x³" || 
                    action == "x!" || action == "1/x" || action == "𝛑" ||
                    action == "Sin" || action == "Cos" || action == "Tan" || 
                    action == "Sin¨¹" || action == "Cos¨¹" || action == "Tan¨¹")
                {
                    setDisplayValue();
                    setAction1();
                    setAction2();

                }



                lblDisplay.Text += o;
            }
            dblDisplay = Convert.ToDouble(lblDisplay.Text);
        }

        private void setDisplayValue(string val="")
        {
            if (val.ToUpper()=="NAN")
            {
                lblDisplay.Text = "Invalid Number";
                dblDisplay = 0;
            }
            else
            {
                lblDisplay.Text = val;
                dblDisplay = Convert.ToDouble(val == "" ? "0" : val);
            }
        }

        private void ActionClick(object sender, EventArgs e)
        {
            dblDisplayRadian = (dblDisplay * (Math.PI)) / 180;
            action = lblAction.Text;
            var o = ((Button)sender).Text;
            if (o == "C")
            {
                reset("0");
            }
            else if (o == "=")
            {
                setAction2();
                if (action == "+")
                {
                    setDisplayValue((no1 + dblDisplay).ToString());
                }
                else if (action == "-")
                {
                    setDisplayValue((no1 - dblDisplay).ToString());
                }
                else if (action == "x")
                {
                    setDisplayValue((no1 * dblDisplay).ToString());
                }
                else if (action == "÷")
                {
                    setDisplayValue((no1 / dblDisplay).ToString());
                }
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                no1 = dblDisplay;
            }

            else if (o == "Sin")
            {
                lblDisplay.Text = Math.Sin(dblDisplayRadian).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Cos")
            {
                lblDisplay.Text = Math.Cos(dblDisplayRadian).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Tan")
            {
                lblDisplay.Text = Math.Tan(dblDisplayRadian).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Sec")
            {
                lblDisplay.Text = (1/Math.Sin(dblDisplayRadian)).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Cosec")
            {
                lblDisplay.Text = (1/Math.Cos(dblDisplayRadian)).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Cot")
            {
                lblDisplay.Text = (1/Math.Tan(dblDisplayRadian)).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Sinh")
            {
                lblDisplay.Text = Math.Sinh(dblDisplay).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Cosh")
            {
                lblDisplay.Text = Math.Cosh(dblDisplay).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Tanh")
            {
                lblDisplay.Text = Math.Tanh(dblDisplay).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Sech")
            {
                lblDisplay.Text = (1/Math.Sinh(dblDisplay)).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Cosech")
            {
                lblDisplay.Text = (1/Math.Cosh(dblDisplay)).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Tanh")
            {
                lblDisplay.Text = (1/Math.Tanh(dblDisplay)).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }

            else if (o == "Sin¨¹")
            {
                setDisplayValue(Math.Asin(dblDisplay).ToString());
                setAction2(o);

            }

            else if (o == "Cos¨¹")
            {
                setDisplayValue(Math.Acos(dblDisplay).ToString());
                setAction2(o);
            }
            else if (o == "Tan¨¹")
            {
                setDisplayValue(Math.Atan(dblDisplay).ToString());
                setAction2(o);
            }
            else if (o == "√¯")  // √
            {
                lblDisplay.Text = Math.Sqrt(dblDisplay).ToString();
                dblDisplay = Convert.ToDouble(lblDisplay.Text);
                setAction2(o);
            }
            else if (o == "x²")
            {
                setDisplayValue((dblDisplay * dblDisplay).ToString());
                setAction2(o);
            }
            else if (o == "x³")
            {
                setDisplayValue((dblDisplay * dblDisplay * dblDisplay).ToString());
                setAction2(o);
            }
            else if (o == "1/x")
            {
                setDisplayValue((1/ dblDisplay).ToString());
                setAction2(o);
            }
            else if (o == "x!")
            {
                if (lblDisplay.Text.Contains(".")) return;
                double no =1;
                for (int i = 1; i < dblDisplay+1; i++)
                {
                    no = no * i;
                }
                setDisplayValue(no.ToString());
                setAction2(o);
            }
            else if (o == "𝛑")
            {
                setDisplayValue(Math.PI.ToString());
                setAction2(o);
            }
            else
            {
                no1 = dblDisplay;
                setAction1(o);
            }

        }

        private void setAction1(string o="")
        {
            lblAction.Text = o;
            action = o;
        }

        private void setAction2(string o="")
        {
            lblAction2.Text = o;
            action2 = o;
        }

        private void NumberMouseOver(object sender, EventArgs e)
        {
            
        }

        private void NumberMouseEnter(object sender, EventArgs e)
        {
            var o = ((Button)sender);
            prevImage = ((Button)sender).BackgroundImage;
            if (prevImage!=null)
            {
                o.BackgroundImage = imageList1.Images[4];
                o.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else /*if (o.Text == "Sin" || o.Text == "Cos" || o.Text == "Tan" || o.Text == "2nd")*/
            {
                prevBCol = o.BackColor;
                o.BackColor = Color.FromArgb(99, 219, 224);
            }


        }

        private void NumberMouseLeave(object sender, EventArgs e)
        {
            var o = ((Button)sender);
            if (prevImage!=null)
            {
                o.BackgroundImage = prevImage;
            }
            else
            {
                o.BackColor = prevBCol;
            }
        }

        private void Btn2nd_Click(object sender, EventArgs e)
        {
            btnSin.Text = btnSin.Text == "Sin" || btnSin.Text == "Sinh" ? "Sin¨¹" : "Sin";
            btnCos.Text = btnCos.Text == "Cos" || btnCos.Text == "Cosh" ? "Cos¨¹" : "Cos";
            btnTan.Text = btnTan.Text == "Tan" || btnTan.Text == "Tanh" ? "Tan¨¹" : "Tan";

            btnsec.Text = btnsec.Text == "Sec" || btnsec.Text == "Sech" ? "Sec¨¹" : "Sec";
            btncsc.Text = btncsc.Text == "Cosec" || btncsc.Text == "Cosech" ? "Cosec¨¹" : "Cosec";
            btncot.Text = btncot.Text == "Cot" || btncot.Text == "Coth" ? "Cot¨¹" : "Cot";

        }

        private void Btnhyp_Click(object sender, EventArgs e)
        {
            btnSin.Text = btnSin.Text == "Sin" || btnSin.Text == "Sin¨¹" ? "Sinh" : "Sin";
            btnCos.Text = btnCos.Text == "Cos" || btnCos.Text == "Cos¨¹" ? "Cosh" : "Cos";
            btnTan.Text = btnTan.Text == "Tan" || btnTan.Text == "Tan¨¹" ? "Tanh" : "Tan";

            btnsec.Text = btnsec.Text == "Sec" || btnsec.Text == "Sec¨¹" ? "Sech" : "Sec";
            btncsc.Text = btncsc.Text == "Cosec" || btncsc.Text == "Cosec¨¹" ? "Cosech" : "Cosec";
            btncot.Text = btncot.Text == "Cot" || btncot.Text == "Cot¨¹" ? "Coth" : "Cot";
        }
    }
}
