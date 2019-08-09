using mshtml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidenLearningEnglish
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisibleAttribute(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public partial class LookupWord : Form
    {
        public delegate void ExtWordDelegate(string text);
        public event ExtWordDelegate WordReceived;
        public LookupWord()
        {
            InitializeComponent();
            this.webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            this.webBrowser1.ScriptErrorsSuppressed = false;
            this.webBrowser1.ObjectForScripting = this;
            //this.LostFocus += LookupWord_LostFocus;
            this.Deactivate += LookupWord_Deactivate;

            this.label1.MouseDown += new MouseEventHandler(label1_MouseDown);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;
        protected override void OnPaint(PaintEventArgs e)
        {
            //Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            //ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            //rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            //e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void LookupWord_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LookupWord_LostFocus(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void ExtClose()
        {
            this.Hide();
        }
        public void ExtWord(String text)
        {
            if (string.IsNullOrEmpty(text)) return;

            if (WordReceived != null)
            {
                WordReceived(text);
            }
        }
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.webBrowser1.Document != null)
            {
                var doc = this.webBrowser1.Document;
                //Console.WriteLine(this.webBrowser1.DocumentText);

                if (e.Url.AbsolutePath.EndsWith("/ttranslatev3"))
                {
                    //[{"detectedLanguage":{"language":"en","score":1.0},"translations":[{"text":"阻碍增长","transliteration":{"text":"zǔ ài zēng zhǎng","script":"Latn"},"to":"zh-Hans"}]}]
                    return;
                }

                if (doc.Body != null && string.IsNullOrEmpty(doc.Body.InnerText))
                {
                    //string posturl = "https://cn.bing.com/ttranslatev3?&IG=EDB8DE8378C4462386978A3559F91228&IID=SERP.5537.15";
                    //string postData = "&fromLang=en&text=" + this.Text + "&to=zh-Hans";
                    //string headers = "";
                    //this.webBrowser1.Navigate(posturl, "", Encoding.UTF8.GetBytes(postData), headers);
                    string jsonResponse = Translate(this.Text);
                    if (!string.IsNullOrEmpty(jsonResponse))
                    {
                        try
                        {
                            JsonValue json = System.Json.JsonObject.Parse(jsonResponse);
                            if (json is JsonArray)
                            {
                                var item = ((JsonArray)json)[0];
                                if (item.ContainsKey("translations"))
                                {
                                    var text = item["translations"][0]["text"];
                                    this.webBrowser1.DocumentText = text;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    return;
                }

                var ht = doc.GetElementById("ht_logo");
                if (ht != null)
                {
                    //ht.InnerHtml = "<a href=\"#\" onclick=\"javascript:window.external.ExtWord('" + this.Text + "');\">访问</a>"
                    //    + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\" onclick=\"javascript:window.external.ExtClose();\">关闭</a>";

                    if (ht.NextSibling != null && ht.NextSibling.NextSibling != null)
                    {
                        if (ht.NextSibling.TagName == "H4" && ht.NextSibling.NextSibling.TagName == "SPAN")
                        {
                            string danci = ht.NextSibling.InnerText;
                            string fayin = ht.NextSibling.NextSibling.InnerText;
                            //    ht.NextSibling.NextSibling.OuterHtml = "";
                            //    ht.NextSibling.InnerHtml = ht.NextSibling.InnerHtml + "&nbsp;&nbsp;" + fayin;

                            this.label1.Text = danci;

                            ht.NextSibling.OuterHtml = "";
                        }
                    }

                    ht.OuterHtml = "";

                    HtmlElement head = webBrowser1.Document.GetElementsByTagName("head")[0];
                    HtmlElement styleEl = webBrowser1.Document.CreateElement("style");
                    IHTMLStyleElement element = (IHTMLStyleElement)styleEl.DomElement;
                    IHTMLStyleSheet styleSheet = element.styleSheet;
                    if (styleSheet == null)
                    {
                        IHTMLDocument2 doc2 = (webBrowser1.Document.DomDocument) as IHTMLDocument2;
                        styleSheet = doc2.createStyleSheet("", 0);
                    }
                    styleSheet.cssText = @"h4 {color:red;font-size:16px;margin-top:0;margin-bottom:5px;} body {margin:5;font-size:12px} #ht_logo{float:right;}";
                    head.AppendChild(styleEl);
                }
            }
        }
        private string Translate(string word)
        {
            if (string.IsNullOrEmpty(word)) return "";
            try
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create("https://cn.bing.com/ttranslatev3?&IG=EDB8DE8378C4462386978A3559F91228&IID=SERP.5537.15");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                //WRITE JSON DATA TO VARIABLE D
                string postData = "&fromLang=en&text=" + word + "&to=zh-Hans";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                //            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
        public void HoverTrans(string word)
        {
            Console.WriteLine("looking up " + word);
            this.Text = word;
            this.label1.Text = word;
            if (word.Contains(" "))
            {
                this.linkLabel2.Hide();
            }
            else
            {
                this.linkLabel2.Show();
            }
            this.webBrowser1.Navigate("https://cn.bing.com/dict/SerpHoverTrans?q=" + this.Text);//取词
        }
        private void LookupWord_Load(object sender, EventArgs e)
        {
            //this.webBrowser1.Navigate("https://cn.bing.com/widget/translation?word=" + this.Text + "&fromlocale=en&tolocale=zh-CHS");
        }

        private void LookupWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExtWord(this.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }
    }
}
