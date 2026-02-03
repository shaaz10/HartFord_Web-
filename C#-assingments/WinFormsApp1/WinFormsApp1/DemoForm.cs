namespace WinFormsApp1
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
        }

        private void BtnBasicButton_Click(object? sender, EventArgs e)
        {
            string message = $"TextBox: {textBoxInput.Text}\nNumeric: {numericUpDownValue.Value}\nChecked: {chkCheckBox.Checked}";
            MessageBox.Show(message, "Basic Controls Data");
        }

        private void BtnShowMessage_Click(object? sender, EventArgs e)
        {
            string selectedItem = comboBoxOptions.SelectedItem?.ToString() ?? "None";
            string listItems = string.Join(", ", listBoxItems.SelectedItems.Cast<object>());
            string message = $"ComboBox Selected: {selectedItem}\nListBox Selected: {(string.IsNullOrEmpty(listItems) ? "None" : listItems)}\nDate: {dateTimePickerControl.Value:yyyy-MM-dd}";
            MessageBox.Show(message, "Data Controls Information");
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            textBoxInput.Clear();
            numericUpDownValue.Value = 42;
            chkCheckBox.Checked = true;
            radioBtnOption1.Checked = true;
            textBoxInGroup.Clear();
            listBoxItems.ClearSelected();
            comboBoxOptions.SelectedIndex = -1;
            dateTimePickerControl.Value = DateTime.Now;
            listViewControl.SelectedItems.Clear();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
