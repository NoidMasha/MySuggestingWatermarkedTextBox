namespace Nvd.Windows.Forms
{
    public class TextBox : System.Windows.Forms.TextBox
    {

        public TextBox() : base()
        {
            list = new textBoxList();
            list.TabStop = false;
            list.Visible = false;
        }

        private textBoxList list;
        private System.Windows.Forms.Form baseForm;
        private System.Collections.Generic.List<string> listItems = null;

        /// <summary>
        /// The list searches inside this object list.(new System.Collections.Generic.List<string> {"text_1","text_2",...,"text_n"};)
        /// </summary>
        public System.Collections.Generic.List<string> ListItems
        {
            get
            {
                return listItems;
            }
            set
            {
                listItems = value;
            }
        }

        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);
            if (this.baseForm == null)
            {
                this.baseForm = (System.Windows.Forms.Form)this.Parent;
                list.baseForm = this.baseForm;
                list.textbox = this;
                list.TabIndex = this.TabIndex;
                baseForm.Controls.Add(list);
                list.Font = this.Font;
                list.BackColor = this.BackColor;
                list.ForeColor = this.ForeColor;
                list.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + this.Size.Height);
            }
        }

        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            if (keyData == System.Windows.Forms.Keys.Tab)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Tab)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }



        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Down && list.Visible)
            {
                baseForm.ActiveControl = list;
                list.SelectedIndex = 0;
                e.Handled = true;
                return;
            }

            if (e.KeyData == System.Windows.Forms.Keys.Tab)
            {
                if (list.Visible)
                {
                    list.Items.Clear();
                    list.Visible = false;
                }
                baseForm.SelectNextControl(this, true, true, true, true);
                e.Handled = true;
                return;
            }

            base.OnKeyUp(e);

            if (list == null || listItems == null) return;

            list.Items.Clear();
            list.Visible = false;

            if (string.IsNullOrWhiteSpace(this.Text)) return;

            //int maxLength = 0;
            foreach (string item in listItems)
            {
                if (item.ToLower().StartsWith(this.Text.ToLower()))
                {
                    if (!list.Visible)
                    {
                        list.Visible = true;
                        list.BringToFront();
                    }
                    //if (item.Length > maxLength) maxLength = item.Length;
                    list.Items.Add(item);
                    //list.Size = new System.Drawing.Size((maxLength + 1) * (int)System.Math.Round(list.Font.SizeInPoints), (list.Items.Count + 1) * list.Font.Height);
                    list.Size = new System.Drawing.Size(this.Size.Width, (list.Items.Count + 1) * list.Font.Height);
                }
            }
        }

        class textBoxList : System.Windows.Forms.ListBox
        {
            public textBoxList() : base()
            {

            }

            public TextBox textbox;
            public System.Windows.Forms.Form baseForm;
            protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
            {
                //base.OnKeyUp(e);
                if (e.KeyData == System.Windows.Forms.Keys.Enter)
                {
                    textbox.Text = (string)this.SelectedItem;
                    baseForm.SelectNextControl(textbox, true, true, true, true);
                    this.Items.Clear();
                    this.Visible = false;
                }
            }

            protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
            {
                if (keyData == System.Windows.Forms.Keys.Tab)
                {
                    return true;
                }
                else
                {
                    return base.IsInputKey(keyData);
                }
            }

            protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
            {
                //base.OnKeyDown(e);
                if (e.KeyData == System.Windows.Forms.Keys.Tab)
                {
                    this.Items.Clear();
                    this.Visible = false;
                }
                else
                {
                    base.OnKeyDown(e);
                }
            }

            protected override void OnDoubleClick(System.EventArgs e)
            {
                //base.OnDoubleClick(e);
                textbox.Text = (string)this.SelectedItem;
                baseForm.SelectNextControl(textbox, true, true, true, true);
                this.Items.Clear();
                this.Visible = false;
            }
        }
    }

}
