namespace AFMR_CloudServer
{
    partial class SelectNetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNetList = new Nevron.UI.WinForm.Controls.NListBox();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.btnServerOn = new Nevron.UI.WinForm.Controls.NButton();
            this.lbTitle = new Nevron.UI.WinForm.Controls.NRichTextLabel();
            this.lbFinishApp = new Nevron.UI.WinForm.Controls.NRichTextLabel();
            this.nuiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbFinishApp)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNetList
            // 
            this.lbNetList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.lbNetList.Border.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lbNetList.CheckBoxDataMember = "";
            this.lbNetList.ForeColor = System.Drawing.Color.White;
            this.lbNetList.ImageSize = new System.Drawing.Size(16, 16);
            this.lbNetList.Location = new System.Drawing.Point(11, 41);
            this.lbNetList.Name = "lbNetList";
            this.lbNetList.Palette.Border = System.Drawing.Color.Black;
            this.lbNetList.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.lbNetList.Palette.CaptionText = System.Drawing.Color.White;
            this.lbNetList.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbNetList.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbNetList.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lbNetList.Palette.ControlBorder = System.Drawing.Color.Black;
            this.lbNetList.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lbNetList.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbNetList.Palette.ControlText = System.Drawing.Color.White;
            this.lbNetList.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbNetList.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbNetList.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbNetList.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.lbNetList.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.lbNetList.Palette.MenuText = System.Drawing.Color.White;
            this.lbNetList.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbNetList.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbNetList.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Longhorn;
            this.lbNetList.Palette.SecondaryBorder = System.Drawing.Color.Empty;
            this.lbNetList.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.lbNetList.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.lbNetList.Palette.WindowText = System.Drawing.Color.White;
            this.lbNetList.Size = new System.Drawing.Size(400, 164);
            this.lbNetList.TabIndex = 0;
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Border.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.nuiPanel1.Controls.Add(this.lbFinishApp);
            this.nuiPanel1.Controls.Add(this.btnServerOn);
            this.nuiPanel1.Controls.Add(this.lbNetList);
            this.nuiPanel1.Controls.Add(this.lbTitle);
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Palette.Border = System.Drawing.Color.Black;
            this.nuiPanel1.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.nuiPanel1.Palette.CaptionText = System.Drawing.Color.White;
            this.nuiPanel1.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nuiPanel1.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nuiPanel1.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.nuiPanel1.Palette.ControlBorder = System.Drawing.Color.Black;
            this.nuiPanel1.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.nuiPanel1.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.nuiPanel1.Palette.ControlText = System.Drawing.Color.White;
            this.nuiPanel1.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nuiPanel1.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nuiPanel1.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nuiPanel1.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.nuiPanel1.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.nuiPanel1.Palette.MenuText = System.Drawing.Color.White;
            this.nuiPanel1.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.nuiPanel1.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.nuiPanel1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Longhorn;
            this.nuiPanel1.Palette.SecondaryBorder = System.Drawing.Color.Empty;
            this.nuiPanel1.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.nuiPanel1.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.nuiPanel1.Palette.WindowText = System.Drawing.Color.White;
            this.nuiPanel1.Size = new System.Drawing.Size(460, 220);
            this.nuiPanel1.TabIndex = 1;
            this.nuiPanel1.Text = "nuiPanel1";
            this.nuiPanel1.UseCustomScrollBars = true;
            // 
            // btnServerOn
            // 
            this.btnServerOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnServerOn.Border.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnServerOn.ButtonProperties.BorderOffset = 3;
            this.btnServerOn.ButtonProperties.ImageSize = new System.Drawing.Size(16, 16);
            this.btnServerOn.ButtonProperties.ShowFocusRect = true;
            this.btnServerOn.ButtonProperties.WrapText = true;
            this.btnServerOn.Location = new System.Drawing.Point(331, 10);
            this.btnServerOn.Name = "btnServerOn";
            this.btnServerOn.Palette.Border = System.Drawing.Color.Black;
            this.btnServerOn.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnServerOn.Palette.CaptionText = System.Drawing.Color.White;
            this.btnServerOn.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnServerOn.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnServerOn.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnServerOn.Palette.ControlBorder = System.Drawing.Color.Black;
            this.btnServerOn.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnServerOn.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnServerOn.Palette.ControlText = System.Drawing.Color.White;
            this.btnServerOn.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnServerOn.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnServerOn.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnServerOn.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.btnServerOn.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnServerOn.Palette.MenuText = System.Drawing.Color.White;
            this.btnServerOn.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnServerOn.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnServerOn.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Longhorn;
            this.btnServerOn.Palette.SecondaryBorder = System.Drawing.Color.Empty;
            this.btnServerOn.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.btnServerOn.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.btnServerOn.Palette.WindowText = System.Drawing.Color.White;
            this.btnServerOn.Size = new System.Drawing.Size(80, 25);
            this.btnServerOn.TabIndex = 26;
            this.btnServerOn.Text = "서버 시작";
            this.btnServerOn.UseVisualStyleBackColor = false;
            this.btnServerOn.Click += new System.EventHandler(this.btnServerOn_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.FillInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbTitle.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Solid;
            this.lbTitle.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbTitle.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lbTitle.Item.Text = "네트워크 목록";
            this.lbTitle.Location = new System.Drawing.Point(11, 10);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Palette.Border = System.Drawing.Color.Black;
            this.lbTitle.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.lbTitle.Palette.CaptionText = System.Drawing.Color.White;
            this.lbTitle.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbTitle.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbTitle.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lbTitle.Palette.ControlBorder = System.Drawing.Color.Black;
            this.lbTitle.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lbTitle.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbTitle.Palette.ControlText = System.Drawing.Color.White;
            this.lbTitle.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbTitle.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbTitle.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbTitle.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.lbTitle.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.lbTitle.Palette.MenuText = System.Drawing.Color.White;
            this.lbTitle.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbTitle.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbTitle.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Longhorn;
            this.lbTitle.Palette.SecondaryBorder = System.Drawing.Color.Empty;
            this.lbTitle.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.lbTitle.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.lbTitle.Palette.WindowText = System.Drawing.Color.White;
            this.lbTitle.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.BlendStyle));
            this.lbTitle.ShadowInfo.BlurColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbTitle.ShadowInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTitle.ShadowInfo.OffsetX = 0;
            this.lbTitle.ShadowInfo.OffsetY = 0;
            this.lbTitle.Size = new System.Drawing.Size(250, 25);
            this.lbTitle.StrokeInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTitle.TabIndex = 25;
            this.lbTitle.Text = "Error Message Box";
            // 
            // lbFinishApp
            // 
            this.lbFinishApp.BackColor = System.Drawing.Color.Transparent;
            this.lbFinishApp.FillInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbFinishApp.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Solid;
            this.lbFinishApp.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbFinishApp.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lbFinishApp.FillInfo.Padding = new Nevron.UI.NPadding(10, 0, 0, 0);
            this.lbFinishApp.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbFinishApp.Item.Style.FontInfo = new Nevron.UI.NThemeFontInfo("맑은 고딕", 20F, Nevron.GraphicsCore.FontStyleEx.Bold);
            this.lbFinishApp.Location = new System.Drawing.Point(422, 0);
            this.lbFinishApp.Name = "lbFinishApp";
            this.lbFinishApp.Palette.Border = System.Drawing.Color.Black;
            this.lbFinishApp.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.lbFinishApp.Palette.CaptionText = System.Drawing.Color.White;
            this.lbFinishApp.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbFinishApp.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbFinishApp.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lbFinishApp.Palette.ControlBorder = System.Drawing.Color.Black;
            this.lbFinishApp.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lbFinishApp.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbFinishApp.Palette.ControlText = System.Drawing.Color.White;
            this.lbFinishApp.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbFinishApp.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbFinishApp.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbFinishApp.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.lbFinishApp.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.lbFinishApp.Palette.MenuText = System.Drawing.Color.White;
            this.lbFinishApp.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbFinishApp.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.lbFinishApp.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Longhorn;
            this.lbFinishApp.Palette.SecondaryBorder = System.Drawing.Color.Empty;
            this.lbFinishApp.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.lbFinishApp.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.lbFinishApp.Palette.WindowText = System.Drawing.Color.White;
            this.lbFinishApp.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.BlendStyle));
            this.lbFinishApp.ShadowInfo.BlurColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbFinishApp.ShadowInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbFinishApp.ShadowInfo.OffsetX = 0;
            this.lbFinishApp.ShadowInfo.OffsetY = 0;
            this.lbFinishApp.Size = new System.Drawing.Size(35, 35);
            this.lbFinishApp.StrokeInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbFinishApp.TabIndex = 69;
            this.lbFinishApp.Text = "X";
            this.lbFinishApp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbFinishApp_MouseDown);
            this.lbFinishApp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbFinishApp_MouseUp);
            // 
            // SelectNetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 220);
            this.Controls.Add(this.nuiPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectNetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectNetForm";
            this.nuiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbFinishApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NListBox lbNetList;
        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NButton btnServerOn;
        private Nevron.UI.WinForm.Controls.NRichTextLabel lbTitle;
        private Nevron.UI.WinForm.Controls.NRichTextLabel lbFinishApp;
    }
}