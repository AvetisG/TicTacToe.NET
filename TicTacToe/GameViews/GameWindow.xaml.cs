using System.Windows;
using TicTacToe.GameViewModels;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow(GameWindowViewModel GameWindowViewModel)
        {
            DataContext = GameWindowViewModel;
            InitializeComponent();
        }
    }
}
