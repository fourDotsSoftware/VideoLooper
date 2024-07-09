using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace VideoLooper
{
    public partial class TimeUpDownControl : UserControl
    {
        public string LastAcceptedValue = "";

        public DataTable dtTimeUpDown = null;
        public int RowIndex = 0;
        public int ColumnIndex = 0;
        public int MsecsColumnIndex = -1;
                
        private TimeSpan _Time;
        public TimeSpan Time
        {
            set
            {
                _Time = value;
            }
            get
            {
                return _Time;
            }
        }

        public TimeUpDownControl()
        {
            InitializeComponent();
            Time = new TimeSpan(0, 0, 0, 0, 0);
            nUpDown.Maximum = (decimal)1000000000000000;
            nUpDown.Minimum = -(decimal)1000000000000000;
            nUpDown.Value = 0;
            OldValue = 0;

            txtBox.Focus();

            txtBox.KeyPress += txtBox_KeyPress;

            txtBox.Validating += txtBox_Validating;
            

        }

        void txtBox_Validating(object sender, CancelEventArgs e)
        {
            int msecs = TimeUpDownControl.StringToMsecs(this.Text);            

            this.Text = TimeUpDownControl.MsecsToString(msecs);

        }

        void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int msecs = TimeUpDownControl.StringToMsecs(this.Text);

            this.Text = TimeUpDownControl.MsecsToString(msecs);
        }

        public string Text
        {
            get
            {
                return txtBox.Text;
            }
            set
            {
                txtBox.Text = value;
                Time = TextBoxTimeSpanValue;
            }
        }

        public string StringValue
        {
            get
            {
                return Time.Hours.ToString("D2") + ":" + Time.Minutes.ToString("D2") + ":" + Time.Seconds.ToString("D2") + "." + Time.Milliseconds.ToString("D3");
            }
        }

        public TimeSpan TextBoxTimeSpanValue
        {
            get
            {
                return new TimeSpan(0, int.Parse(txtBox.Text.Substring(0, 2)),
                    int.Parse(txtBox.Text.Substring(3, 2)),
                    int.Parse(txtBox.Text.Substring(6, 2)),
                    int.Parse(txtBox.Text.Substring(9, 3)));

            }
        }
        
        public static TimeSpan StringToTimeSpan(string str)
        {
            if (str.Length == 11)
            {
                return new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2)),
                        int.Parse(str.Substring(9, 2))*10);
            }
            else if (str.Length == 8)
            {
                //00:00:00
                return new TimeSpan(0, 0,int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2))*10);
            }
            else if (str.Length == 7)
            {
                // 00:12.7
                return new TimeSpan(0, 0,
                        int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)), 
                        int.Parse(str.Substring(6, 1))*100);
            }
            else if (str.Length == 9)
            {
                // 01:00:12.7
                return new TimeSpan(0, 
                        int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2)),
                        int.Parse(str.Substring(8, 1)) * 100);
            }
            else if ((str.Length==3 || str.Length==4) && str.Contains(".") && !str.Contains(":"))
            {
                // 30.8
                // 120.8

                return new TimeSpan(0, 0,0,int.Parse(str.Substring(0,str.Length-2)),int.Parse(str.Substring(str.Length-1))*100);

            }
            else
            {
                try
                {
                    return new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                            int.Parse(str.Substring(3, 2)),
                            int.Parse(str.Substring(6, 2)),
                            int.Parse(str.Substring(9, 3)));
                }
                catch
                {
                    return new TimeSpan(0);
                }
            }
        }

        public static string TimeSpanToString(TimeSpan ts)
        {
            return ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + ts.Milliseconds.ToString("D3");
        }

        public static string MsecsToString(int msecs)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);

            string str = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + ts.Milliseconds.ToString("D3");

            return str;
        }

        public static string MsecsToStringShort(int msecs)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);
            string str = "";

            if (ts.Hours != 0)
            {
                str += ts.Hours.ToString("D2") + ":";
            }

            str += ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

            return str;
        }

        public static string MsecsToStringDuration(int msecs)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);
            string str = "";

            if (ts.Hours != 0)
            {
                str += ts.Hours.ToString("D2") + ":";
            }

            if (ts.Minutes != 0 || ts.Hours != 0)
            {
                str += ts.Minutes.ToString("D2") + ":";
            }

            str+=ts.Seconds.ToString("D2") + "."+ts.Milliseconds.ToString("D3");

            return str;
        }

        public static int StringToMsecs(string str)
        {
            TimeSpan ts = StringToTimeSpan(str);

            return (int)ts.TotalMilliseconds;
        }

        public static int StringSecsToMsecs(string str)
        {
            //431.586
            //4.18268

            int dotpos = str.IndexOf(".");

            if (dotpos > 0)
            {
                string secs = str.Substring(0, dotpos);
                string msecs = str.Substring(dotpos + 1, Math.Min(3, str.Length - dotpos - 1));
                int isecs = int.Parse(secs);
                int imsecs = int.Parse(msecs);

                // get three digits... .1=100, .15=150

                for (int k = msecs.Length; k < 3; k++)
                {
                    imsecs *= 10;
                }

                TimeSpan ts = new TimeSpan(0, 0, 0, isecs, imsecs);

                return (int)ts.TotalMilliseconds;
            }
            else
            {
                int isecs = int.Parse(str);

                TimeSpan ts = new TimeSpan(0, 0, 0, isecs, 0);

                return (int)ts.TotalMilliseconds;
            }
        }

        public static string MsecsToSecsString(int msecs)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);

            return ts.TotalSeconds.ToString("#0.00", new System.Globalization.CultureInfo("en-US"));
        }

        public static string MsecsToString2DecimalPlaces(int msecs)
        {
            //1TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs * 10);

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);

            string str = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + ts.Milliseconds.ToString("D2");

            return str;
        }

        private void UpdateTextBoxSelection()
        {                       

            int selstart = txtBox.SelectionStart;
            
            txtBox.SelectionLength = 0;

            if (selstart == 0 || selstart == 1 || selstart==2)
            {                
                txtBox.Select(0, 2);
            }
            else if (selstart == 3 || selstart == 4 || selstart==5)
            {                
                txtBox.Select(3, 2);
            }
            else if (selstart == 6 || selstart == 7 || selstart==8)
            {                
                txtBox.Select(6, 2);
            }
            else if (selstart == 9 || selstart == 10 || selstart == 11 || selstart==12)
            {             
                txtBox.Select(9, 3);
            }            
        }

        private void UpdateTextBoxSelectionLastChar()
        {
            int selstart = txtBox.SelectionStart;                      

            if (selstart == 2)
            {                
                txtBox.Select(0, 2);
            }
            else if (selstart == 5)
            {                
                txtBox.Select(3, 2);
            }
            else if (selstart == 8)
            {               
                txtBox.Select(6, 2);
            }
            else if (selstart == 12)
            {                
                txtBox.Select(9, 3);
            }
        }
                
        private decimal OldValue;
       
        private void nUpDown_ValueChanged(object sender, EventArgs e)
        {
            int spos = txtBox.SelectionStart;                      
            
            string seltxt="";


            int num = 0;
            
            
                if (txtBox.SelectionStart==0)
                {
                    num=int.Parse(txtBox.Text.Substring(0,2));
                }
                else if (txtBox.SelectionStart==3)
                {
                    num=int.Parse(txtBox.Text.Substring(3,2));
                }
                else if (txtBox.SelectionStart==6)
                {
                    num=int.Parse(txtBox.Text.Substring(6,2));
                }
                else if (txtBox.SelectionStart==9)
                {
                    num=int.Parse(txtBox.Text.Substring(9,3));
                }                
                                    

            if (nUpDown.Value - OldValue > 0)
            {                
                if (txtBox.SelectionStart <9)                    
                {
                    num++;

                    num=num%100;

                    txtBox.SelectedText = num.ToString("D2");
                    
                }
                else if (txtBox.SelectionStart >= 9)
                {
                    num++;

                    num = num % 1000;

                    txtBox.SelectedText = num.ToString("D3");
                }
            }
            else
            {                
                if (txtBox.SelectionStart <9)
                {
                    num--;

                    num = num % 100;

                    txtBox.SelectedText = num.ToString("D2");
                }
                else if (txtBox.SelectionStart >= 9)
                {
                    num--;

                    num = num % 1000;

                    txtBox.SelectedText = num.ToString("D3");
                }
            }

            OldValue = nUpDown.Value;
                                    
            txtBox.Focus();
            
            txtBox.SelectionStart = spos;
            UpdateTextBoxSelection();
            txtBox.Focus();

            this.Validate(); 
            //LastAcceptedValue = txtBox.Text;
        }        

        private void txtBox_Click(object sender, EventArgs e)
        {
            UpdateTextBoxSelection();
        }

        private void txtBox_KeyUp(object sender, KeyEventArgs e)
        {
            // remove comment if you want the control to behave like a datetimepicker and not a simple maskedtextbox
            
            //UpdateTextBoxSelectionLastChar();           
        }

        private void txtBox_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateTextBoxSelection();
        }

        public int MSecsValue
        {
            get
            {
                return StringToMsecs(txtBox.Text);
            }
        }

        protected virtual void OnValueChanged(EventArgs eventargs)
        {

        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                txtBox.Font = value;
                nUpDown.Font = value;

                this.OnResize(new EventArgs());
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);                                              
            
            using (Graphics g = this.CreateGraphics())
            {
                txtBox.Left = 0;
                txtBox.Top = 0;
                nUpDown.Top = 0;
                nUpDown.Left = txtBox.Width;

                SizeF sz = g.MeasureString("00:00:00.000", txtBox.Font);
                txtBox.Width = (int)sz.Width + 6;

                SizeF sz1 = g.MeasureString("0",nUpDown.Font);
                float f1=(float)sz1.Width;
                float f2=(float)10;
                float f=f1/f2;

                //nUpDown.Width = (int)sz1.Width - (int)f;

                int spinsize = 12;

                if (nUpDown.Font.Size == 9.75)
                {
                    spinsize = 16;
                }
                else if (nUpDown.Font.Size == 14.25)
                {
                    spinsize = 17;
                }

                nUpDown.Width = spinsize;

                this.Width = txtBox.Width + nUpDown.Width;

                txtBox.Top = 0;
                txtBox.Left = 0;
                txtBox.Height = (int)sz.Height;
                nUpDown.Left = txtBox.Width;
                nUpDown.Top = 0;
                this.Height = txtBox.Height;

            }                             
        }
        private void TimeUpDownControl_Resize(object sender, EventArgs e)
        {
            
        }
        /*
        public static TimeSpan StringToTimeSpan(string str)
        {
            if (str.Length == 11)
            {
                return new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2)),
                        int.Parse(str.Substring(9, 2)) * 10);
            }
            else
            {
                return new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2)),
                        int.Parse(str.Substring(9, 3)));
            }
        }
        */

        public static int StringToMsecs2DecimalPlaces(string str)
        {
            TimeSpan ts = StringToTimeSpan(str);

            return (int)(ts.TotalMilliseconds);
        }
    }
}
