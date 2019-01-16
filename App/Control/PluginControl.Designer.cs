using MognetPlugin.Enum;
using System.Windows.Forms;

namespace MognetPlugin.Control
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
        private Button btnApplyToken;
        private CheckBox chkEnabled;
        private GroupBox grpHttpLog;
        private RichTextBox rchPluginLog;
        private Button btnClearLog;
        private GroupBox grpAttributes;
        private CheckedListBox chlAttributes;
        private Label lblToken;
        private TextBox txtToken;
        private ComboBox cmbSort;
        private Label lblGuildName;
        private Label lblSort;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.lbDiscordChannel = new System.Windows.Forms.Label();
            this.lblDiscordGuild = new System.Windows.Forms.Label();
            this.lblGuildName = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnApplyToken = new System.Windows.Forms.Button();
            this.grpHttpLog = new System.Windows.Forms.GroupBox();
            this.rchPluginLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.chkTimeEnabled = new System.Windows.Forms.CheckBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
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
            this.chkEnabled.Location = new System.Drawing.Point(6, 85);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(249, 24);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Check this to enable the plugin";
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.lblChannelName);
            this.grpOptions.Controls.Add(this.lbDiscordChannel);
            this.grpOptions.Controls.Add(this.lblDiscordGuild);
            this.grpOptions.Controls.Add(this.lblGuildName);
            this.grpOptions.Controls.Add(this.lblToken);
            this.grpOptions.Controls.Add(this.txtToken);
            this.grpOptions.Controls.Add(this.btnApplyToken);
            this.grpOptions.Controls.Add(this.chkEnabled);
            this.grpOptions.Location = new System.Drawing.Point(9, 3);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(424, 116);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // lblChannelName
            // 
            this.lblChannelName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChannelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChannelName.Location = new System.Drawing.Point(107, 62);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(311, 20);
            this.lblChannelName.TabIndex = 10;
            this.lblChannelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDiscordChannel
            // 
            this.lbDiscordChannel.Location = new System.Drawing.Point(6, 60);
            this.lbDiscordChannel.Name = "lbDiscordChannel";
            this.lbDiscordChannel.Size = new System.Drawing.Size(95, 22);
            this.lbDiscordChannel.TabIndex = 9;
            this.lbDiscordChannel.Text = "Discord Channel:";
            this.lbDiscordChannel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiscordGuild
            // 
            this.lblDiscordGuild.Location = new System.Drawing.Point(6, 38);
            this.lblDiscordGuild.Name = "lblDiscordGuild";
            this.lblDiscordGuild.Size = new System.Drawing.Size(80, 22);
            this.lblDiscordGuild.TabIndex = 8;
            this.lblDiscordGuild.Text = "Discord Guild:";
            this.lblDiscordGuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGuildName
            // 
            this.lblGuildName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGuildName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuildName.Location = new System.Drawing.Point(107, 40);
            this.lblGuildName.Name = "lblGuildName";
            this.lblGuildName.Size = new System.Drawing.Size(311, 20);
            this.lblGuildName.TabIndex = 7;
            this.lblGuildName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToken
            // 
            this.lblToken.Location = new System.Drawing.Point(6, 16);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(54, 22);
            this.lblToken.TabIndex = 5;
            this.lblToken.Text = "Token:";
            this.lblToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(107, 16);
            this.txtToken.MaxLength = 30;
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(230, 20);
            this.txtToken.TabIndex = 6;
            this.txtToken.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnApplyToken
            // 
            this.btnApplyToken.Location = new System.Drawing.Point(343, 15);
            this.btnApplyToken.Name = "btnApplyToken";
            this.btnApplyToken.Size = new System.Drawing.Size(75, 23);
            this.btnApplyToken.TabIndex = 4;
            this.btnApplyToken.Text = "Apply";
            // 
            // grpHttpLog
            // 
            this.grpHttpLog.Controls.Add(this.rchPluginLog);
            this.grpHttpLog.Controls.Add(this.btnClearLog);
            this.grpHttpLog.Location = new System.Drawing.Point(9, 125);
            this.grpHttpLog.Name = "grpHttpLog";
            this.grpHttpLog.Size = new System.Drawing.Size(430, 256);
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
            this.rchPluginLog.Size = new System.Drawing.Size(418, 193);
            this.rchPluginLog.TabIndex = 1;
            this.rchPluginLog.Text = "";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(6, 218);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 2;
            this.btnClearLog.Text = "Clear Log";
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.lblEndTime);
            this.grpAttributes.Controls.Add(this.lblStartTime);
            this.grpAttributes.Controls.Add(this.dtpEndTime);
            this.grpAttributes.Controls.Add(this.dtpStartTime);
            this.grpAttributes.Controls.Add(this.chkTimeEnabled);
            this.grpAttributes.Controls.Add(this.lblSort);
            this.grpAttributes.Controls.Add(this.cmbSort);
            this.grpAttributes.Controls.Add(this.chlAttributes);
            this.grpAttributes.Location = new System.Drawing.Point(445, 3);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Size = new System.Drawing.Size(178, 378);
            this.grpAttributes.TabIndex = 2;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "Include Attributes";
            // 
            // lblEndTime
            // 
            this.lblEndTime.Location = new System.Drawing.Point(3, 307);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(70, 23);
            this.lblEndTime.TabIndex = 12;
            this.lblEndTime.Text = "End Time:";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(3, 285);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(70, 23);
            this.lblStartTime.TabIndex = 11;
            this.lblStartTime.Text = "Start Time:";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(79, 310);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(91, 20);
            this.dtpEndTime.TabIndex = 10;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Enabled = false;
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(79, 284);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(91, 20);
            this.dtpStartTime.TabIndex = 9;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // chkTimeEnabled
            // 
            this.chkTimeEnabled.AutoSize = true;
            this.chkTimeEnabled.Location = new System.Drawing.Point(6, 261);
            this.chkTimeEnabled.Name = "chkTimeEnabled";
            this.chkTimeEnabled.Size = new System.Drawing.Size(139, 17);
            this.chkTimeEnabled.TabIndex = 8;
            this.chkTimeEnabled.Text = "Only post logs between:";
            this.chkTimeEnabled.UseVisualStyleBackColor = true;
            this.chkTimeEnabled.CheckedChanged += new System.EventHandler(this.chkTimeEnabled_CheckedChanged);
            // 
            // lblSort
            // 
            this.lblSort.Location = new System.Drawing.Point(3, 232);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(45, 23);
            this.lblSort.TabIndex = 6;
            this.lblSort.Text = "Sort By:";
            this.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSort
            // 
            this.cmbSort.Items.AddRange(new object[] {
            ""});
            this.cmbSort.Location = new System.Drawing.Point(54, 234);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(116, 21);
            this.cmbSort.TabIndex = 7;
            // 
            // chlAttributes
            // 
            this.chlAttributes.CheckOnClick = true;
            this.chlAttributes.Location = new System.Drawing.Point(6, 16);
            this.chlAttributes.Name = "chlAttributes";
            this.chlAttributes.Size = new System.Drawing.Size(164, 214);
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
            this.Size = new System.Drawing.Size(644, 449);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpHttpLog.ResumeLayout(false);
            this.grpAttributes.ResumeLayout(false);
            this.grpAttributes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private void FillLists()
        {
            this.grpAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // chlAttributes
            // 
            this.chlAttributes.Items.AddRange(new object[]
            {
                AttributeEnum.MaxHitParty,
                AttributeEnum.TotalHealing,
                AttributeEnum.MapName,
                AttributeEnum.DamagePerc,
                AttributeEnum.MaxHitIndividual,
                AttributeEnum.HPS,
                AttributeEnum.HealingPerc,
                AttributeEnum.MaxHeal,
                AttributeEnum.OverHealPerc,
                AttributeEnum.Deaths,
                AttributeEnum.Crit,
                AttributeEnum.DirectHit,
                AttributeEnum.DirectHitCrit,
                AttributeEnum.CritHealPerc
            });

            this.chlAttributes.Sorted = true;

            // 
            // cmbSort
            // 
            this.cmbSort.Items.AddRange(new object[]
            {
                AttributeEnum.DPS,
                AttributeEnum.HPS
            });

            this.grpAttributes.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void AttachEvents()
        {
            this.chkEnabled.CheckedChanged += this.chkEnabled_CheckedChanged;
            this.btnApplyToken.Click += this.btnApplyToken_Click;
            this.rchPluginLog.TextChanged += this.rchPluginLog_TextChanged;
            this.btnClearLog.Click += this.btnClearLog_Click;
            this.chlAttributes.ItemCheck += this.chlAttributes_ItemCheck;
            this.cmbSort.SelectedIndexChanged += this.cmbSort_SelectedIndexChanged;
            this.Load += this.PluginControl_Load;
        }

        private Label lblChannelName;
        private Label lbDiscordChannel;
        private Label lblDiscordGuild;
        private Label lblEndTime;
        private Label lblStartTime;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private CheckBox chkTimeEnabled;
    }
}