namespace Ui.SampleDesktopApp
{
    partial class MainWindows
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbx_displays = new ComboBox();
            dy_tlp = new TableLayoutPanel();
            btn_off = new Button();
            lb1 = new Label();
            btn_on = new Button();
            picBox_preview = new PictureBox();
            dy_tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox_preview).BeginInit();
            SuspendLayout();
            // 
            // cbx_displays
            // 
            cbx_displays.Anchor = AnchorStyles.Left;
            cbx_displays.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_displays.FormattingEnabled = true;
            cbx_displays.Location = new Point(203, 8);
            cbx_displays.Name = "cbx_displays";
            cbx_displays.Size = new Size(542, 33);
            cbx_displays.TabIndex = 0;
            cbx_displays.SelectedIndexChanged += cbx_displays_SelectedIndexChanged;
            // 
            // dynamicTableLayoutPanel
            // 
            dy_tlp.AutoSize = true;
            dy_tlp.BackColor = Color.White;
            dy_tlp.ColumnCount = 2;
            dy_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            dy_tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            dy_tlp.Controls.Add(btn_off, 0, 1);
            dy_tlp.Controls.Add(cbx_displays, 1, 0);
            dy_tlp.Controls.Add(lb1, 0, 0);
            dy_tlp.Controls.Add(btn_on, 0, 2);
            dy_tlp.Controls.Add(picBox_preview, 0, 3);
            dy_tlp.Dock = DockStyle.Fill;
            dy_tlp.Location = new Point(0, 0);
            dy_tlp.Name = "dynamicTableLayoutPanel";
            dy_tlp.RowCount = 4;
            dy_tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            dy_tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            dy_tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            dy_tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            dy_tlp.Size = new Size(954, 566);
            dy_tlp.TabIndex = 0;
            // 
            // btn_off
            // 
            btn_off.Anchor = AnchorStyles.Left;
            btn_off.Location = new Point(3, 58);
            btn_off.Name = "btn_off";
            btn_off.Size = new Size(112, 34);
            btn_off.TabIndex = 3;
            btn_off.Text = "Turn Off";
            btn_off.UseVisualStyleBackColor = true;
            btn_off.Click += btn_off_Click;
            // 
            // lb1
            // 
            lb1.Anchor = AnchorStyles.Left;
            lb1.AutoSize = true;
            lb1.Location = new Point(3, 12);
            lb1.Name = "lb1";
            lb1.Size = new Size(121, 25);
            lb1.TabIndex = 1;
            lb1.Text = "Select Display";
            // 
            // btn_on
            // 
            btn_on.Anchor = AnchorStyles.Left;
            btn_on.Location = new Point(3, 108);
            btn_on.Name = "btn_on";
            btn_on.Size = new Size(112, 34);
            btn_on.TabIndex = 4;
            btn_on.Text = "Turn On";
            btn_on.UseVisualStyleBackColor = true;
            btn_on.Click += btn_on_Click;
            // 
            // picBox_preview
            // 
            picBox_preview.BackgroundImageLayout = ImageLayout.None;
            dy_tlp.SetColumnSpan(picBox_preview, 2);
            picBox_preview.Dock = DockStyle.Fill;
            picBox_preview.Location = new Point(3, 153);
            picBox_preview.Name = "picBox_preview";
            picBox_preview.Size = new Size(948, 410);
            picBox_preview.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox_preview.TabIndex = 2;
            picBox_preview.TabStop = false;
            // 
            // MainWindows
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(954, 566);
            Controls.Add(dy_tlp);
            MaximizeBox = false;
            Name = "MainWindows";
            ShowIcon = false;
            Text = "Sample Monitors Helper";
            dy_tlp.ResumeLayout(false);
            dy_tlp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBox_preview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbx_displays;
        private Label lb1;
        private PictureBox picBox_preview;
        private Button btn_off;
        private Button btn_on;
        private TableLayoutPanel dy_tlp;
    }
}