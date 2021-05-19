using System;
using System.Windows.Forms;
using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.BusinessLogics;
using Unity;

namespace ForumView
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private readonly UsersBusinessLogic logic;

        public FormRegister(UsersBusinessLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните логин", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните Email", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                UsersBindingModel model = new UsersBindingModel
                {
                    Username = textBoxLogin.Text,
                    Password = textBoxPassword.Text,
                    Email = textBoxEmail.Text,
                };
                logic.CreateOrUpdate(model);
                DialogResult = DialogResult.OK;
                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
