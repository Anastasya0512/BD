using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.BusinessLogics;
using ForumBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;
using Microsoft.EntityFrameworkCore;

namespace ForumView
{
    public partial class Форум : Form
    {
        public int Id { set { id = value; } }
        private readonly ForumLogic logic;
        private readonly UsersBusinessLogic logicU;
        private readonly ForumtypeBusinessLogic logicS;
        private int? id;

        public Форум(ForumLogic logic, UsersBusinessLogic logicU, ForumtypeBusinessLogic logicS)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicU = logicU;
            this.logicS = logicS;

        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var listUser = logicU.Read(null);

                foreach (var item in listUser)
                {
                    comboBoxUser.DisplayMember = "Username";
                    comboBoxUser.ValueMember = "Userid";
                    comboBoxUser.DataSource = listUser;
                    comboBoxUser.SelectedItem = null;
                }

                var listForumtype = logicS.Read(null);

                foreach (var item in listForumtype)
                {
                    comboBoxType.DisplayMember = "Nametype";
                    comboBoxType.ValueMember = "Forumtypeid";
                    comboBoxType.DataSource = listForumtype;
                    comboBoxType.SelectedItem = null;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new ForumBindingModel { Forumid = id })?[0];

                    if (view != null)
                    {
                        comboBoxUser.SelectedValue = view.Userid;
                        comboBoxType.SelectedValue = view.Forumtypeid;
                        textBoxName.Text = view.Themeforum;
                        dateTimePicker.Value = view.Startdate;
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

            if (comboBoxUser.SelectedValue == null)
            {
                MessageBox.Show("Выберите заказчика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxType.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип форума", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                logic.CreateOrUpdate(new ForumBindingModel
                {
                    Forumid = id,
                    Startdate = dateTimePicker.Value,
                    Themeforum = textBoxName.Text,
                    Userid = Convert.ToInt32(comboBoxUser.SelectedValue),
                    Forumtypeid = Convert.ToInt32(comboBoxType.SelectedValue)
                });


                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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
