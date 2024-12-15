namespace Modular2024
{
    public partial class MainPage : ContentPage
    {
        int bulls = 0;
        int cows = 0;
        string number = "";

        public MainPage()
        {
            InitializeComponent();
            NewGame(null, null);
        }

        void NewGame(object sender, EventArgs e)
        {
            bulls = 0;
            cows = 0;
            number = "";
            userInput.Text = "";
            UpdateCounters();
            GenerateNumber();
        }

        void UpdateCounters()
        {
            bullsText.Text = $"Быки: {bulls}";
            cowsText.Text = $"Коровы: {cows}";
            bulls = 0;
            cows = 0;
        }

        void GenerateNumber()
        {
            for (int i = 0; i < 6; i++)
            {
                number += Convert.ToDouble(new Random().NextInt64(10));
            }
        }

        void CheckGuess(object sender, EventArgs e)
        {
            if (userInput.Text.Length != 6)
            {
                DisplayAlert("Ошибка", "Пожалуйста, введите 6-значное число.", "OK");
                return;
            }
            for (int i = 0; i < 6; i++)
            {
                if (number[i] == userInput.Text[i])
                {
                    ++bulls;
                }
                else if (userInput.Text.Contains(number[i]))
                {
                    ++cows;
                }
            }

            if (bulls == 6)
            {
                DisplayAlert("Победа!", "Поздравляем. Вы отгадали загаданное число.", "OK");
                NewGame(null, null);
            }

            UpdateCounters();
        }
    }

}
