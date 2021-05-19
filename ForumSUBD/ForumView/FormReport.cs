using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.BusinessLogics;
using ForumBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;
using Microsoft.EntityFrameworkCore;

namespace ForumView
{
    public partial class FormReport : Form
    {
        public int Id { set { id = value; } }
        private readonly ReportsBusinessLogic logic;
        private readonly SpeakersBusinessLogic logicU;
        private int? id;
        public FormReport(ReportsBusinessLogic logic, SpeakersBusinessLogic logicU)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicU = logicU;
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var listSpeakers = logicU.Read(null);

                foreach (var item in listSpeakers)
                {
                    comboBoxSpeaker.DisplayMember = "Namespeaker";
                    comboBoxSpeaker.ValueMember = "Speakerid";
                    comboBoxSpeaker.DataSource = listSpeakers;
                    comboBoxSpeaker.SelectedItem = null;
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
                    var view = logic.Read(new ReportsBindingModel { Reportid = id })?[0];

                    if (view != null)
                    {
                        comboBoxSpeaker.SelectedValue = view.Speakerid;
                        textBoxName.Text = view.Themereport;
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

            if (comboBoxSpeaker.SelectedValue == null)
            {
                MessageBox.Show("Выберите докладчика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                logic.CreateOrUpdate(new ReportsBindingModel
                {
                    Reportid = id,
                    Themereport = textBoxName.Text,
                    Speakerid = Convert.ToInt32(comboBoxSpeaker.SelectedValue),
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
