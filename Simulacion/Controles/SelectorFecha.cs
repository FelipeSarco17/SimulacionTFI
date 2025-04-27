using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Simulacion.Controles
{
    public class SelectorFecha : DateTimePicker
    {
        private Color skinColor = Color.MediumSlateBlue;
        private Color borderColor = Color.PaleVioletRed;
        private Color textColor = Color.White;
        private int borderSize = 0;

        private bool droppedDown = false;
        private Image calendarIcon = Properties.Resources.calendarWhite;
        private Rectangle iconRect;
        private const int calendarIconWidth = 30;
        private const int arrowIconWidth = 17;
    
       public Color SkinColor 
       {
            get
            {
                return skinColor;
            }
            set
            {
                skinColor = value;
                if(skinColor.GetBrightness() >= 0.8F )
                    calendarIcon = Properties.Resources.calendarDark;
                else calendarIcon = Properties.Resources.calendarWhite;
                this.Invalidate();
            }
                
       }
        public Color BorderColor 
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        public Color TextColor 
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                this.Invalidate();
            }
        }
        public int BorderSize 
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        public SelectorFecha()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0, 35);
            this.Font = new Font(this.Font.Name, 9.5F);

        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
            this.Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true; // Prevents the user from typing in the control
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics  graphics = this.CreateGraphics())
            using (Pen penBorder = new Pen(borderColor, borderSize))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat textformat = new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width, this.Height);
                RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0, calendarIconWidth, clientArea.Height);
                penBorder.Alignment = PenAlignment.Inset;
                textformat.LineAlignment = StringAlignment.Center;

                graphics.FillRectangle(skinBrush, clientArea);
                graphics.DrawString("  "+this.Text, this.Font, textBrush, clientArea, textformat);
                if(this.droppedDown) graphics.FillRectangle(openIconBrush, iconArea);
                if (borderSize >= 1) graphics.DrawRectangle(penBorder,clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
                graphics.DrawImage(calendarIcon, iconArea.X + (iconArea.Width - calendarIconWidth) / 2, iconArea.Y + (iconArea.Height - calendarIconWidth) / 2, calendarIconWidth, calendarIconWidth);

            }


        }

    }

}
