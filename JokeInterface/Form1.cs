using ChuckNorrisAPI;

namespace JokeInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetJoke_Click(object sender, EventArgs e)
        {
            Joke newJoke = await ChuckNorrisClient.GetJokeByCategory(cboCategories.SelectedItem.ToString());
            rtxtJokeText.Text = newJoke.JokeText;
        }

        private async void MainMenu_Load(object sender, EventArgs e)
        {
            IEnumerable<string> categories = await ChuckNorrisClient.GetCategories();
            foreach (var cat in categories)
            {
                cboCategories.Items.Add(cat);
            }

            cboCategories.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}