namespace GenericCrash
{
    public partial class MainPage : ContentPage
    {
        private int count = 0;

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            InitializeList();
        }

        private void InitializeList()
        {
            List<CustomModel> models = new List<CustomModel>();

            for (int i = 0; i < 50000; i++)
            {
                models.Add(new CustomModel
                {
                    Title = "Test " + i,
                    Cost = i
                });
            }
            ListItems = models;
        }

        private List<CustomModel> listItems = [];

        public List<CustomModel> ListItems
        {
            get { return listItems; }
            set
            {
                listItems = value;
                OnPropertyChanged(nameof(ListItems));
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var result = ListItems.Average(x => x.Cost);
        }
    }

    public class CustomModel
    {
        public string Title { get; set; }
        public decimal Cost { get; set; }
    }
}