namespace Nvd.Windows.Forms
{
    public class TextBox : System.Windows.Forms.TextBox
    {
        private System.Drawing.Font oldFont = null;
        private bool waterMarkTextEnabled = false;

        #region Attributes 
        private textBoxList list;
        private System.Windows.Forms.Form baseForm;
        private System.Collections.Generic.List<string> listItems = null;

        /// <summary>
        /// The list searches inside this object list.(new System.Collections.Generic.List<string> {"text_1","text_2",...,"text_n"};)
        /// </summary>
        public System.Collections.Generic.List<string> ListItems
        {
            get { return listItems; }
            set
            {
                listItems = value;
            }
        }

        private System.Drawing.Color listItemsForeColor;
        public System.Drawing.Color ListItemsForeColor
        {
            get { return listItemsForeColor; }
            set
            {
                listItemsForeColor = value;
            }
        }

        private System.Drawing.Color listItemsBackColor;
        public System.Drawing.Color ListItemsBackColor
        {
            get { return listItemsBackColor; }
            set
            {
                listItemsBackColor = value;
            }
        }

        private System.Drawing.Font listItemsFont;
        public System.Drawing.Font ListItemsFont
        {
            get { return listItemsFont; }
            set
            {
                listItemsFont = value;
            }
        }

        private bool listBoxDynamicWidth = false;
        public bool ListBoxDynamicWidth
        {
            get { return listBoxDynamicWidth; }
            set
            {
                listBoxDynamicWidth = value;
            }
        }

        private int maxItemesToShow = 10;
        public int MaxItemesToShow
        {
            get { return maxItemesToShow; }
            set
            {
                if (value > 0) maxItemesToShow = value; else maxItemesToShow = 1;
            }
        }

        private System.Drawing.Color waterMarkColor = System.Drawing.Color.Gray;
        public System.Drawing.Color WaterMarkColor
        {
            get { return waterMarkColor; }
            set
            {
                waterMarkColor = value;
                Invalidate();
            }
        }

        private string waterMarkText = "Water Mark";
        public string WaterMarkText
        {
            get { return waterMarkText; }
            set
            {
                waterMarkText = value;
                Invalidate();
            }
        }

        #endregion \Attributes

        //Default constructor
        public TextBox() : base()
        {
            list = new textBoxList();
            list.TabStop = false;
            list.Visible = false;

            //for watermark**********
            JoinEvents(true);
            //***********************
        }

        #region WaterMark
        //Override OnCreateControl 
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            WaterMark_Toggel(null, null);
        }

        //Override OnPaint
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs args)
        {
            // Use the same font that was defined in base class
            System.Drawing.Font drawFont = new System.Drawing.Font(Font.FontFamily,
                Font.Size, Font.Style | System.Drawing.FontStyle.Italic, Font.Unit);
            //Create new brush with gray color or 
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(WaterMarkColor);//use Water mark color
            //Draw Text or WaterMark
            args.Graphics.DrawString((waterMarkTextEnabled ? WaterMarkText : Text),
                drawFont, drawBrush, new System.Drawing.PointF(0.0F, 0.0F));
            base.OnPaint(args);
        }

        private void JoinEvents(bool join)
        {
            if (join)
            {
                this.TextChanged += new System.EventHandler(this.WaterMark_Toggel);
                this.LostFocus += new System.EventHandler(this.WaterMark_Toggel);
                this.FontChanged += new System.EventHandler(this.WaterMark_FontChanged);
            }
        }

        private void WaterMark_Toggel(object sender, System.EventArgs args)
        {
            if (this.Text.Length <= 0)
                EnableWaterMark();
            else
                DisbaleWaterMark();
        }

        private void EnableWaterMark()
        {
            //Save current font until returning the UserPaint style to false (NOTE:
            //It is a try and error advice)
            oldFont = new System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style,
               Font.Unit);
            //Enable OnPaint event handler
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            this.waterMarkTextEnabled = true;
            //Triger OnPaint immediatly
            Refresh();
        }

        private void DisbaleWaterMark()
        {
            //Disbale OnPaint event handler
            this.waterMarkTextEnabled = false;
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, false);
            //Return back oldFont if existed
            if (oldFont != null)
                this.Font = new System.Drawing.Font(oldFont.FontFamily, oldFont.Size,
                    oldFont.Style, oldFont.Unit);
        }

        private void WaterMark_FontChanged(object sender, System.EventArgs args)
        {
            if (waterMarkTextEnabled)
            {
                oldFont = new System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style,
                    Font.Unit);
                Refresh();
            }
        }
#endregion \WaterMark

        //Override OnEnter
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
                if (listItemsFont == null) list.Font = this.Font; else list.Font = listItemsFont;
                if (listItemsBackColor == null) list.BackColor = this.BackColor; else list.BackColor = listItemsBackColor;
                if (listItemsForeColor == null) list.ForeColor = this.ForeColor; else list.ForeColor = listItemsForeColor;
                list.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + this.Size.Height);
            }
        }

        //Override IsInputKey
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

        //Override OnKeyPress
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


        //Override OnKeyUp
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

            int maxLength = 0;
            int itemsToShow = 0;
            int scrollbarWidth = 0;
            foreach (string item in listItems)
            {
                if (item.ToLower().StartsWith(this.Text.ToLower()))
                {
                    if (!list.Visible)
                    {
                        list.Visible = true;
                        list.BringToFront();
                    }
                    list.Items.Add(item);

                    if (list.Items.Count >= maxItemesToShow)
                    {
                        itemsToShow = maxItemesToShow;
                        scrollbarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                    }
                    else
                    {
                        itemsToShow = list.Items.Count;
                        scrollbarWidth = 0;
                    }

                    if (listBoxDynamicWidth)
                    {
                        if (item.Length > maxLength) maxLength = item.Length;
                        list.Size = new System.Drawing.Size((maxLength) * (int)System.Math.Floor(list.Font.SizeInPoints)+ scrollbarWidth
                            , (itemsToShow + 1) * list.Font.Height);
                    }
                    else
                    {
                        list.Size = new System.Drawing.Size(this.Size.Width, (itemsToShow + 1) * list.Font.Height);
                    }
                }
            }
        }



        //ListBox that shows up under textbox
        class textBoxList : System.Windows.Forms.ListBox
        {
            //Default constructor
            public textBoxList() : base()
            {

            }

            public TextBox textbox;
            public System.Windows.Forms.Form baseForm;

            //Override OnKeyUp
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

            //Override IsInputKey
            protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
            {
                if (keyData == System.Windows.Forms.Keys.Tab || keyData == System.Windows.Forms.Keys.Up)
                {
                    return true;
                }
                else
                {
                    return base.IsInputKey(keyData);
                }
            }

            //OnKeyDown
            protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
            {
                //base.OnKeyDown(e);
                if (e.KeyData == System.Windows.Forms.Keys.Tab)
                {
                    this.Items.Clear();
                    this.Visible = false;
                }
                else if (e.KeyData == System.Windows.Forms.Keys.Up && this.SelectedIndex == 0)
                {
                    this.Items.Clear();
                    this.Visible = false;
                    baseForm.ActiveControl = textbox;
                }
                else
                {
                    base.OnKeyDown(e);
                }
            }

            //Override OnDoubleClick
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
