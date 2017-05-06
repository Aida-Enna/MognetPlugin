using System.Windows.Forms;

namespace FFXIVPostParse
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

        private GroupBox groupStatus;
        private Label combatStatus;
        private GroupBox groupOptions;
        private CheckBox enabled;
        private CheckBox includeHPS;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.combatStatus = new System.Windows.Forms.Label();
            this.enabled = new System.Windows.Forms.CheckBox();
            this.includeHPS = new System.Windows.Forms.CheckBox();
            this.groupStatus = new System.Windows.Forms.GroupBox();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.groupStatus.SuspendLayout();
            this.groupOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // combatStatus
            // 
            this.combatStatus.Location = new System.Drawing.Point(6, 17);
            this.combatStatus.Name = "combatStatus";
            this.combatStatus.Size = new System.Drawing.Size(252, 20);
            this.combatStatus.TabIndex = 0;
            this.combatStatus.Text = "Waiting a fight...";
            // 
            // enabled
            // 
            this.enabled.Checked = true;
            this.enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabled.Location = new System.Drawing.Point(6, 23);
            this.enabled.Name = "enabled";
            this.enabled.Size = new System.Drawing.Size(249, 24);
            this.enabled.TabIndex = 0;
            this.enabled.Text = "Check this to enable the plugin";
            this.enabled.CheckedChanged += new System.EventHandler(this.enabled_CheckedChanged);
            // 
            // includeHPS
            // 
            this.includeHPS.Checked = true;
            this.includeHPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeHPS.Location = new System.Drawing.Point(6, 53);
            this.includeHPS.Name = "includeHPS";
            this.includeHPS.Size = new System.Drawing.Size(249, 24);
            this.includeHPS.TabIndex = 1;
            this.includeHPS.Text = "Check this to include Healing per Second";
            // 
            // groupStatus
            // 
            this.groupStatus.Controls.Add(this.combatStatus);
            this.groupStatus.Location = new System.Drawing.Point(0, 0);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(264, 40);
            this.groupStatus.TabIndex = 0;
            this.groupStatus.TabStop = false;
            this.groupStatus.Text = "Status";
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.enabled);
            this.groupOptions.Controls.Add(this.includeHPS);
            this.groupOptions.Location = new System.Drawing.Point(3, 46);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(261, 91);
            this.groupOptions.TabIndex = 0;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupStatus);
            this.Controls.Add(this.groupOptions);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(479, 266);
            this.groupStatus.ResumeLayout(false);
            this.groupOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}