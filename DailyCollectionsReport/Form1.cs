using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyCollectionsReport {
    public partial class DailyCollectionReportForm : Form {
        public DailyCollectionReportForm() {
            InitializeComponent();
        }

        /** Make windows movable
        private bool mouseDown;
        private Point lastLocation;
        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if (mouseDown) {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
        }
        **/
    }

    class MySeparator : Control { //This is the 'line' graphics. Like <hr> in HTML
        private int thickness = 1;
        private bool isVertical; 

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            var size = isVertical ? Height / 2 : Width / 2;
            e.Graphics.TranslateTransform(Width / 2f, Height / 2f);

            using (var pen = new Pen(ForeColor, thickness)) {
                if (!isVertical) {
                    e.Graphics.DrawLine(pen, -size + Padding.Left, 0, size - Padding.Right, 0);
                } else {
                    e.Graphics.DrawLine(pen, 0, -size + Padding.Top, 0, size - Padding.Bottom);
                }
            }
        }
        protected override void OnPaddingChanged(EventArgs e) {
            base.OnPaddingChanged(e);
            Invalidate();
        }
        public bool IsVertical {
            get => isVertical;
            set {
                isVertical = value;
                Invalidate();
            }
        }
        public int Thickness {
            get => thickness;
            set {
                thickness = value;
                if(Height < thickness) {
                    Height = thickness;
                }else {
                    Invalidate();
                }
            }
        }
    }
}
