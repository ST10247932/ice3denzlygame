//ice3game
namespace GameScriptManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadScripts;
        private System.Windows.Forms.Button btnSaveScript;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Button btnDeleteScript;
        private System.Windows.Forms.ListBox lstScripts;
        private System.Windows.Forms.Label lblScriptName;
        private System.Windows.Forms.RichTextBox rtbScriptContent;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.btnLoadScripts = new System.Windows.Forms.Button();
            this.btnSaveScript = new System.Windows.Forms.Button();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.btnDeleteScript = new System.Windows.Forms.Button();
            this.lstScripts = new System.Windows.Forms.ListBox();
            this.lblScriptName = new System.Windows.Forms.Label();
            this.rtbScriptContent = new System.Windows.Forms.RichTextBox();

            // 
            // btnLoadScripts
            // 
            this.btnLoadScripts.Location = new System.Drawing.Point(12, 12);
            this.btnLoadScripts.Name = "btnLoadScripts";
            this.btnLoadScripts.Size = new System.Drawing.Size(100, 30);
            this.btnLoadScripts.Text = "Load Scripts";
            this.btnLoadScripts.UseVisualStyleBackColor = true;

            // 
            // btnSaveScript
            // 
            this.btnSaveScript.Location = new System.Drawing.Point(12, 50);
            this.btnSaveScript.Name = "btnSaveScript";
            this.btnSaveScript.Size = new System.Drawing.Size(100, 30);
            this.btnSaveScript.Text = "Save Script";
            this.btnSaveScript.UseVisualStyleBackColor = true;

            // 
            // btnRunScript
            // 
            this.btnRunScript.Location = new System.Drawing.Point(12, 90);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(100, 30);
            this.btnRunScript.Text = "Run Script";
            this.btnRunScript.UseVisualStyleBackColor = true;

            // 
            // btnDeleteScript
            // 
            this.btnDeleteScript.Location = new System.Drawing.Point(12, 130);
            this.btnDeleteScript.Name = "btnDeleteScript";
            this.btnDeleteScript.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteScript.Text = "Delete Script";
            this.btnDeleteScript.UseVisualStyleBackColor = true;

            // 
            // lstScripts
            // 
            this.lstScripts.Location = new System.Drawing.Point(130, 12);
            this.lstScripts.Name = "lstScripts";
            this.lstScripts.Size = new System.Drawing.Size(200, 148);

            // 
            // lblScriptName
            // 
            this.lblScriptName.Location = new System.Drawing.Point(12, 180);
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(318, 23);
            this.lblScriptName.Text = "Select a script line...";

            // 
            // rtbScriptContent
            // 
            this.rtbScriptContent.Location = new System.Drawing.Point(12, 210);
            this.rtbScriptContent.Name = "rtbScriptContent";
            this.rtbScriptContent.Size = new System.Drawing.Size(318, 150);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(342, 370);
            this.Controls.Add(this.btnLoadScripts);
            this.Controls.Add(this.btnSaveScript);
            this.Controls.Add(this.btnRunScript);
            this.Controls.Add(this.btnDeleteScript);
            this.Controls.Add(this.lstScripts);
            this.Controls.Add(this.lblScriptName);
            this.Controls.Add(this.rtbScriptContent);
            this.Name = "Form1";
            this.Text = "Game Script Manager";
        }
    }
}