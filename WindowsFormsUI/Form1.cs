using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class Form1 : Form
    {
        BindingList<string> errorList = new BindingList<string>();

        public Form1()
        {
            InitializeComponent();
            ErrorListBox.DataSource = errorList;
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            errorList.Clear();
            Decimal amount = 0;

            decimal.TryParse(AmountTextBox.Text, out amount);

            PersonModel p = new PersonModel
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Amount = amount
            };

            var validator = new PersonValidator();
            ValidationResult result = validator.Validate(p);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    errorList.Add($"{failure.PropertyName}: { failure.ErrorMessage }" );
                }
            }
            else
            {
                MessageBox.Show("Form validation: OK");
            }
        }
    }
}
