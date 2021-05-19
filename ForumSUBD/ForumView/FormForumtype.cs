using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.BusinessLogics;
using ForumBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;
using Microsoft.EntityFrameworkCore;

namespace ForumView
{
    public partial class FormForumtype : Form
    {
        public int Id { set { id = value; } }
        private readonly ForumtypeBusinessLogic logic;
        private int? id;

        public FormForumtype(ForumtypeBusinessLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormStatus_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new ForumtypeBindingModel { Forumtypeid = id })?[0];

                    if (view != null)
                    {

                        textBoxType.Text = view.Nametype;

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
            if (string.IsNullOrEmpty(textBoxType.Text))
            {
                MessageBox.Show("Заполните тип", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                logic.CreateOrUpdate(new ForumtypeBindingModel
                {
                    Forumtypeid = id,
                    Nametype = textBoxType.Text
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
