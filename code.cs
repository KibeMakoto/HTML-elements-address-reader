        private void Btn_Click(object sender, EventArgs e)
        {
            textBox.Text = GetInnerTextsInTag("table");
        }

        String GetInnerTextsInTag(String tagname)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                HtmlElementCollection t = webBrowser.Document.GetElementsByTagName(tagname);
                for (int i = 0; i < t.Count; i++)
                {
                    sb.Append("\r\nclassname : "+t[i].GetAttribute("className") + "\r\n");
                    sb.Append(ChildrenInnerText("", t[i].Children)); 
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            return sb.ToString();
        }

        String ChildrenInnerText(String addr, HtmlElementCollection c) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i].Children.Count == 0 && isExistedValue(c[i].InnerText)) { sb.Append(addr + i.ToString() + " : " + c[i].InnerText + "\r\n"); }
                else { sb.Append(ChildrenInnerText(addr + i.ToString() + "-", c[i].Children)); }
            }
            return sb.ToString();
        }
        bool isExistedValue(String tx) {
            if (tx == "" || tx == null) { return false; }
            else { 
             if(tx.Trim() != "") { return true; }
            }
            return false;
        }
