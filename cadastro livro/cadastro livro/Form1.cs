namespace cadastro_livro
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;
    using System.IO;
    using System.Net;

    public partial class Form1 : Form
    {
        public string sql = "";
        public string path = "";
        public string name = "";
        public string fileUrl = "";
        public int flag = 0;
        float tamArquivo, tamPacote = 0, percentEnvio;

        MySqlConnection con = new MySqlConnection("server=localhost; database=catalogo; user id=root; password=iab123; port=3306;");
        MySqlDataReader reader;
        FileInfo fileInfo;

        public Form1()
        {
            InitializeComponent();

            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            try
            {
                con.Open();

                //MessageBox.Show("Conectou!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        void carregaVars(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();

                #region select_livro
                if (textBusca.Text != "")
                    sql = "SELECT id, nome, slug, foto_capa, url_digital, descricao, deleted_at FROM catalogo.produtos WHERE nome LIKE'" + textBusca.Text + "%' ORDER BY id ASC";
                
                else
                    sql = "SELECT id, nome, slug, foto_capa, url_digital, descricao, deleted_at FROM catalogo.produtos ORDER BY id ASC";
                #endregion

                #region alimenta_tabela
                MySqlCommand comando = new MySqlCommand(sql, con);

                if(reader != null)
                    reader.Close();

                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem list = new ListViewItem(reader[0].ToString());
                    list.SubItems.Add(reader[1].ToString());
                    list.SubItems.Add(reader[2].ToString());
                    list.SubItems.Add(reader[3].ToString());
                    list.SubItems.Add(reader[4].ToString());
                    list.SubItems.Add(reader[5].ToString());
                    list.SubItems.Add(reader[6].ToString());

                    listView1.Items.AddRange(new ListViewItem[] { list });
                }
                #endregion

                //verifica se há livros com o nome buscado
                if (listView1.Items.Count == 0)
                {
                    btnLimpar_Click(sender, e);
                    MessageBox.Show("Não há livro registrado com esse nome", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Listagem de livro completa!");
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //verifica se há campos vazios
                if (textName.Text == "" || textSlug.Text == "" || textUrl.Text == "" || textDescricao.Text == "" || comboFotoCapa.Text == "")
                    MessageBox.Show("Informe o(s) campos do produto.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else
                {
                    #region insert
                    if (textId.Text == "")
                    {
                        if (reader != null)
                            reader.Close();

                        sql = "INSERT INTO catalogo.produtos(tipo_produto_id, descricao, foto_capa, url_digital, created_at, nome, slug)" +
                            "VALUES('" + 1 + "', '" + textDescricao.Text + "', '" + comboFotoCapa.Text + "', '" + textUrl.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + textName.Text + "', '" + textSlug.Text + "')";

                        MySqlCommand comando = new MySqlCommand(sql, con);

                        reader = comando.ExecuteReader();

                    }
                    #endregion
                    #region update
                    else
                    {
                        if(reader != null) 
                            reader.Close();

                        sql = "UPDATE catalogo.produtos SET nome='" + textName.Text + "'," +
                            "descricao = '" + textDescricao.Text + "'," +
                            "foto_capa = '" + comboFotoCapa.Text + "'," +
                            "url_digital = '" + textUrl.Text + "'," +
                            "updated_at = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                            "slug = '" + textSlug.Text + "'" +
                            "WHERE catalogo.produtos.id = '" + textId.Text + "'";

                        MySqlCommand comando = new MySqlCommand(sql, con);

                        reader = comando.ExecuteReader();
                    }
                    #endregion

                    #region verifica_operacao
                    if (reader != null)
                    {
                        textBusca.Text = textName.Text;
                        MessageBox.Show("Registrado com sucesso!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //verifica se há arquivo para upload no servidor FTP
                        if (textFlip.Text != "")
                            verificaFTP(sender, e);

                        reader.Close();

                        carregaVars(sender, e);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Sucesso ao salvar livro");
            }
            
        }
        private void listaPastasFtp(NetworkCredential credentials, string enderecoFTP)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(enderecoFTP);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = credentials;
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                //Obtem pastas do FTP
                List<string> pastasFTP = new List<string>();
                StreamReader reader = new StreamReader(responseStream);

                //adiciona para o array pastasFTP as pastas dos livros no servidor ftp
                while (!reader.EndOfStream)
                {
                    pastasFTP.Add(reader.ReadLine());
                }
                reader.Close();
                response.Close();

                //Verifica se há pastas no array pastasFTP
                if (pastasFTP.Count > 0)
                {
                    //percorre todas as pastas
                    foreach (string pasta in pastasFTP)
                    {
                        //verifica se existe pasta com o nome do id do livro
                        if (pasta == textId.Text)
                        {
                            //Deleta Pasta antiga no Servidor FTP
                            deleteFtpDirectory(enderecoFTP + textId.Text + "/", credentials);
                        }
                    }
                }

                //esvazia array utilizado para adicionar as pastas dos livros
                pastasFTP.Clear();
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.ToString()); 
            }
            finally
            {
                Console.WriteLine("Listagem completa!");
                criaPastaLivro(credentials, enderecoFTP);
            }
            
        }
        private void criaPastaLivro(NetworkCredential credentials, string enderecoFTP)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(enderecoFTP+textId.Text);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = credentials;
                request.Proxy = null;
                request.KeepAlive = true;
                request.UseBinary = true;

                //criar pasta no servidor ftp
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                response.Close();

                tamanhoArquivosFlip(fileInfo.DirectoryName);

            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Pasta criada com sucesso!");
            }
        }
        private void deleteFtpDirectory(string url, NetworkCredential credentials)
        {
            try
            {
                var listRequest = (FtpWebRequest)WebRequest.Create(url);
                listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                listRequest.Credentials = credentials;

                List<string> lines = new List<string>();

                using (var listResponse = (FtpWebResponse)listRequest.GetResponse())
                using (Stream listStream = listResponse.GetResponseStream())
                using (var listReader = new StreamReader(listStream))
                {
                    while (!listReader.EndOfStream)
                    {
                        lines.Add(listReader.ReadLine());
                    }
                }

                foreach (string line in lines)
                {
                    string[] tokens =
                        line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[8];
                    string permissions = tokens[0];

                    string fileUrl = url + name;

                    if (permissions[0] == 'd')
                    {
                        deleteFtpDirectory(fileUrl + "/", credentials);
                    }
                    else
                    {
                        var deleteRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                        deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                        deleteRequest.Credentials = credentials;

                        deleteRequest.GetResponse();
                    }
                }

                var removeRequest = (FtpWebRequest)WebRequest.Create(url);
                removeRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
                removeRequest.Credentials = credentials;

                removeRequest.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Pasta do livro deletada com Sucesso!");
            }
        }
        private void tamanhoArquivosFlip(string caminho)
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (var dir in Directory.EnumerateFileSystemEntries(caminho))
                    lines.Add(dir.Substring(dir.LastIndexOf("\\") + 1));

                foreach (string line in lines)
                {
                    string[] tokens =
                        line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);

                    name = tokens[0];

                    if ((line).Contains("."))
                        tamArquivo += line.Length;
                    
                    else
                        tamanhoArquivosFlip(caminho + "\\" + name + "\\");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                progressBar.Maximum = ((int)tamArquivo);
                Console.WriteLine("Tamanho de arquivo para envio contabilizado");
            }
        }
        private void verificaFTP(object sender, EventArgs e) {
            try
            {
                //Dados para conexao ao servidor FTP
                var enderecoFTP = "ftp://127.0.0.1//html//";
                var usuarioFTP = "root";
                var senhaFTP = "root123";
                var credentials = new NetworkCredential(usuarioFTP, senhaFTP);

                listaPastasFtp(credentials, enderecoFTP);
                
                copiaArquivosFTP(enderecoFTP+ textId.Text + "/", credentials, fileInfo.DirectoryName);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                finaliza(sender, e);
            }
        }
        private void atualizaBarraProgresso()
        {
            progressBar.Value = (int)tamPacote;

            percentEnvio = (tamPacote / (tamArquivo * 100));
        }
        private void copiaArquivosFTP(string url, NetworkCredential credentials, string caminho)
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (var dir in Directory.EnumerateFileSystemEntries(caminho))
                    lines.Add(dir.Substring(dir.LastIndexOf("\\") + 1));

                foreach (var aux1 in lines)
                {
                    if (flag == 0 && aux1 == "index.html")
                    {
                        try
                        {
                            var uploadRequest = (FtpWebRequest)WebRequest.Create(url + aux1);
                            uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                            uploadRequest.Credentials = credentials;

                            FileInfo arquivo = new FileInfo(caminho + "\\" + aux1);

                            using (Stream fileStream = File.OpenRead(arquivo.ToString()))
                            using (Stream ftpStream = uploadRequest.GetRequestStream())
                            {
                                fileStream.CopyTo(ftpStream);
                            }
                            
                            flag++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString());
                        }
                        finally
                        {
                            Console.WriteLine("arquivo " + aux1 + " enviado com sucesso.");
                        }
                    }
                }

                foreach (string line in lines)
                {
                    string[] tokens =
                        line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);

                    name = tokens[0];

                    fileUrl = url + name;

                    if ((line).Contains("."))
                    {
                        try
                        {
                            var uploadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                            uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                            uploadRequest.Credentials = credentials;

                            FileInfo arquivo = new FileInfo(caminho + line);

                            using (Stream fileStream = File.OpenRead(arquivo.ToString()))
                            using (Stream ftpStream = uploadRequest.GetRequestStream())
                            {
                                fileStream.CopyTo(ftpStream);
                            }

                            tamPacote += line.Length;

                            atualizaBarraProgresso();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString());
                        }
                        finally
                        {
                            Console.WriteLine("arquivo "+line+" enviado com sucesso.");
                        }
                    }
                    else
                    {
                        try
                        {
                            var makeDirectoryRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                            makeDirectoryRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                            makeDirectoryRequest.Credentials = credentials;

                            makeDirectoryRequest.GetResponse();

                            copiaArquivosFTP(fileUrl + "/", credentials, caminho + "\\" + name + "\\");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString());
                        }
                        finally
                        {
                            Console.WriteLine("pasta " + line + " criada com sucesso.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }
        private void selecionaArquivo(object sender, EventArgs e)
        {
            try
            {
                openFileDialog2.Multiselect = true;
                openFileDialog2.Title = "Select File";
                openFileDialog2.CheckFileExists = true;
                openFileDialog2.CheckPathExists = true;
                openFileDialog2.FilterIndex = 2;
                openFileDialog2.RestoreDirectory = true;
                openFileDialog2.ReadOnlyChecked = true;
                openFileDialog2.ShowReadOnly = true;

                MessageBox.Show("Selecione o arquivo flip para envio", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    fileInfo = new FileInfo(openFileDialog2.FileName);
                    textFlip.Text = fileInfo.FullName;
                }
                else
                    MessageBox.Show("Arquivo não selecionado!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (WebException ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Arquivos para envio selecionados com sucesso!");
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            carregaVars(sender, e);
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                #region alimenta_campos
                textId.Text = listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text;
                textName.Text = listView1.Items[listView1.FocusedItem.Index].SubItems[1].Text;
                textSlug.Text = listView1.Items[listView1.FocusedItem.Index].SubItems[2].Text;
                comboFotoCapa.Text = listView1.Items[listView1.FocusedItem.Index].SubItems[3].Text;
                textUrl.Text = listView1.Items[listView1.FocusedItem.Index].SubItems[4].Text;
                textDescricao.Text = listView1.Items[listView1.FocusedItem.Index].SubItems[5].Text;
                #endregion

                #region status_livro
                //verifica se o livro esta ativo
                if (listView1.Items[listView1.FocusedItem.Index].SubItems[6].Text == "")
                {
                    textStatus.Text = "Ativo";
                    textStatus.BackColor = Color.Green;
                    btnDeletar.Enabled = true;
                }
                else
                {
                    textStatus.Text = "Inativo";
                    textStatus.BackColor = Color.Red;
                    btnDeletar.Enabled = false;
                }
                #endregion

                btnSelect.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Livro selecionado!");
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textId != null)
                {
                    if (MessageBox.Show("Deseja excluir o livro?", "Delete", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            //Delete logico

                            //sql = "DELETE FROM catalogo.produtos WHERE id='" + listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text + "'";
                            sql = "UPDATE catalogo.produtos SET deleted_at ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                                "WHERE catalogo.produtos.id = '" + textId.Text + "'";

                            MySqlCommand comando = new MySqlCommand(sql, con);

                            reader = comando.ExecuteReader();

                            if (reader != null)
                                MessageBox.Show("Livro deletado com sucesso.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            reader.Close();

                            btnLimpar.PerformClick();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("The process failed: {0}", ex.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não há livro selecionado para ser deletado", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Deleção do livro realizada com sucesso!");
                carregaVars(sender, e);
            }
        }
        private void comboFotoCapa_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Open Image";
                openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
                    comboFotoCapa.Text = fileInfo.Name;
                }
                else
                    MessageBox.Show("Foto de capa não selecionada!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Capa de livro selecionada com sucesso!");
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            comboFotoCapa.Text = "Selecionado";
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            selecionaArquivo(sender, e);
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                //limpa campos do livro selecionado
                textId.Text = "";
                textName.Text = "";
                textSlug.Text = "";
                textUrl.Text = "";
                textDescricao.Text = "";
                comboFotoCapa.Text = "Select";
                textStatus.Text = "";
                textFlip.Text = "";

                textStatus.BackColor = SystemColors.Window;

                btnSelect.Enabled = false;
                btnDeletar.Enabled = false;
                path = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("Campos limpos com sucesso!");
            }
        }
        private void finaliza(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Upload de arquivos realizado com sucesso!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #region busca pelo livro alterado
                var aux = textName.Text;

                btnLimpar_Click(sender, e);

                textBusca.Text = aux;

                carregaVars(sender, e);
                #endregion

                //restaura variaveis
                reader.Close(); fileInfo.Refresh(); path = ""; name = "";
                fileUrl = ""; flag = 0; tamArquivo = 0; tamPacote = 0;
                progressBar.Value = 0; percent.Text = "Upload: 0%";
            }
            catch(Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine("The Process Sucess!");
            }
        }
    }
}

        