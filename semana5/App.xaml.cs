using semana5.Utils;

namespace semana5
{
    public partial class App : Application
    {
        public static PersonaRepositorio PersonaRepo { get; set; }
        public App( PersonaRepositorio persona)
        {
            InitializeComponent();

            MainPage = new Vistas.vHome();
            PersonaRepo =  persona; 
        }
    }
}
