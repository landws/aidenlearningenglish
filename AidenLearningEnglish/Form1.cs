using GraphVizWrapper;
using GraphVizWrapper.Commands;
using GraphVizWrapper.Queries;
using Microsoft.Win32;
using mshtml;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AidenLearningEnglish
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisibleAttribute(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var appName = Process.GetCurrentProcess().ProcessName + ".exe";
            SetIE8KeyforWebBrowserControl(appName);

            this.tabControl2.SelectTab(1);

            this.comboBox1.DataSource = Enum.GetNames(typeof(GraphVizWrapper.Enums.RenderingEngine));
            this.comboBox1.SelectedIndex = 5;

            this.webBrowser2.Navigate("about:blank");
            this.webBrowser2.AllowWebBrowserDrop = false;
            //this.webBrowser2.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser2.WebBrowserShortcutsEnabled = false;
            this.webBrowser2.ObjectForScripting = this;

            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ObjectForScripting = this;

            this.webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
            this.webBrowser1.Navigated += WebBrowser1_Navigated;
            this.webBrowser1.NewWindow += WebBrowser1_NewWindow;

            this.webBrowser3.Navigate("about:blank");
            this.webBrowser3.DocumentCompleted += WebBrowser3_DocumentCompleted;
            this.webBrowser3.ScriptErrorsSuppressed = true;
            this.webBrowser3.ObjectForScripting = this;

            string current = Path.GetDirectoryName(Application.ExecutablePath);

            this.cachedir = Path.Combine(current, "history");
            if (!Directory.Exists(this.cachedir))
            {
                Directory.CreateDirectory(this.cachedir);
            }

            var acsc = new AutoCompleteStringCollection();
            textBox1.AutoCompleteCustomSource = acsc;
            textBox1.AutoCompleteMode = AutoCompleteMode.None;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.listBox1.LostFocus += ListBox1_LostFocus;

            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("AidenLearningEnglish.recite.Aiden7940.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var str = reader.ReadToEnd();
                    var lines = str.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(word)) acsc.Add(word);
                    }
                }
            }

            new Thread(delegate ()
            {
                DirectoryInfo di = new DirectoryInfo(this.cachedir);
                FileSystemInfo[] files = di.GetFileSystemInfos("*.png");
                var files1 = files.OrderBy(f => f.CreationTime);
                //var files1 = Directory.GetFiles(this.cachedir, "*.png");
                int count = 0;
                foreach (var filepath in files1)
                {
                    var word = Path.GetFileNameWithoutExtension(filepath.FullName);
                    if (string.IsNullOrEmpty(word)) continue;

                    if (!this.accesswords.Contains(word))
                    {
                        this.accesswords.Insert(0, word);
                    }
                    count++;
                    if (count > 50) break;
                }
            }).Start();

            this.LoadReciteWords();
        }

        private void LoadReciteWords()
        {
            comboBox_recitewords.Items.Clear();
            comboBox_recitewords.Items.Add("COCA20000");
            comboBox_recitewords.Items.Add("Master1000");
            comboBox_recitewords.Items.Add("Aiden7940");

            string recite = UserProfileConfig.GetConfig("recite");
            if (string.IsNullOrEmpty(recite))
            {
                recite = "Master1000";
            }

            int index = comboBox_recitewords.Items.IndexOf(recite);
            if (index > -1 && index < comboBox_recitewords.Items.Count)
            {
                comboBox_recitewords.SelectedIndex = index;
            }
        }

        string cachedir = "";
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void SetIE8KeyforWebBrowserControl(string appName)
        {
            RegistryKey Regkey = null;
            try
            {
                // For 64 bit machine
                if (Environment.Is64BitOperatingSystem)
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                else  //For 32 bit machine
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);

                // If the path is not correct or
                // if the user haven't priviledges to access the registry
                if (Regkey == null)
                {
                    //MessageBox.Show("Application Settings Failed - Address Not found");
                    return;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                // Check if key is already present
                if (FindAppkey == "8000")
                {
                    //MessageBox.Show("Required Application Settings Present");
                    Regkey.Close();
                    return;
                }

                // If a key is not present add the key, Key value 8000 (decimal)
                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)0x1F40), RegistryValueKind.DWord);

                // Check for the key after adding
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                //if (FindAppkey == "8000")
                //    MessageBox.Show("Application Settings Applied Successfully");
                //else
                //    MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Application Settings Failed");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the Registry
                if (Regkey != null)
                    Regkey.Close();
            }
        }
        private void WebBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Console.WriteLine("WebBrowser1_Navigated " + e.Url);
        }
        private void WebBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine("WebBrowser3 " + this.webBrowser1.ReadyState);
            if (this.webBrowser3.ReadyState != WebBrowserReadyState.Complete) return;


        }

        private const int NumberOfRetries = 3;
        private const int DelayOnRetry = 1000;
        public static async Task<HttpResponseMessage> GetFromUrlAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMilliseconds(3000);
                for (int i = 1; i <= NumberOfRetries; ++i)
                {
                    try
                    {
                        return await client.GetAsync(url);
                    }
                    catch (Exception e) when (i < NumberOfRetries)
                    {
                        await Task.Delay(DelayOnRetry);
                    }
                }
            }
            return null;
        }
        private async void GetTheFreeDictionary(string word, string url)
        {
            try
            {
                string file2 = Path.Combine(this.cachedir, word + ".thesaurus.htm");
                if (File.Exists(file2))
                {
                    this.panel1.BeginInvoke((MethodInvoker)delegate
                    {
                        string html = File.ReadAllText(file2);
                        this.webBrowser3.DocumentText = html;

                        if (this.webBrowser3.Document != null)
                        {
                            this.webBrowser3.Document.ContextMenuShowing += Document_ContextMenuShowing;
                            this.webBrowser3.Document.Click += Document_Click;
                        }
                    });

                    return;
                }

                var task = GetFromUrlAsync(url);
                string strResponse = await task.Result.Content.ReadAsStringAsync(); //right!

                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //request.AllowAutoRedirect = false;
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Stream dataStream = response.GetResponseStream();
                ////strLastRedirect = response.ResponseUri.ToString();
                //StreamReader reader = new StreamReader(dataStream);
                //string strResponse = reader.ReadToEnd();

                if (!string.IsNullOrEmpty(strResponse))
                {
                    int svgindex = strResponse.IndexOf("<svg");
                    if (svgindex > 0 && svgindex < strResponse.Length)
                    {
                        int jsonindex = strResponse.IndexOf(" jsonData:", svgindex);
                        if (jsonindex > svgindex && jsonindex < strResponse.Length)
                        {
                            int jsonend = strResponse.IndexOf("setZoom", jsonindex);
                            if (jsonend > jsonindex && jsonend < strResponse.Length)
                            {
                                jsonindex += 10;
                                string jsondata = strResponse.Substring(jsonindex, jsonend - jsonindex);
                                if (!string.IsNullOrEmpty(jsondata))
                                {
                                    jsondata = jsondata.Trim();
                                    if (jsondata.EndsWith(","))
                                    {
                                        jsondata = jsondata.Substring(0, jsondata.Length - 1);
                                    }
                                }
                                Console.WriteLine(jsondata);
                                this.GenerateThesaurus(jsondata);
                            }
                        }
                    }
                }


                //response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine("WebBrowser1 " + this.webBrowser1.ReadyState);
            if (this.webBrowser1.ReadyState != WebBrowserReadyState.Complete && this.webBrowser1.ReadyState != WebBrowserReadyState.Interactive) return;

            //doc.Body.InnerHtml = content.InnerHtml;
            //new Thread(() =>
            //{

            //}).Start();

            HtmlElement content = null;
            do
            {
                var doc = this.webBrowser1.Document;
                var divs = doc.GetElementsByTagName("div");
                foreach (HtmlElement div in divs)
                {
                    string classname = div.GetAttribute("classname");
                    if (classname == null) continue;
                    if (classname.Contains("sidebar"))
                    {
                        //var style = div.GetAttribute("style");
                        //div.SetAttribute("style", style + ";display:none;");
                        div.SetAttribute("visible", "false");
                        div.OuterHtml = "";
                    }
                    if (classname.Contains("contentPadding") || classname.Contains("content"))
                    {
                        div.SetAttribute("classname", "");
                    }
                    else if (classname.Contains("lf_area"))
                    {
                        content = div;
                    }
                    //Console.WriteLine(classname);
                }
                var header = doc.GetElementById("b_header");
                if (header != null) header.OuterHtml = "";
                var footer = doc.GetElementById("b_footer");
                if (footer != null) footer.OuterHtml = "";

                //得到第一张图的URL
                string imgtipurl = "";
                var imgs = doc.GetElementsByTagName("img");
                foreach (HtmlElement img in imgs)
                {
                    string classname = img.GetAttribute("classname");
                    if (classname == null) continue;
                    if (classname.Contains("rms_img"))
                    {
                        imgtipurl = img.GetAttribute("src");
                        break;
                    }
                }
                //var colid = doc.GetElementById("colid");
                //var antoid = doc.GetElementById("antoid");
                //var synoid = doc.GetElementById("synoid");
                var headword = doc.GetElementById("headword");
                if (headword != null)
                {
                    string word = headword.InnerText;
                    if (!string.IsNullOrEmpty(word))
                    {
                        var cols = GetSubSpans(doc, "colid");
                        var ants = GetSubSpans(doc, "antoid");
                        var syns = GetSubSpans(doc, "synoid");

                        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                        if (cols.Count > 0) dict.Add("collocations", cols);
                        if (ants.Count > 0) dict.Add("antonyms", ants);
                        if (syns.Count > 0) dict.Add("synonyms", syns);

                        //如果正在背单词
                        if (this.tabControl2.SelectedTab == this.tabPage6)
                        {
                            if (!string.IsNullOrEmpty(imgtipurl))
                            {
                                imgtipurl = imgtipurl.Replace("&w=80&h=80", "&w=180&h=180");
                                this.pictureBox2.LoadAsync(imgtipurl);
                                Console.WriteLine("Load image "+ imgtipurl);
                            }
                            this.checkedListBox1.Items.Clear();
                            this.checkedListBox1.Items.AddRange(syns.ToArray());
                        }

                        string file1 = Path.Combine(this.cachedir, word + ".interation.htm");
                        string file3 = Path.Combine(this.cachedir, word + ".png");

                        if (!File.Exists(file1) || !File.Exists(file3))
                        {
                            GenerateDot(word, dict, this.webBrowser2, true);
                        }
                        else
                        {
                            string html = File.ReadAllText(file1, Encoding.Default);
                            //string html = ReadFileString(file1);
                            this.webBrowser2.DocumentText = html;

                            if (this.webBrowser2.Document != null)
                            {
                                this.webBrowser2.Document.ContextMenuShowing += Document_ContextMenuShowing;
                                this.webBrowser2.Document.Click += Document_Click;
                            }

                            Bitmap bitmap = new Bitmap(Bitmap.FromFile(file3));
                            this.pictureBox1.Image = bitmap;
                            this.pictureBox1.Width = bitmap.Width;
                            this.pictureBox1.Height = bitmap.Height;
                            this.pictureBox1.Tag = (double)bitmap.Width / bitmap.Height;
                            this.panel1_SizeChanged(null, null);
                        }

                        this.textBox1.Text = word;
                        if (!this.accesswords.Contains(word))
                        {
                            this.accesswords.Insert(0, word);
                        }
                        //else
                        //{
                        //    this.accesswords.Remove(word);
                        //    this.accesswords.Insert(0, word);
                        //}

                        //this.tabControl2.SelectTab(1);
                        break;
                    }
                }
                if (content != null && content.InnerHtml != null)
                {
                    //doc.Body.InnerHtml = content.OuterHtml;
                    //doc.Body.InnerHtml = "";
                    break;
                }

                if (this.AccessNew) break;

                Thread.Sleep(100);
                Application.DoEvents();
            }
            while (content == null && !this.IsDisposed);

            this.AccessNew = false;
        }
        public static string ReadFileString(string path)
        {
            // Use StreamReader to consume the entire text file.
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
        private void GenerateThesaurus(string jsonString)
        {
            var json = System.Json.JsonObject.Parse(jsonString);
            if (json.ContainsKey("name"))
            {
                string word = (string)json["name"];

                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

                if (json.ContainsKey("children"))
                {
                    var children = json["children"];
                    foreach (System.Json.JsonValue child in children)
                    {
                        var childname = "\"" + child["name"] + "\"";

                        List<string> sublist = new List<string>();

                        if (!dict.ContainsKey(childname))
                        {
                            dict.Add(childname, sublist);
                        }
                        else
                        {
                            sublist = dict[childname];
                        }

                        if (child.ContainsKey("children"))
                        {
                            var child_children = child["children"];
                            foreach (System.Json.JsonValue child_child in child_children)
                            {
                                var child_childname = (string)child_child["name"];
                                var child_childtype = (int)child_child["type"];
                                if (child_childtype == 3)
                                {
                                    child_childname = "ANT_" + child_childname;
                                }
                                sublist.Add(child_childname);
                            }
                        }
                    }
                }

                this.panel1.BeginInvoke((MethodInvoker)delegate
                {
                    this.GenerateDot(word, dict, this.webBrowser3, false);
                });
            }
        }
        private void RenderSVG(string word, string dot, WebBrowser browser, bool png = false)
        {
            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

            // GraphGeneration can be injected via the IGraphGeneration interface

            var wrapper = new GraphGeneration(getStartProcessQuery,
                                              getProcessStartInfoQuery,
                                              registerLayoutPluginCommand);

            GraphVizWrapper.Enums.RenderingEngine reout;
            if (Enum.TryParse<GraphVizWrapper.Enums.RenderingEngine>(this.renderselected, out reout))
            {
                wrapper.RenderingEngine = reout;
            }
            else
            {
                wrapper.RenderingEngine = GraphVizWrapper.Enums.RenderingEngine.Fdp;
            }

            string bindevents = "";
            bindevents += "function callextword(ev){";
            //bindevents += "alert(ev.target.textContent);";
            bindevents += "window.external.ExtWord(ev.target.textContent);";
            bindevents += "};";
            bindevents += "function bindevents(){";
            bindevents += "var svg=document.getElementById('graph0');";
            bindevents += "svg.setAttribute('width','100%');";
            bindevents += "svg.style.width='100%';";
            bindevents += "var texts = svg.getElementsByTagName('text');";
            bindevents += "for (var i=0;i<texts.length;i++){";
            bindevents += "texts[i].addEventListener('click',callextword,false);";
            bindevents += "}";
            bindevents += "};";
            //bindevents += "var ds = document.getElementsByTagName('text');alert(ds.length);";
            bindevents += "bindevents();";

            byte[] svgbytes = wrapper.GenerateGraph(dot, GraphVizWrapper.Enums.GraphReturnType.Svg);
            string html = "<!DOCTYPE html><html><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=11\"/><style>body{{width:" + browser.Width + ";height:" + browser.Height + "}} .node{{cursor:pointer;}}</style></head><body>{0}<script language=\"\">{1}</script></body></html>";
            var svgstr = System.Text.Encoding.Default.GetString(svgbytes);

            //<svg width="833pt" height="715pt" viewBox = "0.00 0.00 833.00 715.00" xmlns = "http://www.w3.org/2000/svg" xmlns: xlink = "http://www.w3.org/1999/xlink" >
            int svgindex = svgstr.IndexOf("<svg");
            if (svgindex > 0 && svgindex < svgstr.Length)
            {
                int svgend = svgstr.IndexOf(">", svgindex);
                if (svgend > svgindex && svgend < svgstr.Length)
                {
                    //svgstr = svgstr.Substring(0, svgindex) + "<svg width=\"" + browser.Width + "pt\" height=\"" + browser.Height + "pt\"  viewBox=\"0.00 0.00 " + browser.Width + ".00 " + browser.Height + ".00\">" + svgstr.Substring(svgend + 1);
                    svgstr = svgstr.Substring(0, svgindex) + "<svg>" + svgstr.Substring(svgend + 1);

                    //svgstr = svgstr.Substring(0, svgindex) + "<svg width=\"" + browser.Width + "\" height=\"" + browser.Height + "\" viewBox=\"0 0 " + browser.Width + " " + browser.Height + "\">" + svgstr.Substring(svgend + 1);
                    //svgstr = "<svg width=\"100%\" height=\"" + browser.Height + "\" viewBox=\"0 0 " + browser.Width + "pt " + browser.Height + "pt\">" + svgstr.Substring(svgend + 1);
                }
            }

            string content = string.Format(@html, svgstr, bindevents);

            browser.DocumentText = content;

            if (browser.Document != null)
            {
                browser.Document.ContextMenuShowing += Document_ContextMenuShowing;

                browser.Document.Click += Document_Click;
            }

            if (browser == this.webBrowser2)
            {
                string file1 = Path.Combine(this.cachedir, word + ".interation.htm");
                File.WriteAllText(file1, content);
            }
            else if (browser == this.webBrowser3)
            {
                string file2 = Path.Combine(this.cachedir, word + ".thesaurus.htm");
                File.WriteAllText(file2, content);
            }

            if (png)
            {
                //object[] args = { "alert(1);" };
                //this.webBrowser2.Document.InvokeScript("bindevents();");
                this.pictureBox1.BeginInvoke((MethodInvoker)delegate
                {
                    byte[] output = wrapper.GenerateGraph(dot, GraphVizWrapper.Enums.GraphReturnType.Png);
                    if (output != null && output.Length > 0)
                    {
                        Bitmap bitmap = new Bitmap(Bitmap.FromStream(new MemoryStream(output)));
                        this.pictureBox1.Image = bitmap;
                        this.pictureBox1.Width = bitmap.Width;
                        this.pictureBox1.Height = bitmap.Height;
                        this.pictureBox1.Tag = (double)bitmap.Width / bitmap.Height;
                        this.panel1_SizeChanged(null, null);

                        string file3 = Path.Combine(this.cachedir, word + ".png");
                        bitmap.Save(file3, ImageFormat.Png);
                    }
                });
            }
        }

        private void Document_Click(object sender, HtmlElementEventArgs e)
        {
            Console.WriteLine("#FromElement " + e.FromElement);
            Console.WriteLine(e.ClientMousePosition);
            Point pt = e.ClientMousePosition;

            //if (this.webBrowser1.Document != null)
            //{
            //    int x = this.webBrowser1.Document.ActiveElement.ScrollLeft;
            //    int y = this.webBrowser1.Document.ActiveElement.ScrollTop;

            //    IHTMLDocument3 doc3 = this.webBrowser1.Document.DomDocument as IHTMLDocument3;
            //    IHTMLElement2 html = doc3.documentElement as IHTMLElement2;
            //    //IHTMLElement2 body = doc2.body as IHTMLElement2;

            //    pt.X += html.scrollLeft;
            //    pt.Y += html.scrollTop;
            //}

            if (hover != null && hover.Visible)
            {
                var wb = this.tabControl2.SelectedTab.Controls[0];
                if (wb is WebBrowser)
                {
                    var pt_screen = wb.PointToScreen(pt);

                    pt_screen.Y += (10 + hover.Height);

                    Screen screen = Screen.FromControl(wb);
                    if (!screen.WorkingArea.Contains(pt_screen))
                    {
                        pt_screen.Y -= (10 + hover.Height);
                        pt_screen.Y -= 10;
                        pt_screen.Y -= 10;
                    }
                    pt_screen.Y -= hover.Height;

                    hover.Location = pt_screen;
                }
            }
        }

        private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            Console.WriteLine("#Document_ContextMenuShowing " + sender);

            if (sender is HtmlDocument)
            {
                HtmlDocument doc = sender as HtmlDocument;
                var svgs = doc.GetElementsByTagName("svg");
                if (svgs.Count > 0)
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(svgs[0].OuterHtml);
                    SvgDocument svgDocument = SvgDocument.Open(xml);
                    svgDocument.ShapeRendering = SvgShapeRendering.Auto;
                    var bitmap = svgDocument.Draw();
                    Clipboard.SetImage(bitmap);
                }
            }

            e.ReturnValue = false;
        }

        private void GenerateDot(string word, Dictionary<string, List<string>> dict, WebBrowser browser, bool png)
        {
            string shape1 = "node [shape=plaintext,fontsize=16]; ";
            string dot = "";
            dot += word + " [shape=ellipse,style=filled,color=greenyellow,fontsize=20]; " + Environment.NewLine;
            string shape2 = "node [shape=ellipse,fontsize=16]; ";
            string shape3 = "node [shape=box,fontsize=16]; ";
            foreach (string key in dict.Keys)
            {
                if (!"antonyms".Equals(key))
                    shape2 += "" + key + "; ";
                else
                    shape3 += "" + key + "; ";
            }
            //dot += Environment.NewLine;
            //dot += shape + Environment.NewLine;
            foreach (string key in dict.Keys)
            {
                //shape += key + ";";
                //dot += key + " -> " + word + ";";
                dot += word + " -> " + key + ";";
                foreach (string voc in dict[key])
                {
                    var voc1 = voc;
                    bool ant = voc.StartsWith("ANT_");
                    if (ant) voc1 = voc.Substring(4);
                    //dot += "\"" + voc + "\"" + " -> " + key + ";";
                    dot += key + " -> " + "\"" + voc1 + "\"";
                    if (ant)
                    {
                        //dot += " " + "[label=\"antonyms\"]";
                        //dot += " " + "[shape=point]";
                        shape3 += "\"" + voc1 + "\"; ";
                    }
                    dot += ";";

                    //shape += "\"" + voc + "\"" + "; ";
                }
            }
            //string dot = @"collocation -> {0}; Synonyms -> {0}; Antonyms -> {0};";

            int w_inch = browser.Width / 96;
            int h_inch = browser.Height / 96;

            string graph = "graph[page=\"" + w_inch + "," + h_inch + "\",size=\"" + w_inch + "," + h_inch + "\",ratio=fill,center=1];";

            //dot = "digraph {" + Environment.NewLine + graph + Environment.NewLine + dot + Environment.NewLine + "}";

            dot = "digraph {" + Environment.NewLine +
                shape2 + Environment.NewLine +
                shape3 + Environment.NewLine +
                shape1 + Environment.NewLine + dot + Environment.NewLine + "}";

            Console.WriteLine(dot);

            this.RenderSVG(word, dot, browser, png);
        }
        LookupWord hover = null;
        public void ExtWord(String text)
        {
            if (string.IsNullOrEmpty(text)) return;

            if (hover == null || hover.IsDisposed)
            {
                hover = new LookupWord();
                hover.WordReceived += Hover_WordReceived;
            }
            hover.Show();
            hover.HoverTrans(text);
            hover.BringToFront();
        }

        private void Hover_WordReceived(string text)
        {
            this.FetchWord(text);
            if (hover != null && !hover.IsDisposed)
            {
                hover.Hide();
            }
        }

        public void FetchWord(String text)
        {
            if (string.IsNullOrEmpty(text)) return;
            //MessageBox.Show(text, "client code");
            this.textBox1.Text = text;
            this.webBrowser1.Navigate("https://cn.bing.com/dict/search?q=" + text);

            new Thread(() =>
            {
                this.GetTheFreeDictionary(text, "https://www.freethesaurus.com/" + text);
            }).Start();
            //this.webBrowser3.Navigate("https://www.freethesaurus.com/" + text);

        }
        private List<string> GetSubSpans(HtmlDocument doc, string id)
        {
            List<string> list = new List<string>();

            var colid = doc.GetElementById(id);
            if (colid != null)
            {
                var spans = colid.GetElementsByTagName("span");
                foreach (HtmlElement span in spans)
                {
                    var classname = span.GetAttribute("classname");
                    if (classname != null && classname.Contains("p1-4"))
                    {
                        list.Add(span.InnerText);
                    }
                }
            }
            return list;
        }
        bool AccessNew = false;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string word = this.textBox1.Text.Trim();
            if (string.IsNullOrEmpty(word)) return;

            if (e == null || e.KeyChar == 13)
            {
                //this.webBrowser1.Navigate("https://www.freethesaurus.com/" + word);
                //this.webBrowser1.Navigate("https://cn.bing.com/dict/search?q=" + word);
                FetchWord(word);
                this.AccessNew = true;
            }

            hideResults();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Right)
            {
                if (this.pictureBox1.Image != null) Clipboard.SetImage(this.pictureBox1.Image);
            }
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null || this.pictureBox1.Tag == null) return;
            this.panel1.BeginInvoke((MethodInvoker)delegate
            {
                if (this.pictureBox1.Tag is double)
                {
                    double rate = (double)this.pictureBox1.Tag;
                    if (rate > 1)
                    {
                        this.pictureBox1.Width = this.panel1.Width - 32;
                        this.pictureBox1.Height = (int)(this.pictureBox1.Width / rate);
                    }
                    else
                    {
                        this.pictureBox1.Height = this.panel1.Height - 32;
                        this.pictureBox1.Width = (int)(this.pictureBox1.Height / rate);
                    }
                    //this.pictureBox1.Height = (int)((double)w / this.pictureBox1.Width) * this.pictureBox1.Height;
                }
            });
        }
        string renderselected = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.renderselected = this.comboBox1.SelectedValue.ToString();
            this.textBox1_KeyPress(sender, null);
        }

        int currentindex = -1;
        List<string> accesswords = new List<string>();
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (accesswords.Count > 1)
            {
                if (currentindex < 0)
                    currentindex = 1;
                else if (currentindex > 0 && currentindex < accesswords.Count)
                    currentindex++;

                if (currentindex >= accesswords.Count)
                {
                    currentindex = accesswords.Count - 1;
                    return;
                }

                string word = accesswords[currentindex];
                this.FetchWord(word);
            }
        }
        ContextMenu menu = new ContextMenu();
        private void button_dropdown_Click(object sender, EventArgs e)
        {
            if (accesswords.Count == 0) return;

            string current = this.textBox1.Text.Trim();

            menu.MenuItems.Clear();
            int index = 0;
            MenuItem moreitems = null;
            foreach (var word in accesswords)
            {
                MenuItem menuitem = null;
                if (index > 14)
                {
                    if (moreitems == null)
                    {
                        moreitems = menu.MenuItems.Add("More (" + (accesswords.Count - 15) + ")");
                    }
                    menuitem = moreitems.MenuItems.Add(word);
                }
                else
                {
                    menuitem = menu.MenuItems.Add(word);
                }
                if (current == word) menuitem.Checked = true;
                menuitem.Click += Menuitem_Click;
                index++;
            }
            //var pt = this.button_dropdown.PointToScreen(this.button_dropdown.Location);
            var pt1 = new Point(0, this.button_dropdown.Top + this.button_dropdown.Height);
            var pt = this.button_dropdown.PointToScreen(pt1);
            //menu.Show(this.button_dropdown, pt1);
            menu.Show(this, pt1);
        }

        private void Menuitem_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item != null && !string.IsNullOrEmpty(item.Text) && item.MenuItems.Count == 0)
            {
                this.FetchWord(item.Text);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Focused) return;

            listBox1.Items.Clear();
            if (textBox1.Text.Length == 0)
            {
                hideResults();
                return;
            }

            foreach (String s in textBox1.AutoCompleteCustomSource)
            {
                //if (s.Contains(textBox1.Text))
                if (s.StartsWith(textBox1.Text))
                {
                    Console.WriteLine("Found text in: " + s);
                    listBox1.Items.Add(s);
                    if (!listBox1.Visible)
                    {
                        listBox1.Visible = true;
                        listBox1.BringToFront();
                    }
                }
            }
        }
        void hideResults()
        {
            listBox1.Visible = false;
        }
        private void ListBox1_LostFocus(object sender, EventArgs e)
        {
            hideResults();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);

            if (!listBox1.Visible) return;
            if (e.KeyCode == Keys.Down)
            {
                listBox1.SelectedIndex = 0;
                listBox1.Focus();
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender != null && e.KeyChar != 13) return;

            textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
            hideResults();
            this.textBox1_KeyPress(null, null);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                this.listBox1_KeyPress(null, null);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    this.button_preword_Click(null, null);
                    return true;
                case Keys.Right:
                    this.button_nextword_Click(null, null);
                    return true;
                case Keys.Up:
                    this.button_remember_Click(null, null);
                    return true;
                case Keys.Down:
                    this.button_forget_Click(null, null);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        ReciteRelated rr = null;

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl2.SelectedTab == this.tabPage6)
            {
                this.tabControl1.SelectedTab = this.tabPage7;

                if (this.textBox_reciteword.Text == "")
                {
                    PickReciteWord(0);
                }
            }
            else
            {
                this.tabControl1.SelectedTab = this.tabPage1;
            }
        }

        private void PickReciteWord(int order)
        {
            string recitename = this.comboBox_recitewords.SelectedItem.ToString();
            if (rr == null || (rr != null && rr.Name != recitename))
            {
                rr = new ReciteRelated(recitename);

                this.label_recitesource.Text = "Reciting " + rr.Name + " Totals " + rr.Length;
            }

            this.pictureBox2.Image = null;
            this.checkedListBox1.Items.Clear();
            this.tabControl1.SelectedTab = this.tabPage7;

            if (rr.Available)
            {
                //没加载过这个词单的单词
                string word = "";
                if (order == 0 || rr.Position < 0)
                    word = rr.PickOne();
                else if (order == -1)
                    word = rr.PickPreviousWord();
                else if (order == 1)
                    word = rr.PickNextWord();

                if (!string.IsNullOrWhiteSpace(word))
                {
                    word = word.Trim();
                    textBox_reciteword.Text = word;

                    //加载这个单词
                    this.FetchWord(word);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.comboBox_recitewords.SelectedItem != null)
            {
                UserProfileConfig.SetValue("recite", this.comboBox_recitewords.SelectedItem.ToString());
            }
        }

        private void button_preword_Click(object sender, EventArgs e)
        {
            PickReciteWord(-1);
        }

        private void button_nextword_Click(object sender, EventArgs e)
        {
            PickReciteWord(1);
        }

        private void button_remember_Click(object sender, EventArgs e)
        {
            PickReciteWord(1);
        }

        private void button_forget_Click(object sender, EventArgs e)
        {
            //PickReciteWord(1);
            this.tabControl1.SelectedTab = this.tabPage1;
        }

        private void button_skipit_Click(object sender, EventArgs e)
        {
            PickReciteWord(1);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab == this.tabPage7)
            {
                this.tabControl2.SelectedTab = this.tabPage6;

                if (this.textBox_reciteword.Text == "")
                {
                    PickReciteWord(0);
                }
            }
            else
            {
                //this.tabControl1.SelectedTab = this.tabPage1;
            }


        }

        private void tabPage7_Resize(object sender, EventArgs e)
        {
            pictureBox2.Left = (this.tabPage7.Width - pictureBox2.Width) / 2;

            button_remember.Left = (this.tabPage7.Width - button_remember.Width) / 2;
            button_forget.Left = (this.tabPage7.Width - button_forget.Width) / 2;
            button_skipit.Left = (this.tabPage7.Width - button_skipit.Width) / 2;
        }
    }
}