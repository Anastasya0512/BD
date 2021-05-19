using System;
using System.Windows.Forms;
using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.BusinessLogics;
using Unity;

namespace ForumView
{
    public partial class FormAuthorize : Form
    {
        private readonly UsersBusinessLogic logic;

        public FormAuthorize(UsersBusinessLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните Email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = logic.Read(new UsersBindingModel { Email = textBoxLogin.Text, Password = textBoxPassword.Text })?[0];
            if (user == null)
            {
                MessageBox.Show("Неверный Email или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.User = user;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

