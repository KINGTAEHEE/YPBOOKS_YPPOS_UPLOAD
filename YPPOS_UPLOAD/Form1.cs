using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace YPPOS_UPLOAD
{
    public partial class Form1 : Form
    {
        string[,] branch = new string[100, 2];
        string[] fileSourceNames = new string[2];
        int totalBranchCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            // 지점.txt 파일로부터 지점코드와 지점명을 불러온다
            ReadBranchFile();
            // 지점만큼 체크박스 버튼을 만든다
            MakeCheckBoxButton();

            progressBar1.Step = 100;
        }

        // 지점.txt 파일로부터 지점코드와 지점명을 불러온다
        private void ReadBranchFile()
        {
            FileInfo file = new FileInfo("지점.txt");
            if (file == null)
            {
                MessageBox.Show("지점.txt 파일이 존재하지 않습니다.\r확인해주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StreamReader sr = new StreamReader("지점.txt");
            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();
                string[] split = line.Split('\t');
                branch[totalBranchCount, 0] = split[0];
                branch[totalBranchCount, 1] = split[1];
                totalBranchCount++;
            }
            sr.Close();
        }

        private void MakeCheckBoxButton()
        {
            // 남은 열 갯수
            int checkBoxCol = totalBranchCount % 4;
            // 행 갯수
            int checkBoxRow = totalBranchCount / 4;
            // 카운터
            int i = 0;

            // 지점 수 4의 배수만큼 체크 박스를 만든다
            for (int j = 0; j < checkBoxRow; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Name = branch[i, 0];
                    checkBox.Location = new Point(14 + (k * 135), 20 + (j * 22));
                    checkBox.Size = new Size(130, 16);
                    checkBox.Text = branch[i, 0] + " " + branch[i, 1];
                    groupBox1.Controls.Add(checkBox);
                    i++;
                }
            }

            // 남은 지점 수(남은 열 갯수)만큼 체크 박스를 만든다
            for (int j = 0; j < checkBoxCol; j++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Name = branch[i, 0];
                checkBox.Location = new Point(14 + (j * 135), 20 + (checkBoxRow * 22));
                checkBox.Size = new Size(130, 16);
                checkBox.Text = branch[i, 0] + " " + branch[i, 1];
                groupBox1.Controls.Add(checkBox);
                i++;
            }
        }

        private void buttonUploadFile_Click(object sender, EventArgs e)
        {
            ShowFileOpenDialog();
        }

        public void ShowFileOpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // 담고있던 리스트뷰 및 파일명 정보 초기화
                listViewFileList.Items.Clear();
                fileSourceNames = new string[2];

                foreach (string file in ofd.FileNames)
                {
                    try
                    {
                        listViewFileList.Items.Add(file);
                        fileSourceNames = ofd.SafeFileNames;
                    }
                    catch
                    {
                        MessageBox.Show("파일을 불러오는데 오류가 발생했습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void buttonAllSelect_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked == false)
                    {
                        cb.Checked = true;
                    }
                }
            }
        }

        private void buttonAllCancel_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked == true)
                    {
                        cb.Checked = false;
                    }
                }
            }
        }

        private void buttonUploadStart_Click(object sender, EventArgs e)
        {
            string fileTargetPath1 = @"D:\pos\POSDATA\PGM\";
            // 체크된 체크 박스 갯수 카운터
            int i = 0;

            if (MessageBox.Show("파일 업로드를 진행하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // 선택된 파일이 없으면 메시지박스 띄운다
                if (listViewFileList.Items.Count == 0)
                {
                    MessageBox.Show("선택된 파일이 없습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // 선택된 파일이 1개일 때
                else if (listViewFileList.Items.Count == 1)
                {
                    try
                    {
                        foreach (Control c in groupBox1.Controls)
                        {
                            if (c is CheckBox)
                            {
                                CheckBox cb = (CheckBox)c;
                                if (cb.Checked == true)
                                {
                                    i++;
                                }
                            }
                        }

                        foreach (Control c in groupBox1.Controls)
                        {
                            if (c is CheckBox)
                            {
                                CheckBox cb = (CheckBox)c;
                                if (cb.Checked == true)
                                {
                                    string fileTargetPath2 = cb.Name;
                                    System.IO.Directory.CreateDirectory(fileTargetPath1 + fileTargetPath2);
                                    System.IO.File.Copy(listViewFileList.Items[0].ToString(), fileTargetPath1 + fileTargetPath2 + "\\" + fileSourceNames[0], true);
                                }
                            }
                        }
                        // 선택된 파일은 있지만 선택된 지점이 없으면 메시지박스 띄운다
                        if (i == 0)
                        {
                            MessageBox.Show("선택된 지점이 없습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("파일 업로드에 실패했습니다.\r파일이 올바른지 확인해주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    progressBar1.PerformStep();
                    i = 0;
                    MessageBox.Show("파일 업로드를 완료했습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // 선택된 파일이 2개일 때
                else if (listViewFileList.Items.Count == 2)
                {
                    try
                    {
                        foreach (Control c in groupBox1.Controls)
                        {
                            if (c is CheckBox)
                            {
                                CheckBox cb = (CheckBox)c;
                                if (cb.Checked == true)
                                {
                                    i++;
                                }
                            }
                        }

                        foreach (Control c in groupBox1.Controls)
                        {
                            if (c is CheckBox)
                            {
                                CheckBox cb = (CheckBox)c;
                                if (cb.Checked == true)
                                {
                                    string fileTargetPath2 = cb.Name;
                                    System.IO.Directory.CreateDirectory(fileTargetPath1 + fileTargetPath2);
                                    System.IO.File.Copy(listViewFileList.Items[0].ToString(), fileTargetPath1 + fileTargetPath2 + "\\" + fileSourceNames[0], true);
                                    System.IO.File.Copy(listViewFileList.Items[1].ToString(), fileTargetPath1 + fileTargetPath2 + "\\" + fileSourceNames[1], true);
                                    progressBar1.PerformStep();
                                }
                            }
                        }
                        // 선택된 파일은 있지만 선택된 지점이 없으면 메시지박스 띄운다
                        if (i == 0)
                        {
                            MessageBox.Show("선택된 지점이 없습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("파일 업로드에 실패했습니다.\r파일이 올바른지 확인해주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    progressBar1.PerformStep();
                    i = 0;
                    MessageBox.Show("파일 업로드를 완료했습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("파일 갯수가 잘못됐습니다. 확인해주세요.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}