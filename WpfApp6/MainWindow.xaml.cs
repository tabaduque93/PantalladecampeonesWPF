using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Fondo.Play();
        }

        void loop(object sender, RoutedEventArgs e)
        {
            //Setting the position at the beggining 
            Fondo.Position = TimeSpan.Zero; //We dont need to create a new time span as it already has one for zero

            //Then will just play it 
            Fondo.Play();
        }

        private void verJugadores(object sender, RoutedEventArgs e)
        {
            //sonarAudio("clic");


            Fondo2.Play(); 

            Fondo.Visibility = Visibility.Collapsed;
            Fondo2.Visibility = Visibility.Visible;

            Fondo.Source = new Uri(@"C:\Orden\Principal\Loop_VerJugadores.mp4");
            FondoTeo.Source = new Uri(@"C:\Orden\jugloop\Teo_Seleccion.mp4");
            FondoMiguel.Source = new Uri(@"C:\Orden\jugloop\Borja_Seleccion.mp4");
            FondoMarlon.Source = new Uri(@"C:\Orden\jugloop\Piedrahita_Seleccion.mp4");
            FondoFredy.Source = new Uri(@"C:\Orden\jugloop\Hinestroza_Seleccion.mp4");
            FondoSebastian.Source = new Uri(@"C:\Orden\jugloop\Viera_Seleccion.mp4");
            FondoDidier.Source = new Uri(@"C:\Orden\jugloop\Moreno_Seleccion.mp4");
            FondoTodos.Source = new Uri(@"C:\Orden\jugloop\Grupo_Seleccion.mp4");

            btnVoyPaEsa.Visibility = Visibility.Collapsed;
            /*btnIndividual.Visibility = Visibility.Collapsed;
            btnCapturar.Visibility = Visibility.Collapsed;
            btnCapturar.Margin = new Thickness(336, 869, 0, 0);*/
            Fondo2.MediaEnded += finVideo2;
        }

        void finVideo2(object sender, RoutedEventArgs e)
        {
            Fondo.Visibility = Visibility.Visible;
            Fondo2.Visibility = Visibility.Collapsed;

            Fondo.Play();

            // Mostrar los botones de los jugadores
            btnTeofilo.Visibility = Visibility.Visible;
            btnFredy.Visibility = Visibility.Visible;
            btnMiguel.Visibility = Visibility.Visible;
            btnSebastian.Visibility = Visibility.Visible;
            btnMarlon.Visibility = Visibility.Visible;
            btnDidier.Visibility = Visibility.Visible;
            btnTodos.Visibility = Visibility.Visible;
        }

        void seleccionarJugador(object sender, RoutedEventArgs e)
        {
            //sonarAudio("clic");
            //btnCapturar.Visibility = Visibility.Collapsed;

            Button boton = sender as Button;

            switch (boton.Name)
            {
                case "btnTeofilo":
                    establecerFondoLoop(@"C:\Orden\jugloop\Teo_LoopLong.mp4", FondoTeo, "teofilo");
                    break;

                case "btnFredy":
                    establecerFondoLoop(@"C:\Orden\jugloop\Hinestroza_Loop.mp4", FondoFredy, "fredy");
                    break;

                case "btnMiguel":
                    establecerFondoLoop(@"C:\Orden\jugloop\Borja_Loop.mp4", FondoMiguel, "miguel");
                    break;

                case "btnSebastian":
                    establecerFondoLoop(@"C:\Orden\jugloop\Viera_Loop.mp4", FondoSebastian, "sebastian");
                    break;

                case "btnMarlon":
                    establecerFondoLoop(@"C:\Orden\jugloop\Piedrahita_Loop.mp4", FondoMarlon, "marlon");
                    break;

                case "btnDidier":
                    establecerFondoLoop(@"C:\Orden\jugloop\Moreno_Loop.mp4", FondoDidier, "didier");
                    break;

                case "btnTodos":
                    Fondo2.Source = new Uri(@"C:\Orden\jugloop\Volver_Individual.mp4");
                    Fondo.Source = new Uri(@"C:\Orden\jugloop\Loop_Grupo.mp4");
                    Fondo.Visibility = Visibility.Collapsed;
                    FondoTodos.Visibility = Visibility.Visible;
                    habilitarBtnJugadores("todos");
                    //btnCapturar.Visibility = Visibility.Collapsed;
                    FondoTodos.Play();
                    FondoTodos.MediaEnded += finTodos;
                    break;

                default:
                    break;
            }
        }

        void finTodos(object sender, RoutedEventArgs e)
        {
            FondoTodos.Visibility = Visibility.Collapsed;
            Fondo.Visibility = Visibility.Visible;
            //Fondo.IsLooping = true;
            Fondo.Play();
            /*btnCapturar.Margin = new Thickness(310, 1100, 0, 0);
            btnCapturar.Visibility = Visibility.Visible;
            btnIndividual.Visibility = Visibility.Visible;*/
        }

        void establecerFondoLoop(String rutaAsset, MediaElement fondoJugador, String jugador)
        {

            Fondo.Source = new Uri(rutaAsset);
            Fondo.Visibility = Visibility.Collapsed;
            fondoJugador.Visibility = Visibility.Visible;
            habilitarBtnJugadores(jugador);
            fondoJugador.Play();

            switch (jugador)
            {
                case "teofilo":
                    fondoJugador.MediaEnded += finTeo;
                    break;
                case "marlon":
                    fondoJugador.MediaEnded += finMarlon;
                    break;
                case "fredy":
                    fondoJugador.MediaEnded += finFredy;
                    break;
                case "didier":
                    fondoJugador.MediaEnded += finDidier;
                    break;
                case "sebastian":
                    fondoJugador.MediaEnded += finSebastian;
                    break;
                case "miguel":
                    fondoJugador.MediaEnded += finMiguel;
                    break;
            }
        }

        void finTeo(object sender, RoutedEventArgs e)
        {
            finOpcionSelecionada(FondoTeo);
        }

        void finMiguel(object sender, RoutedEventArgs e)
        {
            finOpcionSelecionada(FondoMiguel);
        }

        void finMarlon(object sender, RoutedEventArgs e)
        {
            finOpcionSelecionada(FondoMarlon);
        }

        void finFredy(object sender, RoutedEventArgs e)
        {
            finOpcionSelecionada(FondoFredy);
        }

        void finSebastian(object sender, RoutedEventArgs e)
        {
            finOpcionSelecionada(FondoSebastian);
        }

        void finDidier(object sender, RoutedEventArgs e)
        {
            finOpcionSelecionada(FondoDidier);
        }

        void finOpcionSelecionada(MediaElement fondoJugador)
        {
            fondoJugador.Visibility = Visibility.Collapsed;
            Fondo.Visibility = Visibility.Visible;
            //Fondo.IsLooping = true;
            Fondo.Play();
            //btnCapturar.Visibility = Visibility.Visible;
        }

        void habilitarBtnJugadores(String jugador)
        {
            btnTeofilo.Visibility = Visibility.Visible;
            btnMiguel.Visibility = Visibility.Visible;
            btnMarlon.Visibility = Visibility.Visible;
            btnFredy.Visibility = Visibility.Visible;
            btnSebastian.Visibility = Visibility.Visible;
            btnDidier.Visibility = Visibility.Visible;
            btnTodos.Visibility = Visibility.Visible;

            switch (jugador)
            {

                case "teofilo":
                    btnTeofilo.Visibility = Visibility.Collapsed;
                    break;

                case "fredy":
                    btnFredy.Visibility = Visibility.Collapsed;
                    break;

                case "marlon":
                    btnMarlon.Visibility = Visibility.Collapsed;
                    break;

                case "sebastian":
                    btnSebastian.Visibility = Visibility.Collapsed;
                    break;

                case "didier":
                    btnDidier.Visibility = Visibility.Collapsed;
                    break;

                case "miguel":
                    btnMiguel.Visibility = Visibility.Collapsed;
                    break;

                case "todos":
                    btnTeofilo.Visibility = Visibility.Collapsed;
                    btnMiguel.Visibility = Visibility.Collapsed;
                    btnMarlon.Visibility = Visibility.Collapsed;
                    btnFredy.Visibility = Visibility.Collapsed;
                    btnSebastian.Visibility = Visibility.Collapsed;
                    btnDidier.Visibility = Visibility.Collapsed;
                    btnTodos.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}
