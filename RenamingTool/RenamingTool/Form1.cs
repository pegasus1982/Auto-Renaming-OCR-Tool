using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Collections;

using TallComponents.PDF.Rasterizer;

using AForge.Imaging.Filters;

using Emgu;
using Emgu.CV.Structure;
using Emgu.CV;

using Tesseract;
using System.Text.RegularExpressions;

namespace RenamingTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_SelectInputFolder_Click(object sender, EventArgs e)
        {
            using(var fbd = new FolderBrowserDialog())
            {
                DialogResult = fbd.ShowDialog();
                if(DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    lb_InputFolderPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void Btn_SelectOutputFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult = fbd.ShowDialog();
                if (DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    lb_OutputFolderPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if(lb_InputFolderPath.Text == "" || lb_OutputFolderPath.Text == "")
            {
                MessageBox.Show("Please select correct Input/Output folder");
            }
            else
            {
                this.btn_Start.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                Thread t = new Thread(() => Renaming());
                t.Start();
            }
        }

        private void Renaming()
        {
            string strDirectoryPath = lb_InputFolderPath.Text;
            DirectoryInfo d = new DirectoryInfo(strDirectoryPath);
            //DirectoryInfo d = new DirectoryInfo(@"C:\Users\gaodawang\Desktop\ocr-input");

            FileInfo[] files = d.GetFiles("*.pdf");
            foreach (FileInfo file in files)
            {
                string filename = file.FullName;
                string strImgFileName = filename + ".png";

                //get template image
                //"Bezeichnung"
                Bitmap bmpTemplate = new Bitmap(@"template-2.png");

                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    float resolution = 450;
                    float scale = resolution / 72f;

                    Document doc = new Document(fs);

                    //get first page
                    TallComponents.PDF.Rasterizer.Page page = doc.Pages[0];

                    //draw page to image
                    using (Bitmap bmp = new Bitmap((int)page.Width, (int)page.Height))
                    using (Graphics graphics = Graphics.FromImage(bmp))
                    {
                        graphics.TranslateTransform(-(float)((scale - 1) * page.Width), -(float)((scale - 1) * page.Height));
                        graphics.ScaleTransform(scale, scale);
                        page.Draw(graphics);

                        //Bitmap bmp = new Bitmap(bmp);
                        //bmp = bmp.Clone(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        
                        Image<Bgr,byte> source = new Image<Bgr, byte>(bmp); //source
                        Image<Bgr, byte> template = new Image<Bgr, byte>(bmpTemplate); //template
                        Image<Bgr, byte> imgToShow = source.Copy();

                        using (Image<Gray, float> result = source.MatchTemplate(template, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
                        {
                            double[] minValues, maxValues;
                            Point[] minLocations, maxLocations;
                            result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                            if (maxValues[0] > 0.5)
                            {
                                Size sz = new Size();
                                sz.Width = template.Size.Width - 30;
                                sz.Height = template.Size.Height;
                                sz.Height -= 70;

                                Point offset = maxLocations[0];
                                offset.X += 15;
                                offset.Y += 50;

                                System.Drawing.Rectangle cropRect = new System.Drawing.Rectangle(offset, sz);

                                Bitmap finalImage = new Bitmap(cropRect.Width, cropRect.Height);
                                using(Graphics g = Graphics.FromImage(finalImage))
                                {
                                    g.DrawImage(bmp, new System.Drawing.Rectangle(0, 0, finalImage.Width, finalImage.Height), cropRect, GraphicsUnit.Pixel);
                                    //finalImage.Save(filename + ".01.final.png");

                                    //convert to 24bit rgb
                                    Bitmap bmpFormat24RGB = new Bitmap(finalImage);
                                    bmpFormat24RGB = bmpFormat24RGB.Clone(new System.Drawing.Rectangle(0, 0, finalImage.Width, finalImage.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                                    //apply filters

                                    //invert
                                    Invert fl_Invert = new Invert();
                                    fl_Invert.ApplyInPlace(bmpFormat24RGB);
                                    //bmpFormat24RGB.Save(filename + ".02.invert.png");

                                    //color filter
                                    ColorFiltering fl_ColorFilter = new ColorFiltering();
                                    fl_ColorFilter.Red      = new AForge.IntRange(140, 255);
                                    fl_ColorFilter.Green    = new AForge.IntRange(140, 255);
                                    fl_ColorFilter.Blue     = new AForge.IntRange(140, 255);
                                    fl_ColorFilter.ApplyInPlace(bmpFormat24RGB);
                                    //bmpFormat24RGB.Save(filename + ".03.color-filter.png");

                                    //sharp
                                    Sharpen fl_Sharp = new Sharpen();
                                    fl_Sharp.ApplyInPlace(bmpFormat24RGB);
                                    //bmpFormat24RGB.Save(filename + ".04.sharpen.png");

                                    bmpFormat24RGB.Save(filename + ".detected.png");
                                    SetImage(bmpFormat24RGB);

                                    var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                                    ocr.SetVariable("tessedit_char_whitelist", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ_&");
                                    var txt = ocr.Process(bmpFormat24RGB);

                                    var strFullText = txt.GetText();
                                    string strRes = Regex.Replace(strFullText, @"\n\n", "_");
                                    strRes = Regex.Replace(strRes, @",", "");
                                    strRes = Regex.Replace(strRes, @" ", "_");
                                    SetText(strRes);

                                    string strDestFolderPath = lb_OutputFolderPath.Text;

                                    string strDestFileName = strDestFolderPath + "/";

                                    //check add prefix checkbox
                                    if(checkBox2.Checked == true && txt_Prefix.Text != "")
                                    {
                                        string prefix = txt_Prefix.Text;
                                        strDestFileName += prefix + "_";
                                    }

                                    strDestFileName += strRes;

                                    //check add date checkbox
                                    if (checkBox3.Checked == true)
                                    {
                                        DateTime date = DateTime.Today;
                                        strDestFileName += "_" + date.ToString("yyyyMMdd");
                                    }
                                    strDestFileName += ".pdf";

                                    //check ask every time
                                    if(checkBox1.Checked == true)
                                    {
                                        if(MessageBox.Show("Do you want to save for this File?","Info",MessageBoxButtons.YesNo) == DialogResult.Yes)
                                        {
                                            //Copy file
                                            System.IO.File.Copy(filename, strDestFileName);
                                        }
                                    }
                                    else
                                    {
                                        //Copy file
                                        System.IO.File.Copy(filename, strDestFileName);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SetText(string text)
        {
            if (textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }

        private void SetImage(Bitmap bmp)
        {
            if (pictureBox1.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(SetImage);
                this.Invoke(d, new object[] { bmp });
            }
            else
            {
                pictureBox1.Image = (Image)bmp;
            }
        }
    }

    delegate void SetTextCallback(string text);
    delegate void SetImageCallback(Bitmap bmp);
}