namespace cadastro_livro
{
    partial class Form1
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
            System.Windows.Forms.ColumnHeader Deleted;
            this.btnSalvar = new System.Windows.Forms.Button();
            this.textBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textSlug = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.textUrl = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.col_name = new System.Windows.Forms.ColumnHeader();
            this.col_slug = new System.Windows.Forms.ColumnHeader();
            this.col_foto_capa = new System.Windows.Forms.ColumnHeader();
            this.col_url = new System.Windows.Forms.ColumnHeader();
            this.col_descricao = new System.Windows.Forms.ColumnHeader();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.comboFotoCapa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textId = new System.Windows.Forms.TextBox();
            this.textDescricao = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.textFlip = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.percent = new System.Windows.Forms.Label();
            Deleted = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // Deleted
            // 
            Deleted.Text = "Deleted";
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSalvar.Location = new System.Drawing.Point(403, 285);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // textBusca
            // 
            this.textBusca.Location = new System.Drawing.Point(12, 47);
            this.textBusca.Name = "textBusca";
            this.textBusca.PlaceholderText = "Nome do Livro";
            this.textBusca.Size = new System.Drawing.Size(267, 23);
            this.textBusca.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(646, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Slug";
            // 
            // textSlug
            // 
            this.textSlug.Location = new System.Drawing.Point(646, 49);
            this.textSlug.Name = "textSlug";
            this.textSlug.PlaceholderText = "Slug do Livro";
            this.textSlug.Size = new System.Drawing.Size(183, 23);
            this.textSlug.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(643, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Foto Capa";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Imagem";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(456, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Url";
            // 
            // textUrl
            // 
            this.textUrl.Location = new System.Drawing.Point(457, 94);
            this.textUrl.Name = "textUrl";
            this.textUrl.PlaceholderText = "Url Digital";
            this.textUrl.Size = new System.Drawing.Size(183, 23);
            this.textUrl.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(285, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(457, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nome";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(457, 49);
            this.textName.Name = "textName";
            this.textName.PlaceholderText = "Nome do Livro";
            this.textName.Size = new System.Drawing.Size(183, 23);
            this.textName.TabIndex = 12;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Enabled = false;
            this.btnDeletar.Location = new System.Drawing.Point(484, 285);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 15;
            this.btnDeletar.Text = "Delete";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.col_name,
            this.col_slug,
            this.col_foto_capa,
            this.col_url,
            this.col_descricao,
            Deleted});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 76);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(348, 232);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 30;
            // 
            // col_name
            // 
            this.col_name.Text = "Nome";
            // 
            // col_slug
            // 
            this.col_slug.Text = "Slug";
            this.col_slug.Width = 40;
            // 
            // col_foto_capa
            // 
            this.col_foto_capa.Text = "Foto Capa";
            this.col_foto_capa.Width = 40;
            // 
            // col_url
            // 
            this.col_url.Text = "URL";
            this.col_url.Width = 40;
            // 
            // col_descricao
            // 
            this.col_descricao.Text = "Descrição";
            this.col_descricao.Width = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(403, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Descrição";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(565, 285);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 19;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // comboFotoCapa
            // 
            this.comboFotoCapa.FormattingEnabled = true;
            this.comboFotoCapa.Location = new System.Drawing.Point(646, 94);
            this.comboFotoCapa.Name = "comboFotoCapa";
            this.comboFotoCapa.Size = new System.Drawing.Size(183, 23);
            this.comboFotoCapa.TabIndex = 10;
            this.comboFotoCapa.Click += new System.EventHandler(this.comboFotoCapa_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Id";
            // 
            // textId
            // 
            this.textId.Enabled = false;
            this.textId.Location = new System.Drawing.Point(403, 49);
            this.textId.Name = "textId";
            this.textId.PlaceholderText = "Id Programa";
            this.textId.Size = new System.Drawing.Size(48, 23);
            this.textId.TabIndex = 20;
            // 
            // textDescricao
            // 
            this.textDescricao.Location = new System.Drawing.Point(403, 137);
            this.textDescricao.Name = "textDescricao";
            this.textDescricao.Size = new System.Drawing.Size(426, 86);
            this.textDescricao.TabIndex = 22;
            this.textDescricao.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(403, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Status";
            // 
            // textStatus
            // 
            this.textStatus.Enabled = false;
            this.textStatus.Location = new System.Drawing.Point(403, 94);
            this.textStatus.Name = "textStatus";
            this.textStatus.PlaceholderText = "Status do Programa";
            this.textStatus.Size = new System.Drawing.Size(48, 23);
            this.textStatus.TabIndex = 23;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Title = "Arquivo";
            // 
            // textFlip
            // 
            this.textFlip.Enabled = false;
            this.textFlip.Location = new System.Drawing.Point(403, 247);
            this.textFlip.Name = "textFlip";
            this.textFlip.PlaceholderText = "c://";
            this.textFlip.Size = new System.Drawing.Size(345, 23);
            this.textFlip.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(407, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 26;
            this.label9.Text = "Arquivo Flip";
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(754, 246);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 27;
            this.btnSelect.Text = "Selecionar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(695, 294);
            this.progressBar.Maximum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(134, 14);
            this.progressBar.TabIndex = 28;
            // 
            // percent
            // 
            this.percent.AutoSize = true;
            this.percent.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.percent.Location = new System.Drawing.Point(695, 280);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(41, 11);
            this.percent.TabIndex = 29;
            this.percent.Text = "Upload";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(861, 321);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textFlip);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.textDescricao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.comboFotoCapa);
            this.Controls.Add(this.textUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textSlug);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBusca);
            this.Controls.Add(this.btnSalvar);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSalvar;
        private TextBox textBusca;
        private Label label1;
        private Label label2;
        private TextBox textSlug;
        private Label label3;
        private OpenFileDialog openFileDialog1;
        private Label label5;
        private TextBox textUrl;
        private Button btnBuscar;
        private Label label6;
        private TextBox textName;
        private Button btnDeletar;
        private ListView listView1;
        private ColumnHeader col_name;
        private ColumnHeader col_slug;
        private ColumnHeader col_foto_capa;
        private ColumnHeader col_url;
        private ColumnHeader col_descricao;
        private Label label7;
        private Button btnLimpar;
        private ComboBox comboFotoCapa;
        private ColumnHeader id;
        private Label label4;
        private TextBox textId;
        private RichTextBox textDescricao;
        private Label label8;
        private TextBox textStatus;
        private ColumnHeader Deleted;
        private OpenFileDialog openFileDialog2;
        private TextBox textFlip;
        private Label label9;
        private Button btnSelect;
        private ProgressBar progressBar;
        private Label percent;
    }
}