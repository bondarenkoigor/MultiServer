namespace WinformsClient
{
    partial class ClientForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.AttachFileButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(50, 401);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(749, 50);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBox_KeyDown);
            // 
            // AttachFileButton
            // 
            this.AttachFileButton.BackgroundImage = global::WinformsClient.Properties.Resources.AttachFile;
            this.AttachFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AttachFileButton.FlatAppearance.BorderSize = 0;
            this.AttachFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AttachFileButton.Location = new System.Drawing.Point(0, 401);
            this.AttachFileButton.Name = "AttachFileButton";
            this.AttachFileButton.Size = new System.Drawing.Size(50, 50);
            this.AttachFileButton.TabIndex = 1;
            this.AttachFileButton.UseVisualStyleBackColor = true;
            this.AttachFileButton.Click += new System.EventHandler(this.AttachFileButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 1);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(799, 403);
            this.flowLayoutPanel.TabIndex = 2;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AttachFileButton);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClientForm";
            this.Text = "Client";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button AttachFileButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}

