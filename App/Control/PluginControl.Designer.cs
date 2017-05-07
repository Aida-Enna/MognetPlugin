using FFXIVPostParse.Enum;
using System.Windows.Forms;

namespace FFXIVPostParse.Control
{
    partial class PluginControl
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
        private GroupBox grpOptions;
        private Label lblPlayerName;
        private TextBox txtPlayerName;
        private Button btnApplyName;
        private CheckBox chkEnabled;
        private GroupBox grpHttpLog;
        private RichTextBox rchPluginLog;
        private Button btnClearLog;
        private GroupBox grpAttributes;
        private CheckedListBox chlAttributes;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.btnApplyName = new System.Windows.Forms.Button();
            this.grpHttpLog = new System.Windows.Forms.GroupBox();
            this.rchPluginLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.chlAttributes = new System.Windows.Forms.CheckedListBox();
            this.grpOptions.SuspendLayout();
            this.grpHttpLog.SuspendLayout();
            this.grpAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(6, 53);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(249, 24);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Check this to enable the plugin";
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.lblPlayerName);
            this.grpOptions.Controls.Add(this.txtPlayerName);
            this.grpOptions.Controls.Add(this.btnApplyName);
            this.grpOptions.Controls.Add(this.chkEnabled);
            this.grpOptions.Location = new System.Drawing.Point(9, 3);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(430, 86);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Location = new System.Drawing.Point(6, 30);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(85, 20);
            this.lblPlayerName.TabIndex = 2;
            this.lblPlayerName.Text = "Your log name:";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(97, 27);
            this.txtPlayerName.MaxLength = 20;
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(187, 20);
            this.txtPlayerName.TabIndex = 3;
            this.txtPlayerName.Text = "YOU";
            // 
            // btnApplyName
            // 
            this.btnApplyName.Location = new System.Drawing.Point(290, 25);
            this.btnApplyName.Name = "btnApplyName";
            this.btnApplyName.Size = new System.Drawing.Size(75, 23);
            this.btnApplyName.TabIndex = 4;
            this.btnApplyName.Text = "Apply";
            this.btnApplyName.Click += new System.EventHandler(this.btnApplyName_Click);
            // 
            // grpHttpLog
            // 
            this.grpHttpLog.Controls.Add(this.rchPluginLog);
            this.grpHttpLog.Controls.Add(this.btnClearLog);
            this.grpHttpLog.Location = new System.Drawing.Point(3, 95);
            this.grpHttpLog.Name = "grpHttpLog";
            this.grpHttpLog.Size = new System.Drawing.Size(430, 240);
            this.grpHttpLog.TabIndex = 1;
            this.grpHttpLog.TabStop = false;
            this.grpHttpLog.Text = "Log";
            // 
            // rchPluginLog
            // 
            this.rchPluginLog.Location = new System.Drawing.Point(6, 19);
            this.rchPluginLog.Name = "rchPluginLog";
            this.rchPluginLog.ReadOnly = true;
            this.rchPluginLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rchPluginLog.Size = new System.Drawing.Size(418, 177);
            this.rchPluginLog.TabIndex = 1;
            this.rchPluginLog.Text = "";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(6, 205);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 2;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.chlAttributes);
            this.grpAttributes.Location = new System.Drawing.Point(445, 3);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Size = new System.Drawing.Size(178, 332);
            this.grpAttributes.TabIndex = 2;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "Include Attributes";
            // 
            // chlAttributes
            // 
            this.chlAttributes.CheckOnClick = true;
            this.chlAttributes.Items.AddRange(new object[] {
            AttributeEnum.START_TIME,
            AttributeEnum.DURATION,
            AttributeEnum.MAX_HIT_PARTY,
            AttributeEnum.TOTAL_HEALING,
            AttributeEnum.MAP_NAME,
            AttributeEnum.BOSS_NAME,
            AttributeEnum.PLAYER_JOB,
            AttributeEnum.PLAYER_NAME,
            AttributeEnum.DPS,
            AttributeEnum.DAMAGE_PERCENTAGE,
            AttributeEnum.MAX_HIT_INDIVIDUAL,
            AttributeEnum.HPS,
            AttributeEnum.HEALING_PERCENTAGE,
            AttributeEnum.MAX_HEAL,
            AttributeEnum.OVERHEAL_PERCENTAGE,
            AttributeEnum.DEATHS,
            AttributeEnum.CRITS,
            AttributeEnum.MISEES});
            this.chlAttributes.SetItemChecked(4, true);
            this.chlAttributes.SetItemChecked(5, true);
            this.chlAttributes.SetItemChecked(6, true);
            this.chlAttributes.SetItemChecked(7, true);
            this.chlAttributes.SetItemChecked(8, true);
            this.chlAttributes.Location = new System.Drawing.Point(6, 16);
            this.chlAttributes.Name = "chlAttributes";
            this.chlAttributes.Size = new System.Drawing.Size(164, 304);
            this.chlAttributes.TabIndex = 1;
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.grpHttpLog);
            this.Controls.Add(this.grpAttributes);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(643, 348);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpHttpLog.ResumeLayout(false);
            this.grpAttributes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}