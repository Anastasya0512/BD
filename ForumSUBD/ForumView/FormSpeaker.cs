using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.BusinessLogics;
using ForumBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;
using Microsoft.EntityFrameworkCore;

namespace ForumView
{
    public partial class FormSpeaker : Form
    {
        public int Id { set { id = value; } }
        private readonly SpeakersBusinessLogic logic;
        private int? id;

        public FormSpeaker(SpeakersBusinessLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormAuthor_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new SpeakersBindingModel { Speakerid = id })?[0];

                    if (view != null)
                    {
                        textBoxName.Text = view.Namespeaker;
                        textBoxEmail.Text = view.Email;
                        textBoxNickname.Text = view.Nickname;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxNickname.Text))
            {
                MessageBox.Show("Заполните никнейм", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                logic.CreateOrUpdate(new SpeakersBindingModel
                {
                    Speakerid = id,
                    Namespeaker = textBoxName.Text,
                    Email = textBoxEmail.Text,
                    Nickname = textBoxNickname.Text,
                });


                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (DbUpdateException exe)
            {
                MessageBox.Show(exe?.InnerException?.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
