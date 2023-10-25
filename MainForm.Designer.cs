namespace Pdf2Image
{
    partial class MaintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintForm));
            labelFilePath = new Label();
            textBoxFilePath = new TextBox();
            buttonFilePath = new Button();
            buttonOutputFolder = new Button();
            textBoxOutputFolder = new TextBox();
            labelOutputFolder = new Label();
            checkBoxLongImage = new CheckBox();
            buttonOK = new Button();
            SuspendLayout();
            // 
            // labelFilePath
            // 
            labelFilePath.AutoSize = true;
            labelFilePath.Location = new Point(12, 15);
            labelFilePath.Name = "labelFilePath";
            labelFilePath.Size = new Size(59, 17);
            labelFilePath.TabIndex = 0;
            labelFilePath.Text = "File Path:";
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(110, 12);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(581, 23);
            textBoxFilePath.TabIndex = 1;
            textBoxFilePath.Text = "D:\\YYXGithub\\Pdf2Image\\TestFiles\\2009最后的邪神种子.pdf";
            // 
            // buttonFilePath
            // 
            buttonFilePath.Location = new Point(697, 12);
            buttonFilePath.Name = "buttonFilePath";
            buttonFilePath.Size = new Size(75, 23);
            buttonFilePath.TabIndex = 2;
            buttonFilePath.Text = "Select";
            buttonFilePath.UseVisualStyleBackColor = true;
            buttonFilePath.Click += buttonFilePath_Click;
            // 
            // buttonOutputFolder
            // 
            buttonOutputFolder.Location = new Point(697, 50);
            buttonOutputFolder.Name = "buttonOutputFolder";
            buttonOutputFolder.Size = new Size(75, 23);
            buttonOutputFolder.TabIndex = 5;
            buttonOutputFolder.Text = "Select";
            buttonOutputFolder.UseVisualStyleBackColor = true;
            buttonOutputFolder.Click += buttonOutputFolder_Click;
            // 
            // textBoxOutputFolder
            // 
            textBoxOutputFolder.Location = new Point(110, 50);
            textBoxOutputFolder.Name = "textBoxOutputFolder";
            textBoxOutputFolder.Size = new Size(581, 23);
            textBoxOutputFolder.TabIndex = 4;
            textBoxOutputFolder.Text = "D:\\YYXGithub\\Pdf2Image\\TestFiles";
            // 
            // labelOutputFolder
            // 
            labelOutputFolder.AutoSize = true;
            labelOutputFolder.Location = new Point(12, 53);
            labelOutputFolder.Name = "labelOutputFolder";
            labelOutputFolder.Size = new Size(92, 17);
            labelOutputFolder.TabIndex = 3;
            labelOutputFolder.Text = "Output Folder:";
            // 
            // checkBoxLongImage
            // 
            checkBoxLongImage.AutoSize = true;
            checkBoxLongImage.Checked = true;
            checkBoxLongImage.CheckState = CheckState.Checked;
            checkBoxLongImage.Location = new Point(110, 88);
            checkBoxLongImage.Name = "checkBoxLongImage";
            checkBoxLongImage.Size = new Size(97, 21);
            checkBoxLongImage.TabIndex = 7;
            checkBoxLongImage.Text = "Long Image";
            checkBoxLongImage.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.Location = new Point(697, 87);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 8;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // MaintForm
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 122);
            Controls.Add(buttonOK);
            Controls.Add(checkBoxLongImage);
            Controls.Add(buttonOutputFolder);
            Controls.Add(textBoxOutputFolder);
            Controls.Add(labelOutputFolder);
            Controls.Add(buttonFilePath);
            Controls.Add(textBoxFilePath);
            Controls.Add(labelFilePath);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MaintForm";
            Text = "Pdf to Image";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelFilePath;
        private TextBox textBoxFilePath;
        private Button buttonFilePath;
        private Button buttonOutputFolder;
        private TextBox textBoxOutputFolder;
        private Label labelOutputFolder;
        private CheckBox checkBox1;
        private Button buttonOK;
        private CheckBox checkBoxLongImage;
    }
}