using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GreenLifeManagementSystem
{
    public static class ThemeHelper
    {
        public static readonly Color PrimaryGreen = Color.FromArgb(46, 125, 50);
        public static readonly Color PrimaryDark = Color.FromArgb(27, 94, 32);
        public static readonly Color AccentGreen = Color.FromArgb(102, 187, 106);
        public static readonly Color LightGreen = Color.FromArgb(200, 230, 201);
        public static readonly Color BackgroundColor = Color.FromArgb(245, 247, 245);
        public static readonly Color CardBackground = Color.White;
        public static readonly Color TextPrimary = Color.FromArgb(33, 33, 33);
        public static readonly Color TextSecondary = Color.FromArgb(117, 117, 117);
        public static readonly Color BorderColor = Color.FromArgb(200, 220, 200);
        public static readonly Color DangerRed = Color.FromArgb(211, 47, 47);
        public static readonly Color WarningOrange = Color.FromArgb(245, 124, 0);
        public static readonly Color GridAltRow = Color.FromArgb(232, 245, 233);
        public static readonly Color GridHeaderBg = Color.FromArgb(46, 125, 50);

        public static readonly Font FontTitle = new Font("Segoe UI", 16, FontStyle.Bold);
        public static readonly Font FontSubtitle = new Font("Segoe UI", 11, FontStyle.Regular);
        public static readonly Font FontBody = new Font("Segoe UI", 10, FontStyle.Regular);
        public static readonly Font FontBodyBold = new Font("Segoe UI", 10, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI", 9, FontStyle.Regular);
        public static readonly Font FontButton = new Font("Segoe UI", 10, FontStyle.Bold);
        public static readonly Font FontCardValue = new Font("Segoe UI", 20, FontStyle.Bold);
        public static readonly Font FontCardLabel = new Font("Segoe UI", 10, FontStyle.Bold);
        public static readonly Font FontNavHeader = new Font("Segoe UI", 8, FontStyle.Bold);
        public static readonly Font FontNavButton = new Font("Segoe UI", 10, FontStyle.Regular);
        public static readonly Font FontLogo = new Font("Segoe UI", 14, FontStyle.Bold);

        public static void ApplyTheme(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = FontBody;

            form.ForeColor = TextPrimary;

            ApplyToControls(form.Controls, form);

            form.Opacity = 0;
            System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer { Interval = 15 };
            fadeTimer.Tick += (s, e) =>
            {
                if (form.Opacity < 1)
                {
                    form.Opacity += 0.06;
                }
                else
                {
                    form.Opacity = 1;
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                }
            };
            form.Shown += (s, e) => fadeTimer.Start();
        }

        private static void ApplyToControls(Control.ControlCollection controls, Form parentForm)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is Button btn)
                {
                    StyleButton(btn);
                }
                else if (ctrl is DataGridView dgv)
                {
                    StyleDataGridView(dgv);
                }
                else if (ctrl is TextBox txt)
                {
                    StyleTextBox(txt);
                }
                else if (ctrl is ComboBox cmb)
                {
                    StyleComboBox(cmb);
                }
                else if (ctrl is GroupBox grp)
                {
                    StyleGroupBox(grp);
                }
                else if (ctrl is Panel panel)
                {
                    StylePanel(panel, parentForm);
                }
                else if (ctrl is Label lbl)
                {
                    StyleLabel(lbl);
                }

                if (ctrl.Controls.Count > 0)
                {
                    ApplyToControls(ctrl.Controls, parentForm);
                }
            }
        }

        private static void StyleButton(Button btn)
        {
            string name = btn.Name.ToLower();

            if (name.StartsWith("btnmanage") || name == "btnreports")
            {
                StyleNavButton(btn);
                return;
            }

            if (name.Contains("logout") || name.Contains("delete") || name.Contains("clear"))
            {
                btn.BackColor = name.Contains("delete") ? DangerRed : Color.FromArgb(120, 120, 120);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = FontButton;
                btn.Cursor = Cursors.Hand;

                Color normalColor = btn.BackColor;
                Color hoverColor = name.Contains("delete") ? Color.FromArgb(183, 28, 28) : Color.FromArgb(90, 90, 90);

                btn.MouseEnter += (s, e) => AnimateColor(btn, normalColor, hoverColor);
                btn.MouseLeave += (s, e) => AnimateColor(btn, hoverColor, normalColor);
                return;
            }

            if (name.Contains("cart"))
            {
                btn.BackColor = WarningOrange;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = FontButton;
                btn.Cursor = Cursors.Hand;

                btn.MouseEnter += (s, e) => AnimateColor(btn, WarningOrange, Color.FromArgb(230, 110, 0));
                btn.MouseLeave += (s, e) => AnimateColor(btn, Color.FromArgb(230, 110, 0), WarningOrange);
                return;
            }

            btn.BackColor = PrimaryGreen;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = FontButton;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => AnimateColor(btn, PrimaryGreen, PrimaryDark);
            btn.MouseLeave += (s, e) => AnimateColor(btn, PrimaryDark, PrimaryGreen);
        }

        private static void StyleNavButton(Button btn)
        {
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 255, 255, 255);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(90, 255, 255, 255);
            btn.Font = FontNavButton;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 0, 0, 0);
        }

        private static void StyleDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = CardBackground;
            dgv.GridColor = BorderColor;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = GridHeaderBg,
                ForeColor = Color.White,
                Font = FontBodyBold,
                Padding = new Padding(8, 4, 8, 4),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = CardBackground,
                ForeColor = TextPrimary,
                Font = FontBody,
                SelectionBackColor = LightGreen,
                SelectionForeColor = TextPrimary,
                Padding = new Padding(6, 3, 6, 3)
            };

            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = GridAltRow,
                ForeColor = TextPrimary,
                Font = FontBody,
                SelectionBackColor = LightGreen,
                SelectionForeColor = TextPrimary
            };

            dgv.RowTemplate.Height = 35;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.Font = FontBody;
            txt.ForeColor = TextPrimary;

            txt.Enter += (s, e) => { txt.BackColor = Color.FromArgb(232, 245, 233); };
            txt.Leave += (s, e) => { txt.BackColor = Color.White; };
        }

        private static void StyleComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.BackColor = Color.White;
            cmb.Font = FontBody;
            cmb.ForeColor = TextPrimary;
        }

        private static void StyleGroupBox(GroupBox grp)
        {
            string name = grp.Name.ToLower();
            grp.BackColor = CardBackground;

            bool isSummaryCard = name.Contains("total") || name.Contains("pending") || name.Contains("lowstock") || name.Contains("low_stock");

            if (isSummaryCard)
            {
                grp.ForeColor = PrimaryGreen;
                grp.Font = FontCardLabel;

                foreach (Control c in grp.Controls)
                {
                    if (c is Label lbl)
                    {
                        lbl.ForeColor = PrimaryDark;
                        lbl.Font = FontCardValue;
                    }
                }

                grp.Paint += (s, e) =>
                {
                    Graphics g = e.Graphics;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    using (Pen pen = new Pen(AccentGreen, 2))
                    {
                        Rectangle rect = new Rectangle(1, 12, grp.Width - 3, grp.Height - 14);
                        int radius = 10;
                        using (GraphicsPath path = CreateRoundedRectPath(rect, radius))
                        {
                            g.DrawPath(pen, path);
                        }
                    }

                    using (Brush brush = new SolidBrush(PrimaryGreen))
                    {
                        g.FillRectangle(new SolidBrush(grp.BackColor), 8, 2, TextRenderer.MeasureText(grp.Text, grp.Font).Width + 4, 20);
                        g.DrawString(grp.Text, grp.Font, brush, 10, 0);
                    }
                };
            }
            else
            {
                grp.ForeColor = PrimaryGreen;
                grp.Font = FontBodyBold;

                foreach (Control c in grp.Controls)
                {
                    if (c is Label lbl)
                    {
                        lbl.ForeColor = TextPrimary;
                        lbl.Font = FontBody;
                    }
                }

                grp.Paint += (s, e) =>
                {
                    Graphics g = e.Graphics;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    using (Pen pen = new Pen(BorderColor, 1.5f))
                    {
                        Rectangle rect = new Rectangle(1, 12, grp.Width - 3, grp.Height - 14);
                        int radius = 8;
                        using (GraphicsPath path = CreateRoundedRectPath(rect, radius))
                        {
                            g.DrawPath(pen, path);
                        }
                    }

                    using (Brush brush = new SolidBrush(PrimaryGreen))
                    {
                        g.FillRectangle(new SolidBrush(grp.BackColor), 8, 2, TextRenderer.MeasureText(grp.Text, grp.Font).Width + 4, 20);
                        g.DrawString(grp.Text, grp.Font, brush, 10, 0);
                    }
                };
            }
        }

        private static void StylePanel(Panel panel, Form parentForm)
        {
            string name = panel.Name.ToLower();

            if (name.Contains("sidebar"))
            {
                panel.BackColor = PrimaryDark;
                panel.BorderStyle = BorderStyle.None;

                foreach (Control c in panel.Controls)
                {
                    if (c is Label lbl)
                    {
                        lbl.ForeColor = Color.White;
                        if (lbl.Name.ToLower().Contains("logo"))
                        {
                            lbl.Font = FontLogo;
                            lbl.ForeColor = Color.White;
                        }
                        else if (lbl.Name.ToLower().Contains("nav"))
                        {
                            lbl.Font = FontNavHeader;
                            lbl.ForeColor = Color.FromArgb(160, 200, 160);
                        }
                    }
                }
            }
            else if (name.Contains("header"))
            {
                panel.BackColor = PrimaryGreen;
                panel.BorderStyle = BorderStyle.None;

                foreach (Control c in panel.Controls)
                {
                    if (c is Label lbl)
                    {
                        string lblName = lbl.Name.ToLower();
                        lbl.ForeColor = Color.White;

                        if (lblName.Contains("brand") && lblName.Contains("title"))
                        {
                            lbl.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                        }
                        else if (lblName.Contains("title"))
                        {
                            lbl.Font = FontTitle;
                        }
                        else if (lblName.Contains("sub") || lblName.Contains("brand"))
                        {
                            lbl.ForeColor = Color.FromArgb(200, 230, 201);
                            lbl.Font = FontSubtitle;
                        }
                    }
                }
            }
        }

        private static void StyleLabel(Label lbl)
        {
            string name = lbl.Name.ToLower();

            if (lbl.Parent is Panel || lbl.Parent is GroupBox)
                return;

            if (name.Contains("header"))
            {
                lbl.ForeColor = PrimaryDark;
                lbl.Font = FontBodyBold;
            }
            else
            {
                lbl.ForeColor = TextPrimary;
                lbl.Font = FontBody;
            }
        }

        private static void AnimateColor(Control ctrl, Color from, Color to)
        {
            int steps = 6;
            int currentStep = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 18 };

            timer.Tick += (s, e) =>
            {
                currentStep++;
                float ratio = (float)currentStep / steps;

                int r = (int)(from.R + (to.R - from.R) * ratio);
                int g = (int)(from.G + (to.G - from.G) * ratio);
                int b = (int)(from.B + (to.B - from.B) * ratio);

                r = Math.Max(0, Math.Min(255, r));
                g = Math.Max(0, Math.Min(255, g));
                b = Math.Max(0, Math.Min(255, b));

                ctrl.BackColor = Color.FromArgb(r, g, b);

                if (currentStep >= steps)
                {
                    ctrl.BackColor = to;
                    timer.Stop();
                    timer.Dispose();
                }
            };

            timer.Start();
        }

        private static GraphicsPath CreateRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}