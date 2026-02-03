namespace WinFormsApp1
{
    partial class DemoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
            
            mainTableLayout = new TableLayoutPanel();
            tabControl = new TabControl();
            tabBasicControls = new TabPage();
            tabLayoutControls = new TabPage();
            tabDataControls = new TabPage();
            panelButtons = new Panel();
            
            // Basic Controls Tab
            lblTextBoxLabel = new Label();
            textBoxInput = new TextBox();
            lblNumberLabel = new Label();
            numericUpDownValue = new NumericUpDown();
            chkCheckBox = new CheckBox();
            radioBtnOption1 = new RadioButton();
            radioBtnOption2 = new RadioButton();
            radioBtnOption3 = new RadioButton();
            btnBasicButton = new Button();
            
            // Layout Controls Tab
            lblGroupBoxLabel = new Label();
            groupBoxContainer = new GroupBox();
            tableLayoutPanelGroup = new TableLayoutPanel();
            lblInGroup = new Label();
            textBoxInGroup = new TextBox();
            flowLayoutPanel = new FlowLayoutPanel();
            lblFlowLayout = new Label();
            btnFlow1 = new Button();
            btnFlow2 = new Button();
            btnFlow3 = new Button();
            
            // Data Controls Tab
            lblListBoxLabel = new Label();
            listBoxItems = new ListBox();
            lblComboBoxLabel = new Label();
            comboBoxOptions = new ComboBox();
            lblDateTimeLabel = new Label();
            dateTimePickerControl = new DateTimePicker();
            listViewControl = new ListView();
            
            // Bottom Button Panel
            btnClose = new Button();
            btnReset = new Button();
            btnShowMessage = new Button();

            // Main Table Layout
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.RowCount = 2;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Controls.Add(tabControl, 0, 0);
            mainTableLayout.Controls.Add(panelButtons, 0, 1);

            // Tab Control
            tabControl.Controls.Add(tabBasicControls);
            tabControl.Controls.Add(tabLayoutControls);
            tabControl.Controls.Add(tabDataControls);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Text = "Demo";

            // ===== BASIC CONTROLS TAB =====
            tabBasicControls.Text = "Basic Controls";
            tabBasicControls.UseVisualStyleBackColor = true;
            
            TableLayoutPanel basicLayout = new TableLayoutPanel();
            basicLayout.ColumnCount = 2;
            basicLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            basicLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            basicLayout.RowCount = 6;
            basicLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            basicLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            basicLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            basicLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            basicLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            basicLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            basicLayout.Dock = DockStyle.Fill;
            basicLayout.Padding = new Padding(10);
            basicLayout.AutoSize = true;

            // TextBox
            lblTextBoxLabel.Text = "Text Input:";
            lblTextBoxLabel.Anchor = AnchorStyles.Left;
            basicLayout.Controls.Add(lblTextBoxLabel, 0, 0);
            textBoxInput.Margin = new Padding(3);
            basicLayout.Controls.Add(textBoxInput, 1, 0);

            // NumericUpDown
            lblNumberLabel.Text = "Numeric Value:";
            lblNumberLabel.Anchor = AnchorStyles.Left;
            basicLayout.Controls.Add(lblNumberLabel, 0, 1);
            numericUpDownValue.Value = 42;
            numericUpDownValue.Minimum = 0;
            numericUpDownValue.Maximum = 100;
            numericUpDownValue.Margin = new Padding(3);
            basicLayout.Controls.Add(numericUpDownValue, 1, 1);

            // CheckBox
            chkCheckBox.Text = "Enable Feature";
            chkCheckBox.Checked = true;
            chkCheckBox.Margin = new Padding(3);
            basicLayout.Controls.Add(chkCheckBox, 1, 2);

            // Radio Buttons
            TableLayoutPanel radioLayout = new TableLayoutPanel();
            radioLayout.ColumnCount = 3;
            radioLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            radioLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            radioLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            radioBtnOption1.Text = "Option 1";
            radioBtnOption1.Checked = true;
            radioBtnOption2.Text = "Option 2";
            radioBtnOption3.Text = "Option 3";
            radioLayout.Controls.Add(radioBtnOption1, 0, 0);
            radioLayout.Controls.Add(radioBtnOption2, 1, 0);
            radioLayout.Controls.Add(radioBtnOption3, 2, 0);
            basicLayout.Controls.Add(radioLayout, 1, 3);

            // Button
            btnBasicButton.Text = "Click Me!";
            btnBasicButton.Click += BtnBasicButton_Click;
            btnBasicButton.Margin = new Padding(3);
            basicLayout.Controls.Add(btnBasicButton, 1, 4);

            tabBasicControls.Controls.Add(basicLayout);

            // ===== LAYOUT CONTROLS TAB =====
            tabLayoutControls.Text = "Layout Controls";
            tabLayoutControls.UseVisualStyleBackColor = true;
            
            TableLayoutPanel layoutTab = new TableLayoutPanel();
            layoutTab.ColumnCount = 1;
            layoutTab.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutTab.RowCount = 3;
            layoutTab.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layoutTab.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layoutTab.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTab.Dock = DockStyle.Fill;
            layoutTab.Padding = new Padding(10);

            // GroupBox
            lblGroupBoxLabel.Text = "Group Box Example:";
            layoutTab.Controls.Add(lblGroupBoxLabel, 0, 0);

            groupBoxContainer.Text = "Container Group";
            groupBoxContainer.AutoSize = true;
            groupBoxContainer.AutoSizeMode = AutoSizeMode.GrowOnly;
            tableLayoutPanelGroup.ColumnCount = 2;
            tableLayoutPanelGroup.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanelGroup.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelGroup.RowCount = 1;
            tableLayoutPanelGroup.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            lblInGroup.Text = "Name:";
            lblInGroup.Anchor = AnchorStyles.Left;
            tableLayoutPanelGroup.Controls.Add(lblInGroup, 0, 0);
            textBoxInGroup.Margin = new Padding(3);
            tableLayoutPanelGroup.Controls.Add(textBoxInGroup, 1, 0);
            groupBoxContainer.Controls.Add(tableLayoutPanelGroup);
            layoutTab.Controls.Add(groupBoxContainer, 0, 1);

            // FlowLayoutPanel
            lblFlowLayout.Text = "Flow Layout Panel:";
            layoutTab.Controls.Add(lblFlowLayout, 0, 0);

            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.WrapContents = true;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFlow1.Text = "Button 1";
            btnFlow1.AutoSize = true;
            btnFlow2.Text = "Button 2";
            btnFlow2.AutoSize = true;
            btnFlow3.Text = "Button 3";
            btnFlow3.AutoSize = true;
            flowLayoutPanel.Controls.Add(btnFlow1);
            flowLayoutPanel.Controls.Add(btnFlow2);
            flowLayoutPanel.Controls.Add(btnFlow3);
            layoutTab.Controls.Add(flowLayoutPanel, 0, 2);

            tabLayoutControls.Controls.Add(layoutTab);

            // ===== DATA CONTROLS TAB =====
            tabDataControls.Text = "Data Controls";
            tabDataControls.UseVisualStyleBackColor = true;
            
            TableLayoutPanel dataLayout = new TableLayoutPanel();
            dataLayout.ColumnCount = 2;
            dataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            dataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            dataLayout.RowCount = 3;
            dataLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            dataLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            dataLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            dataLayout.Dock = DockStyle.Fill;
            dataLayout.Padding = new Padding(10);

            // ListBox
            lblListBoxLabel.Text = "List Box:";
            dataLayout.Controls.Add(lblListBoxLabel, 0, 0);
            listBoxItems.Items.AddRange(new object[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" });
            listBoxItems.SelectionMode = SelectionMode.MultiSimple;
            listBoxItems.Margin = new Padding(3);
            dataLayout.Controls.Add(listBoxItems, 0, 2);

            // ComboBox and DateTimePicker in right column
            TableLayoutPanel rightColumn = new TableLayoutPanel();
            rightColumn.ColumnCount = 1;
            rightColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightColumn.RowCount = 4;
            rightColumn.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rightColumn.Padding = new Padding(3);

            lblComboBoxLabel.Text = "Combo Box:";
            rightColumn.Controls.Add(lblComboBoxLabel, 0, 0);
            comboBoxOptions.Items.AddRange(new object[] { "Option A", "Option B", "Option C", "Option D" });
            comboBoxOptions.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxOptions.Margin = new Padding(3);
            rightColumn.Controls.Add(comboBoxOptions, 0, 1);

            lblDateTimeLabel.Text = "Date/Time:";
            rightColumn.Controls.Add(lblDateTimeLabel, 0, 2);
            dateTimePickerControl.Margin = new Padding(3);
            rightColumn.Controls.Add(dateTimePickerControl, 0, 3);

            dataLayout.Controls.Add(rightColumn, 1, 0);
            dataLayout.SetRowSpan(rightColumn, 3);

            // ListView
            listViewControl.View = View.Details;
            listViewControl.FullRowSelect = true;
            listViewControl.GridLines = true;
            listViewControl.Columns.Add("Column 1", 100);
            listViewControl.Columns.Add("Column 2", 100);
            listViewControl.Columns.Add("Column 3", 100);
            listViewControl.Items.Add(new ListViewItem(new[] { "Row 1, Col 1", "Row 1, Col 2", "Row 1, Col 3" }));
            listViewControl.Items.Add(new ListViewItem(new[] { "Row 2, Col 1", "Row 2, Col 2", "Row 2, Col 3" }));
            listViewControl.Margin = new Padding(3);
            dataLayout.Controls.Add(listViewControl, 0, 2);
            dataLayout.SetColumnSpan(listViewControl, 2);

            tabDataControls.Controls.Add(dataLayout);

            // ===== BOTTOM PANEL =====
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.AutoSize = true;
            panelButtons.Padding = new Padding(10);

            FlowLayoutPanel buttonLayout = new FlowLayoutPanel();
            buttonLayout.FlowDirection = FlowDirection.RightToLeft;
            buttonLayout.AutoSize = true;
            buttonLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            btnClose.Text = "Close";
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Click += BtnClose_Click;
            btnReset.Text = "Reset";
            btnReset.Click += BtnReset_Click;
            btnShowMessage.Text = "Show Message";
            btnShowMessage.Click += BtnShowMessage_Click;

            buttonLayout.Controls.Add(btnClose);
            buttonLayout.Controls.Add(btnReset);
            buttonLayout.Controls.Add(btnShowMessage);
            panelButtons.Controls.Add(buttonLayout);

            // Form settings
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 600);
            Controls.Add(mainTableLayout);
            Name = "DemoForm";
            Text = "WinForms Controls Showcase";
            StartPosition = FormStartPosition.CenterScreen;
            Icon = SystemIcons.Application;

            ((System.ComponentModel.ISupportInitialize)numericUpDownValue).EndInit();
        }

        private TableLayoutPanel mainTableLayout;
        private TabControl tabControl;
        private TabPage tabBasicControls;
        private TabPage tabLayoutControls;
        private TabPage tabDataControls;
        private Panel panelButtons;

        // Basic Controls
        private Label lblTextBoxLabel;
        private TextBox textBoxInput;
        private Label lblNumberLabel;
        private NumericUpDown numericUpDownValue;
        private CheckBox chkCheckBox;
        private RadioButton radioBtnOption1;
        private RadioButton radioBtnOption2;
        private RadioButton radioBtnOption3;
        private Button btnBasicButton;

        // Layout Controls
        private Label lblGroupBoxLabel;
        private GroupBox groupBoxContainer;
        private TableLayoutPanel tableLayoutPanelGroup;
        private Label lblInGroup;
        private TextBox textBoxInGroup;
        private FlowLayoutPanel flowLayoutPanel;
        private Label lblFlowLayout;
        private Button btnFlow1;
        private Button btnFlow2;
        private Button btnFlow3;

        // Data Controls
        private Label lblListBoxLabel;
        private ListBox listBoxItems;
        private Label lblComboBoxLabel;
        private ComboBox comboBoxOptions;
        private Label lblDateTimeLabel;
        private DateTimePicker dateTimePickerControl;
        private ListView listViewControl;

        // Bottom Panel
        private Button btnClose;
        private Button btnReset;
        private Button btnShowMessage;
    }
}
