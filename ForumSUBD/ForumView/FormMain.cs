using System;
using System.Windows.Forms;
using ForumBusinessLogic.BusinessLogics;
using Unity;

namespace ForumView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ForumLogic logic;

        public FormMain(ForumLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);

                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[4].Visible = false;
                    dataGridView.Columns[6].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuthorize>();
            form.ShowDialog();
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRegister>();
            form.ShowDialog();
        }

        private void докладчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormSpeakers>();
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void типыФорумовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormForumtypes>();
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void докладыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormReports>();
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void форумыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                var form = Container.Resolve<FormForums>();
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Необходимо авторизоваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
