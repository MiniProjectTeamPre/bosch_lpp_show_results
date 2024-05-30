using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bosch_lpp_show_results {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            PictureBox pictureBox = new PictureBox();
            Label label = new Label();
            Result result = new Result();

            for (int i = 1; i <= 20; i++) {
                pictureBox = GetPictureBox(i);
                label = GetLabel(i);

                result.allText = GetMain(i);
                result = SplitResult(result);

                label.Text = LabelShow.sn + result.sn + LabelShow.newLine;

                if (result.result == Defile.pass) {
                    label.Text += LabelShow.pass;
                    label.ForeColor = Color.Lime;
                } else {

                    label.Text += LabelShow.fail + result.stepFail + LabelShow.newLine;
                    label.Text += LabelShow.value + result.value;
                    label.ForeColor = Color.Red;

                    pictureBox.Image = Image.FromFile(Defile.pathImageFail);
                }

                DeleteFile(i);
            }

            textBox1.Focus();
        }
        private void timer1_Tick(object sender, EventArgs e) {
            this.Focus();
            this.Activate();
            this.Show();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            this.Close();
        }

        private string GetMain(int head) {
            string result = "";

            try {
                result = File.ReadAllText(Defile.fileResult + head + Defile.lastNameTxt);
            } catch {
                ShowError(head);
            }

            return result;
        }
        private void ShowError(int head) {
            timer1.Stop();

            this.Activate();
            this.Show();
            MessageBox.Show(Defile.errorFile + head + Defile.lastNameTxt);

            timer1.Start();
        }
        private PictureBox GetPictureBox(int head) {
            PictureBox pictureBox = new PictureBox();

            switch (head) {
                case 1: pictureBox = pictureBox1; break;
                case 2: pictureBox = pictureBox2; break;
                case 3: pictureBox = pictureBox3; break;
                case 4: pictureBox = pictureBox4; break;
                case 5: pictureBox = pictureBox5; break;
                case 6: pictureBox = pictureBox6; break;
                case 7: pictureBox = pictureBox7; break;
                case 8: pictureBox = pictureBox8; break;
                case 9: pictureBox = pictureBox9; break;
                case 10: pictureBox = pictureBox10; break;
                case 11: pictureBox = pictureBox11; break;
                case 12: pictureBox = pictureBox12; break;
                case 13: pictureBox = pictureBox13; break;
                case 14: pictureBox = pictureBox14; break;
                case 15: pictureBox = pictureBox15; break;
                case 16: pictureBox = pictureBox16; break;
                case 17: pictureBox = pictureBox17; break;
                case 18: pictureBox = pictureBox18; break;
                case 19: pictureBox = pictureBox19; break;
                case 20: pictureBox = pictureBox20; break;
            }

            return pictureBox;
        }
        private Label GetLabel(int head) {
            Label label = new Label();

            switch (head) {
                case 1: label = label1; break;
                case 2: label = label2; break;
                case 3: label = label3; break;
                case 4: label = label4; break;
                case 5: label = label5; break;
                case 6: label = label6; break;
                case 7: label = label7; break;
                case 8: label = label8; break;
                case 9: label = label9; break;
                case 10: label = label10; break;
                case 11: label = label11; break;
                case 12: label = label12; break;
                case 13: label = label13; break;
                case 14: label = label14; break;
                case 15: label = label15; break;
                case 16: label = label16; break;
                case 17: label = label17; break;
                case 18: label = label18; break;
                case 19: label = label19; break;
                case 20: label = label20; break;
            }

            return label;
        }
        private Result SplitResult(Result data) {
            Result result = new Result();

            string[] split = data.allText.Split(',');
            result.result = split[result.splitResult];
            result.sn = split[result.splitSN];
            result.value = split[result.splitValue];
            result.stepFail = split[result.splitStepFail];

            return result;
        }
        private void DeleteFile(int head) {
            File.Delete(Defile.fileResult + head + Defile.lastNameTxt);
        } 

        public static class Defile {
            public static readonly string pass = "PASS";
            public static readonly string fail = "FAIL";
            public static readonly string fileResult = "bosch_lpp_show_results_head_";
            public static readonly string lastNameTxt = ".txt";
            public static readonly string errorFile = "not find file\r\nbosch_lpp_show_results_head_";
            public static readonly string pathImageFail = "../../config/bosch_lpp_image_fail.png";
        }
        public static class LabelShow {
            public static readonly string sn = "SN = ";
            public static readonly string pass = "PASS";
            public static readonly string fail = "FAIL = ";
            public static readonly string value = "Value = ";
            public static readonly string newLine = "\r\n";
        }
        public class Result {
            public string allText { get; set; }
            public string sn { get; set; }
            public string result { get; set; }
            public string stepFail { get; set; }
            public string value { get; set; }
            /// <summary>Value = 0</summary>
            public int splitResult { get; set; }
            /// <summary>Value = 1</summary>
            public int splitSN { get; set; }
            /// <summary>Value = 2</summary>
            public int splitStepFail { get; set; }
            /// <summary>Value = 3</summary>
            public int splitValue { get; set; }

            public Result() {
                splitResult = 0;
                splitSN = 1;
                splitStepFail = 2;
                splitValue = 3;
                
            }
        }
    }
}
